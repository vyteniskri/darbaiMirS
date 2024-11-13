using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exercises.Register
{
    class DogsRegister
    {
        private List<Dog> AllDogs;
        public DogsRegister()
        {
            AllDogs = new List<Dog>();
        }

        public DogsRegister(List<Dog> Dogs)
        {
            AllDogs = new List<Dog>();
            foreach (Dog dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }

        public void Add(Dog dog)
        {
            AllDogs.Add(dog);
        }        public int DogsCount()
        {
            return this.AllDogs.Count;
        }        //Using one array by index        public Dog OneDog(int ind)
        {
            return AllDogs[ind];
        }        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }


        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in AllDogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) // uses List method Constains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public List<Dog> FilterByBreed(string breed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in AllDogs)
            {
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

        public Dog FindOldestDogByBreed(string breed)
        {
            Dog oldest = AllDogs[0];

            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs[i].Breed.Equals(breed))
                {
                    if (DateTime.Compare(AllDogs[i].BirthDate, oldest.BirthDate) < 0)
                    {
                        oldest = AllDogs[i];
                    }
                }

            }
            return oldest;
        }

        public List<string> MostPopular()
        {
            int[] howMany = new int[AllDogs.Count];
            List<string> Popular = new List<string>();
            int zero = 0;
            for (int i = 0; i < AllDogs.Count; i++)
            {
                for (int j = i; j < AllDogs.Count; j++)
                {
                    if (AllDogs[i].Breed == AllDogs[j].Breed)
                    {
                        howMany[i]++;
                    }
                }
            }
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (howMany[i] > zero)
                {
                    zero = howMany[i];
                }
            }
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (zero == howMany[i])
                {
                    Popular.Add(AllDogs[i].Breed);
                }
            }
            return Popular;

        }

        public Dog FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }

        public Dog FindOldestDog(string breed)
        {
            List<Dog> Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }

        private Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0];
            for (int i = 1; i < Dogs.Count; i++)
            {
                if (DateTime.Compare(oldest.BirthDate, Dogs[i].BirthDate) > 0)
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }

        private Dog FindDogByID(int ID)
        {
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.ID == ID)
                {
                    return dog;
                }
            }
            return null;
        }

        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Dog dog = this.FindDogByID(vaccination.DogID);
                if (dog != null) //Program works if there are more values in Vaccinations.txt than in Dogs.txt
                {
                    if (vaccination > dog.LastVaccinationDate)
                    {
                        dog.LastVaccinationDate = vaccination.Date;
                    }
                }
                  
            }
        }

        //Creating a list of dogs whose vaccination date has expired
        public List<Dog> FilterByVaccinationExpired()
        {
            List<Dog> Expired = new List<Dog>();
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs[i].RequiresVaccination == true)
                {
                    Expired.Add(AllDogs[i]);
                }
            }
            return Expired;
        }

        public bool Contains(Dog dog)
        {
            return AllDogs.Contains(dog);
        }
    }
}
