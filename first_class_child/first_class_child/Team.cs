using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_class_child
{
    internal class Team
    {

        public string name { get; set; }
        public int league { get; set; }
        public List<Player> squad { get; set; }
        public Dictionary<int, Stats> stats { get; set; }

        public Team() {squad = new List<Player>();stats = new Dictionary<int, Stats>(); }

        public Team(string name, int league)
        {
            this.name = name;
            this.league = league;
            squad = new List<Player>();
            stats = new Dictionary<int, Stats>();
        }

        public override string ToString()
        {
            string tmp = $"{name} league: {league} players in team: ";
            foreach (Player p in squad)
                tmp += $"\n{p.ToString}";
            return tmp;
        }

        public void Details() { Console.WriteLine(this); }

        public void AddPlayer(string firstName, string lastName, DateTime dateOfBirth, string position, int scoredGoals)
        {
            squad.Add(new Player(firstName, lastName, dateOfBirth, position, scoredGoals));
            stats.Add(squad.Count - 1, new());
        }
        public void AddPlayer(Player p)
        {
            squad.Add(p);
            stats.Add(squad.Count - 1, new());
        }
        public void RemovePlayer(Player p)
        {
            stats.Remove(squad.IndexOf(p));
            squad.Remove(p);
        }
        public void RemovePlayer(string firstName, string lastName, DateTime dateOfBirth, string position)
        {
            foreach (Player p in squad)
            {
                if(p.FirstName== firstName && p.LastName== lastName && dateOfBirth == p.DateOfBirth &&position == p.Position)
                { RemovePlayer(p); }    
            }
        }
        public void SearchPlayer(Player p)
        {
            if (squad.Contains(p))
                Console.WriteLine("Player exist");
            else
                Console.WriteLine("Player doesnt exist");
        }

        public void ScoreGoal(Player p)
        {
            stats[squad.IndexOf(p)].Goals++;
        }

        public void AddTime(Player p, double time)
        {
            _ = stats[squad.IndexOf(p)].AverageTime + time;
        }

        public void ResetStat(Player p)
        {
            stats[squad.IndexOf(p)].AverageTime = .0;
            stats[squad.IndexOf(p)].Goals = 0;

        }
        
        public void ResetTeam()
        {
            squad.Clear();
            stats.Clear();

        }
    }
}
