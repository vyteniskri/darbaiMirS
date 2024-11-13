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
        /// Represents year
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Start of year
        /// </summary>
        public DateTime YearStart { get; set; }
        /// <summary>
        /// End of year
        /// </summary>
        public DateTime YearEnd { get; set; }
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
        /// Represents given value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Creates Player method
        /// </summary>
        /// <param name="year">Represents year</param>
        /// <param name="yearStart">Start of year</param>
        /// <param name="yearEnd">End of year</param>
        /// <param name="name">Name of player</param>
        /// <param name="surname">Surname of player</param>
        /// <param name="birthDate">Birth date of player</param>
        /// <param name="hight">Hight of player</param>
        /// <param name="number">Number of player</param>
        /// <param name="club">Club of player</param>
        /// <param name="invited">Invited or not invited player</param>
        /// <param name="captainOrNot">Player who is captain or not</param>
        public Player(int year, DateTime yearStart, DateTime yearEnd, string name, string surname, DateTime birthDate, int hight, int number, string club, bool invited, bool captainOrNot)
        {
            this.Year = year;
            this.YearStart = yearStart;
            this.YearEnd = yearEnd;
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

        /// <summary>
        /// Creates overriden string method
        /// </summary>
        /// <returns>String line of text</returns>
        public override string ToString()
        {
            string line;
            line = String.Format("| {0, 8} | {1, -23:yyyy-MM-dd} | {2, -23:yyyy-MM-dd} | {3, -8} | {4, -15} | {5, -12:yyyy-MM-dd} | {6, 8} | {7, 8} | {8, -12} | {9, -20} | {10, -17} |", Year, YearStart, YearEnd, Name, Surname, BirthDate, Hight, Number, Club, Invited, CaptainOrNot);

            return line;
        }

        /// <summary>
        /// Creates overriden bool operator
        /// </summary>
        /// <param name="player1">Information about the player</param>
        /// <param name="player2">Information about the player</param>
        /// <returns>True or false</returns>        public static bool operator ==(Player player1, Player player2)
        {
            if (player1.Name.Equals(player2.Name) && player1.Surname.Equals(player2.Surname))
            {
                return true;
            }
            return false;
            
        }

        /// <summary>
        /// Creates overriden bool operator
        /// </summary>
        /// <param name="player1">Information about the player</param>
        /// <param name="player2">Information about the player</param>
        /// <returns>True or false</returns>
        public static bool operator !=(Player player1, Player player2)
        {
            if (!player1.Name.Equals(player2.Name) && !player1.Surname.Equals(player2.Surname))
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Creates overriden bool operator
        /// </summary>
        /// <param name="player">Information about the player</param>
        /// <param name="club">String variable</param>
        /// <returns>True or false</returns>        public static bool operator ==(Player player, string club)
        {
            if (player.Club.Equals(club))
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Creates overriden bool operator
        /// </summary>
        /// <param name="player">Information about the player</param>
        /// <param name="club">String variable</param>
        /// <returns>True or false</returns>
        public static bool operator !=(Player player, string club)
        {
            if (!player.Club.Equals(club))
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Creates overriden bool operator
        /// </summary>
        /// <param name="player">Information about the player</param>
        /// <param name="x">Int type variable</param>
        /// <returns>Biggest value</returns>        public static bool operator >(Player player, int x)
        {
            return player.Hight.CompareTo(x) > 0;
        }

        /// <summary>
        /// Creates overriden bool operator
        /// </summary>
        /// <param name="player">Information about the player</param>
        /// <param name="x">Int type variable</param>
        /// <returns>Smallest value</returns>
        public static bool operator <(Player player, int x)
        {
            return player.Hight.CompareTo(x) < 0;
        }

        /// <summary>
        /// Creates overriden bool operator
        /// </summary>
        /// <param name="player">Information about the player</param>
        /// <param name="Max">Int type variable</param>
        /// <returns>True or false</returns>        public static bool operator ==(Player player, int Max)
        {
            if (player.Hight.Equals(Max))
            {
                return true;
            }
            return false;
 
        }

        /// <summary>
        /// Creates overriden bool operator
        /// </summary>
        /// <param name="player">Information about the player</param>
        /// <param name="Max">Int type variable</param>
        /// <returns>True or false</returns>
        public static bool operator !=(Player player, int Max)
        {
            if (!player.Hight.Equals(Max))
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Creates overriden bool operator
        /// </summary>
        /// <param name="player">Information about the player</param>
        /// <param name="x">Int type variable</param>
        /// <returns>Greater or equal value</returns>        public static bool operator >=(Player player, int x)
        {
            return player.Hight.CompareTo(x) >= 0; 
        }

        /// <summary>
        /// Creates overriden bool operator
        /// </summary>
        /// <param name="player">Information about the player</param>
        /// <param name="x">Int type variable</param>
        /// <returns>Lesser or equal value</returns>        public static bool operator <=(Player player, int x)
        {
            return player.Hight.CompareTo(x) <= 0;
        }        /// <summary>
        /// Creates overriden equals method
        /// </summary>
        /// <param name="other">Given object</param>
        /// <returns>Values are equal</returns>        public override bool Equals(object other)
        {
            return this.Value == (int)other;
        }        /// <summary>
        /// Creates overriden GetHashCode method
        /// </summary>
        /// <returns>Value</returns>        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
