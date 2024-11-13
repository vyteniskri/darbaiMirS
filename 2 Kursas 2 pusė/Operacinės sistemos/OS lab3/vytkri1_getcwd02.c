#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
#include <libgen.h>

int test_getcwd();

int test_getcwd(){
	char *cwd;
	cwd = getcwd(NULL, pathconf(".",_PC_PATH_MAX));
	printf( "Current working directory: %s\n", cwd );
	
	int dskr;
	dskr = open(cwd, O_RDONLY ); 
	printf( "dskr = %d\n", dskr );
	free( cwd );
	
	chdir("/tmp");
	cwd = getcwd(NULL, pathconf(".", _PC_PATH_MAX));
	printf("Current working directory: %s\n", cwd);
	free( cwd );
	
	fchdir(dskr);
	cwd = getcwd(NULL, pathconf(".", _PC_PATH_MAX));
	printf("Current working directory: %s\n", cwd);
	free( cwd );
	
	return 1;
}

int main (){
	test_getcwd();
	return 0;
}	