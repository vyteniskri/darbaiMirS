using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    /// <summary>
    /// Class that gives information about a lines of symbols
    /// </summary>
    public class Whole
    {
        /// <summary>
        /// String of symbols
        /// </summary>
        public string LineOfSymbols { get; set; }

        /// <summary>
        /// Line of symbols constructor
        /// </summary>
        /// <param name="lineOfSymbols"></param>
        public Whole(string lineOfSymbols)
        {
            this.LineOfSymbols = lineOfSymbols;
        }

        /// <summary>
        /// Overrriden ToString method
        /// </summary>
        /// <returns>Line of text</returns>
        public override string ToString()
        {
            return string.Format("| {0,-20} |", this.LineOfSymbols);
        }

    }
}