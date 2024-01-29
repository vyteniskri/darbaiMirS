using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiskas
{
    class Team
    {
        public string NameOfTheTeam { get; set;}
        public string City { get; set; }
        public string TeamTrainer { get; set; }
        public int MatchesCount { get; set; }

        public Team(string nameOfTheTeam, string city, string teamTrainer, int matchesCount)
        {
            this.NameOfTheTeam = nameOfTheTeam;
            this.City = city;
            this.TeamTrainer = teamTrainer;
            this.MatchesCount = matchesCount;
        }


    }
}
