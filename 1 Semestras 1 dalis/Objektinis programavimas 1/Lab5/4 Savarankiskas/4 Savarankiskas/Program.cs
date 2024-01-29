using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiskas
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd1 = @"Players.txt";
            const string CFd2 = @"Teams.txt";

            PlayersConteiner allPlayers = InOut.ReadPlayers(CFd1);
            List<Team> allTeams = InOut.ReadTeams(CFd2);

            PlayerRegister playerRegister = new PlayerRegister(allPlayers);

            TeamRegister teamRegister = new TeamRegister(allTeams);

            string city = Console.ReadLine();
            PlayersConteiner selectedPlayers = TaskUtils.FilteredPlayers(city, teamRegister, playerRegister);

            InOut.PrintPlayers(selectedPlayers);
        }
    }
}
