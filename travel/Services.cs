using Microsoft.EntityFrameworkCore;
using TravelAgencyApp.Data;
using TravelAgencyApp.Entities;

namespace TravelAgencyApp.Services
{
    // --- SERWIS ADMINISTRATORA ---
    public class AdminService
    {
        public Branch CreateBranch(Branch branch)
        {
            using var db = new AppDbContext();
            db.Branches.Add(branch);
            db.SaveChanges();
            return branch;
        }

        public List<Branch> ReadBranches()
        {
            using var db = new AppDbContext();
            return db.Branches.Include(b => b.Employees).ToList();
        }

        public Employee CreateEmployee(Employee employee)
        {
            using var db = new AppDbContext();

            // Auto-generowanie loginu
            string fPart = employee.FirstName.Length >= 2 ? employee.FirstName.Substring(0, 2) : employee.FirstName;
            string lPart = employee.LastName.Length >= 2 ? employee.LastName.Substring(0, 2) : employee.LastName;
            string idPart = employee.Id.ToString().Substring(0, 2);
            employee.Login = (fPart + lPart + idPart).ToLower();

            db.Employees.Add(employee);
            db.SaveChanges();
            return employee;
        }

        public List<Employee> ReadEmployees()
        {
            using var db = new AppDbContext();
            return db.Employees.Include(e => e.Branch).ToList();
        }

        public Offer CreateOffer(Offer offer)
        {
            using var db = new AppDbContext();
            db.Offers.Add(offer);
            db.SaveChanges();
            return offer;
        }

        public List<Offer> ReadOffers()
        {
            using var db = new AppDbContext();
            return db.Offers.ToList();
        }

        public bool DeleteOffer(Guid id)
        {
            using var db = new AppDbContext();
            var offer = db.Offers.Find(id);
            if (offer == null) return false;

            db.Offers.Remove(offer);
            db.SaveChanges();
            return true;
        }

        public List<Booking> ReadBookings()
        {
            using var db = new AppDbContext();
            return db.Bookings
                     .Include(b => b.Offer)
                     .Include(b => b.Customer)
                     .Include(b => b.Employee)
                     .Include(b => b.Branch)
                     .ToList();
        }
    }

    // --- SERWIS PRACOWNIKA ---
    public class EmployeeService
    {
        public Employee? Authenticate(string login, string password)
        {
            using var db = new AppDbContext();
            return db.Employees.Include(e => e.Branch)
                     .FirstOrDefault(e => e.Login == login && e.Password == password);
        }

        public Customer CreateCustomer(Customer customer)
        {
            using var db = new AppDbContext();
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer;
        }

        public List<Customer> ReadCustomers()
        {
            using var db = new AppDbContext();
            return db.Customers.ToList();
        }

        public Booking CreateBooking(Booking booking)
        {
            using var db = new AppDbContext();

            var offer = db.Offers.Find(booking.OfferId);
            if (offer == null) throw new Exception("Oferta nie istnieje.");
            if (offer.AvailableSeats < booking.NumberOfPeople)
                throw new Exception($"Brak miejsc! Dostępne: {offer.AvailableSeats}");

            // Zmniejszenie liczby wolnych miejsc
            offer.AvailableSeats -= booking.NumberOfPeople;
            db.Offers.Update(offer);

            db.Bookings.Add(booking);
            db.SaveChanges();
            return booking;
        }
    }
}