using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20042023
{
    internal class Clinic : IContainer
    {
        public string name { get; set; }
        public string addres { get; set; }
        public IList<Vet> vets { get; set; }
        public IList<Visits> visits { get; set; }

        public Clinic(string name, string addres)
        {
            this.name = name;
            this.addres = addres;
            visits = new List<Visits>();
            vets = new List<Vet>();
        }
        public string Info()
        {
            return $"{name} {addres}";
        }
    }
}
