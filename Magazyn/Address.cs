using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    internal class Address
    {
        //składowe klasy Address
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }

        //konstruktor klasy Address
        public Address(string street, string postalCode, string city, string buildingNumber, string apartmentNumber)
        {
            Street = street;
            PostalCode = postalCode;
            City = city;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
        }
        //nadpisana metoda tostring zwracając ciąg znaków
        public override string ToString()
        {
            return $"{Street}, {PostalCode} {City}, Building {BuildingNumber}, Apartment {ApartmentNumber}";
        }
    }
}
