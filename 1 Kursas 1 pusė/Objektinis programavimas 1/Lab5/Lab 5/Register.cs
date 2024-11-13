using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    /// <summary>
    /// Class that calculates given information to the register
    /// </summary>
    public class Register
    {
        /// <summary>
        /// Array of members
        /// </summary>
        private MembersConteiner AllMembers;

        /// <summary>
        /// Formats a list
        /// </summary>
        public Register()
        {
            AllMembers = new MembersConteiner();
        }

        /// <summary>
        /// Method that disperses information
        /// </summary>
        /// <param name="members">Array of members</param>
        public Register(MembersConteiner members)
        {
            AllMembers = new MembersConteiner();
            for (int i = 0; i < members.Count; i++)
            {
                AllMembers.Add(members.Get(i));
            }
        }

        /// <summary>
        /// Void method that adds specific information to the list
        /// </summary>
        /// <param name="member">Member's information</param>
        public void Add(Member member)
        {
            AllMembers.Add(member);
        }

        /// <summary>
        /// Method which counts how many
        /// </summary>
        /// <returns>Specific number</returns>
        public int Count()
        {
            return AllMembers.Count;
        }

        /// <summary>
        /// Method that gives information about one member
        /// </summary>
        /// <param name="index">An index</param>
        /// <returns>Player's information</returns>
        public Member OneMember(int index)
        {
            return AllMembers.Get(index);
        }

        /// <summary>
        /// Method that finds youngest staff member
        /// </summary>
        /// <returns>Youngest staff member</returns>
        public Member YoungestStaffMember()
        {
            DateTime date = new DateTime(1000, 01, 01);
            Member youngest = null;
            for (int i = 0; i < AllMembers.Count; i++)
            {
                if (AllMembers.Get(i) is Staff && AllMembers.Get(i) > date)
                {
                    date = AllMembers.Get(i).BirthDate;
                    youngest = AllMembers.Get(i);
                }
            }
            return youngest;

        }

        /// <summary>
        /// Method that finds players from a certain club
        /// </summary>
        /// <param name="clubName">A clubs title</param>
        /// <returns>Formated list of players</returns>
        public MembersConteiner PlayedInClub(string clubName)
        {
            MembersConteiner playersFromClub = new MembersConteiner();
            for (int i = 0; i < AllMembers.Count; i++)
            {
                if (AllMembers.Get(i) is Player && (AllMembers.Get(i) as Player) == clubName)
                {
                    playersFromClub.Add(AllMembers.Get(i));
                }
            }
            return playersFromClub;
        }

        /// <summary>
        /// Method that finds out if a member is from this register
        /// </summary>
        /// <param name="member">Team's member</param>
        /// <returns>True or false</returns>
        public bool Contains(Member member)
        {
            for (int i = 0; i < AllMembers.Count; i++)
            {
                if (AllMembers.Get(i).Name == member.Name && AllMembers.Get(i).Surname == member.Surname)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method that finds players who are two meters or higher
        /// </summary>
        /// <param name="hight">Given hight value</param>
        /// <returns>Formated list of players</returns>
        public MembersConteiner TwoMetersOrHigher(int hight)
        {
            MembersConteiner TwoOrHigher = new MembersConteiner();
            for (int i = 0; i < AllMembers.Count; i++)
            {
                Member member = AllMembers.Get(i);
                if (member is Player && (member as Player).Hight >= hight)
                {
                    TwoOrHigher.Add(member);
                }
            }
            return TwoOrHigher;
        }

        /// <summary>
        /// Method that finds staff members who are masseurs
        /// </summary>
        /// <param name="staffType">Given staff type</param>
        /// <returns>Formated list of masseurs</returns>
        public MembersConteiner MassageStaff(string staffType)
        {
            MembersConteiner selectedStaff = new MembersConteiner();
            for (int i = 0; i < AllMembers.Count; i++)
            {
                Member member = AllMembers.Get(i);
                if (member is Staff && (member as Staff).Duties == staffType)
                {
                    selectedStaff.Add(member);
                }
            }
            return selectedStaff;
        }
    }

}
