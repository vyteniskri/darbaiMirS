#include <stdio.h>
#include <sys/types.h>
#include <unistd.h>
#include <wait.h>
#include <signal.h>
#include <stdlib.h>

static int received_sig = 0;

void il_catch_USR1(int);
int il_child(void);
int il_parent(pid_t pid);

int il_child(void) {
    sleep(1);
    printf("        child: my ID = %d\n", getpid());

    while (1) {
        if (received_sig == 1) {
            printf("        child: Received signal from parent!\n");
            sleep(1);
            printf("        child: Executing 'who' command:\n");
            system("who");
            sleep(1);
            printf("        child: Sending SIGUSR2 to parent\n");
            kill(getppid(), SIGUSR2);
            sleep(1);
            printf("        child: I'm exiting\n");
            return 0;
        }
    }
}

int il_parent(pid_t pid) {
    printf("parent: my ID = %d\n", getpid());
    printf("parent: my child's ID = %d\n", pid);
    sleep(3);
    kill(pid, SIGUSR1);
    printf("parent: Signal was sent\n");

    while (1) {
        if (received_sig == 2) {
            printf("parent: Received SIGUSR2 from child\n");
            printf("parent: Terminating child process\n");
            wait(NULL);
            sleep(5);
            printf("parent: Work finished. Exiting.\n");
            return 0;
        }
    }
}

void il_catch_USR1(int snum) {
    received_sig = 1;
}

void il_catch_USR2(int snum) {
    received_sig = 2;
}

int main(int argc, char **arg) {
    pid_t pid;
    printf("(C) 2013 Ingrida Lagzdinyte-Budnike, %s\n", __FILE__);
    signal(SIGUSR1, il_catch_USR1);
    signal(SIGUSR2, il_catch_USR2);

    switch (pid = fork()) {
        case 0: // fork() returns 0 for child process
            il_child();
            break;

        default: // fork() returns child's PID for parent process
            il_parent(pid);
            break;

        case -1: // fork() failed
            perror("fork");
            exit(1);
    }

    exit(0);
}