using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstrakcja_to_moje_życie
{
    internal class Librarian : Person
    {
        public DateTime hireDate { get; set; }
        public decimal salary { get; set; }
        public Librarian() :base() { }
        public Librarian(string firstName, string lastName, DateTime hireDate, decimal salary) : base(firstName, lastName)
        {
            this.hireDate = hireDate;
            this.salary = salary;
        }
        public override string ToString()
        {
            return base.ToString() + $" {salary} {hireDate}";
        }
        public override void Details()
        {
            Console.WriteLine(this);
        }
    }
}
