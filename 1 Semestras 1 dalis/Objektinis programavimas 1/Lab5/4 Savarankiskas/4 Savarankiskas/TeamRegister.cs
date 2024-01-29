using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Savarankiskas
{
    class TeamRegister
    {
        private List<Team> AllTeams;

        public TeamRegister()
        {
            this.AllTeams = new List<Team>();
        }

        public TeamRegister(List<Team> Teams)
        {
            AllTeams = new List<Team>();
            for (int i = 0; i < Teams.Count; i++)
            {
                this.AllTeams.Add(Teams[i]);
            }
        }

        public void Add(Team team)
        {
            AllTeams.Add(team);
        }

        public int Count()
        {
            return AllTeams.Count;
        }

        public Team OneTeam(int ind)
        {
            return AllTeams[ind];
        }

    }
}
