using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_uzduotis
{
    /// <summary>
    /// Class that saves information about one basketball player
    /// </summary>
    class Player
    {
        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name { get; set; } 
        /// <summary>
        /// Surname of the player
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Birth date of player
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Hight of player
        /// </summary>
        public int Hight { get; set; }
        /// <summary>
        /// Number of player
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Club of player
        /// </summary>
        public string Club { get; set; }
        /// <summary>
        /// Invited or not invited player
        /// </summary>
        public bool Invited { get; set; }
        /// <summary>
        /// Player who is captain or not
        /// </summary>
        public bool CaptainOrNot { get; set; }

        /// <summary>
        /// Creates public method with the same name as class name
        /// </summary>
        /// <param name="name">Name of player</param>
        /// <param name="surname">Surname of player</param>
        /// <param name="birthDate">Birth date of player</param>
        /// <param name="hight">Hight of player</param>
        /// <param name="number">Number of player</param>
        /// <param name="club">Club of player</param>
        /// <param name="invited">Invited or not invited player</param>
        /// <param name="captainOrNot">Player who is captain or not</param>
        public Player(string name, string surname, DateTime birthDate, int hight, int number, string club, bool invited, bool captainOrNot)
        {
            this.Name = name;
            this.Surname = surname;
            this.BirthDate = birthDate;
            this.Hight = hight;
            this.Number = number;
            this.Club = club;
            this.Invited = invited;
            this.CaptainOrNot = captainOrNot;

        }

        /// <summary>
        /// Creates int method
        /// </summary>
        /// <returns>Formated int value</returns>
        public int CalculateAge()
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
}
