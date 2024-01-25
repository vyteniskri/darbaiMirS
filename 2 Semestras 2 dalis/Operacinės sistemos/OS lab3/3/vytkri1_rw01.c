#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
#include <string.h>
#include <aio.h>
int openFile(char *name);
int OpenWRT(char *name);
int nustBait(const int dr, const int dw, void *buf, struct aiocb *aiorp, const int count, struct aiocb *aiorp2);

int openFile(char *name){
	int dskr;
	dskr = open(name, O_RDONLY);
	if (dskr == -1){
		perror(name);
		exit(1);
	}
	printf("dskr = %d\n", dskr);
	return dskr;
}

int OpenWRT(char *name){
	int dskr;
	dskr = open(name, O_WRONLY | O_TRUNC | O_CREAT ); //rasimo failas string info jei yra, jei nera sukurt
	if (dskr == -1){
		perror(name);
		exit(1);
	}
	printf("dskr = %d\n", dskr);
	return dskr;
}

int nustBait(const int dr, const int dw, void *buf, struct aiocb *aiorp, const int count, struct aiocb *aiorp2){
	int rv = 0;
	memset( (void *)aiorp, 0, sizeof( struct aiocb ) );
	aiorp->aio_fildes = dr;
	aiorp->aio_buf = buf;
	aiorp->aio_nbytes = count;
	aiorp->aio_offset = 0;
	rv = aio_read(aiorp);
	
	if( rv != 0 ){
      perror( "aio_read failed" );
      abort();
    }
	////
	
	memset( (void *)aiorp2, 0, sizeof( struct aiocb ) );
	aiorp2->aio_fildes = dw;
	aiorp2->aio_buf = aiorp->aio_buf;
	int ret = aio_write(aiorp2);
	printf("aio_write 1: %d\n",ret);
   return 1;
}

int main ( int argc, char *arg[]){
	int dskr;
	int dskw;
	int nread;
	char buffer[sizeof(arg[3])];
	
	//struct aiocb aior;
	//struct aiocb aior2;
	if (argc < 2){
		printf( "Naudojimas:\n %s failas\n", arg[0] );
		exit(255);
	}
	
	dskr = openFile(arg[1]);
	dskw = OpenWRT(arg[2]);
	
	nread = read(dskr, buffer, sizeof(arg[3]));
	write(dskw, buffer, nread);
	
	
	//nustBait(dskr, dskw, buffer, &aior, sizeof(buffer), &aior2);
   
	return 0;
}