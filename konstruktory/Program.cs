using System.ComponentModel.Design;
using System.Threading;
using System;
using myMath = System.Math;

namespace konstruktory
{
    internal class Program
    {
        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public double FuelAmaount { get; set; }
            public double FuelTankCapacity { get; set; }
            public double Capacity { get; set; }
            public Car (string  Brand, string Model, double capacity, double FuelAmaount, double tankCapacity)
            {
                this.Brand = Brand;
                this.Model = Model;
                this.Capacity = capacity;
                this.FuelAmaount = FuelAmaount;
                this.FuelTankCapacity = tankCapacity;
            }
            public void Drive(int driveDistance)
            {
                double fuelLeft = FuelAmaount - (4 * Capacity / 100) * driveDistance;
                if (fuelLeft < 0)
                    throw new Exception("Za mało paliwa!");
                int driveTime = driveDistance * 100;
                carAnimation.carAnimation.animation(driveTime);
                FuelAmaount = fuelLeft;
            }
            public void Refuel(int refuelAmount)
            {
                if (FuelTankCapacity < FuelAmaount + refuelAmount)
                    throw new Exception("Za dużo paliwa!");
                FuelAmaount += refuelAmount;
            } 
        }
        static void main_menu(Car[] cars)
        {
            string nick = "";
            if (String.IsNullOrEmpty(nick))
            {
                Console.Clear();
                Console.Write("Podaj swój nick: ");
                nick = inputLibrary.String.string_input();
            }
            do
            {
                Console.Clear();
                Console.WriteLine($"Witaj, {nick}!");
                Console.WriteLine("1. Wybierz samochód z listy\n2. Stwórz nowy samochód");
                Console.Write("Co chesz zrobić: "); int choose = inputLibrary.Int.restricted_int_input(1, 2);
                switch (choose)
                {
                    case 1: car_list(cars); break;
                    case 2: car_make(); break;
                }

            } while (true);
        }
        static void game_menu(Car c)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Ilość paliwa w baku: " + c.FuelAmaount);
                Console.WriteLine("1. Podróż\n2. Tankowanie\n3. Wyjście");
                Console.Write("Co chesz zrobić: "); int choose = inputLibrary.Int.restricted_int_input(1, 3);
                if (choose == 3) break;
                switch (choose)
                {
                    case 1: Console.Write("Podaj dystans podróży w km: "); int driveDistance = inputLibrary.Int.restricted_int_input(0, int.MaxValue); c.Drive(driveDistance); break;
                    case 2: Console.WriteLine("Ilość paliwa: " + c.FuelAmaount + ", pojemność baku: " + c.FuelTankCapacity); break;
                }
                Console.Clear();
            } while (true);
        }
        static void car_make()
        {
            Console.Clear();
            Console.Write("Podaj markę auta: ");
            string brand = inputLibrary.String.string_input();
            Console.Write("Podaj model auta: ");
            string model = inputLibrary.String.string_input();

            Console.Write("Podaj pojemność silnika w litrach: "); double engineCapacity = inputLibrary.Double.restricted_double_input(0, double.MaxValue);
            Console.Write("Podaj ilość paliwa w baku litrach: "); double amaountOfFuel = inputLibrary.Double.restricted_double_input(0, double.MaxValue);
            Console.Write("Podaj pojemność baku w litrach: "); double tankCapacity = inputLibrary.Double.restricted_double_input(0, double.MaxValue);

            Car c = new Car(brand, model, engineCapacity, amaountOfFuel, tankCapacity);
        }
        static void car_list(Car[] cars)
        {
            Console.Clear();
            for (int i = 0; i < cars.Length; i++)
            {
                if (Object.Equals(cars[i], null))
                    break;
                Console.WriteLine($"{i}.{cars[i].Brand}, {cars[i].Model}, {cars[i].Capacity}L");
            }
        }
        static void Main(string[] args)
        {
            Car[] cars = new Car[200];
            cars[0] = new Car("Audi", "A3", 1.8, 40, 40);
            cars[1] = new Car("Skoda", "Felicia", 1.1, 40, 40);
            car_list(cars);
        }
    }
}