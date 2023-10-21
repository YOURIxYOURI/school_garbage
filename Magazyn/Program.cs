using System;
using System.Collections.Generic;
using Magazyn;
using static System.Formats.Asn1.AsnWriter;

List<Store> shops = new List<Store>();

bool exit = false;

while (!exit)
{
    Console.WriteLine("1. Dodaj sklep");
    Console.WriteLine("2. Wybierz sklep");
    Console.WriteLine("3. Wyjście");

    Console.Write("Wybierz opcję: ");
    string choice = Console.ReadLine();
    Console.Clear();
    switch (choice)
    {
        case "1":
            AddShop();
            break;
        case "2":
            SelectShop();
            break;
        case "3":
            exit = true;
            break;
        default:
            Console.WriteLine("Nieprawidłowy wybór. Wybierz ponownie.");
            break;
    }
}

void AddShop()
{
    Store shop = new Store();
    shops.Add(shop);
    Console.WriteLine("Sklep dodany.");
}

void SelectShop()
{
    if (shops.Count == 0)
    {
        Console.WriteLine("Brak dostępnych sklepów. Najpierw dodaj sklep.");
        return;
    }

    Console.WriteLine("Dostępne sklepy:");

    for (int i = 0; i < shops.Count; i++)
    {
        Console.WriteLine($"{i}. Sklep {i + 1}");
    }

    Console.Write("Wybierz numer sklepu: ");
    if (int.TryParse(Console.ReadLine(), out int shopIndex) && shopIndex >= 0 && shopIndex < shops.Count)
    {
        ManageShop(shops[shopIndex]);
    }
    else
    {
        Console.WriteLine("Nieprawidłowy numer sklepu.");
    }
}

void ManageShop(Store shop)
{
    Console.Clear();
    bool shopExit = false;

    while (!shopExit)
    {
        Console.WriteLine($"Sklep z {shop.Warehouses.Count} magazynami.");
        Console.WriteLine("1. Dodaj magazyn");
        Console.WriteLine("2. Usuń magazyn");
        Console.WriteLine("3. Wyświetl magazyny");
        Console.WriteLine("4. Dodaj produkt");
        Console.WriteLine("5. Usuń produkt");
        Console.WriteLine("6. Wyświetl produkty");
        Console.WriteLine("7. Powrót");

        Console.Write("Wybierz opcję: ");
        string choice = Console.ReadLine();
        Console.Clear();
        switch (choice)
        {
            case "1":
                AddWarehouse(shop);
                break;
            case "2":
                RemoveWarehouse(shop);
                break;
            case "3":
                DisplayWarehouses(shop);
                break;
            case "4":
                AddProduct(shop);
                break;
            case "5":
                RemoveProduct(shop);
                break;
            case "6":
                DisplayWarehouse(shop);
                break;
            case "7":
                shopExit = true;
                break;
            default:
                Console.WriteLine("Nieprawidłowy wybór. Wybierz ponownie.");
                break;
        }
    }
}

static void AddWarehouse(Store shop)
{
    Console.WriteLine("Podaj dane adresu magazynu:");
    Console.Write("Ulica: ");
    string street = Console.ReadLine();
    Console.Write("Kod pocztowy: ");
    string postalCode = Console.ReadLine();
    Console.Write("Miasto: ");
    string city = Console.ReadLine();
    Console.Write("Numer budynku: ");
    string buildingNumber = Console.ReadLine();
    Console.Write("Numer lokalu: ");
    string apartmentNumber = Console.ReadLine();

    Address address = new Address(street, postalCode, city, buildingNumber, apartmentNumber);
    shop.AddWarehouse(address);
    Console.WriteLine("Magazyn dodany.");
}

