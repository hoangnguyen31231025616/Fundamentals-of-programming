using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalCSharp
{
    internal class bài_tập_string
    {
        public static void Main(string[] args)
        {
            baitap1();
            baitap2();
            baitap3();
            baitap4();
            baitap5();
        }
        static void baitap1()
        {
            Console.WriteLine("input a: ");
            float a = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("input b: ");
            float b = Convert.ToSingle(Console.ReadLine());
            float sum_of_ab = a+b;
            float minus_of_ab = a-b;
            float multi_of_ab = a*b;
            float division_of_ab = a/b;
            float mod_of_ab = a%b;
            Console.WriteLine($"{a} + {b} = {sum_of_ab}");
            Console.WriteLine($"{a} - {b} = {minus_of_ab}");
            Console.WriteLine($"{a} * {b} = {multi_of_ab}");
            Console.WriteLine($"{a} / {b} = {division_of_ab}");
            Console.WriteLine($"{a} mod {b} = {mod_of_ab}");
        }
        static void baitap2()
        {
            int x, y;
            Console.WriteLine("x=y^2 - 2*y +1");
            Console.WriteLine();
            for (y = -5; y <= 5; y++)
            {
                x = y * y - 2 * y + 1;
                Console.WriteLine("y = {0} ; x = ({0})² - 2*({0}) + 1 = {1}", y, x);
            }
        }
        static void baitap3()
        {
            float time_to_sec;
            Console.WriteLine("input distance (metres): ");
            float distance = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("input hour(s): ");
            float hour = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("input minute(s): ");
            float minute = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("input second(s): ");
            float second = Convert.ToSingle(Console.ReadLine());
            time_to_sec = (hour * 3600) + (minute * 60) + second;
            float kph = (distance / 1000f) / (time_to_sec / 3600f);
            float mph = kph / 1.609f;
            Console.WriteLine("Your speed in km/h is {0}", kph);
            Console.WriteLine("Your speed in miles/h is {0}", mph);
        }
        static void baitap4()
        {
            Console.WriteLine("Input radius: ");
            float R = Convert.ToSingle(Console.ReadLine());
            double V = Math.Round((4/3)*Math.PI*Math.Pow(R, 3), 2);
            Console.WriteLine($"output Volume: {V}");
        }
        static void baitap5()
        {
            Console.Write("Input a symbol: ");
            char symbol = Convert.ToChar(Console.ReadLine());
                if ((symbol == 'a') || (symbol == 'e') || (symbol == 'i') || (symbol == 'o') || (symbol == 'u'))
                    {
                    Console.WriteLine("It's a lowercase vowel.");
                    }
                else if ((symbol >= '0') && (symbol <= '9'))
                    {
                    Console.WriteLine("It's a digit.");
                    }
                else
                    {
                    Console.Write("It's another symbol.");
                    }   
        }
    }
}