using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class Register
    {
        private AnimalsContainer AllAnimals;
        public Register()
        {
            AllAnimals = new AnimalsContainer();
        }

        public Register(AnimalsContainer Animals)
        {
            AllAnimals = new AnimalsContainer();
            for (int i = 0; i < Animals.Count; i++)
            {
                this.AllAnimals.Add(Animals.Get(i));
            }
        }

        public void Add(Animal animal)
        {
            AllAnimals.Add(animal);
        }        public int AnimalsCount()
        {
            return this.AllAnimals.Count;
        }        //Using one array by index        public Animal OneAnimal(int ind)
        {
            return AllAnimals.Get(ind);
        }        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                if (AllAnimals.Get(i).Gender.Equals(gender))
                {
                    count++;
                }
            }   
            return count;
        }

        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                Animal animal = AllAnimals.Get(i);
                string breed = animal.Breed;
                if (!Breeds.Contains(breed)) // uses List method Constains()
                {
                    Breeds.Add(breed);
                }

            }
            return Breeds;
        }

        public AnimalsContainer FilterByBreed(string breed)
        {
            AnimalsContainer Filtered = new AnimalsContainer();
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                Animal animal = AllAnimals.Get(i);
                if (animal.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(animal);
                }
            }
            return Filtered;
        }

        public Animal FindOldestAnimalByBreed(string breed)
        {
            Animal oldest = AllAnimals.Get(0);
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                if (AllAnimals.Get(i).Breed.Equals(breed))
                {
                    if (DateTime.Compare(AllAnimals.Get(i).BirthDate, oldest.BirthDate) < 0)
                    {
                        oldest = AllAnimals.Get(i);
                    }
                }

            }
            return oldest;
        }

        public List<string> MostPopular()
        {
            int[] howMany = new int[AllAnimals.Count];
            List<string> Popular = new List<string>();
            int zero = 0;
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                for (int j = i; j < AllAnimals.Count; j++)
                {
                    if (AllAnimals.Get(i).Breed == AllAnimals.Get(j).Breed)
                    {
                        howMany[i]++;
                    }
                }
            }
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                if (howMany[i] > zero)
                {
                    zero = howMany[i];
                }
            }
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                if (zero == howMany[i])
                {
                    Popular.Add(AllAnimals.Get(i).Breed);
                }
            }
            return Popular;

        }

        public Animal FindOldestAnimal()
        {
            return this.FindOldestAnimal(this.AllAnimals);
        }

        public Animal FindOldestAnimal(string breed)
        {
            AnimalsContainer Filtered = this.FilterByBreed(breed);
            return FindOldestAnimal(Filtered);
        }

        private Animal FindOldestAnimal(AnimalsContainer Animals)
        {
            Animal oldest = Animals.Get(0);
            for (int i = 1; i < Animals.Count; i++)
            {
                if (DateTime.Compare(oldest.BirthDate, Animals.Get(i).BirthDate) > 0)
                {
                    oldest = Animals.Get(i);
                }
            }
            return oldest;
        }

        private Animal FindAnimalByID(int ID)
        {
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                if (AllAnimals.Get(i).ID == ID)
                {
                    return AllAnimals.Get(i);
                }
            }
            return null;
        }

        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Animal animal = this.FindAnimalByID(vaccination.AnimalID);
                if (animal != null) //Program works if there are more values in Vaccinations.txt than in Dogs.txt
                {
                    if (vaccination > animal.LastVaccinationDate)
                    {
                        animal.LastVaccinationDate = vaccination.Date;
                    }
                }
                  
            }
        }

        //Creating a list of dogs whose vaccination date has expired
        public AnimalsContainer FilterByVaccination()
        {
            AnimalsContainer Expired = new AnimalsContainer();
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                if (AllAnimals.Get(i).RequiresVaccination == true)
                {
                    Expired.Add(AllAnimals.Get(i));
                }
            }
            return Expired;
        }

        public bool Contains(Animal animal)
        {
            return AllAnimals.Contains(animal);
        }

        public int CountAggresiveDogs()
        {
            int count = 0;
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                Animal animal = this.AllAnimals.Get(i);
                if (animal is Dog && (animal as Dog).Aggresive)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
