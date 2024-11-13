#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

int main (){
	char script[] = "myscript.sh";
    FILE *fp;
	
	fp = fopen(script, "w");
	
	fprintf(fp, "#!/bin/bash\n");
    fprintf(fp, "echo \"Hello from my script!\"\n");
    fclose(fp);
	
	if (execl("/bin/sh", "sh", script, NULL) != 0) {
        perror("Error executing script");
        exit(EXIT_FAILURE);
    }

    return 0;
}