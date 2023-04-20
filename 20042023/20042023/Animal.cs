using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20042023
{
    internal class Animal
    {
        public string name { get; set; }
        public string species { get; set; }
        public DateTime birth{ get; set; }
        public string description { get; set; }
        public string healthStatus { get; set; }

        public Animal(string name, string species, DateTime birth, string description, string healthStatus)
        {
            this.name = name;
            this.species = species;
            this.birth = birth;
            this.description = description;
            this.healthStatus = healthStatus;
        }
        public Animal() { }

        public override string ToString()
        {
            return $"{name} {species} {birth.Date} {description} {healthStatus}";
        }
    }
}
