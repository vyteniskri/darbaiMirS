using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    /// <summary>
    /// A class that does calculations and other tasks
    /// </summary>
    public class TaskUtils
    {
        /// <summary>
        /// Method that finds team's members who had been to all camps
        /// </summary>
        /// <param name="members1">First year's registered members</param>
        /// <param name="members2">Second year's registered members</param>
        /// <param name="members3">Third year's registered members</param>
        /// <returns>Formated list of members</returns>
        public static MembersConteiner BeenInAllCamps(Register members1, Register members2, Register members3)
        {
            MembersConteiner filteredMembers = new MembersConteiner();
            for (int i = 0; i < members1.Count(); i++)
            {
                Member member = members1.OneMember(i);
                if (members2.Contains(member) == true && members3.Contains(member) == true)
                {
                    filteredMembers.Add(member);
                }
            }
            return filteredMembers;
        }

        /// <summary>
        /// Method that creates a list of players from all the given conteiners of players who are two meters or higher
        /// </summary>
        /// <param name="members1">First conteiner of players who are two meters or higher</param>
        /// <param name="members2">Second conteiner of players who are two meters or higher</param>
        /// <param name="members3">Third conteiner of players who are two meters or higher</param>
        /// <returns>Formated list of players</returns>
        public static MembersConteiner FilteredByHight(MembersConteiner members1, MembersConteiner members2, MembersConteiner members3)
        {
            MembersConteiner filteredPlayers = new MembersConteiner();
            Contains(filteredPlayers, members1);
            Contains(filteredPlayers, members2);
            Contains(filteredPlayers, members3);

            return filteredPlayers;
        }

        /// <summary>
        /// Method that finds out if the list of players contains certain players
        /// </summary>
        /// <param name="filteredPlayers">A new list of players</param>
        /// <param name="members">An older list of players</param>
        private static void Contains(MembersConteiner filteredPlayers, MembersConteiner members)
        {
            for (int i = 0; i < members.Count; i++)
            {
                Member member = members.Get(i);
                if (!filteredPlayers.Contains(member))
                {
                    filteredPlayers.Add(member);
                }
            }
        }
    }
}
