using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using PC_Build;

static void program()
{
    try
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Dodaj komponent");
            Console.WriteLine("2. Wybierz zestaw komputerowy");
            Console.WriteLine("3. Wyświetl dostępne komponęty");
            Console.WriteLine("4. Wyjdź z programu");
            Console.Write("Wybierz opcję: ");
            var opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    Console.Clear();
                    DodajKomponent();
                    break;
                case "2":
                    Console.Clear();
                    WybierzZestaw();
                    break;
                case "3":
                    Console.Clear();
                    WyswietlKomponenty();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja");
                    break;
            }

        }
    }
    catch (Exception e) { Console.WriteLine($"Wystąpił błąd w głownej funkcji programu: {e}"); }
}
static void DodajKomponent()
{
    try
    {
        var kp = new List<Komponent>();
        while (true)
        {
            Console.WriteLine("Dodaj nowy komponent:");
            Console.WriteLine("Do poprawnego działania nazwa musi być: CPU,MB,RAM,PSU,GPU,DRIVE");
            Console.Write("Nazwa: ");
            var nazwa = Console.ReadLine();
            if(nazwa !="CPU" && nazwa != "MB" && nazwa != "RAM" && nazwa != "PSU" && nazwa != "GPU" && nazwa != "DRIVE")
            {
                Console.WriteLine("Nie poprawna nazwa");
                break;
            }
            Console.Write("Model: ");
            var model = Console.ReadLine();

            Console.Write("Typ złącza: ");
            var typZlacza = Console.ReadLine();

            Console.Write("Producent: ");
            var producent = Console.ReadLine();

            Console.Write("Parametr charakterystyczny: ");
            var parametr = Console.ReadLine();

            Console.Write("Cena: ");
            if (double.TryParse(Console.ReadLine(), out var cena))
            {
                if (string.IsNullOrEmpty(nazwa) || string.IsNullOrEmpty(model) || string.IsNullOrEmpty(typZlacza) || string.IsNullOrEmpty(producent) || string.IsNullOrEmpty(parametr)) 
                {
                    Console.WriteLine("Puste recordy");
                }
                else
                {
                    var komponent = new Komponent
                    {
                        Nazwa = nazwa,
                        Model = model,
                        TypZlacza = typZlacza,
                        Producent = producent,
                        Parametr = parametr,
                        Cena = cena
                    };

                    kp.Add(komponent);

                    Console.WriteLine("Komponent dodany do listy.");
                }
            }
            else
            {
                Console.WriteLine("Błąd podczas wprowadzania ceny. Spróbuj ponownie.");
            }

            Console.Write("Czy chcesz dodać kolejny komponent? (T/N): ");
            var kontynuuj = Console.ReadLine();
            if (kontynuuj != null && kontynuuj.ToUpper() != "T")
            {
                break;
            }
        }

        ZapiszDoPlikuCsv(kp);
    }
    catch (Exception e) { Console.WriteLine($"Wystąpił błąd w funkcji 'DodajKomponent': {e}"); }
}
static void WyswietlKomponenty()
{
    try
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Wszysktie komponęty");
        Console.WriteLine("2. Kategorie");
        Console.Write("Wybierz opcję: ");
        var opcja = Console.ReadLine();
        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };
        List<Komponent> records;
        using (var reader = new StreamReader("komponenty.csv"))
        using (var csv = new CsvReader(reader, csvConfiguration))
        {
            records = csv.GetRecords<Komponent>().ToList();
        }
        Console.WriteLine("Odczytane dane z pliku CSV:");
        switch (opcja)
        {
            case "1":
                break;
            case "2":
                Console.WriteLine("Kategoria:");
                Console.WriteLine("1. CPU");
                Console.WriteLine("2. Motherboard");
                Console.WriteLine("3. RAM");
                Console.WriteLine("4. PSU");
                Console.WriteLine("5. GPU");
                Console.WriteLine("6. Harddrive");
                Console.Write("Wybierz opcję: ");
                var kategoria = Console.ReadLine();
                switch (kategoria)
                {
                    case "1":
                        records = records.FindAll(x => x.Nazwa == "CPU");
                        break;
                    case "2":
                        records = records.FindAll(x => x.Nazwa == "MB");
                        break;
                    case "3":
                        records = records.FindAll(x => x.Nazwa == "RAM");
                        break;
                    case "4":
                        records = records.FindAll(x => x.Nazwa == "PSU");
                        break;
                    case "5":
                        records = records.FindAll(x => x.Nazwa == "GPU");
                        break;
                    case "6":
                        records = records.FindAll(x => x.Nazwa == "DRIVE");
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja");
                        break;
                }
                break;
            default:
                Console.WriteLine("Nieprawidłowa opcja");
                break;
        }
        foreach (var record in records)
        {
            record.Details();
        }
    }
    catch (Exception e) { Console.WriteLine($"Wystąpił błąd w funkcji 'WyświetlKomponenty': {e}"); }
}
static void ZapiszDoPlikuCsv(List<Komponent> komponenty)
{
    try
    {
        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            HasHeaderRecord = false
        };
        //csvConfiguration.HasHeaderRecord = false;
        var writer = new StreamWriter("komponenty.csv", true);
        using (var csv = new CsvWriter(writer, csvConfiguration)) { csv.WriteRecords(komponenty); };
        Console.WriteLine("Dane zapisane do pliku komponenty.csv.");
    }
    catch (Exception e) { Console.WriteLine($"Wystąpił błąd w funkcji 'ZapiszDoPlikuCsv': {e}"); }
}
static void WybierzZestaw()
{
    try
    {
        Console.WriteLine("Podaj Socket procesora");
        var socket = Console.ReadLine();

        Console.Write("Podaj maksymalną cenę: ");
        if (double.TryParse(Console.ReadLine(), out var maksymalnaCena))
        {
            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };
            List<Komponent> records;
            using (var reader = new StreamReader("komponenty.csv"))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                records = csv.GetRecords<Komponent>().ToList();
                records.OrderBy(o => o.Cena).ToList();
            }
            double cenaZestawu = 0;
            List<Komponent> zestaw = new();
            zestaw.Add(records.Find(x => x.Nazwa == "CPU" && x.TypZlacza == socket));
            if (zestaw[0] != null)
            {
                cenaZestawu += zestaw[0].Cena;
                zestaw.Add(records.Find(x => x.Nazwa == "MB" && x.TypZlacza == socket));
                cenaZestawu += zestaw[1].Cena;
                zestaw.Add(records.Find(x => x.Nazwa == "RAM" && x.TypZlacza == zestaw[1].Parametr));
                cenaZestawu += zestaw[2].Cena;
                zestaw.Add(records.Find(x => x.Nazwa == "PSU"));
                cenaZestawu += zestaw[3].Cena;
                zestaw.Add(records.Find(x => x.Nazwa == "GPU"));
                cenaZestawu += zestaw[4].Cena;
                zestaw.Add(records.Find(x => x.Nazwa == "DRIVE"));
                cenaZestawu += zestaw[5].Cena;
                if (cenaZestawu > maksymalnaCena)
                {
                    Console.WriteLine("Nie da się stworzyc komputera z obecnych komponętów");
                }
                else
                {
                    while (true)
                    {
                        List<Komponent> zestawFor = zestaw.ToList();
                        bool czyZmienione = false;
                        foreach (var k in zestaw)
                        {
                            Komponent newk;
                            if (k.Nazwa == "CPU" || k.Nazwa == "MB" || k.Nazwa == "RAM")
                            {
                                newk = records.Find(x => x.Nazwa == k.Nazwa && x.Cena > k.Cena && x.TypZlacza == k.TypZlacza && (x.Model != k.Model && x.TypZlacza != k.TypZlacza));
                            }
                            else
                            {
                                newk = records.Find(x => x.Nazwa == k.Nazwa && x.Cena > k.Cena && (x.Model != k.Model && x.TypZlacza != k.TypZlacza));
                            }
                            if (newk != null)
                            {
                                if (cenaZestawu - k.Cena + newk.Cena < maksymalnaCena)
                                {
                                    int index = zestawFor.FindIndex(x => x == k);
                                    if (index != -1)
                                    {
                                        cenaZestawu -= k.Cena;
                                        cenaZestawu += newk.Cena;
                                        zestawFor[index] = newk;
                                        czyZmienione = true;
                                    }
                                }
                            }
                        }
                        zestaw = zestawFor.ToList();
                        if (czyZmienione)
                        {
                            break;
                        }
                    }
                    Console.WriteLine($"Wybrany zestaw za cenę: {cenaZestawu}");
                    foreach (var record in zestaw)
                    {
                        record.Details();
                    }
                }
            }
            else
            {
                Console.WriteLine("Nie poprawny socket");
            }
        }

        else
        {
            Console.WriteLine("Błąd podczas wprowadzania ceny. Spróbuj ponownie.");
        }
    }
    catch (Exception e) { Console.WriteLine($"Wystąpił błąd w funkcji 'WybierzZestaw': {e}"); }
}

program();
