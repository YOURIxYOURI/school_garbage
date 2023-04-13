using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstrakcja_to_moje_życie
{
    internal class Journal : Item
    {
        public int number { get; set; }
        public Journal() :base(){ }
        public Journal(string title, int id, string publisher, DateTime dateOfIssue,int number): base(id, title, publisher, dateOfIssue)
        {
            this.number = number;
        }
        public override string ToString()
        {
            return $"{number}: {base.ToString()}";
        }
        public override void details()
        {
            Console.WriteLine(this);
        }
        public override string GenerateBarCode()
        {
            return $"{id}{number}{dateOfIssue.Year}";
        }
    }
}
