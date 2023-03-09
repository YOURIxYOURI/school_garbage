using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_class_child
{
    internal class Person
    {
        protected string _FirstName;
        protected string _LastName;
        protected DateTime _DateOfBirth;

        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        public DateTime DateOfBirth { get { return _DateOfBirth; } set { _DateOfBirth = value; } }

        public Person() {}
        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            _FirstName = firstName;
            _LastName = lastName;
            _DateOfBirth = dateOfBirth;
        }
        public override string ToString()
        {
            return $"{_FirstName} {_LastName} {_DateOfBirth} ";
        }

        public virtual void Details()
        {
            Console.WriteLine(this);
        }
    }
}
