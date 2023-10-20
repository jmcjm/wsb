using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using contacts.classes;

namespace contacts.classes
{
    internal class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address Address { get; set; }
        public string FullAddress { get => $"{Address.PostalAddress}"; }
        public string Introduce()
        {
            return $"Nazywam się {FirstName} {LastName}, \nAdres: {FullAddress}";
        }

        public void SetData(string firstName, string lastName, Address address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
        }
    }
}
