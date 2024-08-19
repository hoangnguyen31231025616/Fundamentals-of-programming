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
            baitap1();

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
    }
}