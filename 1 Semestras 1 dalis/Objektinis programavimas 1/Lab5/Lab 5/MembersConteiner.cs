using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    /// <summary>
    /// Connteiner of basketball team members
    /// </summary>
    public class MembersConteiner
    {
        /// <summary>
        /// Array of members
        /// </summary>
        public Member[] members;
        /// <summary>
        /// Total count of members
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Total capacity of members
        /// </summary>
        public int Capacity;

        /// <summary>
        /// Year of the camp
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Camp's start date
        /// </summary>
        public DateTime StartYear { get; set; }
        /// <summary>
        /// Camp's end date
        /// </summary>
        public DateTime EndYear { get; set; }

        /// <summary>
        /// MembersConteiner constructor
        /// </summary>
        /// <param name="capacity">Capacity of members</param>
        public MembersConteiner(int capacity = 5)
        {
            this.Capacity = capacity;
            this.members = new Member[capacity];
        }

        /// <summary>
        /// Method that makes sure of the capacity in the list of members
        /// </summary>
        /// <param name="minimumCapacity">Minimum capacity of members</param>
        public void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Member[] temp = new Member[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.members[i];
                }
                this.Capacity = minimumCapacity;
                this.members = temp;
            }
        }

        /// <summary>
        /// Method that adds information to the list
        /// </summary>
        /// <param name="member">Member variable</param>
        public void Add(Member member)
        {
            if (Count == Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            this.members[Count++] = member;
        }

        /// <summary>
        /// Method that gives a member's information
        /// </summary>
        /// <param name="index">An index</param>
        /// <returns>Members information</returns>
        public Member Get(int index)
        {
            return this.members[index];
        }

        /// <summary>
        /// Method that finds out if a list contains something about the member
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool Contains(Member member)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.members[i].Equals(member))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method that sorts information in the list of members
        /// </summary>
        public void Sort()
        {
            bool flag = true;

            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Member a = this.members[i];
                    Member b = this.members[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.members[i] = b;
                        this.members[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

    }
}
