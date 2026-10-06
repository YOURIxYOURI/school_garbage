using TravelAgencyApp.Data;
using TravelAgencyApp.Entities;
using TravelAgencyApp.Services;

namespace TravelAgencyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
                DatabaseSeeder.Seed(db);
            }

            bool exitApp = false;
            while (!exitApp)
            {
                Console.Clear();
                Console.WriteLine("=== SYSTEM BIURA PODRÓŻY ===");
                Console.WriteLine("1. Panel Administratora (Zarządzanie strukturą)");
                Console.WriteLine("2. Panel Pracownika (Logowanie / Sprzedaż)");
                Console.WriteLine("0. Wyjdź");
                Console.Write("\nWybór: ");

                switch (Console.ReadLine())
                {
                    case "1": RunAdminMenu(); break;
                    case "2": RunEmployeeLogin(); break;
                    case "0": exitApp = true; break;
                }
            }
        }

        static void RunAdminMenu()
        {
            var adminService = new AdminService();
            bool exitAdmin = false;

            while (!exitAdmin)
            {
                Console.Clear();
                Console.WriteLine("=== PANEL ADMINISTRATORA ===");
                Console.WriteLine("1. Lista Oddziałów i Kadry");
                Console.WriteLine("2. Otwórz nowe Biuro");
                Console.WriteLine("3. Zatrudnij Pracownika (Login stworzy się sam)");
                Console.WriteLine("4. Dodaj nową Ofertę wycieczki");
                Console.WriteLine("5. Usuń Ofertę wycieczki");
                Console.WriteLine("6. HISTORIA REZERWACJI (Przegląd sprzedaży)");
                Console.WriteLine("7. Baza wszystkich Klientów");
                Console.WriteLine("0. Wyloguj");
                Console.Write("\nWybór: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        foreach (var b in adminService.ReadBranches())
                        {
                            Console.WriteLine($"\nBIURO: {b.City}, ul. {b.Address}");
                            foreach (var e in b.Employees)
                                Console.WriteLine($" - {e.FirstName} {e.LastName} | Login: {e.Login} | Stanowisko: {e.Position}");
                        }
                        Console.ReadKey();
                        break;

                    case "2":
                        var newBranch = new Branch();
                        Console.Write("Miasto: "); newBranch.City = Console.ReadLine() ?? "";
                        Console.Write("Ulica i lokal: "); newBranch.Address = Console.ReadLine() ?? "";
                        Console.Write("Kod pocztowy: "); newBranch.PostalCode = Console.ReadLine() ?? "";

                        adminService.CreateBranch(newBranch);
                        Console.WriteLine($"\n[SUKCES] Otarto nowe biuro!");
                        Console.ReadKey();
                        break;

                    case "3":
                        var branches = adminService.ReadBranches();
                        if (!branches.Any()) { Console.WriteLine("Brak biur!"); Console.ReadKey(); break; }

                        var newEmp = new Employee();
                        Console.Write("Imię: "); newEmp.FirstName = Console.ReadLine() ?? "";
                        Console.Write("Nazwisko: "); newEmp.LastName = Console.ReadLine() ?? "";
                        Console.Write("Telefon służbowy: "); newEmp.PhoneNumber = Console.ReadLine() ?? "";
                        Console.Write("Stanowisko: "); newEmp.Position = Console.ReadLine() ?? "";
                        Console.Write("Miesięczna pensja brutto (PLN): ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal salary)) newEmp.Salary = salary;
                        Console.Write("Ustal hasło do konta: "); newEmp.Password = Console.ReadLine() ?? "";

                        Console.WriteLine("\nDo którego biura przypisać?");
                        for (int i = 0; i < branches.Count; i++)
                            Console.WriteLine($"{i + 1}. {branches[i].City}, ul. {branches[i].Address}");

                        if (int.TryParse(Console.ReadLine(), out int bIndex) && bIndex > 0 && bIndex <= branches.Count)
                        {
                            newEmp.BranchId = branches[bIndex - 1].Id;

                            var savedEmp = adminService.CreateEmployee(newEmp);

                            Console.WriteLine($"\n[SUKCES] Zatrudniono pracownika.");
                            Console.WriteLine($"Ważne! Przekaż pracownikowi jego wygenerowany LOGIN: {savedEmp.Login}");
                        }
                        Console.ReadKey();
                        break;

                    case "4":
                        var newOffer = new Offer();
                        Console.Write("Tytuł: "); newOffer.Title = Console.ReadLine() ?? "";
                        Console.Write("Cel (Kraj): "); newOffer.Destination = Console.ReadLine() ?? "";
                        Console.Write("Środek transportu: "); newOffer.TransportType = Console.ReadLine() ?? "";

                        Console.Write("Data wyjazdu (RRRR-MM-DD): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime sDate)) newOffer.StartDate = sDate;
                        Console.Write("Data powrotu (RRRR-MM-DD): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime eDate)) newOffer.EndDate = eDate;

                        Console.Write("Cena za osobę (PLN): ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal price)) newOffer.PricePerPerson = price;
                        Console.Write("Liczba wolnych miejsc: ");
                        if (int.TryParse(Console.ReadLine(), out int seats)) newOffer.AvailableSeats = seats;

                        adminService.CreateOffer(newOffer);
                        Console.WriteLine($"\n[SUKCES] Dodano ofertę.");
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.Clear();
                        var offers = adminService.ReadOffers();
                        for (int i = 0; i < offers.Count; i++)
                            Console.WriteLine($"{i + 1}. {offers[i].Title} (Dostępne: {offers[i].AvailableSeats})");

                        Console.Write("\nWybierz numer oferty do usunięcia: ");
                        if (int.TryParse(Console.ReadLine(), out int delIdx) && delIdx > 0 && delIdx <= offers.Count)
                        {
                            bool success = adminService.DeleteOffer(offers[delIdx - 1].Id);
                            if (success) Console.WriteLine("Usunięto ofertę z bazy.");
                        }
                        Console.ReadKey();
                        break;

                    case "6":
                        // NOWA OPCJA: Podgląd rezerwacji
                        Console.Clear();
                        Console.WriteLine("--- REJESTR WSZYSTKICH REZERWACJI ---");
                        var bookings = adminService.ReadBookings();
                        if (!bookings.Any()) Console.WriteLine("Brak rezerwacji w systemie.");

                        foreach (var b in bookings)
                        {
                            Console.WriteLine($"[Transakcja: {b.BookingDate:yyyy-MM-dd HH:mm}] Wycieczka: {b.Offer.Title}");
                            Console.WriteLine($"   Płatnik: {b.Customer.FirstName} {b.Customer.LastName}");
                            Console.WriteLine($"   Agent: {b.Employee.FirstName} {b.Employee.LastName} (Biuro: {b.Branch.City})");
                            Console.WriteLine($"   Wartość: {b.TotalPrice} PLN | Liczba osób: {b.NumberOfPeople}\n");
                        }
                        Console.ReadKey();
                        break;

                    case "7":
                        // NOWA OPCJA: Podgląd bazy klientów przez admina (wykorzystuje klasę EmployeeService)
                        Console.Clear();
                        Console.WriteLine("--- BAZA KLIENTÓW ---");
                        var empService = new EmployeeService();
                        foreach (var c in empService.ReadCustomers())
                        {
                            Console.WriteLine($"- {c.FirstName} {c.LastName} | Tel: {c.Phone} | Email: {c.Email} | Adres: {c.ResidentialAddress}");
                        }
                        Console.ReadKey();
                        break;

                    case "0": exitAdmin = true; break;
                }
            }
        }
        static void RunEmployeeLogin()
        {
            var adminService = new AdminService();
            Console.Clear();
            Console.WriteLine("=== LOGOWANIE DO SYSTEMU SPRZEDAŻY ===");

            Console.WriteLine("Wskazówka (Konta w bazie):");
            foreach (var e in adminService.ReadEmployees())
                Console.WriteLine($"- {e.FirstName} {e.LastName} | Login: {e.Login} | Hasło: {e.Password}");

            Console.Write("\nPodaj Login: ");
            var inputLogin = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(inputLogin)) return;

            Console.Write("Podaj Hasło: ");
            string password = ReadPassword();

            var employeeService = new EmployeeService();
            var loggedInEmployee = employeeService.Authenticate(inputLogin, password);

            if (loggedInEmployee?.BranchId != null)
                RunEmployeeMenu(loggedInEmployee);
            else
            {
                Console.WriteLine("\n[BŁĄD] Zły login, hasło lub brak przypisanego biura.");
                Console.ReadKey();
            }
        }
        static void RunEmployeeMenu(Employee me)
        {
            var employeeService = new EmployeeService();
            bool exitEmployee = false;

            while (!exitEmployee)
            {
                Console.Clear();
                Console.WriteLine($"=== KONTO: {me.FirstName} {me.LastName} ===");
                Console.WriteLine("1. Przeglądaj Ofertę");
                Console.WriteLine("2. Baza Klientów (Dodaj/Przeglądaj)");
                Console.WriteLine("3. SPRZEDAŻ (Kreator Rezerwacji)");
                Console.WriteLine("4. MOJE WYNIKI (Historia sprzedaży)");
                Console.WriteLine("0. Wyloguj");
                Console.Write("\nWybór: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--- DOSTĘPNE WYCIECZKI ---");
                        var adminService = new AdminService();
                        foreach (var o in adminService.ReadOffers())
                        {
                            var ostrzezenie = o.AvailableSeats <= 5 ? "!!! OSTATNIE MIEJSCA !!!" : "";
                            Console.WriteLine($"- {o.Title} ({o.Destination}) | Termin: {o.StartDate:dd.MM.yyyy} - {o.EndDate:dd.MM.yyyy}");
                            Console.WriteLine($"  Wolne miejsca: {o.AvailableSeats} {ostrzezenie} | {o.PricePerPerson} PLN/os.\n");
                        }
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("1. Lista klientów\n2. Dodaj klienta");
                        var cChoice = Console.ReadLine();
                        if (cChoice == "1")
                        {
                            foreach (var c in employeeService.ReadCustomers())
                                Console.WriteLine($"\n- {c.FirstName} {c.LastName} | Tel: {c.Phone} | {c.Email}");
                        }
                        else if (cChoice == "2")
                        {
                            var newCust = new Customer();
                            Console.Write("Imię: "); newCust.FirstName = Console.ReadLine() ?? "";
                            Console.Write("Nazwisko: "); newCust.LastName = Console.ReadLine() ?? "";
                            Console.Write("Telefon: "); newCust.Phone = Console.ReadLine() ?? "";
                            Console.Write("Email: "); newCust.Email = Console.ReadLine() ?? "";
                            Console.Write("Adres: "); newCust.ResidentialAddress = Console.ReadLine() ?? "";

                            employeeService.CreateCustomer(newCust);
                            Console.WriteLine($"\n[SUKCES] Zapisano klienta w bazie.");
                        }
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        var offers = (new AdminService()).ReadOffers().Where(o => o.AvailableSeats > 0).ToList();
                        var customers = employeeService.ReadCustomers();

                        if (!offers.Any() || !customers.Any())
                        {
                            Console.WriteLine("Brak wolnych ofert lub klientów w bazie!");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Wybierz ofertę:");
                        for (int i = 0; i < offers.Count; i++)
                            Console.WriteLine($"{i + 1}. {offers[i].Title} (Miejsc: {offers[i].AvailableSeats}) | Termin: {offers[i].StartDate:dd.MM.yyyy}");
                        if (!int.TryParse(Console.ReadLine(), out int oIdx) || oIdx < 1 || oIdx > offers.Count) break;

                        Console.WriteLine("\nWybierz płatnika rezerwacji:");
                        for (int i = 0; i < customers.Count; i++)
                            Console.WriteLine($"{i + 1}. {customers[i].FirstName} {customers[i].LastName}");
                        if (!int.TryParse(Console.ReadLine(), out int cIdx) || cIdx < 1 || cIdx > customers.Count) break;

                        Console.Write("\nLiczba osób: ");
                        if (!int.TryParse(Console.ReadLine(), out int peopleCount)) peopleCount = 1;

                        try
                        {
                            var booking = new Booking
                            {
                                OfferId = offers[oIdx - 1].Id,
                                CustomerId = customers[cIdx - 1].Id,
                                EmployeeId = me.Id,
                                BranchId = me.BranchId!.Value,
                                NumberOfPeople = peopleCount,
                                TotalPrice = offers[oIdx - 1].PricePerPerson * peopleCount
                            };

                            var savedBooking = employeeService.CreateBooking(booking);
                            Console.WriteLine($"\n[SUKCES] Zarezerwowano {peopleCount} miejsc!");
                            Console.WriteLine($"ID Transakcji: {savedBooking.Id}");
                            Console.WriteLine($"Do zapłaty: {savedBooking.TotalPrice} PLN");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\n[BŁĄD] {ex.Message}");
                        }
                        Console.ReadKey();
                        break;

                    case "4":
                        // NOWA OPCJA: Pracownik widzi tylko swoje rezerwacje
                        Console.Clear();
                        Console.WriteLine("--- MOJE SPRZEDANE REZERWACJE ---");
                        var adminSvc = new AdminService();

                        // Używamy LINQ do przefiltrowania listy po ID aktualnie zalogowanego pracownika
                        var myBookings = adminSvc.ReadBookings().Where(b => b.EmployeeId == me.Id).ToList();

                        if (!myBookings.Any()) Console.WriteLine("Nie masz jeszcze żadnych sprzedanych wycieczek.");

                        foreach (var b in myBookings)
                        {
                            Console.WriteLine($"- {b.BookingDate:dd.MM.yyyy} | {b.Offer.Title} | Klient: {b.Customer.FirstName} {b.Customer.LastName} | {b.TotalPrice} PLN");
                        }
                        Console.ReadKey();
                        break;

                    case "0": exitEmployee = true; break;
                }
            }
        }


        static string ReadPassword()
        {
            string pass = string.Empty;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass.Substring(0, (pass.Length - 1));
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }
    }
}