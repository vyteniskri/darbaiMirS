using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_uzduotis_nr._2
{
    class PlayersRegister
    {
        private List<Player> AllPlayers;

        public PlayersRegister()
        {
            AllPlayers = new List<Player>();
        }

        public PlayersRegister(List<Player> players)
        {
            AllPlayers = new List<Player>();
            foreach (Player player in players)
            {
                this.AllPlayers.Add(player);
            }
        }

        public void Add(Player player)
        {
            AllPlayers.Add(player);
        }

        public int Count()
        {
            return this.AllPlayers.Count;
        }

        public Player OnePlayer(int index)
        {
            return AllPlayers[index];
        }

        public List<int> Number(List<Player> players)
        {
            List<int> x = new List<int>();
            int[] k = new int[AllPlayers.Count()];
            for (int i = 0; i < AllPlayers.Count(); i++)
            {
                for (int j = 0; j < players.Count; j++)
                {
                    if (AllPlayers[i].Name == players[j].Name && AllPlayers[i].Surname == players[j].Surname)
                    {
                        k[i]++;
                    }
                }
                x.Add(k[i]);

            }
            return x;
        }
        public List<Player> PlayedInZalgiris(List<Player> players)
        {
            List<int> x = Number(players);
            List<Player> played1 = new List<Player>();
            for (int i = 0; i < AllPlayers.Count(); i++)
            {
                if (x[i] == 0 && AllPlayers[i].Club == "Žalgiris" )
                {
                    played1.Add(AllPlayers[i]);
                }
            }
            return played1; 
   
        }
        public List<Player> PlayedInZalgiri(List<Player> players)
        {
            List<Player> played2 = new List<Player>();
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Club == "Žalgiris")
                {
                    played2.Add(players[i]);
                }
            }
            return played2;
        }

        public int Highest1()
        {
            int x = 0;
            for (int i = 0; i < AllPlayers.Count(); i++)
            {
                if (AllPlayers[i].Hight > x)
                {
                    x = AllPlayers[i].Hight;
                }
            }
            return x;
        }

        public int Highest2(List<Player> players)
        {
            int x = 0;
            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].Hight > x)
                {
                    x = players[i].Hight;
                }
            }
            return x;
        }

        public int Compare(List<Player> players)
        {
            return Math.Max(Highest1(), Highest2(players));
        }

        public List<Player> FilteredByHighest1(List<Player> players)
        {
            List<Player> HighestPlayers = new List<Player>();
            for (int i = 0; i < AllPlayers.Count(); i++)
            {
                if (AllPlayers[i].Hight == Compare(players) && Number(players)[i] == 0)
                {
                    HighestPlayers.Add(AllPlayers[i]);
                }
            }
            return HighestPlayers;
        }

        public List<Player> FilteredByHighest2(List<Player> players)
        {
            List<Player> HighestPlayers = new List<Player>();
            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].Hight == Compare(players))
                {
                    HighestPlayers.Add(players[i]);
                }
            }
            return HighestPlayers;
        }

        public List<Player> TwoMetersOrHigher1(List<Player> players)
        {
            List<Player> moreThanTwoMeters = new List<Player>();
            for (int i = 0; i < AllPlayers.Count(); i++)
            {
                if (AllPlayers[i].Hight >= 200 && Number(players)[i] == 0)
                {
                    moreThanTwoMeters.Add(AllPlayers[i]);
                }
            }
            return moreThanTwoMeters;
        }

        public List<Player> TwoMetersOrHigher2(List<Player> players)
        {
            List<Player> moreThanTwoMeters = new List<Player>();
            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].Hight >= 200)
                {
                    moreThanTwoMeters.Add(players[i]);
                }
            }
            return moreThanTwoMeters;
        }
    }
}
