using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace first_class_child
{
    internal class Player : Person
    {
        private string _Position;
        private string _Dub;
        private int _ScoredGoals;

        public string Position { get { return _Position; } set { _Position = value; } }
        public string Dub { get { return _Dub; } set { _Dub = value; } }
        public int ScoredGoals {get { return _ScoredGoals; } set { _ScoredGoals = value; } }

        public Player() : base() { _ScoredGoals = 0; }

        public Player(string firstName, string lastName, DateTime dateOfBirth, string position, string dub, int scoredGoals) : base(firstName, lastName, dateOfBirth)
        {
            Position = position;
            Dub = dub;
            ScoredGoals = scoredGoals;
        }

        public override string ToString()
        {
            return base.ToString() + $"{_Position} {_Dub} {_ScoredGoals}";
        }

        public override void Details()
        {
            Console.WriteLine(this);
        }

        public void ScoreGoal() { _ScoredGoals++; }
    }
}
