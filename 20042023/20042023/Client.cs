using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20042023
{
    internal class Client : Person, IContainer
    {
        
        public IList<Animal> Animals { get; set; }
        
        public Client(string name, string email, int phone) : base(name, email, phone)
        {
            Animals = new List<Animal>();
        }
        public override string ToString()
        {
            return $" KLIENT: {base.ToString()} \n{DisplayAnimals()}";
        }
        public string DisplayAnimals()
        {
            string tmp = "";
            foreach(Animal a in Animals) { tmp += a.ToString() +"\n"; }
            return tmp;
        }
    }
}
