using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_uzduotis
{
    /// <summary>
    /// Class that calculates given information
    /// </summary>
    class PlayersRegister
    {
        /// <summary>
        /// Array of players
        /// </summary>
        private List<Player> AllPlayers;

        /// <summary>
        /// Creates method to format list;
        /// </summary>
        public PlayersRegister()
        {
            AllPlayers = new List<Player>();
        }

        /// <summary>
        /// Creates method to disperse given information
        /// </summary>
        /// <param name="players">Array of players</param>
        public PlayersRegister(List<Player> players)
        {
            AllPlayers = new List<Player>();
            foreach (Player player in players)
            {
                this.AllPlayers.Add(player);
            }
        }

        /// <summary>
        /// Creates void method which adds specific information to the list
        /// </summary>
        /// <param name="player">Single player information</param>
        public void Add(Player player)
        {
            AllPlayers.Add(player);
        }

        /// <summary>
        /// Creates int method which counts how many
        /// </summary>
        /// <returns>Specific number</returns>
        public int Count()
        {
            return this.AllPlayers.Count;
        }

        /// <summary>
        /// Creates method of Specific information by index
        /// </summary>
        /// <param name="index">An index</param>
        /// <returns>Player information</returns>
        public Player OnePlayer(int index)
        {
            return AllPlayers[index];
        }

        /// <summary>
        /// Creates void method 
        /// </summary>
        /// <param name="players">PlayersRegister variable</param>
        /// <returns>Certain Value</returns>
        public void Number(PlayersRegister players)
        {
            for (int i = 0; i < players.Count(); i++)
            {
                for (int j = 0; j < AllPlayers.Count(); j++)
                {
                    if (players.OnePlayer(i) == AllPlayers[j])
                    {
                        players.OnePlayer(i).Value++;
                    }
                }
            }
        }

        /// <summary>
        /// Creates a method to disperse the information
        /// </summary>
        /// <param name="club">Club that player represents</param>
        /// <returns>Formated lis</returns>
        public PlayersRegister Zalgiris(string club)
        {
            PlayersRegister played = new PlayersRegister();
            for (int i = 0; i < AllPlayers.Count(); i++)
            {
                if (AllPlayers[i] == club && AllPlayers[i].Equals(0))
                {
                    played.Add(AllPlayers[i]);
                }
            }
            return played;
        }

        /// <summary>
        /// Creates int method
        /// </summary>
        /// <returns>Certain number</returns>
        public int Highest()
        {
            int x = 0;
            for (int i = 0; i < AllPlayers.Count(); i++)
            {
                if (AllPlayers[i] > x)
                {
                    x = AllPlayers[i].Hight;
                }
            }
            return x;
        }

        /// <summary>
        /// Creates int method
        /// </summary>
        /// <param name="players">PlayersRegister variable</param>
        /// <returns>Biggest number</returns>
        public int MaxHight(PlayersRegister players)
        {
            return Math.Max(Highest(), players.Highest());
        }

        /// <summary>
        /// Creates a method to disperse the information
        /// </summary>
        /// <param name="players">PlayersRegister variable</param>
        /// <returns>Formated list</returns>
        public PlayersRegister FilteredByHighest(PlayersRegister players)
        {
            PlayersRegister HighestPlayers = new PlayersRegister();
            for (int i = 0; i < AllPlayers.Count(); i++)
            {
                if (AllPlayers[i] == MaxHight(players) && AllPlayers[i].Equals(0))
                {
                    HighestPlayers.Add(AllPlayers[i]);
                }
            }
            return HighestPlayers;
        }

        /// <summary>
        /// Creates a method to disperse the information
        /// </summary>
        /// <returns>Formated list</returns>
        public PlayersRegister TwoMetersOrHigher()
        {
            int x = 200;
            PlayersRegister moreThanTwoMeters = new PlayersRegister();
            for (int i = 0; i < AllPlayers.Count(); i++)
            {
                if (AllPlayers[i] >= x && AllPlayers[i].Equals(0))
                {
                    moreThanTwoMeters.Add(AllPlayers[i]);
                }
            }
            return moreThanTwoMeters;
        }

    }
}
