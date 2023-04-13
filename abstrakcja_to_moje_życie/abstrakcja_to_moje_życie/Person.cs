using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstrakcja_to_moje_życie
{
    internal class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public Person() { }
        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }
        public virtual void Details()
        {
            Console.WriteLine(this);
        }

    }
}
