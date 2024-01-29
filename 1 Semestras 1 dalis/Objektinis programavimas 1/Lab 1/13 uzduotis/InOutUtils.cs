using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _13_uzduotis
{
    /// <summary>
    /// Class that prints or reads information
    /// </summary>
    class InOutUtils
    {
        /// <summary>
        /// Creates a list to disperse the information
        /// </summary>
        /// <param name="fileName">Specific file name</param>
        /// <returns>Formated list</returns>
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
                int hight = int.Parse(Values[3]);
                int number = int.Parse(Values[4]);
                string club = Values[5];
                //Finding out if player is invited or not
                bool Invited = false; 
                if (Values[6] == "pakviestas")
                {
                    Invited = true;
                }
                //Finding out if player is captain or not
                bool captainOrNot = false;
                if (Values[7] == "kapitonas")
                {
                    captainOrNot = true;
                }
                Player Player = new Player(name, surname, birthDate, hight, number, club, Invited, captainOrNot);
                Players.Add(Player);
            }
            return Players;
        }

        /// <summary>
        /// Creates a void function where information is printed
        /// </summary>
        /// <param name="players">Array of players</param>
        /// <param name="fileName1">Specific file name</param>
        public static void PrintToTxt(List<Player> players, string fileName1)
        {
            string[] lines = new string[players.Count + 4];
            lines[0] = String.Format(new string('-', 121));
            lines[1] = String.Format("| {0, -8} | {1, -12} | {2, -6} | {3, 8} | {4, 8} | {5, -8} | {6, -8} | {7, -8} |", "Vardas", "Pavardė", "Gimimo data", "Žaidėjo ūgis", "Numeris", "Klubas", "Ar pakviestas", "Komandos kapitonas ar ne");
            lines[2] = String.Format(new string('-', 121));
            for (int i = 0; i < players.Count; i++)
            {
                lines[i + 3] = String.Format("| {0, -8} | {1, -12} | {2, -11:yyyy-MM-dd} | {3, 12} | {4, 8} | {5, -8} | {6, -13} | {7, -24} |", players[i].Name, players[i].Surname, players[i].BirthDate, players[i].Hight, players[i].Number, players[i].Club, players[i].Invited, players[i].CaptainOrNot);
            }
            lines[players.Count + 3] = String.Format(new string('-', 121));
            File.WriteAllLines(fileName1, lines, Encoding.UTF8);

        }

        /// <summary>
        /// Creates a void function where information is printed
        /// </summary>
        /// <param name="players">Array of players</param>
        public static void PrintYoungestPlayers(List<Player> players)
        {
            int x = 0;
            foreach (Player player in players)
            {
                Console.WriteLine("{0};{1};{2};{3}", player.Name, player.Surname, player.CalculateAge(), player.Number);
                x++;
            }
            if (x == 0)
            {
                Console.WriteLine("Tokių žaidėjų nėra.");
            }
        }

        /// <summary>
        /// Creates a void function where information is printed
        /// </summary>
        /// <param name="players">Array of players</param>
        public static void PrintClubPlayers(List<Player> players)
        {
            int x = 0;
            foreach (Player player in players)
            {
                Console.WriteLine("{0};{1};{2}", player.Name, player.Surname, player.Number);
                x++;
            }
            if (x == 0)
            {
                Console.WriteLine("Tokių žaidėjų nėra.");
            }

        }

        /// <summary>
        /// Creates a void function where information is printed
        /// </summary>
        /// <param name="fileName">Specific file name</param>
        /// <param name="players">Array of players</param>
        public static void PrintToCsv(string fileName, List<Player> players)
        {
            int x = 0;
            string[] lines = new string[players.Count];
            for (int i = 0; i < players.Count; i++)
            {
                lines[i] = string.Format("{0};{1};{2:MM-dd}", players[i].Name, players[i].Surname, players[i].BirthDate);
                x++;
            }
            if (x == 0)
            {
                string[] none = new string[0];
                none[0] = "Tokių žaidėjų nėra.";
                File.WriteAllLines(fileName, none, Encoding.UTF8);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
           
        }

    }
}
