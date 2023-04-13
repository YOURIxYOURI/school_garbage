using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13042023
{
    internal class Lokomotywa : Wagon
    {
        public double Ciag { get; set; }

        public Lokomotywa(double ciag, double masa, string nazwa) : base(masa, nazwa)
        {
            Ciag = ciag;
        }
        public Lokomotywa() : base() { }

        public override string typ()
        {
            return "Lokomotywa";
        }

        public override string ToString()
        {
            return base.ToString() + $" {Ciag}";
        }
        public override void Print()
        {
            Console.WriteLine(this);
            Console.WriteLine(typ());
        }
    }
}
