using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.Register1
{
    static class TaskUtils
    {
        public static int CountByGender(List<Dog> Dogs, Gender gender)
        {
            int count = 0;
            foreach (Dog dog in Dogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        
        public static Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0]; // means least value
            for (int i = 1; i < Dogs.Count; i++)
            {
                if (DateTime.Compare(Dogs[i].BirthDate, oldest.BirthDate) < 0)
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }

        public static List<string> FindBreeds(List<Dog> Dogs)
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in Dogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) // uses List method Constains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public static List<Dog> FilterByBreed(List<Dog> Dogs, string breed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in Dogs)
            {
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

        public static Dog FindOldestDogByBreed(List<Dog> Dogs, string breed)
        {
            Dog oldest = Dogs[0];
           
            for (int i = 0; i < Dogs.Count; i++)
            {
                if (Dogs[i].Breed.Equals(breed)) 
                {
                     if (DateTime.Compare(Dogs[i].BirthDate, oldest.BirthDate) < 0)
                     {
                         oldest = Dogs[i];
                     }
                }
               
            }
            return oldest;
        }

        public static List<string> MostPopular(List<Dog> Dogs)
        {
            int[] howMany = new int[Dogs.Count];
            List<string> Popular = new List<string>();
            int zero = 0;
            for (int i = 0; i < Dogs.Count; i++)
            {
                for (int j = i; j < Dogs.Count; j++)
                {
                    if (Dogs[i].Breed == Dogs[j].Breed)
                    {
                        howMany[i]++;
                    }
                }
            }
            for (int i = 0; i < Dogs.Count; i++)
            {
                if (howMany[i] > zero)
                {
                    zero = howMany[i];
                }
            }
            for (int i = 0; i < Dogs.Count; i++)
            {
                if (zero == howMany[i])
                {
                   Popular.Add(Dogs[i].Breed);   
                }
            }
            return Popular;
            
        }
    }
}
