#include <sys/types.h>
#include <unistd.h>
#include <wait.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <fcntl.h>

#define BUFFER_SIZE 1024

int main(int argc, char *argv[]) {
   int fd[2];
   pid_t pid;
   int status;

   if (argc != 2) {
      fprintf(stderr, "Naudojimas: %s <failo_vardas>\n", argv[0]);
      exit(1);
   }

   if (pipe(fd) == -1) {
      fprintf(stderr, "Nepavyko sukurti programinio kanalo!\n");
      exit(1);
   }

   pid = fork();
   if (pid == -1) {
      fprintf(stderr, "Nepavyko sukurti vaiko!\n");
      exit(1);
   }

   if (pid == 0) {
      close(fd[1]); // Uždaryti rašymo galą, nes vaikas tik skaitys

      char buffer[BUFFER_SIZE];
      int bytesRead;

      // Skaitome iš tėvo per kanalą
      bytesRead = read(fd[0], buffer, BUFFER_SIZE);

      // Įrašome gautus duomenis į naują failą
      int outputFile = open("rezultatas.txt", O_WRONLY | O_CREAT | O_TRUNC, 0666);
      write(outputFile, buffer, bytesRead);
      close(outputFile);

      close(fd[0]); // Uždaryti skaitymo galą
      exit(0);
   } else {
      close(fd[0]); // Uždaryti skaitymo galą, nes tėvas tik rašys

      // Atidarome nurodytą failą skaitymui
      int inputFile = open(argv[1], O_RDONLY);
      if (inputFile == -1) {
         fprintf(stderr, "Nepavyko atidaryti failo: %s\n", argv[1]);
         exit(1);
      }

      char buffer[BUFFER_SIZE];
      int bytesRead;

      // Skaitome failą ir rašome į kanalą, kad vaikas gautų duomenis
      while ((bytesRead = read(inputFile, buffer, BUFFER_SIZE)) > 0) {
         write(fd[1], buffer, bytesRead);
      }

      close(inputFile);
      close(fd[1]); // Uždaryti rašymo galą

      wait(&status); // Laukiame vaiko proceso

      printf("Failo turinys persiųstas į vaiką.\n");
   }

   return 0;
}