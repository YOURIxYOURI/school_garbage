using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    internal class Product
    {
        //składowe klasy Product
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        // konstruktor klasy Product
        public Product(string manufacturer, string name, string category, string productCode, double price, string description)
        {
            Manufacturer = manufacturer;
            Name = name;
            Category = category;
            ProductCode = productCode;
            Price = price;
            Description = description;
        }
        // nadpisana metoda tostring zwracająca ciąg znaków
        public override string ToString()
        {
            return $"{Name} ({Manufacturer}), Category: {Category}, Price: {Price} PLN";
        }
    }
}
