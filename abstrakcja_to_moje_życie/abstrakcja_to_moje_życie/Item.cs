using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstrakcja_to_moje_życie
{
    internal abstract class Item
    {
        protected int _id;
        protected string _title;
        protected string _publisher;
        protected DateTime _dateOfIssue;

        public int id { get { return _id; } set { _id = value; } }
        public string title { get { return _title; } set { _title = value; } }
        public string publisher { get { return _publisher; } set { _publisher = value; } }
        public DateTime dateOfIssue { get { return _dateOfIssue; } set { _dateOfIssue = value; }}

        public Item(int id, string title, string publisher, DateTime dateOfIssue)
        {
            this.id = id;
            this.title = title;
            this.publisher = publisher;
            this.dateOfIssue = dateOfIssue;
        }
        public Item() { }

        public override string ToString()
        {
            return $"{id}: {title}, {publisher}, {dateOfIssue.ToShortDateString()}";
        }
        public virtual void details()
        {
            Console.WriteLine(this);
        }
        public abstract string GenerateBarCode();
    }
}
