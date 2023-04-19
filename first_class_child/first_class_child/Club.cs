using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_class_child
{
    internal class Club
    {
        public string name { get; set; }
        public List<Team> teams { get; set; }

        public Club() { teams = new List<Team>(); }

        public Club(string name)
        {
            this.name = name;
            teams = new List<Team>();
        }

        public override string ToString()
        {
            string tmp = $"{name} squads: ";
            foreach (Team p in teams)
                tmp += $"\n{p.ToString}";
            return tmp;
        }

        public void Details() { Console.WriteLine(this); }

        public void AddTeam(Team t)
        {
            teams.Add(t);
        }
        public void RemoveTeam(Team t)
        {
            teams.Remove(t);
        }
        public void SearchTeam(Team t)
        {
            if (teams.Contains(t))
                Console.WriteLine("Team exist");
            else
                Console.WriteLine("Team doesnt exist");
        }
        public void ResetClub()
        {
            teams.Clear();
        }
    }
}
