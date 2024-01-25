#include <stdio.h>
#include <unistd.h>
#include <sys/wait.h>
#include <stdlib.h>

int main(int argc, char *argv[]){
	if (argc != 2){
		printf("Per mazai argumentu");
		exit(100);
	}
	
	printf("PID: %d\n", getpid());
	printf("PIDP: %d\n", getppid());
	printf("Argumentas: %s\n", argv[1]);
	
	int arg = atoi(argv[1]); //konvertuoju i int
	if (arg > 0){
		arg = arg - 1;
		char newArg[10];
		sprintf(newArg, "%d", arg); //konvertuoju i string
		char *a[] = {argv[0], newArg, NULL};//sudedu argumentus i masyva
		execvp(argv[0], a);
		
	}
	
	return 0;
}