using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exercises.Register
{
    class DogsContainer
    {
        private Dog[] dogs;
        public int Count { get; private set; }
        private int Capacity;

        public DogsContainer(int capacity = 5) //parameter with default value
        {
            this.Capacity = capacity;
            this.dogs = new Dog[capacity]; //default capacity
        }

        public DogsContainer(DogsContainer container):this(container.Count) //calls another constructor
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
                Dog[] temp = new Dog[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.dogs[i];
                }
                this.Capacity = minimumCapacity;
                this.dogs = temp;
            }
        }

        public void Add(Dog dog)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.dogs[this.Count++] = dog;
        }

        public Dog Get(int index)
        {
            return this.dogs[index];
        }

        public bool Contains(Dog dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].Equals(dog))
                {
                    return true;
                }
            }
            return false;
        }

        //Put method
        public void Put(Dog dog, int index)
        {
            dogs[index] = dog;
        }

        //Insert method
        public void Insert(Dog dog, int index)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            int j = index;
            for (int i = index + 1; i < this.Count; i++)
            {
                dogs[i] = dogs[j];
                j++;
            }         
            dogs[index] = dog;
        }

        //Remove method
        public void Remove(Dog dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
               
                if (dogs[i] == dog)
                {
                    for (int j = i; j < this.Count; j++)
                    {
                        dogs[j] = dogs[j+1];
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
                        dogs[j] = dogs[j+1];
                    }
                    Count--;
                }
                 
            }
        }

        // Sort method
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Dog a = this.dogs[i];
                    Dog b = this.dogs[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.dogs[i] = b;
                        this.dogs[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public DogsContainer Intersect(DogsContainer other)
        {
            DogsContainer result = new DogsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Dog current = this.dogs[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
    }
}
