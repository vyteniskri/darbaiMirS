using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _13_uzduotis
{
    class InOutUtils
    {
        public static List<Player> ReadFile(string fileName)
        {
            List<Player> Players = new List<Player>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string name = Values[0];
                string surname = Values[1];
                DateTime birthDate = DateTime.Parse(Values[2]);
                int hightOfPlayer = int.Parse(Values[3]);
                int number = int.Parse(Values[4]);
                string club = Values[5];
                string inOut = Values[6];
                string captainOrNot = Values[7];

                Player Player = new Player(name, surname, birthDate, hightOfPlayer, number, club, inOut, captainOrNot);
                Players.Add(Player);
            }
            return Players;
        }

        public static void PrintPlayers(List<Player> Players, string fileName1)
        {
            int x = Players.Count;
            string[] lines = new string[Players.Count + 4];
            lines[0] = String.Format(new string('-', 121));
            lines[1] = String.Format("| {0, -8} | {1, -12} | {2, -6} | {3, 8} | {4, 8} | {5, -8} | {6, -8} | {7, -8} |", "Vardas", "Pavardė", "Gimimo data", "Žaidėjo ūgis", "Numeris", "Klubas", "Ar pakviestas", "Komandos kapitonas ar ne");
            lines[2] = String.Format(new string('-', 121));
            for (int i = 0; i < Players.Count; i++)
            {
                lines[i + 3] = String.Format("| {0, -8} | {1, -12} | {2, -11:yyyy-MM-dd} | {3, 12} | {4, 8} | {5, -8} | {6, -13} | {7, -24} |", Players[i].Name, Players[i].Surname, Players[i].BirthDate, Players[i].HightOfPlayer, Players[i].Number, Players[i].Club, Players[i].InOut, Players[i].CaptainOrNot);
            }
            File.WriteAllLines(fileName1, lines, Encoding.UTF8);

        }

        public static void YoungestList(List<Player> Players)
        {
            foreach (Player player in Players)
            {
                Console.WriteLine("{0} {1} {2} {3}", player.Name, player.Surname, player.CalculateAge(), player.Number);
            }
        }

        public static void FromZalgiris(List<Player> Players)
        {
            foreach (Player player in Players)
            {
                Console.WriteLine("{0} {1} {2}", player.Name, player.Surname, player.Number);
            }

        }

        public static void CelebratesBirthDay(string fileName, List<Player> Players)
        {
            string[] lines = new string[Players.Count];
            for (int i = 0; i < Players.Count; i++)
            {
                lines[i] = string.Format("{0} {1} {2:MM-dd}", Players[i].Name, Players[i].Surname, Players[i].BirthDate);
               
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

    }
}
