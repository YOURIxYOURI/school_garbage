using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13042023
{
    abstract class Wagon : IInfo
    {
        public double masa { get; set; }
        public string nazwa { get; set; }

        public Wagon(double masa, string nazwa)
        {
            this.masa = masa;
            this.nazwa = nazwa;
        }
        public Wagon() { }

        public abstract void Print();
        public abstract string typ();

        public override string ToString()
        {
            return $"{nazwa} {masa}";
        }
    }
}
