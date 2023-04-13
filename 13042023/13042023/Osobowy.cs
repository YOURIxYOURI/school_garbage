using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13042023
{
    internal class Osobowy : Wagon
    {
        public int miejsca { get; set; }
        public int zajete { get; set; }

        public Osobowy(int miejsca, double masa, string nazwa) : base(masa, nazwa)
        {
            this.miejsca = miejsca;
            this.zajete = 0;
        }
        public Osobowy() : base() { }

        public override string ToString()
        {
            return base.ToString() + $" {miejsca} {zajete}";
        }

        public override void Print()
        {
            Console.WriteLine(this);
            Console.WriteLine(typ());
        }

        public override string typ()
        {
            return "Osobowy";
        }
        public void ZajmijMiejsca(int ile)
        {
            if(zajete +ile <= miejsca)
            zajete += ile;
        }
        public void ZwolnijMiejsca(int ile)
        {
            
            zajete -= ile;
        }
    }
}
