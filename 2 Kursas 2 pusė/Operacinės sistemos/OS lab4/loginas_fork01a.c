#include <stdio.h>
#include <unistd.h>
#include <sys/wait.h>

int main() {
	pid_t pid3, pid4;
	
	pid3 = fork();
	if (pid3 == 0){
		pid4 = fork();

		if ( pid4 != 0) {
			printf("Vaiko PID: %d ir tevo PPID:%d\n", getpid(), getppid());
		}
		else {
			printf("Anuko PID:%d ir tevo PPID:%d\n", getpid(), getppid());
		}
	}
	else {
		printf("Tevo PID:%d\n", getpid());
	}
	wait(NULL);
    return 0;
}