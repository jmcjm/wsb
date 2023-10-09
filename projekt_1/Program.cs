using System.ComponentModel.Design;
using System;
using inputLibrary;

namespace projekt_1
{
    internal class Program
    {
        static void main_menu()
        {
            int choose;
            Console.WriteLine("Menu:");
            Console.WriteLine("1) Nowa gra");
            Console.WriteLine("2) Statystyki dla gracza");
            Console.WriteLine("3) Wyjście");
            Console.Write("Co chesz zrobić?: ");
            choose = inputLibrary.Int.restricted_int_input(1,3);
            switch (choose)
            {
                case 1:
                    Console.Clear();
                    game();
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
        static void game()
        {
            char[,] cords = new char[3, 3];
            int x_or_o=0;
            for (int i = 0; i < cords.GetLength(0); i++)
            {
                for (int j = 0; j < cords.GetLength(1); j++)
                {
                    cords[i, j] = ' ';
                }
            }
            Console.WriteLine("Aby przerwać grę wpisz 0 jako miejsce pionowe (postęp zostanie utracony)");
            while (true) 
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine
                    (" {0} | {1} | {2} \n" +
                     "-----------\n" +
                     " {3} | {4} | {5} \n" +
                     "-----------\n" +
                     " {6} | {7} | {8} ",
                     cords[0, 0], cords[0, 1], cords[0, 2],
                     cords[1, 0], cords[1, 1], cords[1, 2],
                     cords[2, 0], cords[2, 1], cords[2, 2]);
                Console.ForegroundColor = ConsoleColor.White;
                if (win_checking(cords) == 1)
                {
                    if (x_or_o % 2 == 0)
                        Console.WriteLine("Wygrał gracz O!");
                    else
                        Console.WriteLine("Wygrał gracz X!");
                    Console.WriteLine("Naciśnij dowolny klawisz aby powrócić do menu...");
                    Console.ReadKey();
                    break;
                }
                else if (x_or_o > 8)
                {
                    Console.WriteLine("Remis!\nNaciśnij dowolny klawisz aby powrócić do menu...");
                    Console.ReadKey();
                    break;
                }
                else if (x_or_o % 2 == 0) 
                    next_move(cords, 'X');
                else 
                    next_move(cords, 'O');
                x_or_o++;
                Console.Clear();
            }
        }
        static char[,] next_move(char[,] cords, char x_o)
        {
            int x, y;
            while(true) 
            {
                Console.Write("Wybierz pionowe miejsce {0}: ", x_o);
                x = inputLibrary.Int.restricted_int_input(0, 3);
                if (x == 0)
                    Main();
                Console.Write("Wybierz poziome miejsce {0}: ", x_o);
                y = inputLibrary.Int.restricted_int_input(1, 3);
                if (cords[x - 1, y - 1] == ' ')
                {
                    cords[x - 1, y - 1] = x_o;
                    break;
                }
                Console.WriteLine("Miejsce zajęte!");
            }
            return cords;
        }
        private static int win_checking(char[,] cords)
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row
            if (cords[0, 0] != ' ' && cords[0, 0] == cords[0, 1] && cords[0, 1] == cords[0, 2])
            {
                return 1;
            }
            //Winning Condition For Second Row
            else if (cords[1, 0] != ' ' &&  cords[1, 0] == cords[1, 1] && cords[1, 1] == cords[1, 2])
            {
                return 1;
            }
            //Winning Condition For Third Row
            else if (cords[2, 0] != ' ' && cords[2, 0] == cords[2, 1] && cords[2, 1] == cords[2, 2])
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            //Winning Condition For First Column
            else if (cords[0, 0] != ' ' && cords[0, 0] == cords[1, 0] && cords[1, 0] == cords[2, 0])
            {
                return 1;
            }
            //Winning Condition For Second Column
            else if (cords[0, 1] != ' ' && cords[0, 1] == cords[1, 1] && cords[1, 1] == cords[2, 1])
            {
                return 1;
            }
            //Winning Condition For Third Column
            else if (cords[0, 2] != ' ' && cords[0, 2] == cords[1, 2] && cords[1, 2] == cords[2, 2])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if (cords[0, 0] != ' ' && cords[0, 0] == cords[1, 1] && cords[1, 1] == cords[2, 2])
            {
                return 1;
            }
            else if (cords[2, 0] != ' ' &&cords[2, 0] == cords[1, 1] && cords[1, 1] == cords[0, 2])
            {
                return 1;
            }
            #endregion
            else
                return 0;
        }
        static void stats()
        {
            Console.WriteLine("Staty: ");
            Console.ReadKey();
        }
        static void Main()
        {
            Console.WriteLine("Gra kółko i krzyżyk");
            while (true)
            {
                Console.Clear();
                main_menu();
                Console.Clear();
            }
        }
    }
}