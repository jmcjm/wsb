using System.ComponentModel.DataAnnotations;
using System;
namespace inputLibrary
{
    public class Int
    {
        public static int int_input()
        {
            int var;
            while (true)
            {
                try
                {
                    var = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.Write("Nieodpowiedni znak, podaj liczbę: ");
                }
            }
            return var;
        }
        public static int restricted_int_input(int min, int max)
        {
            int var;
            while (true)
            {
                var = inputLibrary.Int.int_input();
                if (var <= max && var >= min)
                    break;
                Console.Write("Wprowadź liczbę z odpowiedniego przedziału: ");
            }
            return var;
        }
    }
}