using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13042023
{
    internal class OsobowyPrzedzialy : Wagon
    {
        IList<Przedzial> przedzialy;

        public OsobowyPrzedzialy(IList<Przedzial> p, double masa, string nazwa) : base(masa, nazwa)
        {
            przedzialy = new List<Przedzial>(p);
        }
        public OsobowyPrzedzialy() : base() { przedzialy = new List<Przedzial>(); }

        public override string ToString()
        {
            string tmp= "";
            foreach (Przedzial p in przedzialy) tmp += p.ToString();  
            return base.ToString() + tmp;
        }

        public override void Print()
        {
            Console.WriteLine(this);
            Console.WriteLine(typ());
        }

        public override string typ()
        {
            return "OsobowyPrzedział";
        }
    }
}
