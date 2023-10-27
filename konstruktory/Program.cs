using System.ComponentModel.Design;

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
            public void Drive(int driveDistance)
            {
                Console.WriteLine("Jadę!");
                int sleepTime = driveDistance * 100;
                Thread.Sleep(sleepTime);
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
            public void working(int DriveDstance)
            {
                double fuelLeft = FuelAmaount - (4 * Capacity / 100) * DriveDstance;
                if (fuelLeft < 0)
                    throw new Exception("Za mało paliwa!");
                FuelAmaount = fuelLeft;
                Console.WriteLine("Jestem!");
            }
        }
        static void menu()
        {
            Console.WriteLine("Co chesz zrobić: "); int choose = inputLibrary.Int.restricted_int_input(1, 2);
            switch (choose)
            {
                case 0: Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {            
            Console.Write("Podaj markę auta: ");
            string brand = inputLibrary.String.string_input();
            Console.Write("Podaj model auta: ");
            string model = inputLibrary.String.string_input();

            Console.Write("Podaj pojemność silnika w L: ");  int engineCapacity = inputLibrary.Int.restricted_int_input(0, int.MaxValue);
            Console.Write("Podaj ilość paliwa w L: ");  int amaountOfFuel = inputLibrary.Int.restricted_int_input(0, int.MaxValue);
            Console.Write("Podaj pojemność baku w L: "); int tankCapacity = inputLibrary.Int.restricted_int_input(0, int.MaxValue);

            Engine k = new Engine(engineCapacity, amaountOfFuel, tankCapacity);

            Console.Write("Podaj odległość do przejechania: "); int driveDistance = inputLibrary.Int.restricted_int_input(0, int.MaxValue);

            Car c = new Car(brand, model, k);
            c.Drive(driveDistance);

            Console.WriteLine("Pozostało paliwa " + k.FuelAmaount);

            menu();

        }
    }
}