using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_uzduotis
{
    class Player
    {
        public string Name { get; set; } 
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int HightOfPlayer { get; set; }
        public int Number { get; set; }
        public string Club { get; set; }
        public string InOut { get; set; }
        public string CaptainOrNot { get; set; }
       
        public Player(string name, string surname, DateTime birthDate, int hightOfPlayer, int number, string club, string inOut, string captainOrNot)
        {
            this.Name = name;
            this.Surname = surname;
            this.BirthDate = birthDate;
            this.HightOfPlayer = hightOfPlayer;
            this.Number = number;
            this.Club = club;
            this.InOut = inOut;
            this.CaptainOrNot = captainOrNot;

        }

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
