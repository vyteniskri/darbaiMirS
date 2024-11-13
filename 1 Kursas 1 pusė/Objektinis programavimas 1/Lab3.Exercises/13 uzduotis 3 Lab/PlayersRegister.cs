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
        private PlayersConteiner AllPlayers;

        /// <summary>
        /// Formats a list;
        /// </summary>
        public PlayersRegister()
        {
            AllPlayers = new PlayersConteiner();
        }

        /// <summary>
        /// Method that disperses information
        /// </summary>
        /// <param name="players">Array of players</param>
        public PlayersRegister(PlayersConteiner players)
        {
            AllPlayers = new PlayersConteiner();
            for (int i = 0; i < players.Count; i++)
            {
                AllPlayers.Add(players.Get(i));
            }
        }

        /// <summary>
        /// Void method that adds specific information to the list
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
            return AllPlayers.Get(index);
        }

        /// <summary>
        /// Void method that calls a second mathod
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
        /// Method that finds out if a player from another list has been in this list
        /// </summary>
        /// <param name="players">Player variable</param>
        public void Value(Player players)
        {
            for (int i = 0; i < AllPlayers.Count; i++)
            {
                if (players == AllPlayers.Get(i))
                {
                    players.Value++;
                }
            }
            
        }

        /// <summary>
        /// Finds youngest player
        /// </summary>
        /// <returns>Age of youngest player represented in date format</returns>
        public DateTime Youngest()
        {
            DateTime date = new DateTime(1000, 01, 01);
            for (int i = 0; i < AllPlayers.Count; i++)
            {
                if (AllPlayers.Get(i) > date)
                {
                    date = AllPlayers.Get(i).BirthDate;
                }
            }
            return date;
        }

        /// <summary>
        /// Finds youngest player from two lists of players
        /// </summary>
        /// <param name="players">PlayersRegister variable</param>
        /// <returns>Longest date</returns>
        public DateTime MinAge(PlayersRegister players)
        {
            if (Youngest() > players.Youngest())
            {
                return Youngest();
            }
            else
                return players.Youngest();
        }

        /// <summary>
        /// Method that formats a list of youngest players
        /// </summary>
        /// <param name="players">PlayersRegister variable</param>
        /// <returns>Formated list</returns>
        public PlayersRegister FilteredByYoungest(PlayersRegister players)
        {
            PlayersRegister YoungestPlayers = new PlayersRegister();
            for (int i = 0; i < AllPlayers.Count; i++)
            {
                if (AllPlayers.Get(i) == MinAge(players) && AllPlayers.Get(i).Equals(0))
                {
                    YoungestPlayers.Add(AllPlayers.Get(i));
                }
            }
            return YoungestPlayers;
        }

        /// <summary>
        /// Method that finds out if players played in sertain club
        /// </summary>
        /// <param name="club">Club that player represents</param>
        /// <returns>Formated list</returns>
        public PlayersRegister FilteredByClub(string club)
        {
            PlayersRegister played = new PlayersRegister();
            for (int i = 0; i < AllPlayers.Count; i++)
            {
                if (AllPlayers.Get(i) == club && AllPlayers.Get(i).Equals(0))
                {
                    played.Add(AllPlayers.Get(i));
                }
            }
            return played;
        }

        /// <summary>
        /// Method that finds players who participated in both camps
        /// </summary>
        /// <returns>Formated list</returns>
        public void BeenToBothCamps(PlayersConteiner players)
        {

            for (int i = 0; i < AllPlayers.Count; i++)
            {
                if (AllPlayers.Get(i).Value > 0)
                {
                    players.Add(AllPlayers.Get(i));
                }
            }
        }

        /// <summary>
        /// Method that finds players who are higher or equal to two meters
        /// </summary>
        /// <param name="x">Sertain integer</param>
        /// <returns>Formated list</returns>
        public PlayersRegister TwoMetersOrHigher(int x)
        {
            PlayersRegister moreThanTwoMeters = new PlayersRegister();
            for (int i = 0; i < AllPlayers.Count; i++)
            {
                if (AllPlayers.Get(i) >= x && AllPlayers.Get(i).Equals(0))
                {
                    moreThanTwoMeters.Add(AllPlayers.Get(i));
                }
            }
            return moreThanTwoMeters;
        }

    }
}
