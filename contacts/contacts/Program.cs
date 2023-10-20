using inputLibrary;
using contacts.classes;
namespace contacts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ile adresów chcesz wprowadzić?");
            int howmany = inputLibrary.Int.int_input();
            Address address1 = new Address();
            Person person1 = new Person();
            Console.Write("Podaj imie: ");
            string firtstName = inputLibrary.String.string_input();
            Console.Write("Podaj nazwisko: ");
            string lastName = inputLibrary.String.string_input();
            Console.Write("Podaj Ulice: ");
            string street = inputLibrary.String.string_input();
            Console.Write("Podaj numer domu: ");
            string houseNumber = inputLibrary.String.string_input();
            Console.Write("Podaj numer mieszkania: ");
            string ApartmentNumber = Console.ReadLine();
            Console.Write("Podaj kod pocztowy: ");
            string zipcode = inputLibrary.String.string_input();
            Console.Write("Podaj miasto: ");
            string city = inputLibrary.String.string_input();
            Console.Write("Podaj kraj: ");
            string country = inputLibrary.String.string_input();
            address1.SetAddress(street, houseNumber, ApartmentNumber, zipcode,city, country);
            person1.SetData(firtstName, lastName, address1);
            Console.WriteLine(person1.Introduce());
        }
    }
}