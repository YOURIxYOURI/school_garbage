using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20042023
{
    internal static class Extension 
    {
        public static IList<T> Set<T>(this IContainer container)
        {
            var type = container.GetType();
            var collection = type.GetProperties().FirstOrDefault(k => k.PropertyType == typeof(IList<T>));
            var collectionObj = collection.GetValue(container);
            return collectionObj as IList<T>;
        }
        public static void Add<T>(this IContainer container, T obj)
        {
            var collection = Set<T>(container);
            collection.Add(obj);
        }
        public static void Remove<T>(this IContainer container, T obj)
        {
            var collection = Set<T>(container);
            collection.Add(obj);
        }
        public static string ShowAll<T>(this IList<T> l)
        {
            string tmp = "";
            foreach (T v in l)
            {
                tmp += v.ToString() + "\n";
            }
            return tmp;
        }
    }
}
