using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_class_child
{
    internal class FootballPlayer : Player
    {
        public FootballPlayer(string firstName, string lastName, DateTime dateOfBirth, string position,  int scoredGoals)
            : base(firstName, lastName, dateOfBirth, position, scoredGoals) { }
        public override void ScoreGoal()
        {
            base.ScoreGoal();
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Details()
        {
            Console.WriteLine(this);
        }
    }
}
