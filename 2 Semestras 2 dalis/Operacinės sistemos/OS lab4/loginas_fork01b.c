#include <stdio.h>
#include <unistd.h>
#include <sys/wait.h>

int main() {
	pid_t pid3, pid4;
	
	pid3 = fork();
	pid4 = fork();
	if (pid3 == 0 && pid4 != 0){
		printf("Pirmo vaiko PID: %d ir tevo PPID:%d\n", getpid(), getppid());
		
	}
	else if (pid3 != 0 && pid4 == 0){
		printf("Antro vaiko PID: %d ir tevo PPID:%d\n", getpid(), getppid());
	}
	else if (pid3 != 0 && pid4 != 0){
		printf("Tevo PID:%d\n", getpid());
	}
	wait(NULL);
    return 0;
}