using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalCSharp
{
    internal class bài_tập_1
    {
        public static void Main(string[] args)
        {
            baitap9();
        }
        static void baitap1()
        {
            Console.Write("input a: ");
            string a = Console.ReadLine();
            int so_a = Convert.ToInt32(a);
            Console.Write("input b: ");
            string b = Console.ReadLine();
            int so_b = Convert.ToInt32(b);
            Console.WriteLine($"a+b: {so_a + so_b}");
        }

        static void baitap2()
        {
            Console.Write("input a: ");
            string var1 = Console.ReadLine();
            Console.Write("input b: ");
            string var2 = Console.ReadLine();
            (var1, var2) = (var2, var1);
            Console.WriteLine($"a will be {var1}, b will be {var2}");
        }
        static void baitap3()
        {
            Console.Write("input a: ");
            string a = Console.ReadLine();
            float so_a = Convert.ToInt32(a);
            Console.Write("input b: ");
            string b = Console.ReadLine();
            float so_b = Convert.ToInt32(b);
            Console.WriteLine($"a+b: {so_a * so_b}");
        }
        static void baitap4()
        {
            Console.Write("input length (in Feet): ");
            double feet = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"convert to meter: {feet * 0.3048}");
        }
        static void baitap5()
        {
            Console.WriteLine("how do you want to convert ");
            Console.WriteLine("F to C (1) or C to F(2): ");
            byte choice = Convert.ToByte(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("input F");
                Double Faren = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"output: {(Faren - 32) / 1.8}");
            }
            if (choice == 2)
            {
                Console.WriteLine("input C");
                Double Celsi = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"output: {(Celsi * 1.8) + 32}");
            }
        }
        static void baitap6()
        {
            Console.WriteLine("sizeof(char)     : {0}", sizeof(char)); 
            Console.WriteLine("sizeof(byte)     : {0}", sizeof(byte)); 
            Console.WriteLine("sizeof(sbyte)    : {0}", sizeof(sbyte)); 
            Console.WriteLine("sizeof(float)    : {0}", sizeof(float)); 
            Console.WriteLine("sizeof(ushort)   : {0}", sizeof(ushort)); 
            Console.WriteLine("sizeof(double)   : {0}", sizeof(double)); 
            Console.WriteLine("sizeof(int)      : {0}", sizeof(int)); 
            Console.WriteLine("sizeof(bool)     : {0}", sizeof(bool)); 
            Console.WriteLine("sizeof(short)    : {0}", sizeof(short)); 
        }
        static void baitap8()
        {
            Console.WriteLine("input R of circle: ");
            double Rad = Convert.ToDouble(Console.ReadLine());
            double Area = Math.PI*Rad*Rad;
            Console.WriteLine($"Area of circle: {Math.Truncate(Area)}");
        }
        static void baitap9()
        {
            Console.WriteLine("input side(a) of square: ");
            double a = Convert.ToDouble(Console.ReadLine());
            double Area = a*a;
            Console.WriteLine($"Area of circle: {Area}");
        }
    }
}
