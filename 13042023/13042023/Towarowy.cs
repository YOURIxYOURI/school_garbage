using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13042023
{
    internal class Towarowy : Wagon
    {
        public string ladunek { get; set; }

        public Towarowy(string ladunek, double masa, string nazwa) : base(masa, nazwa)
        {
            this.ladunek = ladunek;
        }
        public Towarowy() : base() { }

        public override string typ()
        {
            return "Towarowy";
        }

        public override string ToString()
        {
            return base.ToString() + $" {ladunek}";
        }

        public override void Print()
        {
            Console.WriteLine(this);
            Console.WriteLine(typ());
        }

    }
}
