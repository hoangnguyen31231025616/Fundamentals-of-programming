using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalCSharp
{
    internal class bài_tập_control_flow
    {
        public static void Main(string[] args)
        {
            //baitap1();
            baitap2();
            //baitap3();
        }
        static void baitap1()
        {
            Console.WriteLine("input number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num%2 == 0)
                {
                    Console.WriteLine("this is an even number");
                }
                else Console.WriteLine("this is an odd number");
        }
        static void baitap2()
        {
            int max;
            Console.WriteLine("input number a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input number b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input number c: ");
            int c = Convert.ToInt32(Console.ReadLine());
            if (a > b)
            {
                if ( a > c ) 
                {
                    Console.WriteLine("a is the largest number");
                }
                else Console.WriteLine("c is the largest number");
            }
            else if (b > c) Console.WriteLine("b is the largest number");
            else Console.WriteLine("c is the largest number");
        }
    }
}