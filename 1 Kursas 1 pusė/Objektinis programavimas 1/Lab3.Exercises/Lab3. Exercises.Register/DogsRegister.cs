using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exercises.Register
{
    class DogsRegister
    {
        private DogsContainer AllDogs;
        public DogsRegister()
        {
            AllDogs = new DogsContainer();
        }

        public DogsRegister(DogsContainer Dogs)
        {
            AllDogs = new DogsContainer();
            for (int i = 0; i < Dogs.Count; i++)
            {
                this.AllDogs.Add(Dogs.Get(i));
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
            return AllDogs.Get(ind);
        }        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).Gender.Equals(gender))
                {
                    count++;
                }
            }   
            return count;
        }

        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            for (int i = 0; i < AllDogs.Count; i++)
            {
                Dog dog = AllDogs.Get(i);
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) // uses List method Constains()
                {
                    Breeds.Add(breed);
                }

            }
            return Breeds;
        }

        public DogsContainer FilterByBreed(string breed)
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 0; i < AllDogs.Count; i++)
            {
                Dog dog = AllDogs.Get(i);
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

        public Dog FindOldestDogByBreed(string breed)
        {
            Dog oldest = AllDogs.Get(0);
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).Breed.Equals(breed))
                {
                    if (DateTime.Compare(AllDogs.Get(i).BirthDate, oldest.BirthDate) < 0)
                    {
                        oldest = AllDogs.Get(i);
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
                    if (AllDogs.Get(i).Breed == AllDogs.Get(j).Breed)
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
                    Popular.Add(AllDogs.Get(i).Breed);
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
            DogsContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }

        private Dog FindOldestDog(DogsContainer Dogs)
        {
            Dog oldest = Dogs.Get(0);
            for (int i = 1; i < Dogs.Count; i++)
            {
                if (DateTime.Compare(oldest.BirthDate, Dogs.Get(i).BirthDate) > 0)
                {
                    oldest = Dogs.Get(i);
                }
            }
            return oldest;
        }

        private Dog FindDogByID(int ID)
        {
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).ID == ID)
                {
                    return AllDogs.Get(i);
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
        public DogsContainer FilterByVaccination()
        {
            DogsContainer Expired = new DogsContainer();
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).RequiresVaccination == true)
                {
                    Expired.Add(AllDogs.Get(i));
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
