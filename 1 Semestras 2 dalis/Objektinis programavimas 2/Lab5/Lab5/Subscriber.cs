using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5
{
    /// <summary>
    /// Class of subscriber data
    /// </summary>
    public class Subscriber
    {
        /// <summary>
        /// Date of when a subscriber was put on a formated list
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Subscribers surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Subscribers address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Starting date of the subscribtion
        /// </summary>
        public int StartingMonth { get; set; }

        /// <summary>
        /// Subscribtion lenght
        /// </summary>
        public int SubcribeLenght { get; set; }

        /// <summary>
        /// Code of the publication
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Number of publications
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Subscriber's constructor
        /// </summary>
        /// <param name="date">Date of when a subscriber was put on a formated list</param>
        /// <param name="surname">Subscribers surname</param>
        /// <param name="address">Subscribers address</param>
        /// <param name="startingMonth">Starting date of the subscribtion</param>
        /// <param name="subcribeLenght">Subscribtion lenght</param>
        /// <param name="code">Code of the publication</param>
        /// <param name="count">Number of publications</param>
        public Subscriber(DateTime date, string surname, string address, int startingMonth, int subcribeLenght, string code, int count)
        {
            this.Date = date;
            this.Surname = surname;
            this.Address = address;
            this.StartingMonth = startingMonth;
            this.SubcribeLenght = subcribeLenght;
            this.Code = code;
            this.Count = count;
        }

        /// <summary>
        /// Overriden ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("| {0, -20:yyyy-MM-dd} | {1, -20} | {2, -20} | {3, 20} | {4, 20} | {5, -20} | {6, 20} |", Date, Surname, Address, StartingMonth, SubcribeLenght, Code, Count);
        }

    }
}