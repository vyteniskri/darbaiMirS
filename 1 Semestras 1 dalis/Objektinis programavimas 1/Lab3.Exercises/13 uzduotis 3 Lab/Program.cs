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
        const string CFr2 = "Senbuviai.csv";
        /// <summary>
        /// Represents a .csv file where data will be put
        /// </summary>
        const string CFr3 = "Aukštaūgiai.csv";

        static void Main(string[] args)
        {
            File.Delete(CFr1);
            File.Delete(CFr3);
            PlayersConteiner FirstList = InOutUtils.ReadFile(CFd1);
            PlayersConteiner SecondList = InOutUtils.ReadFile(CFd2);
            InOutUtils.PrintToTxt(FirstList, CFr1);
            InOutUtils.PrintToTxt(SecondList, CFr1);

            PlayersRegister register1 = new PlayersRegister(FirstList);
            PlayersRegister register2 = new PlayersRegister(SecondList);

            register1.Number(register2);

            //Youngest players
            Console.WriteLine("Jauniausi krepšininkai:");
            InOutUtils.PrintYoungestPlayers(register1.FilteredByYoungest(register2));
            InOutUtils.PrintYoungestPlayers(register2.FilteredByYoungest(register1));

            if (register1.FilteredByYoungest(register2).Count() == 0 && register2.FilteredByYoungest(register2).Count() == 0)
            {
                Console.WriteLine("Tokių žaidėjų nėra.");
            }
            Console.WriteLine();

            //Players who played in Žalgiris
            Console.WriteLine("Krepšininkai žaidę Žalgiryje:");
            InOutUtils.PrintPlayers(register1.FilteredByClub("Žalgiris"));
            InOutUtils.PrintPlayers(register2.FilteredByClub("Žalgiris"));

            if (register1.FilteredByClub("Žalgiris").Count() == 0 && register2.FilteredByClub("Žalgiris").Count() == 0)
            {
                Console.WriteLine("Tokių žaidėjų nėra.");
            }
            Console.WriteLine();

            //Players who participated in both camps
            PlayersConteiner ListOfFiltered = new PlayersConteiner();
            register2.BeenToBothCamps(ListOfFiltered);
            ListOfFiltered.Sort();
            InOutUtils.ToSenbuviaiCSV(ListOfFiltered, CFr2);
            Console.WriteLine(1 / 2.0);
            if (ListOfFiltered.Count == 0)
            {
                File.Delete(CFr2);
            }
            Console.WriteLine();

            //Players who are two meters or higher
            InOutUtils.ToCsv(register1.TwoMetersOrHigher(200), CFr3);
            InOutUtils.ToCsv(register2.TwoMetersOrHigher(200), CFr3);

            if (register1.TwoMetersOrHigher(200).Count() == 0 && register2.TwoMetersOrHigher(200).Count() == 0)
            {
                File.Delete(CFr3);
            }
          

        }
    }
}