static void RemoveWarehouse(Store shop)
{
    Console.WriteLine("Lista magazynów:");
    DisplayWarehouses(shop);

    if (shop.Warehouses.Count > 0)
    {
        Console.Write("Podaj numer magazynu do usunięcia: ");
        if (int.TryParse(Console.ReadLine(), out int warehouseIndex) && warehouseIndex >= 0 && warehouseIndex < shop.Warehouses.Count)
        {
            shop.RemoveWarehouse(shop.Warehouses[warehouseIndex]);
            Console.WriteLine("Magazyn usunięty.");
        }
        else
        {
            Console.WriteLine("Nieprawidłowy numer magazynu.");
        }
    }
}

static void DisplayWarehouses(Store shop)
{
    int index = 0;
    foreach (var warehouse in shop.Warehouses)
    {
        Console.WriteLine($"{index}. {warehouse}");
        index++;
    }
}

static void AddProduct(Store shop)
{
    Console.WriteLine("Podaj dane produktu:");
    Console.Write("Producent: ");
    string manufacturer = Console.ReadLine();
    Console.Write("Nazwa: ");
    string name = Console.ReadLine();
    Console.Write("Kategoria: ");
    string category = Console.ReadLine();
    Console.Write("Kod produktu: ");
    string productCode = Console.ReadLine();
    Console.Write("Cena: ");
    if (double.TryParse(Console.ReadLine(), out double price))
    {
        Console.Write("Opis: ");
        string description = Console.ReadLine();

        Product product = new Product(manufacturer, name, category, productCode, price, description);

        Console.WriteLine("Lista magazynów:");
        DisplayWarehouses(shop);

        if (shop.Warehouses.Count > 0)
        {
            Console.Write("Podaj numer magazynu, do którego chcesz dodać produkt: ");
            if (int.TryParse(Console.ReadLine(), out int warehouseIndex) && warehouseIndex >= 0 && warehouseIndex < shop.Warehouses.Count)
            {
                shop.Warehouses[warehouseIndex].AddProduct(product);
                Console.WriteLine("Produkt dodany do magazynu.");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy numer magazynu.");
            }
        }
        else
        {
            Console.WriteLine("Brak dostępnych magazynów. Najpierw dodaj magazyn.");
        }
    }
    else
    {
        Console.WriteLine("Nieprawidłowa cena.");
    }
}

void RemoveProduct(Store shop)
{
    Console.WriteLine("Lista magazynów:");
    DisplayWarehouses(shop);

    if (shop.Warehouses.Count > 0)
    {
        Console.Write("Podaj numer magazynu, z którego chcesz usunąć produkt: ");
        if (int.TryParse(Console.ReadLine(), out int warehouseIndex) && warehouseIndex >= 0 && warehouseIndex < shop.Warehouses.Count)
        {
            Warehouse warehouse = shop.Warehouses[warehouseIndex];

            Console.WriteLine("Lista produktów w magazynie:");
            DisplayProducts(warehouse.Products);

            if (warehouse.Products.Count > 0)
            {
                Console.Write("Podaj numer produktu do usunięcia: ");
                if (int.TryParse(Console.ReadLine(), out int productIndex) && productIndex >= 0 && productIndex < warehouse.Products.Count)
                {
                    warehouse.RemoveProduct(warehouse.Products[productIndex]);
                    Console.WriteLine("Produkt usunięty z magazynu.");
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy numer produktu.");
                }
            }
            else
            {
                Console.WriteLine("Brak produktów w magazynie.");
            }
        }
        else
        {
            Console.WriteLine("Nieprawidłowy numer magazynu.");
        }
    }
    else
    {
        Console.WriteLine("Brak dostępnych magazynów. Najpierw dodaj magazyn.");
    }
}

void DisplayWarehouse(Store shop)
{
    int index = 0;
    foreach (var warehouse in shop.Warehouses)
    {
        Console.WriteLine($"Magazyn {index} zawiera {warehouse.Products.Count} produktów.");
        DisplayProducts(warehouse.Products);
        index++;
    }
}

void DisplayProducts(List<Product> products)
{
    int index = 0;
    foreach (var product in products)
    {
        Console.WriteLine($"{index}. {product}");
        index++;
    }
}
