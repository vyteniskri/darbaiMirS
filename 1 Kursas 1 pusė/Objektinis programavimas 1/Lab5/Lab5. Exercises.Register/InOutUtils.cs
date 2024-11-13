using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class InOutUtils
    {
        

        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }        public static void PrintAnimalsToCSVFile(string fileName, AnimalsContainer animals)
        {
            string[] lines = new string[animals.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4}", "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis", "Agresyvus ar ne");
            for (int i = 0; i < animals.Count; i++)
            {
                Animal animal = animals.Get(i);  
                lines[i + 1] = animal.ToString;
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }        public static AnimalsContainer ReadAnimals(string fileName)
        {
            AnimalsContainer animals = new AnimalsContainer();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string type = Values[0];
                int id = int.Parse(Values[1]);
                string name = Values[2];
                string breed = Values[3];
                DateTime birthDate = DateTime.Parse(Values[4]);
                Gender gender;
                Enum.TryParse(Values[5], out gender); //tries to convert value to enum
                switch(type)
                {
                    case "DOG":
                        bool aggresive = bool.Parse(Values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggresive);
                        animals.Add(dog);
                        break;
                    case "CAT":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        animals.Add(cat);
                        break;
                    case "GUINEAPIG":
                        GuineaPig guineaPig = new GuineaPig(id, name, breed, birthDate, gender);
                        animals.Add(guineaPig);
                        break;
                    default:
                        break; // unknown type
                }

            }
            return animals;
        }

        public static void PrintAnimals(string label, AnimalsContainer animals)
        { 
            Console.WriteLine(new string('-', 95));
            Console.WriteLine("| {0,-91} |", label);
            Console.WriteLine(new string('-', 95));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} | {5, -18} |", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis", "Agresyvus ar ne");
            Console.WriteLine(new string('-', 95));
            for (int i = 0; i < animals.Count; i++)
            {
                Animal animal = animals.Get(i);
                //1 Savarankiskas
                Console.WriteLine(animal.ToString);
               
            } 
            Console.WriteLine(new string('-', 95));
        }

        public static void PrintDogs(AnimalsContainer animals)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis", "Agresyvus ar ne");
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < animals.Count; i++)
            {
                Animal animal = animals.Get(i);
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | {5,-18} |", animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender, (animal as Dog).Aggresive);
            }
            Console.WriteLine(new string('-', 74));
        }

        public static List<Vaccination> ReadVaccinations(string fileName)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                DateTime vaccinationDate = DateTime.Parse(Values[1]);
                Vaccination v = new Vaccination(id, vaccinationDate);
                Vaccinations.Add(v);
            }
            return Vaccinations;
        }

        //Dogs whose Vaccination date has expired printed on screen
        public static void ExpiredDate(AnimalsContainer animals)
        {
            
            for (int i = 0; i < animals.Count; i++)
            {
                Animal animal = animals.Get(i);
                Console.WriteLine(new string('-', 87));
                if (animal.LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | {5, 10} |", animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender, " ");
                }
                else
                    Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | {5, -8:yyyy-MM-dd} |", animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender, animal.LastVaccinationDate);
                Console.WriteLine(new string('-', 87));

            }
        }

    }
}
