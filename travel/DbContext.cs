using Microsoft.EntityFrameworkCore;
using TravelAgencyApp.Entities;

namespace TravelAgencyApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Branch> Branches { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Offer> Offers { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=travel_agency.sqlite");
        }
    }

    public static class DatabaseSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (db.Branches.Any()) return;

            var branch1 = new Branch { City = "Warszawa", Address = "Al. Jerozolimskie 50/2", PostalCode = "00-024" };
            db.Branches.Add(branch1);

            db.Employees.Add(new Employee
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                FirstName = "Jan",
                LastName = "Kowalski",
                PhoneNumber = "555-111-222",
                Position = "Starszy Specjalista",
                Salary = 6500.00m,
                Login = "jako11", // Wygenerowany testowy login
                Password = "admin",
                Branch = branch1
            });

            db.Offers.Add(new Offer
            {
                Title = "Tydzień w Paryżu",
                Destination = "Francja",
                PricePerPerson = 3000,
                StartDate = DateTime.Now.AddDays(30),
                EndDate = DateTime.Now.AddDays(37),
                TransportType = "Samolot",
                AvailableSeats = 20
            });

            db.Offers.Add(new Offer
            {
                Title = "Weekend w Pradze",
                Destination = "Czechy",
                PricePerPerson = 800,
                StartDate = DateTime.Now.AddDays(14),
                EndDate = DateTime.Now.AddDays(17),
                TransportType = "Autokar",
                AvailableSeats = 5
            });

            db.Customers.Add(new Customer { FirstName = "Anna", LastName = "Nowak", Phone = "123456789", Email = "anna@test.pl", ResidentialAddress = "ul. Wesoła 2, Kraków" });

            db.SaveChanges();
        }
    }
}