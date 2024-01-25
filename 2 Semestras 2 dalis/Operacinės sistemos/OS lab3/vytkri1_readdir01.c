#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
#include <dirent.h>

int main(){
	DIR *dir = opendir(".");
	if ( dir != NULL ){
		printf( "Open. \n");
		
	}
	
	struct dirent *entry;
	while ((entry = readdir(dir)) != NULL){
		printf("%ld ", entry->d_ino);
		printf("%s\n", entry->d_name);
	}
	closedir(dir);
	
	return 0;
}
