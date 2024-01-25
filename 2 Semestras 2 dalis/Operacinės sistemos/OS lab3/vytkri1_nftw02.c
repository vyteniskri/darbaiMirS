#include <ftw.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#define _XOPEN_SOURCE 500
#include <stdio.h>
#include <stdlib.h>
#include <ftw.h>
#include <sys/stat.h>
#include <sys/statvfs.h>
#include <dirent.h>
#include <unistd.h>
#include <fcntl.h>
#include <dirent.h>
#include <unistd.h>
#include <aio.h>
#include <sys/mman.h>
#include <string.h>


static int display_info(const char *fpath, const struct stat *sb, int tflag, struct FTW *ftwbuf){
	if (tflag == FTW_PHYS) {
        printf("%s\n", fpath);
    }
    return 0;
}

int main(int argc, char *argv[]){
	if (argc != 2){
		printf("Per mazai argumentu");
		return 1;
	}
	
	int flags = FTW_PHYS;
	
	nftw(argv[1], display_info, 20, flags);
	
	return 0;
}