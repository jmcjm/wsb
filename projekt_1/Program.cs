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
            choose = inputLibrary.Int.restricted_int_input(1, 3);
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
            char[] cords = new char[9];
            int x_or_o = 0;
            for (int i = 0; i < cords.GetLength(0); i++)
            {
                cords[i] = ' ';
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Aby przerwać grę wpisz 0 jako miejsce pionowe (postęp zostanie utracony)");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (x_or_o == 0)
                {
                    Console.WriteLine
                        (" 1 | 2 | 3 \n" +
                         "-----------\n" +
                         " 4 | 5 | 6 \n" +
                         "-----------\n" +
                         " 7 | 8 | 9 ");
                }
                else
                {
                    Console.WriteLine
                        (" {0} | {1} | {2} \n" +
                         "-----------\n" +
                         " {3} | {4} | {5} \n" +
                         "-----------\n" +
                         " {6} | {7} | {8} ",
                         cords[0], cords[1], cords[2],
                         cords[3], cords[4], cords[5],
                         cords[6], cords[7], cords[8]);
                }
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
        static char[] next_move(char[] cords, char x_o)
        {
            int x, y;
            while (true)
            {
                Console.Write("Wybierz miejsce {0}: ", x_o);
                x = inputLibrary.Int.restricted_int_input(0, 9);
                if (x == 0)
                    Main();
                if (cords[x - 1] == ' ')
                {
                    cords[x - 1] = x_o;
                    break;
                }
                Console.WriteLine("Miejsce zajęte!");
            }
            return cords;
        }
        private static int win_checking(char[] cords)
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row
            if (cords[0] != ' ' && cords[0] == cords[1] && cords[1] == cords[2])
            {
                return 1;
            }
            //Winning Condition For Second Row
            else if (cords[3] != ' ' && cords[3] == cords[4] && cords[4] == cords[5])
            {
                return 1;
            }
            //Winning Condition For Third Row
            else if (cords[6] != ' ' && cords[6] == cords[7] && cords[7] == cords[8])
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            //Winning Condition For First Column
            else if (cords[0] != ' ' && cords[0] == cords[3] && cords[3] == cords[6])
            {
                return 1;
            }
            //Winning Condition For Second Column
            else if (cords[1] != ' ' && cords[1] == cords[4] && cords[4] == cords[7])
            {
                return 1;
            }
            //Winning Condition For Third Column
            else if (cords[2] != ' ' && cords[2] == cords[5] && cords[5] == cords[8])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if (cords[0] != ' ' && cords[0] == cords[4] && cords[4] == cords[8])
            {
                return 1;
            }
            else if (cords[6] != ' ' && cords[6] == cords[4] && cords[4] == cords[2])
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