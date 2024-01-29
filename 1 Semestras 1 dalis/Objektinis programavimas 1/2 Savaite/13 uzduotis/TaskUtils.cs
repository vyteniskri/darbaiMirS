using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_uzduotis
{
    class TaskUtils
    {
       public static List<Player> Youngest(List<Player> Players)
        {
            List<Player> youngest = new List<Player>();
            Player age = Players[0];
            for (int i = 1; i < Players.Count; i++)
            {
                if (DateTime.Compare(Players[i].BirthDate, age.BirthDate) > 0)
                {
                    age = Players[i];
                }
            }
            for (int i = 0; i < Players.Count; i++)
            {
                if (age.BirthDate == Players[i].BirthDate)
                {
                    youngest.Add(Players[i]);
                }
            }
            return youngest;
        }

        public static List<Player> Zalgiris(List<Player> Players)
        {
            List<Player> InTheTeam = new List<Player>();
            foreach (Player player in Players)
            {
                if (player.Club.Equals("Žalgiris"))
                {
                    InTheTeam.Add(player);
                }
            }
            return InTheTeam;
        }

        public static List<Player> CelebratesBirthDays(List<Player> Players)
        {
            List<Player> Celebrates = new List<Player>();
            DateTime DateBegining = new DateTime(2000, 7, 20);
            DateTime DateEnding = new DateTime(2000, 9, 3);
            foreach (Player player in Players)
            {
                if (player.BirthDate.DayOfYear >= DateBegining.DayOfYear && player.BirthDate.DayOfYear <= DateEnding.DayOfYear)
                {
                    Celebrates.Add(player);
                }
            }
            return Celebrates;
        }

    }
}
