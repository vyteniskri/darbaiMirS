using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiskas
{
    class PlayersConteiner
    {
        public int Count { get; private set; }
        private Player[] players;
        private int Capacity;

        public PlayersConteiner(int capacity = 5)
        {
            this.Capacity = capacity;
            this.players = new Player[capacity];
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Player[] temp = new Player[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = players[i];

                }
                this.Capacity = minimumCapacity;
                players = temp;
            }
        }

        public void Add(Player player)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            this.players[this.Count++] = player;
        }

        public void Add(PlayersConteiner allPlayers)
        {
            for (int i = 0; i < allPlayers.Count; i++)
            {
                if (this.Count == Capacity)
                {
                    EnsureCapacity(Capacity * 2);
                }
                players[this.Count++] = allPlayers.Get(i);
            }
        }

        public Player Get(int index)
        {
            return players[index];
        }

        public bool Contains(Player player)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (players[i].Equals(player))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
