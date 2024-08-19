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
            //baitap1();
            baitap2();
        }           
        static void baitap1 ()
        {
            Console.WriteLine("input C: ");
            float Celsi = Convert.ToSingle(Console.ReadLine());
            float kelvin = Celsi + 273;
            float Faren = (Celsi*18)/10+32;
            Console.WriteLine($"output Kelvin: {kelvin}");
            Console.WriteLine($"output Farenheit: {Faren}"); 
        }
        static void baitap2()
        {
            Console.WriteLine("Input radius: ");
            float R = Convert.ToSingle(Console.ReadLine());
            double S = Math.Round((4*Math.PI*Math.Pow(R, 2)), 2);
            double V = Math.Round((4/3)*Math.PI*Math.Pow(R, 3), 2);
            Console.WriteLine($"output surface: {S}");
            Console.WriteLine($"output Volume: {V}");
        }
    }
}