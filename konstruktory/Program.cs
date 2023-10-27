using System.ComponentModel.Design;
using System.Threading;
using System;

namespace konstruktory
{
    internal class Program
    {
        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public Engine Engine { get; set; }
            public Car (string  Brand, string Model, Engine engine)
            {
                this.Brand = Brand;
                this.Model = Model;
                this.Engine = engine;
            }
            public void Drive(double driveDistance)
            {
                Console.WriteLine("Jadę!");
                int sleepTime = Convert.ToInt32(driveDistance * 100);
                carAnimation.carAnimation.animation(sleepTime);
                Engine.working(driveDistance);
            }
            public void Refuel(int refuelAmount)
            {
                if (Engine.FuelTankCapacity < Engine.FuelAmaount + refuelAmount)
                    throw new Exception("Za dużo paliwa!");
                Engine.FuelAmaount += refuelAmount;
            } 
        }
        class Engine
        {
            public double Capacity { get; set; }
            public double FuelAmaount { get; set; }
            public double FuelTankCapacity { get; } = 50.0;
            public Engine(double capacity, double FuelAmaount) 
            { 
                this.Capacity = capacity;
                this.FuelAmaount = FuelAmaount;
                this.FuelTankCapacity = 40;
            }
            public Engine(double capacity, double FuelAmaount, double tankCapacity):this(capacity,FuelAmaount)
            {
                this.FuelTankCapacity = tankCapacity;
            }
            public void working(double DriveDstance)
            {
                double fuelLeft = FuelAmaount - (4 * Capacity / 100) * DriveDstance;
                if (fuelLeft < 0)
                    throw new Exception("Za mało paliwa!");
                FuelAmaount = fuelLeft;
                Console.WriteLine("Jestem!");
            }
        }
        static void menu(Car c, Engine k)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Ilość paliwa w baku: " + k.FuelAmaount);
                Console.WriteLine("1. Podróż\n2. Tankowanie\n3. Wyjście");
                Console.Write("Co chesz zrobić: "); int choose = inputLibrary.Int.restricted_int_input(1, 3);
                if (choose == 3) break;
                switch (choose)
                {
                    case 1: Console.Write("Podaj dystans podróży w km: "); double driveDistance = inputLibrary.Double.restricted_double_input(0, double.MaxValue); c.Drive(driveDistance); break;
                    case 2: Console.WriteLine("Ilość paliwa: " + k.FuelAmaount + ", pojemność baku: " + k.FuelTankCapacity); break;
                }
                Console.Clear();
            } while (true);

        }
        static void Main(string[] args)
        {            
            Console.Write("Podaj markę auta: ");
            string brand = inputLibrary.String.string_input();
            Console.Write("Podaj model auta: ");
            string model = inputLibrary.String.string_input();

            Console.Write("Podaj pojemność silnika w L: ");  double engineCapacity = inputLibrary.Double.restricted_double_input(0, double.MaxValue);
            Console.Write("Podaj ilość paliwa w L: "); double amaountOfFuel = inputLibrary.Double.restricted_double_input(0, double.MaxValue);
            Console.Write("Podaj pojemność baku w L: "); double tankCapacity = inputLibrary.Double.restricted_double_input(0, double.MaxValue);

            Engine k = new Engine(engineCapacity, amaountOfFuel, tankCapacity);
            Car c = new Car(brand, model, k);

            menu(c, k);

        }
    }
}