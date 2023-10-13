using System;
using System.Collections.Generic;
using Magazyn;
Store store = new Store();

// Dodawanie produktów
Product product1 = new Product("Manufacturer1", "Product1", "Category1", "12345", 10.99, "Description1");
Product product2 = new Product("Manufacturer2", "Product2", "Category2", "54321", 15.99, "Description2");

// Dodawanie magazynu
Address warehouseAddress = new Address("123 Main St", "12345", "City1", "1A", "101");
Warehouse warehouse = store.AddWarehouse(warehouseAddress);

// Dodawanie produktów do magazynu
warehouse.AddProduct(product1);
warehouse.AddProduct(product2);

// Wyświetlanie informacji
Console.WriteLine(store);
Console.WriteLine(warehouse);
foreach (var product in warehouse.Products)
{
    Console.WriteLine(product);
}
