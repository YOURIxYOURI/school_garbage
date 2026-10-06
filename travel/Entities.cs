namespace TravelAgencyApp.Entities
{
    public class Branch
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }

    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal Salary { get; set; }

        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Guid? BranchId { get; set; }
        public Branch? Branch { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }

    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ResidentialAddress { get; set; } = string.Empty;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }

    public class Offer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public decimal PricePerPerson { get; set; }

        // Cechy w czasie dotyczące samej wycieczki
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string TransportType { get; set; } = "Samolot";
        public int AvailableSeats { get; set; }
    }

    public class Booking
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        // Moment "kliknięcia" i zawarcia umowy w biurze
        public DateTime BookingDate { get; set; } = DateTime.Now;

        public int NumberOfPeople { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid OfferId { get; set; }
        public Offer Offer { get; set; } = null!;

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public Guid BranchId { get; set; }
        public Branch Branch { get; set; } = null!;
    }
}