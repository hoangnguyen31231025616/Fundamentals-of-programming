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
            //baitap2();
            //baitap3();
            //baitap4();
            //baitap5();
            baitap6();
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
        static void baitap3()
        {
            Console.WriteLine("input point x: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input point y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            if (x>0 && y>0)
            {
                Console.WriteLine("the coordiante xy is in the 1st quadrant");
            }
            else if (x<0 && y>0) Console.WriteLine("the coordinate xt is in the 2nd quadrant");
            else if (x<0 && y<0) Console.WriteLine("the coordinate xy is in the 3rd quadrant");
            else if (x>0 && y<0) Console.WriteLine("the coordiante xy is in the 4th quadrant");
            else Console.WriteLine("the coordiante is in the center");
        }
        static void baitap4()
        {
            Console.WriteLine("input side a: ");
            double a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input side b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input side c: ");
            int c = Convert.ToInt32(Console.ReadLine());
            if (a==b || a==c || b==c )
            {
                if (a==b && b==c) Console.WriteLine("this is a Equilateral triangle");
                else Console.WriteLine("this is a  Isosceles triangle");
            }
            else Console.WriteLine("this is a Scalene triangle");
        }
        static void baitap5()
        {
            int count = 1;
            float sum = 0;
            for (count = 1; count <= 10; count++)
            {
                Console.WriteLine($"number {count}: {count}");
                sum +=count;
            }
            float avg = sum/10;
            Console.WriteLine($"sum: {sum}");
            Console.WriteLine($"average: {avg}");
        }
        static void baitap6()
        {
            Console.WriteLine("input wanted number to output multiplication table: ");
            int num = Convert.ToInt16(Console.ReadLine());
            for (int count = 1; count < 10; count++)
            {
                Console.WriteLine($"number {count}: {count*num}");
            }
        }
        static void baitap7()
        {
            
        }

    }
}