using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3
{
    /// <summary>
    /// Workers data class
    /// </summary>
    public class Worker: IComparable<Worker>, IEquatable<Worker>
    {
        /// <summary>
        /// Specific date 
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Worker's surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Worker's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Part's code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Number of parts
        /// </summary>
        public int VntCount { get; set; }

        /// <summary>
        /// Total number of days worked
        /// </summary>
        public int DaysWorked { get; set; }

        /// <summary>
        /// Total number of made parts
        /// </summary>
        public int PartsCount { get; set; }

        /// <summary>
        /// Total Salary of a worker
        /// </summary>
        public decimal MoneyCount { get; set; }

        /// <summary>
        /// First constructor
        /// </summary>
        public Worker()
        {

        }

        /// <summary>
        /// Second constructor
        /// </summary>
        /// <param name="date">Specific date </param>
        /// <param name="surname">Worker's surname</param>
        /// <param name="name">Worker's name</param>
        /// <param name="code">Part's code</param>
        /// <param name="vntCount">Number of parts</param>
        /// <param name="daysWorked">Total number of days worked</param>
        /// <param name="partCount">Total number of made parts</param>
        /// <param name="moneyCount">Total Salary of a worker</param>
        public Worker(DateTime date, string surname, string name, string code, int vntCount, int daysWorked, int partCount, decimal moneyCount)
        {
            this.Date = date;
            this.Surname = surname;
            this.Name = name;
            this.Code = code;
            this.VntCount = vntCount;
            this.DaysWorked = daysWorked;
            this.PartsCount = partCount;
            this.MoneyCount = moneyCount;
        }

        /// <summary>
        /// Overriden ToString method
        /// </summary>
        /// <returns>A formated string</returns>
        public override string ToString()
        {
            if (Date != DateTime.MinValue)
            {
                return string.Format("| {0,-20:yyyy-MM-dd} | {1,-20} | {2,-20} | {3,-20} | {4,20} |", Date, Surname, Name, Code, VntCount);
            }
            else if (Name == null)
            {
                return string.Format("| {0,-20} | {1,20} | {2,20} | {3,20} |", Surname, DaysWorked, PartsCount, MoneyCount);
            }
            else
                return string.Format("| {0,-20} | {1,-20} | {2,-20} | {3,20} | {4,20} |", Surname, Name, Code, PartsCount, MoneyCount);
        }

        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="obj">Other worker</param>
        /// <returns>If it is true or false</returns>
        public bool Equals(Worker obj)
        {

            if (Surname.Equals(obj) == true)
            {
                return true;
            }
            else if (Code.Equals(obj) == true)
            {
                return true;
            }
            else if (Date.Equals(obj) == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method that compares two workers
        /// </summary>
        /// <param name="other">Other worker</param>
        /// <returns>An integer</returns>
        public int CompareTo(Worker other)
        {
            if ((object)other == null)
            {
                return 1;
            }
            if (Surname.CompareTo(other.Surname) != 0)
            {
                return Surname.CompareTo(other.Surname);
            }
            else
                return Name.CompareTo(other.Name);
        }

        

    }
}