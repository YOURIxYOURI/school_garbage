using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20042023
{
    internal class Visits
    {
        public Animal animal { get; set; }
        public Vet vet { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }

        public Visits(Animal animal, Vet vet, DateTime date, string description, Clinic c)
        {
            this.animal = animal;
            this.vet = vet;
            this.description = description;
            this.date = date;
            c.Add(this);
        }
        public Visits(Animal animal, Vet vet, DateTime date, string description)
        {
            this.animal = animal;
            this.vet = vet;
            this.description = description;
            this.date = date;
        }
        public override string ToString()
        {
            return $"WIZYTA \n{animal} \n{vet}\n{date} \n{description}";
        }
    }
}
