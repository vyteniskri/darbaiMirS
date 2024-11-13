using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_uzduotis
{
    /// <summary>
    /// Class that calculates given information and forms lists
    /// </summary>
    class TaskUtils
    {
        /// <summary>
        /// Creates a Player type method to disperse the information
        /// </summary>
        /// <param name="players">Single player information</param>
        /// <returns>Formated single player information</returns>
        public static Player Age(List<Player> players)
        {
            Player age = players[0];
            for (int i = 1; i < players.Count; i++)
            {
                if (DateTime.Compare(players[i].BirthDate, age.BirthDate) > 0)
                {
                    age = players[i];
                }
            }
            return age;
        }

        /// <summary>
        /// Creates a list to disperse the information
        /// </summary>
        /// <param name="players">Array of players</param>
        /// <returns>Formated list</returns>
        public static List<Player> Youngest(List<Player> players) 
        {
            Player age = TaskUtils.Age(players);
            List<Player> youngest = new List<Player>();
            for (int i = 0; i < players.Count; i++)
            {
                if (age.BirthDate == players[i].BirthDate) //Comparing ealiest DateTime information to player birth date
                {
                    youngest.Add(players[i]);
                }
            }
            return youngest;
        }

        /// <summary>
        /// Creates a list to disperse the information
        /// </summary>
        /// <param name="players">Array of players</param>
        /// <param name="team">string representing a team</param>
        /// <returns>Formated list</returns>
        public static List<Player> Zalgiris(List<Player> players, string team)
        {
            List<Player> InTheTeam = new List<Player>();
            foreach (Player player in players)
            {
                if (player.Club.Equals(team))
                {
                    InTheTeam.Add(player);
                }
            }
            return InTheTeam;
        }

        /// <summary>
        /// Creates a list to disperse the information
        /// </summary>
        /// <param name="players">Array of players</param>
        /// <returns>Formated list</returns>
        public static List<Player> CelebratesBirthDays(List<Player> players)
        {
            List<Player> Celebrates = new List<Player>();
            DateTime DateBegining = new DateTime(DateTime.Now.Year, 7, 20); //Intodusing new DateTime variable
            DateTime DateEnding = new DateTime(DateTime.Now.Year, 9, 3); //Intodusing new DateTime variable
            foreach (Player player in players)
            {
                if (player.BirthDate.DayOfYear >= DateBegining.DayOfYear && player.BirthDate.DayOfYear <= DateEnding.DayOfYear) //Converting DateTime information to values and then comparing them
                {
                    Celebrates.Add(player);
                }
            }
            return Celebrates;
        }

    }
}
