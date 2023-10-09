using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Build
{
    public class Komponent
    {
        public string Nazwa { get; set; }
        public string Model { get; set; }
        public string TypZlacza { get; set; }
        public string Producent { get; set; }
        public string Parametr { get; set; }
        public double Cena { get; set; }

        public override string ToString()
        {
            return $"{Nazwa}: {Model} {TypZlacza} {Producent} {Parametr}";
        }
        public void Details () { Console.WriteLine(this); }
    }
}


