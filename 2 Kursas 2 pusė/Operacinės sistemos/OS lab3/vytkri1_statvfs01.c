#include <stdio.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <unistd.h>
#include <fcntl.h>
#include <sys/vfs.h>
#include <sys/statvfs.h>

int main(int argc, char *arg[]){
	if (argc != 2){
		printf("Per mazai pasirinkta");
		return 1;
	}
	
	struct statvfs fsstat;
	statvfs(arg[1], &fsstat);
	
	printf("Failu sistemos bloko dydis %ld\n", fsstat.f_frsize);
	printf("Failu sistemos ID %ld\n", fsstat.f_fsid);
	printf("Failu sistemos dydis %ld\n", fsstat.f_blocks);
	printf("Failu sistemos ilgis %ld\n", fsstat.f_namemax);
	
	return 0;
}
