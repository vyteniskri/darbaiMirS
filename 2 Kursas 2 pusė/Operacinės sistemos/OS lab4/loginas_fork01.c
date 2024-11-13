#include <stdio.h>
#include <unistd.h>
#include <sys/wait.h>

int main() {
	pid_t pid1, pid2;

	pid1 = fork();
	pid2 = fork();
	
	if (pid1 == 0 && pid2 == 0){
		 printf("A (leaf) PID:%d PPID:%d\n", getpid(), getppid());
	}
	else if (pid1 != 0 && pid2 == 0) {
        printf("B (left child) PID:%d PPID:%d\n", getpid(), getppid());
    }
	else if (pid1 == 0 && pid2 != 0) {
        printf("C (right child) PID:%d PPID:%d\n", getpid(), getppid());
    }
    else {
        printf("D (root) PID:%d\n", getpid());
    }
	wait(NULL);
	
    return 0;
}