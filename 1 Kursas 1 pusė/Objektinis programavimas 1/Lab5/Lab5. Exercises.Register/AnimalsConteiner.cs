using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class AnimalsContainer
    {
        private Animal[] animals;
        public int Count { get; private set; }
        private int Capacity;

        public AnimalsContainer(int capacity = 5) //parameter with default value
        {
            this.Capacity = capacity;
            this.animals = new Animal[capacity]; //default capacity
        }

        public AnimalsContainer(AnimalsContainer container):this(container.Count) //calls another constructor
        {
        
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Animal[] temp = new Animal[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.animals[i];
                }
                this.Capacity = minimumCapacity;
                this.animals = temp;
            }
        }

        public void Add(Animal animal)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.animals[this.Count++] = animal;
        }

        public Animal Get(int index)
        {
            return this.animals[index];
        }

        public bool Contains(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i].Equals(animal))
                {
                    return true;
                }
            }
            return false;
        }

        //Put method
        public void Put(Animal animal, int index)
        {
            animals[index] = animal;
        }

        //Insert method
        public void Insert(Animal animal, int index)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            int j = index;
            for (int i = index + 1; i < this.Count; i++)
            {
                animals[i] = animals[j];
                j++;
            }         
            animals[index] = animal;
        }

        //Remove method
        public void Remove(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
               
                if (animals[i] == animal)
                {
                    for (int j = i; j < this.Count; j++)
                    {
                        animals[j] = animals[j+1];
                    }
                    Count--;
                    i--;    
                }
            }
        }

        //RemoveAt method
        public void RemoveAt(int index)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (i == index)
                {
                    for (int j = i; j < this.Count; j++)
                    {
                        animals[j] = animals[j+1];
                    }
                    Count--;
                }
                 
            }
        }

        // Sort method
        public void Sort(AnimalsComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Animal a = this.animals[i];
                    Animal b = this.animals[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.animals[i] = b;
                        this.animals[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public void Sort()
        {
            Sort(new AnimalsComparator());
        }

        public AnimalsContainer Intersect(AnimalsContainer other)
        {
            AnimalsContainer result = new AnimalsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal current = this.animals[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
    }
}
