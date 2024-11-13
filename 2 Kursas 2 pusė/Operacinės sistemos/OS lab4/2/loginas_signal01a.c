#include <stdlib.h>
#include <unistd.h>
#include <signal.h>
#include <stdio.h>
#include <sys/wait.h>

void il_catch_CHLD(int);        /* signalo apdorojimo f-ja */
void il_child(void);            /* vaiko proceso veiksmai */
void il_parent(int pid);        /* tevo proceso veiksmai */
void il_alarm_handler(int signum); /* signalo apdorojimo f-ja */

void il_child(void) {
    printf("        child: I'm the child\n");
    sleep(3);
    printf("        child: I'm exiting\n");
    kill(getppid(), SIGALRM); /* Išsiunčiame SIGALRM signalą tėvo procesui */
    exit(123);
}

void il_parent(int pid) {
    printf("parent: I'm the parent\n");
    signal(SIGALRM, il_alarm_handler); /* Nustatome signalo apdorojimo funkciją */
    sleep(10);
    printf("parent: exiting\n");
}

void il_catch_CHLD(int snum) {
    int pid;
    int status;
    pid = wait(&status);
    printf("parent: child process (PID=%d) exited with value %d\n", pid, WEXITSTATUS(status));
}

void il_alarm_handler(int signum) {
    printf("parent: received alarm signal (SIGALRM)\n");
}

int main(int argc, char **argv) {
    int pid; /* proceso ID */
    printf("(C) 2013 Ingrida Lagzdinyte-Budnike, %s\n", __FILE__);
    signal(SIGCHLD, il_catch_CHLD); /* aptikti vaiko proc pasibaigima ir apdoroti */
    switch (pid = fork()) {
        case 0: /* fork() grazina 0 vaiko procesui */
            il_child();
            break;
        default: /* fork() grazina vaiko PID tevo procesui */
            il_parent(pid);
            break;
        case -1: /* fork() nepavyko */
            perror("fork");
            exit(1);
    }
    exit(0);
}