using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiskas
{
    class Football : Player
    {
        public int YellowCardCount { get; set; }

        public Football(string teamName, string name, string surname, DateTime birthDate, int matchesCount, int points, int yellowCardCount) : base(teamName, name, surname, birthDate, matchesCount, points)
        {
            this.YellowCardCount = yellowCardCount;
        }

        public override string ToString
        {
            get
            {
                string line = string.Format("Komandos pavadinimas: {0}, vardas: {1}, pavardė: {2}, gimimo data: {3:yyyy-MM-dd}, žaistų rungtynių skaičius: {4}, įmuštų įvarčių skaičius: {5}, surinktų geltonų kortelių skaičius: {6}", TeamName, Name, Surname, BirthDate, MatchesCount, Points, YellowCardCount);
                return line;
            }
        }
    }
}
