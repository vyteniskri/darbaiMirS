using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_uzduotis
{
    /// <summary>
    /// Conteiner of basketball players
    /// </summary>
    class PlayersConteiner
    {
        /// <summary>
        /// Array of players
        /// </summary>
        private Player[] players;
        /// <summary>
        /// Total count of players
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Total capacity of players
        /// </summary>
        private int Capacity;

        /// <summary>
        /// PlayersConteiner constructor
        /// </summary>
        /// <param name="capacity">Capacity of players</param>
        public PlayersConteiner(int capacity = 5)
        {
            this.Capacity = capacity;
            this.players = new Player[capacity];
        }

        /// <summary>
        /// Method that makes sure of the capacity in the list of players
        /// </summary>
        /// <param name="minimumCapacity">Minimum capacity of players</param>
        public void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Player[] temp = new Player[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.players[i];
                }
                this.Capacity = minimumCapacity;
                this.players = temp;
            }
        }

        /// <summary>
        /// Method that adds information to the list
        /// </summary>
        /// <param name="player">Player variable</param>
        public void Add(Player player)
        {
            if (Count == Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            this.players[Count++] = player;
        }

        /// <summary>
        /// Method that gives one players information
        /// </summary>
        /// <param name="index">An index</param>
        /// <returns>Players information</returns>
        public Player Get(int index)
        {
            return this.players[index];
        }

        /// <summary>
        /// Method that finds out if a list contains something 
        /// </summary>
        /// <param name="player">Player variable</param>
        /// <returns></returns>
        public bool Contains(Player player)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.players[i].Equals(player))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method that puts information in an indicated place
        /// </summary>
        /// <param name="player">Player variable</param>
        /// <param name="index">An index</param>
        public void Put(Player player, int index)
        {
            players[index] = player;
        }

        /// <summary>
        /// Method that inserts infrormation in an indicated place
        /// </summary>
        /// <param name="player">Player variable</param>
        /// <param name="index">An index</param>
        public void Insert(Player player, int index)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }

            if (index == this.Count)
            {
                this.Count++;
            }

            int j = index;
            for (int i = index + 1; i < this.Count; i++)
            {
                players[i] = players[j];
                j++;
            }
            players[index] = player;
        }

        /// <summary>
        /// Method that removes information from the list 
        /// </summary>
        /// <param name="player">Player variable</param>
        public void Remove(Player player)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }

            for (int i = 0; i < this.Count; i++)
            {
                if(players[i] == player)
                {
                    for (int j = i; j < this.Count; j++)
                    {
                        players[j] = players[j + 1];
                    }
                    Count--;
                    i--;
                }
            }
        }

        /// <summary>
        /// Method that removes information from an indicated place in the list
        /// </summary>
        /// <param name="index">An index</param>
        public void RemoveAt(int index)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (i == index)
                {
                    for (int j = i; j < this.Count; j++)
                    {
                        players[j] = players[j + 1];
                    }
                    Count--;
                }
            }
        }

        /// <summary>
        /// Method that sorts information in the list of players
        /// </summary>
        public void Sort()
        {
            bool flag = true;

            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Player a = this.players[i];
                    Player b = this.players[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.players[i] = b;
                        this.players[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

    }
}
