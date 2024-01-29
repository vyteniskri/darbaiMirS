using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_uzduotis_nr._2
{
    class Player
    {
        public int Year { get; set; }
        public DateTime YearStart { get; set; }
        public DateTime YearEnd { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Hight { get; set; }
        public int Number { get; set; }
        public string Club { get; set; }
        public string InOrOut { get; set; }
        public string CaptainOrNot { get; set; }

        public Player(int year, DateTime yearStart, DateTime yearEnd, string name, string surname, DateTime dateOfBirth, int hight, int number, string club, string inOrOut, string captainOrNot)
        {
            this.Year = year;
            this.YearStart = yearStart;
            this.YearEnd = yearEnd;
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.Hight = hight;
            this.Number = number;
            this.Club = club;
            this.InOrOut = inOrOut;
            this.CaptainOrNot = captainOrNot;
        }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.DateOfBirth.Year;
                if (this.DateOfBirth.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }

        }
    }
}
