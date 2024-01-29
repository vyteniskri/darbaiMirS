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
        public static PlayersRegister ReadFile(string fileName)
        {
            PlayersRegister Players = new PlayersRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int year = int.Parse(Values[0]);
                DateTime startYear = DateTime.Parse(Values[1]);
                DateTime endYear = DateTime.Parse(Values[2]);
                string name = Values[3];
                string surname = Values[4];
                DateTime birthDate = DateTime.Parse(Values[5]);
                int hight = int.Parse(Values[6]);
                int number = int.Parse(Values[7]);
                string club = Values[8];
                //Finding out if player is invited or not
                bool Invited = false; 
                if (Values[9] == "pakviestas")
                {
                    Invited = true;
                }
                //Finding out if player is captain or not
                bool captainOrNot = false;
                if (Values[10] == "kapitonas")
                {
                    captainOrNot = true;
                }
                Player Player = new Player(year, startYear, endYear, name, surname, birthDate, hight, number, club, Invited, captainOrNot);
                Players.Add(Player);
            }
            return Players;
        }

        /// <summary>
        /// A method that prints information to the screen
        /// </summary>
        /// <param name="players">PlayersRegister variable</param>
        /// <param name="fileName">Specific file name</param>
        public static void PrintToTxt(PlayersRegister players, string fileName)
        {
            string[] lines = new string[players.Count() + 4];
            lines[0] = String.Format(new string('-', 188));
            lines[1] = String.Format("| {0, -8} | {1, -8} | {2, -8} | {3, -8} | {4, -15} | {5, -8} | {6, 8} | {7, 8} | {8, -12} | {9, -8} | {10, -8} |", "Metai", "Stovyklos pradžios data", "Stovyklos pabaigos data", "Vardas", "Pavardė", "Gimimo metai", "Ūgis", "Numeris", "Klubas", "Pakviestas į komandą", "Kapitonas arba ne");
            lines[2] = String.Format(new string('-', 188));

            for (int i = 0; i < players.Count(); i++)
            {
                lines[i + 3] = players.OnePlayer(i).ToString();
            }

            lines[players.Count() + 3] = String.Format(new string('-', 188));

            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }

        /// <summary>
        /// A method that prints information about players who played in sertain club to the screen
        /// </summary>
        /// <param name="players">PlayersRegister variable</param>
        public static void PrintPlayers(PlayersRegister players)
        {
            for (int i = 0; i < players.Count(); i++)
            {
                Console.WriteLine("{0};{1};{2}", players.OnePlayer(i).Name, players.OnePlayer(i).Surname, players.OnePlayer(i).Invited);
            }

        }

        /// <summary>
        /// A method that prints information about highest players to the screen
        /// </summary>
        /// <param name="players">PlayersRegister variable</param>
        public static void PrintHigestPlayers(PlayersRegister players)
        { 
            for (int i = 0; i < players.Count(); i++)
            {
                Console.WriteLine("{0};{1};{2}", players.OnePlayer(i).Name, players.OnePlayer(i).Surname, players.OnePlayer(i).CalculateAge());
            }
        }

        /// <summary>
        /// Method that prints information about players who are two meters or higher to .csv file
        /// </summary>
        /// <param name="players">PlayersRegister variable</param>
        /// <param name="fileName">Specific file name</param>
        public static void ToCsv(PlayersRegister players, string fileName)
        {
            string[] lines = new string[players.Count()];
            for (int i = 0; i < players.Count(); i++)
            {
                lines[i] = String.Format("{0};{1};{2}", players.OnePlayer(i).Name, players.OnePlayer(i).Surname, players.OnePlayer(i).Hight);
            }

            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }


    }
}
