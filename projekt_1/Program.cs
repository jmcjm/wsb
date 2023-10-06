using System.ComponentModel.Design;

namespace projekt_1
{
    internal class Program
    {
        static int int_input()
        {
            int var;
            while (true)
            {
                try
                {
                    var = int.Parse(Console.ReadLine());
                    if (var > 0 && var < 4)
                        break;
                    Console.Write("Wybierz odpowiednią pozycje z menu: ");
                }
                catch (Exception)
                {
                    Console.Write("Wybierz odpowiednią pozycje z menu: ");
                }
            }
            return var;
        }
        static void main_menu()
        {
            int choose;
            Console.WriteLine("Menu:");
            Console.WriteLine("1) Nowa gra");
            Console.WriteLine("2) Statystyki dla gracza");
            Console.WriteLine("3) Wyjście");
            Console.Write("Co chesz zrobić?: ");
            choose = int_input();
            switch (choose)
            {
                case 1:
                    Console.Clear();
                    new_game();
                    break;
                case 2:
                    Console.Clear();
                    stats();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        static void new_game()
        {
            Console.WriteLine("huj");
            Console.ReadKey();
        }
        static void stats()
        {
            Console.WriteLine("Staty: ");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Gra kółko i krzyżyk");
            while (true)
            {
                main_menu();
                Console.Clear();
            }
        }
    }
}