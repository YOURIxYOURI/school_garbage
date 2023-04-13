using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstrakcja_to_moje_życie
{
    internal class Author : Person
    {
        public string nationality { get; set; }

        public Author(string firstName, string lastName, string nationality) : base(firstName, lastName)
        {
            this.nationality = nationality;
        }
        public Author() : base() { }


        public override string ToString()
        {
            return $"{firstName} {lastName} {nationality}";
        }
        public override void Details()
        {
            Console.WriteLine(this);
        }
    }
}
