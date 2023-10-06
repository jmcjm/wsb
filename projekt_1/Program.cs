using System.ComponentModel.Design;

namespace projekt_1
{
    internal class Program
    {
        static int int_input()
        {
            int var = 0;
            return var;
        }
        static void main_menu()
        {
            int choose;
            Console.WriteLine("Menu:");
            Console.WriteLine("1) Nowa gra");
            Console.WriteLine("2) Statystyki dla gracza");
            Console.WriteLine("3) Wyjście");
            while (true)
            {
                Console.Write("Co chesz zrobić?: ");
                choose = int_input();
                switch (choose)
                {
                    1:
                        Console.WriteLine("Test");
                        break;
                    default:
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Gra kółko i krzyżyk");
            main_menu();
        }
    }
}