using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contacts.classes
{
    internal class Address
    {
        public string Street {  get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string ZIPCode { get; set; }
        public string Country { get; set; }
        public string PostalAddress 
        {
            get
            {
                return $"Ul. {Street} {HouseNumber}/{ApartmentNumber}\n" +
                    $"{ZIPCode} {City}\n" +
                    $"{Country}";
            }
        }
        public void SetAddress(string Street, string HouseNumber, string ApartamentNumber, string City, string ZIPCode, string Country)
        {
            this.Street = Street; this.HouseNumber = HouseNumber; this.ApartmentNumber = ApartmentNumber; this.City = City; this.ZIPCode = ZIPCode; this.Country = Country;
        }
    }
}
