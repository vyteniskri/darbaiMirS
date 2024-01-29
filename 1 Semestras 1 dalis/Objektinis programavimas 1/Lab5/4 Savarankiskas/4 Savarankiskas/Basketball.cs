using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiskas
{
    class Basketball : Player
    {
        public int RetakenBallCount { get; set; }
        public int PassesCount { get; set; }

        public Basketball(string teamName, string name, string surname, DateTime birthDate, int matchesCount, int points, int retakenBallCount, int passesCount) : base(teamName, name, surname, birthDate, matchesCount, points)
        {
            this.RetakenBallCount = retakenBallCount;
            this.PassesCount = passesCount;
        }

        public override string ToString
        {
            get
            {
                string line = string.Format("Komandos pavadinimas: {0}, vardas: {1}, pavardė: {2}, gimimo data: {3:yyyy-MM-dd}, žaistų rungtynių skaičius: {4}, įmestų taškų skaičius: {5}, atkovotų kamolių skaičius: {6}, rezultatyvių perdavimų skaičius: {7}", TeamName, Name, Surname, BirthDate, MatchesCount, Points, RetakenBallCount, PassesCount);
                return line;
            }
        }

    }
}
