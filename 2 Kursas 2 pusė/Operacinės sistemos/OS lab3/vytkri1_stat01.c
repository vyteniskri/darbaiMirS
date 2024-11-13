#include <stdio.h>
#include <stdlib.h>
#include <sys/stat.h>
#include <unistd.h>

int main(int argc, char *arg[]){
	if (argc != 2){
		printf("Per mazai pasirinkta");
		return 1;
	}
	
	struct stat filestat;
	stat(arg[1], &filestat);
	
	printf("ID %d\n", filestat.st_uid);
	printf("Dydis %ld\n", filestat.st_size);
	printf("I-node %lu\n", filestat.st_ino);
	printf("Leidimas %o\n", filestat.st_mode);
	return 0;
}
