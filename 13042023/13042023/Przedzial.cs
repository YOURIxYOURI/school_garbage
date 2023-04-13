using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13042023
{
    internal class Przedzial 
    {
        public int miejsca { get; set; }
        public int zajete { get; set; }

        public Przedzial(int miejsca) 
        {
            this.miejsca = miejsca;
            this.zajete = 0;
        }

        public override string ToString()
        {
            return $" {miejsca} {zajete}";
        }

        public void Print()
        {
            Console.WriteLine(this);
        }
        public void ZajmijMiejsca(int ile)
        {
            if (zajete + ile <= miejsca)
                zajete += ile;
        }
        public void ZwolnijMiejsca(int ile)
        {
            zajete -= ile;
        }
    }
}
