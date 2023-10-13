using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    internal class Warehouse
    {
        //składowe klasy Warehouse
        public Address Address { get; }
        public List<Product> Products { get; }
        // konstruktor klasy Warehouse
        public Warehouse(Address address)
        {
            Address = address;
            Products = new List<Product>();
        }
        //metoda dodająca produkt do magazynu
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        // metoda usuwająca produkt z magazynu
        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }
        // nadpisana metoda tostring zwracająca ciąg znaków
        public override string ToString()
        {
            return $"Warehouse at {Address} contains {Products.Count} products.";
        }
    }
}
