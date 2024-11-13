#include <stdio.h>
#include <unistd.h>
#include <errno.h>

int main( int argc, char *argv[]){
	long d = pathconf("/", _PC_NAME_MAX );
	if (d == -1){
		printf("Netinkamas!");
		return 1;
	}
	else
		printf("The value of _PC_NAME_MAX is %ld\n", d);
	
	return 0;
}