using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20042023
{
    internal class Vet : Person
    {
        public string specialization { get; set; }
        public double salary { get; set; }

        public Vet(string name, string email, int phone,string specialization, double salary) : base(name, email, phone)
        {
            this.specialization = specialization;
            this.salary = salary;
        }
        public override string ToString()
        {
            return $"WETERYNARZ: {base.ToString()} {specialization} {salary}";
        }
    }
}
