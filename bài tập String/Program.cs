using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalCSharp
{
    internal class bài_tập_string
    {
        public static void Main(string[] args)
        {
            //baitap1();
            //baitap2();
            baitap3();
        }
        static void baitap1()
        {
            Console.WriteLine("input string: ");
            string s = Console.ReadLine();
            Console.WriteLine("the string you entered is: "+ s);
        }
        static void baitap3()
        {
            Console.WriteLine("input string: ");
            string s = Console.ReadLine();
            var characters = s.Split('');
            Console.WriteLine(characters);
        }
        static void baitap2()
        {
            Console.WriteLine("input string: ");
            string s = Console.ReadLine();
            int numberOfLetters = 0;
            foreach (var c in s)
                {
                    numberOfLetters++;
                }
            Console.WriteLine("Length of string: "+ numberOfLetters);
        }
    }
}           