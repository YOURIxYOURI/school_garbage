using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace abstrakcja_to_moje_życie
{
    internal class Library : ItemManagment
    {
        public string adress { get; set; }
        public List<Librarian> librarians { get; set; }
        public List<Catalog> catalogs { get; set; }

        public Library(string adress, IList<Librarian> librarians, IList<Catalog> catalogs)
        {
            this.adress = adress;
            this.librarians = new List<Librarian>();
            this.librarians.AddRange(librarians);
            this.catalogs = new List<Catalog>();
            this.catalogs.AddRange(catalogs);
        }

        public void AddLibrarian(Librarian l)
        {
            librarians.Add(l);
        }

        public void AddCatalog(Catalog c)
        {
            catalogs.Add(c);
        }

        public void AddItem(Item i, string str)
        {
            foreach(Catalog c in catalogs)
            {
                if(c.thematicDepartment == str)
                {
                    c.items.Add(i);
                    break;
                }
            }
        }

        public override string ToString()
        {
            string tmp1 = "Bibliotekarze:";
            string tmp2 = "Katalogi:";
            foreach (Librarian l in librarians) { tmp1 += $"\n{l}"; }
            foreach (Catalog c in catalogs) { tmp2 += $"\n{c}"; }
            return $"{adress} {tmp1}\n {tmp2}";
        }

        public void ShowAllLibrarians() { foreach (Librarian l in librarians) { Console.WriteLine($"\n {l}"); } }

        public void ShowAllItems() { Console.WriteLine(this); }
        public Item FindItemBy(int id)
        {
            foreach(Catalog c in catalogs)
            {
                foreach( Item i in c.items)
                {
                    if(i.id == id)
                    {
                        return i;
                    }
                }
            }
            return null;
        }
        public Item FindItemBy(string title)
        {
            foreach (Catalog c in catalogs)
            {
                foreach (Item i in c.items)
                {
                    if (i.title == title)
                    {
                        return i;
                    }
                }
            }
            return null;
        }
        public Item FindItem(Expression<Func<Item, bool>> predicate)
        {
            Func<Item, bool> delag = predicate.Compile();
            foreach (Catalog c in catalogs)
            {
                foreach (Item i in c.items)
                {
                    if (delag(i))
                    {
                        return i;
                    }
                }
            }
            return null;
        }
        public IList<Item> FindItemsBy(string p)
        {
            IList<Item> list = new List<Item>();
            foreach (Catalog c in catalogs)
            {
                foreach (Item i in c.items)
                {
                    if (i.publisher == p)
                    {
                        list.Add(i);
                    }
                }
            }
            return list;
        }
    }
}
