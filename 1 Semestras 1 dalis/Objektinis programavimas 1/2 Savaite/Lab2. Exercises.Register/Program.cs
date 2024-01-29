using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Lab2.Exercises.Register
{
    class Program
    {
        static void Main(string[] args)
        {

            
            DogsRegister register = InOutUtils.ReadDogs(@"Dogs.txt");
            Console.WriteLine("Registro informacija:");
            InOutUtils.PrintDogs(register);
            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());            Console.WriteLine("Patinu: {0}", register.CountByGender(Gender.Male));            Console.WriteLine("Pateliu: {0}", register.CountByGender(Gender.Female));

            Dog dog = register.FindOldestDog();
            Console.WriteLine("Seniausias suo");
            Console.WriteLine("Vardas: {0}, Vesile: {1}, Amzius: {2}", dog.Name, dog.Breed, dog.Age);

            Console.WriteLine();
            Console.WriteLine("Sunu veisles:");
            InOutUtils.PrintBreeds(register.FindBreeds());
            Console.WriteLine();

            Console.WriteLine("Kokios veisles sunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            List<Dog> FilteredByBreed = register.FilterByBreed(selectedBreed);
            InOutUtils.PrintDogs(FilteredByBreed);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);

            Console.WriteLine("Seniausios pasirinktos suns veisles duomenys:");
            Dog oldestByBreed = register.FindOldestDog(selectedBreed);
            Console.WriteLine("Vardas: {0}, Veisle: {1}, Amzius: {2}", oldestByBreed.Name, oldestByBreed.Breed, oldestByBreed.Age);

            Console.WriteLine("Populiariausia veisle:");
            InOutUtils.PrintBreeds(register.MostPopular());
            Console.WriteLine();

            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.txt");
            register.UpdateVaccinationsInfo(VaccinationsData);

            Console.WriteLine("Šunys, kuriems reikia pasiskiepyti:");
            InOutUtils.ExpiredDate(register.FilterByVaccinationExpired());

            


        }
    }
}
