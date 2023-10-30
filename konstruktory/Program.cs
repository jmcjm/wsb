using System.ComponentModel.Design;
using System.Threading;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace konstruktory
{
    internal class Program
    {
        class Car
        {
            public int Id { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public double FuelAmaount { get; set; }
            public int FuelTankCapacity { get; set; }
            public double Capacity { get; set; }
            public Car (int Id, string  Brand, string Model, double capacity, double FuelAmaount, int tankCapacity)
            {
                this.Id = Id;
                this.Brand = Brand;
                this.Model = Model;
                this.Capacity = capacity;
                this.FuelAmaount = FuelAmaount;
                this.FuelTankCapacity = tankCapacity;
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
                Console.WriteLine($"Witaj, {nick}!");
                Console.WriteLine("0. Wyjście\n1. Stwórz nowy samochód");
                int list_lenght = 1;
                foreach (var Car in carsList)
                {
                    Console.WriteLine($"{Car.Id+1}. {Car.Brand} {Car.Model} {Car.Capacity}L");
                }
                Console.Write("Wybierz samochód: "); int choose = inputLibrary.Int.restricted_int_input(0, list_lenght);
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
            Console.Write("Podaj pojemność baku w litrach: "); int tankCapacity = inputLibrary.Int.restricted_int_input(0, int.MaxValue);
            carsList.Add(new Car(carsList.Count+1,brand, model, engineCapacity, amaountOfFuel, tankCapacity));
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
            saveList.RemoveAt(1);
            string json = JsonSerializer.Serialize(saveList);
            File.WriteAllText("userCars.json", json);
        }
        static List<Car> cars_reader(List<Car> carsList)
        {
            if (File.Exists("userCars.json"))
            {
                string json = File.ReadAllText("userCars.json");
                var cars = JsonSerializer.Deserialize<List<Car>>(json);
                Console.WriteLine(cars.Count);
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
            carsList.Add(new Car(1, "Audi", "A3", 1.8, 40, 40));
            carsList.Add(new Car(2, "Skoda", "Felicia", 1.1, 40, 40));
            cars_reader(carsList);
            Console.Clear();
            main_menu(carsList, "newGame");
        }
    }
}