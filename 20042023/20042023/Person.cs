using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20042023
{
    internal abstract class Person
    {
        public string name { get; set; }
        public string email { get; set; }
        public int phone { get; set; }

        public Person(string name, string email, int phone)
        {
            this.phone = phone;
            this.name = name;
            this.email = email;
        }
        public override string ToString()
        {
            return $"{name} {email} {phone}";
        }
    }
}
