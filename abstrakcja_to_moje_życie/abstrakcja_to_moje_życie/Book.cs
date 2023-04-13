using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstrakcja_to_moje_życie
{
    internal class Book : Item
    {
        public int pageCount { get; set; }
        public List<Author> authors { get; set; }
        public Book(string title, int id, string publisher, DateTime dateOfIssue, int pageCount, List<Author> authors) : base(id, title, publisher, dateOfIssue)
        {
            this.pageCount = pageCount;
            this.authors = new List<Author>();
            this.authors.AddRange(authors);
        }
        public override string ToString()
        {
            string tmp = "";
            foreach (Author a in authors) { tmp += a.ToString() + ", "; }
            return $"Pages: {pageCount} Authors: {tmp} \n{base.ToString()}";
        }
        public override void details()
        {
            Console.WriteLine(this);
        }
        public void AddAuthor(Author a)
        {
            authors.Add(a);
        }
        public override string GenerateBarCode()
        {
            return $"{id}{pageCount}{dateOfIssue.Year}";
        }
    }
}
