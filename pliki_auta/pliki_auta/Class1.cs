using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pliki_auta
{
    internal class Samochod
    {
        public string marka { get; set; }
        public string model { get; set; }
        public double poj{ get; set; }
        public int moc { get; set; }

        public Samochod() { }
        public Samochod(string marka, string model, double poj, int moc)
        {
            this.marka = marka;
            this.model = model;
            this.poj = poj;
            this.moc = moc;
        }
        public Samochod(Samochod s) 
        {
            this.marka = s.marka;
            this.model = s.model;
            this.poj = s.poj;
            this.moc = s.moc;
        }

        public void Copy(Samochod s)
        {
            this.marka = s.marka;
            this.model = s.model;
            this.poj = s.poj;
            this.moc = s.moc;
        }

        public override string ToString()
        {
            return $"{marka} {model} {poj} {moc}";
        }
    }
}
