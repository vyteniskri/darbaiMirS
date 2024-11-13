using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    /// <summary>
    /// Conteiner of counted wholes 
    /// </summary>
    public class WholesConteiner
    {
        /// <summary>
        /// Array of wholes
        /// </summary>
        private int[] wholesNumber;

        /// <summary>
        /// Count of moles
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Total capacity of moles
        /// </summary>
        private int Capacity;

        /// <summary>
        /// WholesConteiner constructor
        /// </summary>
        /// <param name="capacity">Capacity of moles</param>
        public WholesConteiner(int capacity = 5)
        {
            this.Capacity = capacity;
            this.wholesNumber = new int[capacity];
        }

        /// <summary>
        /// Method that makes sure of the moles capacity
        /// </summary>
        /// <param name="minimumCapacity">Minimum capacity of moles</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                int[] temp = new int[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = wholesNumber[i];
                }
                this.Capacity = minimumCapacity;
                wholesNumber = temp;
            }
        }

        /// <summary>
        /// Method that adds wholes number to the array
        /// </summary>
        /// <param name="wholesNumber">Wholes number</param>
        public void Add(int wholesNumber)
        {
            if (Capacity == Count)
            {
                EnsureCapacity(Capacity * 2);
            }
            this.wholesNumber[Count++] = wholesNumber;
        }

        /// <summary>
        /// Method that gives information about mole's number of created wholes
        /// </summary>
        /// <param name="index">Index of a single mole</param>
        /// <returns>Number of wholes</returns>
        public int Get(int index)
        {
            return wholesNumber[index];
        }

        /// <summary>
        /// Method that calculates and gives information about the size of wholes
        /// </summary>
        /// <param name="size">Size of one whole</param>
        /// <param name="index">Index of a single mole</param>
        /// <returns>Claculated area informationn</returns>
        public int GetArea(int size, int index)
        {
            return wholesNumber[index] * size;
        }

        /// <summary>
        /// Method that sorts information the conteiner
        /// </summary>
        public void Sort()
        {
            for (int i = 0; i < wholesNumber.Count(); i++)
            {
                for (int j = i + 1; j < wholesNumber.Count(); j++)
                {
                    if (wholesNumber[i] < wholesNumber[j])
                    {
                        int a = wholesNumber[i];
                        int b = wholesNumber[j];
                        wholesNumber[i] = b;
                        wholesNumber[j] = a;
                    }
                }
            }
        }
    }

}