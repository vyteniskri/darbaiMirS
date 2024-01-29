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
        /// Formats a list;
        /// </summary>
        public PlayersRegister()
        {
            AllPlayers = new List<Player>();
        }

        /// <summary>
        /// Method that disperses information
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
        /// Void method which adds specific information to the list
        /// </summary>
        /// <param name="player">Single player information</param>
        public void Add(Player player)
        {
            AllPlayers.Add(player);
        }

        /// <summary>
        /// Method which counts how many
        /// </summary>
        /// <returns>Specific number</returns>
        public int Count()
        {
            return this.AllPlayers.Count;
        }

        /// <summary>
        /// Method that gives one players information
        /// </summary>
        /// <param name="index">An index</param>
        /// <returns>Player information</returns>
        public Player OnePlayer(int index)
        {
            return AllPlayers[index];
        }

        /// <summary>
        /// Void method 
        /// </summary>
        /// <param name="players">PlayersRegister variable</param>
        public void Number(PlayersRegister players)
        {
            for (int i = 0; i < players.Count(); i++)
            {
                Value(players.OnePlayer(i));
            }
        }

        /// <summary>
        /// Counts player value
        /// </summary>
        /// <param name="players">Player variable</param>
        public void Value(Player players)
        {
            for (int i = 0; i < AllPlayers.Count(); i++)
            {
                if (players == AllPlayers[i])
                {
                    players.Value++;
                }
            }
            
        }

        /// <summary>
        /// Method that finds out if players played in sertain club
        /// </summary>
        /// <param name="club">Club that player represents</param>
        /// <returns>Formated lis</returns>
        public PlayersRegister FilteredByClub(string club)
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
        /// Finds highest player
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
        /// Finds highest player from two lists of players
        /// </summary>
        /// <param name="players">PlayersRegister variable</param>
        /// <returns>Biggest number</returns>
        public int MaxHight(PlayersRegister players)
        {
            return Math.Max(Highest(), players.Highest());
        }

        /// <summary>
        /// Method that finds highest players
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
        /// Method that finds players who are higher or equal to two meters
        /// </summary>
        /// <param name="x">Sertain integer</param>
        /// <returns>Formated list</returns>
        public PlayersRegister TwoMetersOrHigher(int x)
        {
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
