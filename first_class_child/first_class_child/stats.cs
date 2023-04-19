using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_class_child
{
    internal class Stats
    {
        public int Goals { get; set; }
        public double AverageTime { get; set; }

        public Stats() { }

        public Stats(int goals, int averageTime)
        {
            Goals = goals;
            AverageTime = averageTime;
        }

        
    }

}
