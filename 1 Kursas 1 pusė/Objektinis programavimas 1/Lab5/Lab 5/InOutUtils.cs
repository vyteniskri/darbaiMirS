using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    /// <summary>
    /// Class that prints or reads information
    /// </summary>
    public class InOutUtils
    {
        /// <summary>
        /// Creates a list to disperse the information
        /// </summary>
        /// <param name="fileName">Specific file name</param>
        /// <returns>Formated list</returns>
        public static MembersConteiner ReadPlayers(string fileName)
        {
            int x = 0;
            MembersConteiner members = new MembersConteiner();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            members.Year = int.Parse(lines[0]);
            members.StartYear = DateTime.Parse(lines[1]);
            members.EndYear = DateTime.Parse(lines[2]);
            foreach (string line in lines)
            {
                string[] Values = line.Split(';');
                if (x > 2)
                {
                    string type = Values[0];
                    string name = Values[1];
                    string surname = Values[2];
                    DateTime birthDate = DateTime.Parse(Values[3]);
                    switch(type)
                    {

                        case "Player":
                            int hight = int.Parse(Values[4]);
                            int number = int.Parse(Values[5]);
                            string club = Values[6];
                            //Finding out if player is invited or not
                            bool Invited = false;
                            if (Values[7] == "pakviestas")
                            {
                                Invited = true;
                            }
                            //Finding out if player is captain or not
                            bool captainOrNot = false;
                            if (Values[8] == "kapitonas")
                            {
                                captainOrNot = true;
                            }
                            Player player = new Player(name, surname, birthDate, hight, number, club, Invited, captainOrNot);
                            members.Add(player);
                            break;

                        case "Staff":
                            string duties = Values[4];
                            Staff staff = new Staff(name, surname, birthDate, duties);
                            members.Add(staff);
                            break;

                        default:
                            break;
                    }
                }
                x++;
            }
            return members;
        }

        /// <summary>
        /// A method that prints information to .txt file
        /// </summary>
        /// <param name="players">Register variable</param>
        /// <param name="fileName">Specific file name</param>
        public static void PrintToTxt(Register members, string fileName)
        {
            string[] lines = new string[members.Count() + 2];
            lines[0] = String.Format(new string('-', 132));

            for (int i = 0; i < members.Count(); i++)
            {
                lines[i + 1] = members.OneMember(i).ToString();
            }

            lines[members.Count() + 1] = String.Format(new string('-', 132));

            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }

        /// <summary>
        /// A method that prints information about players who played in a certain club to the screen
        /// </summary>
        /// <param name="players">MembersConteiner variable</param>
        public static void PrintClubPlayers(MembersConteiner players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                Member player = players.Get(i);
                Console.WriteLine("{0};{1};{2}", player.Name, player.Surname, (player as Player).Number);
            }
        }

        /// <summary>
        /// A method that print informarion about players who have been to all camps to .csv file
        /// </summary>
        /// <param name="members">MembersConteiner variable</param>
        /// <param name="fileName">specific file name</param>
        public static void PrintToCsvBeenToCamps(MembersConteiner members, string fileName)
        {
            string[] lines = new string[members.Count];
            for (int i = 0; i < members.Count; i++)
            {
                lines[i] = members.Get(i).ToString();
            }

            File.WriteAllLines(fileName, lines, Encoding.UTF8);
            if (members.Count == 0)
            {
                File.Delete(fileName);
            }
        }

        /// <summary>
        /// A method that print highest players to the screen 
        /// </summary>
        /// <param name="members">MembersConteiner variable</param>
        /// <param name="fileName">Specific file name</</param>
        public static void PrintToCsvHighestPlayers(MembersConteiner members, string fileName)
        {
            string[] lines = new string[members.Count];
            for (int i = 0; i < members.Count; i++)
            {
                Member member = members.Get(i);
                lines[i] = string.Format("{0};{1};{2}", member.Name, member.Surname, (member as Player).Hight);
            }

            File.WriteAllLines(fileName, lines, Encoding.UTF8);
            if (members.Count == 0)
            {
                File.Delete(fileName);
            }
        }

        /// <summary>
        /// A method that print information about staff members to .csv file
        /// </summary>
        /// <param name="members">MembersConteiner variable</param>
        /// <param name="fileName">Specific file name</param>
        /// <param name="text">A line of text</param>
        public static void PrintToCsvMassageStaffMembers(MembersConteiner members, string fileName, string text)
        {
            int Count = members.Count;
            if (members.Count == 0)
            {
                Count = Count + 1;
            }
            string[] lines = new string[Count + 1];
            lines[0] = text;
            for (int i = 0; i < members.Count; i++)
            {
                Member member = members.Get(i);
                lines[i + 1] = member.ToString();
            }

            if (members.Count == 0)
            {
                lines[1] = "Tokių personalo narių nėra.";
            }
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
            
        }
    }
}
