using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace abstrakcja_to_moje_życie
{
    internal interface ItemManagment 
    {
        public void ShowAllItems();
        public Item FindItemBy(int id);
        public Item FindItemBy(string title);
        public Item FindItem(Expression<Func<Item, bool>> predicate);
    }
}
