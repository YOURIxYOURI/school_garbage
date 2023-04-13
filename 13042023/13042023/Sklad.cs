using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _13042023
{
    internal class Sklad : IInfo
    {
        public IList<Lokomotywa> lokomotywy{ get; set; }
        public IList<Wagon> wagony { get; set; }

        public Sklad(IList<Lokomotywa> lokomotywy, IList<Wagon> wagony)
        {
            this.lokomotywy = new List<Lokomotywa>(lokomotywy);
            this.wagony = new List<Wagon>(wagony);
        }
        public Sklad()
        {
            this.lokomotywy = new List<Lokomotywa>();
            this.wagony = new List<Wagon>();
        }

        public bool MozeJechac()
        {
            double ciag=.0, masa=.0;

            foreach (Lokomotywa l in this.lokomotywy)
            {
                ciag += l.Ciag;
                masa += l.masa;
            }
            foreach(Wagon w in this.wagony)
            {
                masa += w.masa;
            }
            if (ciag >= masa) return true;
            else return false;
        }
        public override string ToString()
        {
            string tmp = "";
            foreach (Lokomotywa l in this.lokomotywy)
            {
                tmp += "\n"+l.ToString();
            }
            foreach (Wagon w in this.wagony)
            {
                tmp += "\n"+w.ToString();
            }
            return tmp;
        }

        public void Print()
        {
            Console.WriteLine(this);
            if (MozeJechac()) { Console.WriteLine("MOZE JECHAC"); }
            else { Console.WriteLine("NIE MOZE JECHAC"); }
        }
        public Wagon FindWagonBy(Expression<Func<Wagon, bool>> predicate)
        {
            Func<Wagon, bool> delag = predicate.Compile();
            foreach(Wagon w in wagony)
            {
                if (delag(w)) return w;
            }
            return null;
        }
        public Lokomotywa FindLokomotywaBy(Expression<Func<Lokomotywa, bool>> predicate)
        {
            Func<Lokomotywa, bool> delag = predicate.Compile();
            foreach (Lokomotywa l in lokomotywy)
            {
                if (delag(l)) return l;
            }
            return null;
        }
        public void addWagon(Wagon w) { wagony.Add(w); }
        public void addLokomotywa(Lokomotywa l) { lokomotywy.Add(l); }
        public void removeLokomotywa(Expression<Func<Lokomotywa, bool>> predicate) { lokomotywy.Remove(FindLokomotywaBy(predicate)); }
        public void removeWagon(Expression<Func<Wagon, bool>> predicate) { wagony.Remove(FindWagonBy(predicate)); }

    }
}
