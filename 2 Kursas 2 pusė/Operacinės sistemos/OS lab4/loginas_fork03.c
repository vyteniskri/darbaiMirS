#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>

int main()
{
    pid_t pid;

    pid = fork();

    if (pid < 0) {
        fprintf(stderr, "Fork failed\n");
        exit(1);
    }
    else if (pid == 0) {
        printf("I am the child process, my PID is %d, my parent's PID is %d\n", getpid(), getppid());
        printf("Child process exiting\n");
        exit(0);
    }
    else {
        printf("I am the parent process, my PID is %d, my child's PID is %d\n", getpid(), pid);
        printf("Parent process waiting for child to exit\n");
        sleep(10);
        system("ps -ef | grep defunct");
    }

    return 0;
}
