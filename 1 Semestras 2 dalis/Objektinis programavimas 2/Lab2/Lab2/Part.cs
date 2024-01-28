using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// Parts data class
    /// </summary>
    public class Part
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
    }
}