using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace abstrakcja_to_moje_życie
{
    internal class Catalog : ItemManagment
    {
        public IList<Item> items { get; set; }
        public string thematicDepartment { get; set; }

        public Catalog(IList<Item> items)
        {
            this.items = new List<Item>(items);
        }
        public Catalog(string thematicDepartment, IList<Item> items) : this(items)
        {
            this.thematicDepartment = thematicDepartment;
        }
        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public override string ToString()
        {
            string tmp = $"{thematicDepartment}";
            foreach(Item item in items)
            {
                tmp += $" \n{item}";
            }

            return tmp;
        }
        public void ShowAllItems() { Console.WriteLine(this); }
        public Item FindItemBy(int id)
        {
            foreach (Item i in items)
            {
                if (i.id == id)
                {
                    return i;
                }
            }
            return null;
        }
        public Item FindItemBy(string title)
        {
            foreach (Item i in items)
            {
                if (i.title == title)
                {
                    return i;
                }
            }
            return null;
        }
        public Item FindItem(Expression<Func<Item, bool>> predicate)
        {
            Func<Item, bool> delag = predicate.Compile();

            foreach (Item i in items)
            {
                if (delag(i))
                {
                    return i;
                }
            }
            return null;
        }
    }
}
