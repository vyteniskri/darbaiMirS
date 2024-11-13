using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiskas
{
    class TaskUtils
    {
        public static PlayersConteiner FilteredPlayers(string city, TeamRegister teams, PlayerRegister players)
        {
            PlayersConteiner rezultPlayers = new PlayersConteiner();
            for (int i = 0; i < teams.Count(); i++)
            {
                if (teams.OneTeam(i).City == city)
                {
                    double average = players.PointsAverage(teams.OneTeam(i).NameOfTheTeam);
                    PlayersConteiner OneTeamPlayers = players.SelectedPlayers(teams.OneTeam(i).NameOfTheTeam, teams.OneTeam(i).MatchesCount, average);
                    rezultPlayers.Add(OneTeamPlayers);
                }

            }
            return rezultPlayers;

        }

    }
}
