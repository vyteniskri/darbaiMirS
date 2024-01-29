using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    /// <summary>
    /// Class that gives information about one staff member
    /// </summary>
    public class Staff : Member
    {
        /// <summary>
        /// Duties of staff's member
        /// </summary>
        public string Duties { get; set; }

        /// <summary>
        /// Staff constructor
        /// </summary>
        /// <param name="name">Staff's members name</param>
        /// <param name="surname">Staff's members surname</param>
        /// <param name="birthDate">Staff's members birth date</param>
        /// <param name="duties">Staff's members duties</param>
        public Staff(string name, string surname, DateTime birthDate, string duties):base(name, surname, birthDate)
        {
            this.Duties = duties;
        }

        /// <summary>
        /// Overrriden ToString method
        /// </summary>
        /// <returns>Line of text</returns>
        public override string ToString()
        {
            string line = string.Format(" {0, 15} | {1, 8} | {2, -12} | {3, -20} | {4, -17} |", Duties, "-", "-", "-", "-");
            return base.ToString() + line;
        }
    }
}
