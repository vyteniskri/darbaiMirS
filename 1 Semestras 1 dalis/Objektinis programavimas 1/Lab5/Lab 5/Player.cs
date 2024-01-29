using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    public class Player : Member
    {
        /// <summary>
        /// Player's hight
        /// </summary>
        public int Hight { get; set; }
        /// <summary>
        /// Player's number
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Player's club
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
        /// Player constructor
        /// </summary>
        /// <param name="name">Player's name</param>
        /// <param name="surname">Player's surname</param>
        /// <param name="birthDate">Player's birth date</param>
        /// <param name="hight">Player's hight</param>
        /// <param name="number">Player's number</param>
        /// <param name="club">Player's club</param>
        /// <param name="invited">Invited or not invited player</param>
        /// <param name="captainOrNot">Player who is captain or not</param>
        public Player(string name, string surname, DateTime birthDate, int hight, int number, string club, bool invited, bool captainOrNot):base(name, surname, birthDate)
        {
            this.Hight = hight;
            this.Number = number;
            this.Club = club;
            this.Invited = invited;
            this.CaptainOrNot = captainOrNot;
        }

        /// <summary>
        /// Overriden ToString method
        /// </summary>
        /// <returns>Line of text</returns>
        public override string ToString()
        {
            string line = string.Format(" {0, 15} | {1, 8} | {2, -12} | {3, -20} | {4, -17} |", Hight, Number, Club, Invited, CaptainOrNot);
            return base.ToString() + line;
        }

        /// <summary>
        /// Oparator that compares player's club to a centain club
        /// </summary>
        /// <param name="player">Player variable</param>
        /// <param name="club">A certain club</param>
        /// <returns>True or false</returns>
        public static bool operator ==(Player player, string club)
        {
            return player.Club == club;
        }

        /// <summary>
        /// Oparator that compares player's club to a centain club
        /// </summary>
        /// <param name="player">Player variable</param>
        /// <param name="club">A certain club</param>
        /// <returns>True or false</returns>
        public static bool operator !=(Player player, string club)
        {
            return player.Club != club;
        }

    }
}
