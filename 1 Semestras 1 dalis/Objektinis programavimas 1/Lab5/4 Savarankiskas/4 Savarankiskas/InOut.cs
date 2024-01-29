using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiskas
{
    class InOut
    {
        public static PlayersConteiner ReadPlayers(string fileName)
        {
            PlayersConteiner players = new PlayersConteiner();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

            foreach (string line in lines)
            {
                string[] Values = line.Split(';');

                string type = Values[0];
                string teamName = Values[1];
                string surname = Values[2];
                string name = Values[3];
                DateTime birthDate = DateTime.Parse(Values[4]);
                int matchesCount = int.Parse(Values[5]);
                int points = int.Parse(Values[6]);

                switch(type)
                {
                    case "BASKETBALL":
                        int retakenBallCount = int.Parse(Values[7]);
                        int passesCount = int.Parse(Values[8]);
                        Basketball basketball = new Basketball(teamName, name, surname, birthDate, matchesCount, points, retakenBallCount, passesCount);
                        players.Add(basketball);
                        break;
                    case "FOOTBALL":
                        int yellowCardCount = int.Parse(Values[7]);
                        Football football = new Football(teamName, name, surname, birthDate, matchesCount, points, yellowCardCount);
                        players.Add(football);
                        break;
                }
            }
            return players;
        }

        public static List<Team> ReadTeams(string fileName)
        {
            List<Team> teams = new List<Team>();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] Values = line.Split(';');
                string nameOfTheTeam = Values[0];
                string city = Values[1];
                string teamTrainer = Values[2];
                int matchesCount = int.Parse(Values[3]);

                Team team = new Team(nameOfTheTeam, city, teamTrainer, matchesCount);
                teams.Add(team);
            }
            return teams;
        }

        public static void PrintPlayers(PlayersConteiner players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players.Get(i);
                Console.WriteLine(player.ToString);
            }
        }
    }
}
