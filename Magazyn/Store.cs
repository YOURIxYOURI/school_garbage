using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    internal class Store
    {
        // składowe klasy Store
        public List<Warehouse> Warehouses { get; }
        //konstruktor klasy Store
        public Store()
        {
            Warehouses = new List<Warehouse>();
        }
        //metoda dodająca magazyn do listy magazynów sklepu
        public Warehouse AddWarehouse(Address address)
        {
            var warehouse = new Warehouse(address);
            Warehouses.Add(warehouse);
            return warehouse;
        }
        // metoda usuwająca magazyn z listy sklepu
        public void RemoveWarehouse(Warehouse warehouse)
        {
            Warehouses.Remove(warehouse);
        }
        // nadpisana metoda tostring zwracająca ciąg znaków
        public override string ToString()
        {
            return $"Store with {Warehouses.Count} warehouses.";
        }
    }
}
