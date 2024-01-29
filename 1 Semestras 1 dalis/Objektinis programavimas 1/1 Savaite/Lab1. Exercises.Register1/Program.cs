using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Lab1.Exercises.Register1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dog> allDogs = InOutUtils.ReadDogs(@"Dogs.txt");
            
            Console.WriteLine("Registro informacija:");
            InOutUtils.PrintDogs(allDogs);

            Console.WriteLine("Iš viso šunų: {0}", allDogs.Count);

            Console.WriteLine("Patinu: {0}", TaskUtils.CountByGender(allDogs, Gender.Male));
            Console.WriteLine("Pateliu: {0}", TaskUtils.CountByGender(allDogs, Gender.Female));

            Dog oldest = TaskUtils.FindOldestDog(allDogs);
            Console.WriteLine();
            Console.WriteLine("Seniausias suo");
            Console.WriteLine("Vardas: {0}, Vesile: {1}, Amzius: {2}", oldest.Name, oldest.Breed, oldest.CalculateAge());

            List<string> Breeds = TaskUtils.FindBreeds(allDogs);
            Console.WriteLine();
            Console.WriteLine("Sunu veisles:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();

            Console.WriteLine("Kokios veisles sunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            List<Dog> FilteredByBreed = TaskUtils.FilterByBreed(allDogs, selectedBreed);
            InOutUtils.PrintDogs(FilteredByBreed);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);

            Console.WriteLine("Seniausios pasirinktos suns veisles duomenys:");
            Dog oldestByBreed = TaskUtils.FindOldestDogByBreed(allDogs, selectedBreed);
            Console.WriteLine("Vardas: {0}, Veisle: {1}, Amzius: {2}", oldestByBreed.Name, oldestByBreed.Breed, oldestByBreed.CalculateAge());

            Console.WriteLine("Populiariausia veisle:");
            List<string> popular = TaskUtils.MostPopular(allDogs);
            InOutUtils.PrintBreeds(popular);

        }
    }
}
