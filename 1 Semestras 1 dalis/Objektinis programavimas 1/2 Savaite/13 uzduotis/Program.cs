using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _13_uzduotis
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> allPlayers = InOutUtils.ReadFile(@"Players.txt");
            string fileName1 = "Rezults.txt";
            InOutUtils.PrintPlayers(allPlayers, fileName1);

            //Finding yougest players
            List<Player> youngest = TaskUtils.Youngest(allPlayers); 
            Console.WriteLine("Jauniausi krepsininkai:");
            InOutUtils.YoungestList(youngest);
            Console.WriteLine("");

            //Finding players who play in Žalgiris
            List<Player> inTheTeam = TaskUtils.Zalgiris(allPlayers); 
            Console.WriteLine("Krepsininkai zaide Zalgiryje:");
            InOutUtils.FromZalgiris(inTheTeam);
            Console.WriteLine("");

            //Printing players who celebrates their birthdays of a given time frame
            List<Player> whoCelebrates = TaskUtils.CelebratesBirthDays(allPlayers);
            string fileName = "Gimtadieniai.csv";
            InOutUtils.CelebratesBirthDay(fileName, whoCelebrates);

        }
    }
}
