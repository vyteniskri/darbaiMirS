using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class Program
    {
        static void Main(string[] args)
        {

            
            AnimalsContainer allAnimals = InOutUtils.ReadAnimals(@"Animals.txt");
            Register register = new Register(allAnimals);
            Console.WriteLine("Registro informacija:");
            InOutUtils.PrintAnimals("Gyvūnų sarašas", allAnimals);
            Console.WriteLine("Iš viso gyvūnų: {0}", allAnimals.Count);            Console.WriteLine("Patinu: {0}", register.CountByGender(Gender.Male));            Console.WriteLine("Pateliu: {0}", register.CountByGender(Gender.Female));

            Animal animal = register.FindOldestAnimal();
            Console.WriteLine("Seniausias gyvūnas");
            Console.WriteLine("Vardas: {0}, Vesile: {1}, Amzius: {2}", animal.Name, animal.Breed, animal.Age);

            Console.WriteLine();
            Console.WriteLine("gyvūnų veislės:");
            InOutUtils.PrintBreeds(register.FindBreeds());
            Console.WriteLine();

            Console.WriteLine("Kokios veislės gyvūnus atrinkti?");
            string selectedBreed = Console.ReadLine();
            AnimalsContainer FilteredByBreed = register.FilterByBreed(selectedBreed);
            InOutUtils.PrintDogs(FilteredByBreed);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintAnimalsToCSVFile(fileName, FilteredByBreed);

            Console.WriteLine("Seniausios pasirinktos gyvūno veisles duomenys:");
            Animal oldestByBreed = register.FindOldestAnimal(selectedBreed);
            Console.WriteLine("Vardas: {0}, Veisle: {1}, Amzius: {2}", oldestByBreed.Name, oldestByBreed.Breed, oldestByBreed.Age);

            Console.WriteLine("Populiariausia veisle:");
            InOutUtils.PrintBreeds(register.MostPopular());
            Console.WriteLine();

            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.txt");
            register.UpdateVaccinationsInfo(VaccinationsData);




            ////Put
            //allAnimals.Put(allAnimals.Get(3), 2);
            //InOutUtils.PrintAnimals("Gyvūnų sarašas", allAnimals);
            //Console.WriteLine("Iš viso gyvūnų: {0}", allAnimals.Count);

            ////Insert
            //allAnimals.Insert(allAnimals.Get(1), 4);
            //InOutUtils.PrintAnimals("Gyvūnų sarašas", allAnimals);
            //Console.WriteLine("Iš viso gyvūnų: {0}", allAnimals.Count);

            ////Remove
            //allAnimals.Remove(allAnimals.Get(0));
            //InOutUtils.PrintAnimals("Gyvūnų sarašas", allAnimals);
            //Console.WriteLine("Iš viso gyvūnų: {0}", allAnimals.Count);

            ////Remove at
            //allAnimals.RemoveAt(2);
            //InOutUtils.PrintAnimals("Gyvūnų sarašas", allAnimals);
            //Console.WriteLine("Iš viso gyvūnų: {0}", allAnimals.Count);

            //2 Savarankiskas. Du kartus Sortinu
            allAnimals.Sort(new AnimalsComparatorByNameAndID());
            InOutUtils.PrintAnimals("Gyvūnų sarašas", allAnimals);
            Console.WriteLine("Iš viso gyvūnų: {0}", allAnimals.Count);

            allAnimals.Sort(new AnimalsComparatorByBirthDateAndID());
            InOutUtils.PrintAnimals("Gyvūnų sarašas", allAnimals);
            Console.WriteLine("Iš viso gyvūnų: {0}", allAnimals.Count);

            AnimalsContainer requiresVaccination = register.FilterByVaccination();
            InOutUtils.PrintAnimals("Reikia skiepyti (" + selectedBreed +")", requiresVaccination.Intersect(FilteredByBreed));

            Console.WriteLine("Agresivių šunų iš viso yra: {0}", register.CountAggresiveDogs());
        }
    }
}
