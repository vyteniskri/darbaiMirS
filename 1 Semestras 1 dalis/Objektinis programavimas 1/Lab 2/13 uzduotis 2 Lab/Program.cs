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
        const string CFd1 = @"FirstYearPlayers.txt";
        /// <summary>
        /// Represents a .txt file from which data will be read
        /// </summary>
        const string CFd2 = @"SecondYearPlayers.txt";
        /// <summary>
        /// Represents a .txt file where data will be put
        /// </summary>
        const string CFr1 = "Rezults.txt";
        /// <summary>
        /// Represents a .csv file where data will be put
        /// </summary>
        const string CFr2 = "Aukštaūgiai.csv";

        static void Main(string[] args)
        {
            File.Delete(CFr2);
            File.Delete(CFr1);
            PlayersRegister register1 = InOutUtils.ReadFile(CFd1);
            PlayersRegister register2 = InOutUtils.ReadFile(CFd2);
            InOutUtils.PrintToTxt(register1, CFr1);
            InOutUtils.PrintToTxt(register2, CFr1);

            //Players who played in Žalgiris
            Console.WriteLine("Krepšininkai žaidę Žalgiryje:");
            register1.Number(register2);
            InOutUtils.PrintPlayers(register1.Zalgiris("Žalgiris"));
            InOutUtils.PrintPlayers(register2.Zalgiris("Žalgiris"));
            if (register1.Zalgiris("Žalgiris").Count() == 0 && register2.Zalgiris("Žalgiris").Count() == 0)
            {
                Console.WriteLine("Tokių žaidėjų nėra.");
            }
            Console.WriteLine();

            //Highest players
            Console.WriteLine("Aukščiausi krepšininkai:");
            register1.Highest();
            register2.Highest();
            register1.MaxHight(register2);
            InOutUtils.PrintHigestPlayers(register1.FilteredByHighest(register2));
            InOutUtils.PrintHigestPlayers(register2.FilteredByHighest(register2));
            if (register1.FilteredByHighest(register2).Count() == 0 && register2.FilteredByHighest(register2).Count() == 0)
            {
                Console.WriteLine("Tokių žaidėjų nėra.");
            }
            Console.WriteLine();

            //Players who are two meters or higher
            InOutUtils.ToCsv(register1.TwoMetersOrHigher(), CFr2);
            InOutUtils.ToCsv(register2.TwoMetersOrHigher(), CFr2);

            if (register1.TwoMetersOrHigher().Count() == 0 && register2.TwoMetersOrHigher().Count() == 0)
            {
                File.Delete(CFr2);
            }
          

        }
    }
}
