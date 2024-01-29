using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _13_uzduotis_nr._2
{
    class InOutUtils
    {
        public static PlayersRegister ReadPlayers(string fileName)
        {
            PlayersRegister Players = new PlayersRegister();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int year = int.Parse(Values[0]);
                DateTime yearStart = DateTime.Parse(Values[1]);
                DateTime yearEnd = DateTime.Parse(Values[2]);
                string name = Values[3];
                string surname = Values[4];
                DateTime dateOfBirth = DateTime.Parse(Values[5]);
                int hight = int.Parse(Values[6]);
                int number = int.Parse(Values[7]);
                string club = Values[8];
                string inOrOut = Values[9];
                string captainOrNot = Values[10];

                Player player = new Player(year, yearStart, yearEnd, name, surname, dateOfBirth, hight, number, club, inOrOut, captainOrNot);
                Players.Add(player);
            }
            return Players;
        }

        public static List<Player> ReadPlayer(string fileName)
        {
            List<Player> Players = new List<Player>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int year = int.Parse(Values[0]);
                DateTime yearStart = DateTime.Parse(Values[1]);
                DateTime yearEnd = DateTime.Parse(Values[2]);
                string name = Values[3];
                string surname = Values[4];
                DateTime dateOfBirth = DateTime.Parse(Values[5]);
                int hight = int.Parse(Values[6]);
                int number = int.Parse(Values[7]);
                string club = Values[8];
                string inOrOut = Values[9];
                string captainOrNot = Values[10];

                Player player = new Player(year, yearStart, yearEnd, name, surname, dateOfBirth, hight, number, club, inOrOut, captainOrNot);
                Players.Add(player);
            }
            return Players;
        }

        //public static void PrintPlayers(PlayersRegister players)
        //{
        //    Console.WriteLine(new string('-', 100));
        //    Console.WriteLine("| {0, 8} | {1, -8} | {2, -8} | {3, -8} | {4, -8} | {5, -8} | {6, 8} | {7, 8} | {8, -8} | {9, -8} | {10, -8}", "Metai", "Stovyklos pradžios data", "Stovyklos pabaigos data", "Vardas", "Pavardė", "Gimimo metai", "Ūgis", "Numeris", "Klubas", "Pakviestas į komandą", "Kapitonas arba ne");
        //    for (int i = 0; i < players.Count(); i++)
        //    {
        //        Player player = players.OnePlayer(i);
        //        Console.WriteLine("| {0, 8} | {1, -8} | {2, -8} | {3, -8} | {4, -8} | {5, -8} | {6, 8} | {7, 8} | {8, -8} | {9, -8} | {10, -8}", player.Year , player.YearStart, player.YearEnd, player.Name, player.Surname, player.DateOfBirth, player.Hight, player.Number, player.Club, player.InOrOut, player.CaptainOrNot);
        //    }
        //    Console.WriteLine(new string('-', 100));
        //}

        public static void PrintZalgiris(List<Player> year1, List<Player> year2)
        {
            for (int i = 0; i < year1.Count(); i++)
            {
                
               Console.WriteLine("{0}, {1}, {2}", year1[i].Name, year1[i].Surname, year1[i].InOrOut);
                
            }

            for (int i = 0; i < year2.Count(); i++)
            {

                Console.WriteLine("{0}, {1}, {2}", year2[i].Name, year2[i].Surname, year2[i].InOrOut);

            }

        }

        // Higest players list
        public static void HighestPlayers(List<Player> year1, List<Player> year2)
        {
            for (int i = 0; i < year1.Count(); i++)
            {
                Console.WriteLine("{0} {1} {2}", year1[i].Name, year1[i].Surname, year1[i].Age);
            }

            for (int i = 0; i < year2.Count(); i++)
            {
                Console.WriteLine("{0} {1} {2}", year2[i].Name, year2[i].Surname, year2[i].Age);
            }
        }

        // List of players who are higher or equal to two meters
        public static void HigherThanTwo(List<Player> year1, List<Player> year2)
        {
            for (int i = 0; i < year1.Count(); i++)
            {
                Console.WriteLine("{0} {1} {2}", year1[i].Name, year1[i].Surname, year1[i].Hight);
            }

            for (int i = 0; i < year2.Count(); i++)
            {
                Console.WriteLine("{0} {1} {2}", year2[i].Name, year2[i].Surname, year2[i].Hight);
            }
        }

        public static void ToCsv(List<Player> year1, List<Player> year2, string fileName)
        {
            int x = 0;
            string[] Lines = new string[year1.Count() + year2.Count() + 1];
            Lines[0] = String.Format("{0} {1} {2}", "Vardas", "Pavardė", "Ūgis");
            for (int  i = 0; i < year1.Count(); i++)
            {
                Lines[i + 1] = String.Format("{0} {1} {2}", year1[i].Name, year1[i].Surname, year1[i].Hight);
                x++;
            }

            for (int i = 0; i < year2.Count(); i++)
            {
                Lines[i + x + 1] = String.Format("{0} {1} {2}", year2[i].Name, year2[i].Surname, year2[i].Hight);
            }

            File.WriteAllLines(fileName, Lines, Encoding.UTF8);
        }
    }
}
