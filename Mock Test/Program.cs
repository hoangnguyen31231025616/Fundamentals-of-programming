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
            //Console.Write("nhap so a: \n");
            //int a = Convert.ToInt16(Console.ReadLine());
            //Console.Write("nhap so b: \n");
            //int b = Convert.ToInt16(Console.ReadLine());
            //int ucln = UCLN(a, b);
           // int bcnn = BCNN(a, b, ucln);
            //Console.Write($"UCLN: {ucln} \n");
            //Console.Write($"BCNN {bcnn}");
            //Console.Write("Enter a string :");
            //string str = Console.ReadLine();
            Console.Write("enter N: \n");
            int StringLenth = Convert.ToInt16(Console.ReadLine());
            int[] Numbers = new int[StringLenth];
            InputArray(Numbers);
            int sum = SumRevered(Numbers);
            Console.Write($"sum reversed: {sum}");
        }
        static int[] InputArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Input number at index {i}: ");
                bool res = int.TryParse(Console.ReadLine(), out numbers[i]);
                if (!res)
                {
                    Console.Write($"Wrong format, Input number at index {i}: ");
                    i--;
                }
            }
            return numbers;
        }
        static int UCLN(int a, int b)
        {
             int UCLN = 0;
            for (int i = 1; i < a && i < b; i++)
            {
                if(a % i == 0 && b % i == 0)
                {
                    UCLN = i;
                }
            }
            return UCLN;
        }
        static int BCNN(int a, int b, int UCLN)
        {
            int BCNN = (a*b)/UCLN; 
            return BCNN;
        }
        static void CountLetterAndNumber(string str)
        {
            int SumL = 0;
            int SumN = 0;
            int SumS = 0;
            int Sum = 0;
            char[] strArray = str.ToCharArray();
            foreach (var item in strArray)
            {
                if (char.IsDigit(item))
                    SumN++;
                if (char.IsLetter(item))
                    SumL++;
                if (!char.IsLetterOrDigit(item))
                    SumS++;
                Sum++;
            }
            Console.WriteLine("Total Characters In String : "+Sum);
            Console.WriteLine("Total Letter Character String : "+SumL);
            Console.WriteLine("Total Digit Character String : "+SumN);
            Console.WriteLine("Total Special Character String : "+SumS);
        }
        static int reversed_number(int number)
        {
            int reverse = 0;
            while ( number > 0)
                {
                    int remainder = number % 10;
                    reverse = (reverse * 10) + remainder;
                    number = number / 10;
                }
            Console.WriteLine(reverse);
            return reverse;
        }
        static int SumRevered(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] >50 && numbers[i] <100 && numbers[i]%2==1) 
                sum+=reversed_number(numbers[i]);
            }
            return sum;
        }
    }
}