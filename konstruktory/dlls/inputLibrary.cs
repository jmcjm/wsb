using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
                    if (var != null)
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
    public class Double
    {
        public static double double_input()
        {
            double var;
            while (true)
            {
                try
                {
                    var = double.Parse(Console.ReadLine());
                    if (var != null)
                        break;
                }
                catch (Exception)
                {
                    Console.Write("Nieodpowiedni znak, podaj liczbę: ");
                }
            }
            return var;
        }
        public static double restricted_double_input(double min, double max)
        {
            double var;
            while (true)
            {
                var = inputLibrary.Double.double_input();
                if (var <= max && var >= min)
                    break;
                Console.Write("Wprowadź liczbę z odpowiedniego przedziału: ");
            }
            return var;
        }
    }
    public class String
    {
        public static string string_input()
        {
            string var;
            while (true)
            {
                try
                {
                    var = Console.ReadLine();
                    if (var != null)
                        break;
                }
                catch (Exception)
                {
                    Console.Write("Nieodpowiedni znak!");
                }
            }
            return var;
        }
    }
}
