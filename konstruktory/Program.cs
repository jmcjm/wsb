using System.ComponentModel.Design;
using System.Threading;
using System;
using System.Net.Http.Json;

namespace konstruktory
{
    internal class Program
    {
        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public double Capacity { get; set; }
            public double FuelAmaount { get; set; }
            public int FuelTankCapacity { get; set; }
            public Car (string  Brand, string Model, double capacity, double FuelAmaount, int FuelTankCapacity)
            {
                this.Brand = Brand;
                this.Model = Model;
                this.Capacity = capacity;
                this.FuelAmaount = FuelAmaount;
                this.FuelTankCapacity = FuelTankCapacity;
            }
            public void Drive(int driveDistance)
            {
                int driveTime;
                double fuelLeft = Math.Round(FuelAmaount - (4 * Capacity / 100) * driveDistance, 2);
                double how_far_can_you_go = Math.Round(FuelAmaount / (4 * Capacity / 100), 0);
                if (fuelLeft < 0)
                {
                    driveTime = Convert.ToInt32(how_far_can_you_go * 100);
                    carAnimation.carAnimation.animation(driveTime);
                    lost();
                }
                driveTime = driveDistance * 100;
                carAnimation.carAnimation.animation(driveTime);
                FuelAmaount = fuelLeft;
            }
            public void Refuel()
            {
                Console.Clear();
                Console.WriteLine($"Pojemność baku: {FuelTankCapacity}L, ilość paliwa: {FuelAmaount}L");
                Console.Write($"Ile paliwa chcesz zatankować (max {FuelTankCapacity - FuelAmaount}): ");
                double refuelAmount = inputLibrary.Double.restricted_double_input(0, FuelTankCapacity - FuelAmaount);
                FuelAmaount += refuelAmount;
            } 
        }
        static void main_menu(List<Car> carsList, string arg)
        {
            if (arg == "newGame")
                Console.Write("Podaj swój nick: "); string nick = inputLibrary.String.string_input();
            do
            {
                Console.Clear();
                Console.WriteLine($"Witaj, {nick}\nWybierz samochód którym chcesz się dziś przejechać!\n");
                Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("1. Stwórz nowy samochód");
                int list_lenght = 2;
                foreach (var Car in carsList)
                {
                    if (list_lenght % 2 == 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{list_lenght}. {Car.Brand} {Car.Model} {Car.Capacity}L");
                    list_lenght++;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("0. Wyjście");
                Console.ResetColor();
                Console.Write("\nWybierz samochód: "); int choose = inputLibrary.Int.restricted_int_input(0, list_lenght);
                if (choose == 0) Environment.Exit(0);
                else if (choose == 1) car_make(carsList);
                else game_menu(carsList[choose-1]);
            } while (true);
        }
        static void game_menu(Car c)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"Auto: {c.Brand} {c.Model} {c.Capacity}L\nIlość paliwa w baku: {c.FuelAmaount}L");
                Console.WriteLine("0. Wyjście\n1. Podróż\n2. Tankowanie");
                Console.Write("Co chesz zrobić: "); int choose = inputLibrary.Int.restricted_int_input(0, 2);
                if (choose == 0) break;
                switch (choose)
                {
                    case 1: Console.Write("Podaj dystans podróży w km: "); int driveDistance = inputLibrary.Int.restricted_int_input(0, int.MaxValue); c.Drive(driveDistance); break;
                    case 2: 
                        Random rnd = new Random();
                        int gasStationDistance = rnd.Next(0,50);
                        Console.WriteLine($"Najbliższa stacja jest za {gasStationDistance}km");
                        Console.ReadKey();
                        c.Drive(gasStationDistance);
                        c.Refuel(); 
                        break;
                }
                Console.Clear();
            } while (true);
        }
        static List<Car> car_make(List<Car> carsList)
        {
            Console.Clear();
            Console.Write("Podaj markę auta: "); string brand = inputLibrary.String.string_input();
            Console.Write("Podaj model auta: "); string model = inputLibrary.String.string_input();
            Console.Write("Podaj pojemność silnika w litrach: "); double engineCapacity = inputLibrary.Double.restricted_double_input(0, double.MaxValue);
            Console.Write("Podaj ilość paliwa w baku litrach: "); double amaountOfFuel = inputLibrary.Double.restricted_double_input(0, double.MaxValue);
            Console.Write("Podaj pojemność baku w litrach: "); int FuelTankCapacity = inputLibrary.Int.restricted_int_input(0, int.MaxValue);
            carsList.Add(new Car(brand, model, engineCapacity, amaountOfFuel, FuelTankCapacity));
            cars_saver(carsList);
            return carsList;
        }
        static void lost()
        {
            Console.Clear();
            Console.Write("Skończyło ci się paliwo, przegrałeś!\nNaciśnij dowolny przycisk aby powrócić do menu głownego...");
            Console.ReadKey();
            Main();
        }
        static void cars_saver(List<Car> carsList)
        {
            List<Car> saveList = new List<Car>(carsList);
            saveList.RemoveAt(0);
            saveList.RemoveAt(0);
            string json = JsonSerializer.Serialize(saveList);
            File.WriteAllText("userCars.json", json);
        }
        static List<Car> cars_reader(List<Car> carsList)
        {
            if (File.Exists("userCars.json"))
            {
                string json = File.ReadAllText("userCars.json");
                var cars = JsonSerializer.Deserialize<List<Car>>(json);
                foreach (var Car in cars)
                {
                    carsList.Add(Car);
                }
            }
            return carsList;
        }
        static void Main()
        {
            List<Car> carsList = new List<Car>();
            carsList.Add(new Car("Audi", "A3", 1.8, 40, 40));
            carsList.Add(new Car("Skoda", "Felicia", 1.1, 40, 40));
            cars_reader(carsList);
            Console.Clear();
            main_menu(carsList, "newGame");
        }
    }
}