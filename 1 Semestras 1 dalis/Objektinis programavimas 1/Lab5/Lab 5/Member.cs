using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    /// <summary>
    /// Class that saves information about one team member
    /// </summary>
    public abstract class Member
    {
        /// <summary>
        /// Name of the member
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Surname of the member
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Birth date of the member
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Members Constructor
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="surname">Surname of the member</param>
        /// <param name="birthDate">Birth date of the member</param>
        public Member(string name, string surname, DateTime birthDate)
        {
            this.Name = name;
            this.Surname = surname;
            this.BirthDate = birthDate;

        }

        /// <summary>
        /// Overriden ToString method 
        /// </summary>
        /// <returns>Line of text</returns>
        public override string ToString()
        {
            string line = string.Format("| {0,-8} | {1,-15} | {2,-12:yyyy-MM-dd} |", Name, Surname, BirthDate);
            return line;
        }

        /// <summary>
        /// Member's age
        /// </summary>
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDate.Year;
                if (this.BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        /// <summary>
        /// Operator that compares players birth date to DateTime variable
        /// </summary>
        /// <param name="member">Information about one mamber</param>
        /// <param name="date2">DateTime variable</param>
        /// <returns>Greater value</returns>
        public static bool operator >(Member member, DateTime date2)
        {
            return member.BirthDate > date2;
        }

        /// <summary>
        /// Operator that compares players birth date to DateTime variable
        /// </summary>
        /// <param name="member">Information about one mamber</param>
        /// <param name="date2">DateTime variable</param>
        /// <returns>Lesser value</returns>
        public static bool operator <(Member member, DateTime date2)
        {
            return member.BirthDate < date2;
        }

        /// <summary>
        /// Overriden Equals method that compares two members surnames
        /// </summary>
        /// <param name="other">Other member</param>
        /// <returns>Equal value</returns>
        public override bool Equals(object other)
        {
            return this.Surname == ((Member)other).Surname;
        }

        /// <summary>
        /// Overriden GetHashCode of value method
        /// </summary>
        /// <returns>Value</returns>
        public override int GetHashCode()
        {
            return this.Surname.GetHashCode();
        }

        /// <summary>
        /// A method that compares members by their name and surname
        /// </summary>
        /// <param name="other">Other member</param>
        /// <returns>Compared members</returns>
        public int CompareTo(Member other)
        {
            if (this.Surname != other.Surname)
            {
                return this.Surname.CompareTo(other.Surname);
            }
            else
                return this.Name.CompareTo(other.Name);
        }
    }
}
