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
            //baitap3();
            //baitap4();
            baitap5();
        }
        static void baitap1()
        {
            Console.WriteLine("input string: ");
            string s = Console.ReadLine();
            Console.WriteLine("the string you entered is: "+ s);
        }
        static void baitap3()
        {
            int startnum = 0;
            Console.Write("input string: ");
            string s = Console.ReadLine();
            while (startnum <= s.Length - 1)
            {
                Console.Write(s[startnum] + " ");
                startnum ++;
            }
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
        static void baitap4()
        {
            int startnum = 0;
            Console.Write("input string: ");
            string s = Console.ReadLine();
            char[] characters = s.ToCharArray();
            Array.Reverse(characters);
            foreach (char chars in characters)
            {
                Console.Write(chars +" ");
            }
        }
        static void baitap5()
        {
            int startnum = 0;
            int wordnum = 1;
            Console.Write("input string: ");
            string s = Console.ReadLine();
            while (startnum <= s.Length - 1)
            {
                if (s[startnum] == ' ' || s[startnum] == '\n' || s[startnum] == '\t')
                {
                    wordnum++;
                }
                startnum ++;
            }
            Console.Write("total number of words: {0}", wordnum);
        }
    }
}           