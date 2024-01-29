using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
//Main function of this program is to do all kinds of calculations with different basketball players information

//Vytenis Kriščiūnas

namespace _13_uzduotis
{
    /// <summary>
    /// Main class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Represents a .txt file from which data will be read
        /// </summary>
        const string CFd = @"Players.txt"; 
        /// <summary>
        /// Represents a .txt file where data will be put
        /// </summary>
        const string CFr1 = "Rezults.txt"; 
        /// <summary>
        /// Represents a .csv file where data will be put
        /// </summary>
        const string CFr2 = "Gimtadieniai.csv"; 

        static void Main(string[] args)
        {
            List<Player> allPlayers = InOutUtils.ReadFile(CFd);
            InOutUtils.PrintToTxt(allPlayers, CFr1);

            //Finding and printing yougest players
            List<Player> youngest = TaskUtils.Youngest(allPlayers); 
            Console.WriteLine("Jauniausi krepšininkai:");
            InOutUtils.PrintYoungestPlayers(youngest);
            Console.WriteLine();

            //Finding and printing players who play in Žalgiris
            List<Player> inTheTeam = TaskUtils.Zalgiris(allPlayers, "Žalgiris"); 
            Console.WriteLine("Krepšininkai žaidę Žalgiryje:");
            InOutUtils.PrintClubPlayers(inTheTeam);
            Console.WriteLine();

            //Printing players who celebrates their birthdays of a given time frame
            List<Player> whoCelebrates = TaskUtils.CelebratesBirthDays(allPlayers);
            InOutUtils.PrintToCsv(CFr2, whoCelebrates);

        }
    }
}
