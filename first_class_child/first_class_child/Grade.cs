using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_class_child
{
    internal class Grade
    {
        private string _SubjectName;
        private DateTime _Date;
        private double _Value;

        public string SubjectName { get { return _SubjectName; } set { _SubjectName = value; } }
        public DateTime Date { get { return _Date; } set { _Date = value; } }
        public double Value { get { return _Value; } set { _Value = value; } }

        public Grade() { }

        public Grade(string subjectName, DateTime date, double value)
        {
            SubjectName = subjectName;
            Date = date;
            Value = value;
        }

        public override string ToString()
        {
            return $"{_SubjectName} {_Date} {_Value}";
        }
        public void details()
        {
            Console.WriteLine(this);
        }
    }
}
