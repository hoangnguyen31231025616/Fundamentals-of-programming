using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalCSharp
{
    internal class Method
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("input string: ");
            string Input = Console.ReadLine();
            InputAndPrint(Input);
            int LengthString = LengthOfString(Input);
            Console.WriteLine(LengthString);
            SeperateCharacters(Input);
            Console.WriteLine();
            string reversed_string = ReverseString(Input);
            InputAndPrint(reversed_string);
            int word_counter = CountWord(Input);
            Console.Write("number of word(s) in string: "+ word_counter + "\n");
        }
        static string InputAndPrint(string Input)
        {
            Console.Write("here your string: "+ Input +"\n");
            return Input;
        }
        static int LengthOfString(string Input)
        {
            int count = 0;
            foreach (char i in Input)
            {
                count++;
            }
            return count;
        }
        static void SeperateCharacters(string Input)
        {
            for (int i = 0; i < Input.Length; i++)
            {
                Console.Write(Input[i] +" ");
            }
        }
        static string ReverseString(string Input)
        {
            string Output = string.Empty;
            for (int i = Input.Length - 1; i >=0; i--)
            {
                Output += Input[i];
            }
            return Output;
        }
        static int CountWord(string Input)
        {
            int startnum = 0;
            int wordnum = 1;
            Input = Input.Trim();
            if (string.IsNullOrEmpty(Input))
            while (startnum <= Input.Length - 1)
            {
                if (Input[startnum] == ' ' || Input[startnum] == '\n' || Input[startnum] == '\t' )
                {
                    wordnum++;
                }
                startnum ++;
            }
            return wordnum;
        }
    }
}