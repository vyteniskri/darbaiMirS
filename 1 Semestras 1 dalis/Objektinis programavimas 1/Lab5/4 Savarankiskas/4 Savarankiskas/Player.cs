using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiskas
{
    public abstract class Player
    {
        public string TeamName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int MatchesCount { get; set; }
        public int Points { get; set; }

        public Player(string teamName, string name, string surname, DateTime birthDate, int matchesCount, int points)
        {
            TeamName = teamName;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            MatchesCount = matchesCount;
            Points = points;
        }

        public abstract string ToString { get;}
        
    }
}
