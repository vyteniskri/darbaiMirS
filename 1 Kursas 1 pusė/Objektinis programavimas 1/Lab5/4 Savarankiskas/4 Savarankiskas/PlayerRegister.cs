using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiskas
{
    class PlayerRegister
    {
        private PlayersConteiner AllPlayers;

        public PlayerRegister()
        {
            this.AllPlayers = new PlayersConteiner();
        }

        public PlayerRegister(PlayersConteiner Players)
        {
            AllPlayers = new PlayersConteiner();
            for (int i = 0; i < Players.Count; i++)
            {
                this.AllPlayers.Add(Players.Get(i));
            }
        }

        public void Add(Player player)
        {
            AllPlayers.Add(player);
        }

        public int PlayersCount()
        {
            return AllPlayers.Count;
        }

        public Player OnePlayer(int ind)
        {
            return AllPlayers.Get(ind);
        }

        public PlayersConteiner SelectedPlayers(string team, int matchesCount, double average)
        {
            PlayersConteiner players = new PlayersConteiner();
            for (int i = 0; i < AllPlayers.Count; i++)
            {
                if (AllPlayers.Get(i).TeamName == team && AllPlayers.Get(i).MatchesCount == matchesCount && AllPlayers.Get(i).Points >= average)
                {      
                    players.Add(AllPlayers.Get(i));
                }
            }
            return players;
        }

        public double PointsAverage(string teamName)
        {
            double sum = 0;
            int x = 0;
            for (int i = 0; i < AllPlayers.Count; i++)
            {
                if (teamName == AllPlayers.Get(i).TeamName)
                {
                    sum = sum + AllPlayers.Get(i).Points;
                    x++;
                }
            }

            return sum / x;
        }
    }
}
