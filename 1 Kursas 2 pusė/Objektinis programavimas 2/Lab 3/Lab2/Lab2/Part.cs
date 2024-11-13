using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3
{
    /// <summary>
    /// Parts data class
    /// </summary>
    public class Part : IComparable<Part>, IEquatable<Part>
    {
        /// <summary>
        /// Part's code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name of the part
        /// </summary>
        public string Name{ get; set; }

        /// <summary>
        /// Part's value
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// First constructor
        /// </summary>
        public Part()
        {

        }

        /// <summary>
        /// Second constructor
        /// </summary>
        /// <param name="code">Part's code</param>
        /// <param name="name">Name of the part</param>
        /// <param name="price">Part's value</param>
        public Part(string code, string name, decimal price)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
        }

        /// <summary>
        /// Overriden ToString method
        /// </summary>
        /// <returns>A formated string</returns>
        public override string ToString()
        {
            return string.Format("| {0,-20} | {1,-20} | {2,20} |", Code, Name, Price);
        }

        /// <summary>
        /// Method that compares parts
        /// </summary>
        /// <param name="other">Second part</param>
        /// <returns>NotImplementedException</returns>
        public int CompareTo(Part other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method that finds out if parts are equal or not
        /// </summary>
        /// <param name="other">Second part</param>
        /// <returns>NotImplementedException</returns>
        public bool Equals(Part other)
        {
            throw new NotImplementedException();
        }
    }
}