using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_class_child
{
    internal class Student : Person
    {
        private int _Year;
        private int _Group;
        private int _IndexId;
        private List<Grade> _Grades;

        public int Year { get { return _Year; } set { _Year = value; } }
        public int Group { get { return _Group; } set { _Group = value; } }
        public int IndexId { get { return _IndexId; } set { _IndexId = value; } }
        public List<Grade> Grades { get { return _Grades; }}

        public Student() : base() { _Grades = new List<Grade>(); }

        public Student(string firstName, string lastName, DateTime dateOfBirth, int Year, int Group, int Index) : base(firstName, lastName, dateOfBirth)
        {
            _Year = Year;
            _Group = Group;
            _IndexId = Index;
            _Grades = new List<Grade>();
        }

        public override string ToString()
        {
           string tmp = base.ToString() + $"{_Year} {_Group} {_IndexId}";
            
            foreach (Grade g in _Grades) 
                tmp += "\n" + g.ToString();

            return tmp;
        }

        public override void Details()
        {
            Console.WriteLine(this);
        }

        public void AddGrade(string subjectName, double value, DateTime date)
        {
            Grades.Add(new Grade(subjectName, date, value));
        }
        public void AddGrade(Grade g)
        {
            Grades.Add(g);
        }
        public void DisplayGrades()
        {
            foreach(Grade g in Grades)
                Console.WriteLine(g.ToString());
        }
        public void DisplayGrades(string sn)
        {
            foreach (Grade g in Grades)
            {
                if (g.SubjectName == sn)
                    Console.WriteLine(g.ToString());
            }
        }
        public void DeleteGrade(string subjectName, double value, DateTime date)
        {
            foreach(var g in Grades)
            {
                if(g.SubjectName == subjectName && g.Value == value && g.Date == date) { Grades.Remove(g);break; }
            }
        }
        public void DeleteGrade(Grade g)
        {
            Grades.Remove(g);
        }
        public void DeleteGrades(string sn)
        {
            List<Grade> newgrades = new List<Grade>();
            foreach (Grade g in Grades)
            {
                if (g.SubjectName != sn) 
                    newgrades.Add(g);
            }
            Grades.Clear();
            Grades.AddRange(newgrades);
        }
        public void DeleteGrades() { Grades.Clear(); }
    }
}
