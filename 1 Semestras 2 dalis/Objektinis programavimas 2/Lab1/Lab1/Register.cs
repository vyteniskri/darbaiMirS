using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    /// <summary>
    /// Class that calculates given information
    /// </summary>
    public class Register
    {
        /// <summary>
        /// List of wholes information
        /// </summary>
        private List<Whole> AllWholes;

        /// <summary>
        /// Size of columns
        /// </summary>
        public int ColumnsSize;

        /// <summary>
        /// Size of rows
        /// </summary>
        public int RowsSize;

        /// <summary>
        /// Formats a list
        /// </summary>
        public Register()
        {
            AllWholes = new List<Whole>();
        }

        /// <summary>
        /// Method that disperses information
        /// </summary>
        /// <param name="wholes">List of members</param>
        public Register(List<Whole> wholes)
        {
            AllWholes = new List<Whole>();
            for (int i = 0; i < wholes.Count; i++)
            {
                AllWholes.Add(wholes[i]);
            }
        }

        /// <summary>
        /// Method that adds information to the list
        /// </summary>
        /// <param name="wholes">Single line of wholes</param>
        public void Add(Whole wholes)
        {
            AllWholes.Add(wholes);
        }

        /// <summary>
        /// Method that counts how many
        /// </summary>
        /// <returns>Counted rezult</returns>
        public int Count()
        {
            return AllWholes.Count;
        }

        /// <summary>
        /// Method that gives line of information from the list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Whole WholeLine(int index)
        {
            return AllWholes[index];
        }

        /// <summary>
        /// Method that creates two dimensional char array
        /// </summary>
        /// <returns>Formated two dimensional char array</returns>
        public char[,] ToCharArray()
        {
            char[,] symbols = new char[ColumnsSize, RowsSize];
            for (int i = 0; i < ColumnsSize; i++)
            {
                for (int j = 0; j < RowsSize; j++)
                {
                    symbols[i, j] = AllWholes[i].LineOfSymbols.ToCharArray()[j];
                }
            }
            return symbols;
        }
    }
}