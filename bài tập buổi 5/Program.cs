using System;
using System.Collections.Generic;
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
            Console.WriteLine("enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Maximum_of_three(5,7,8));
            Console.WriteLine(Maximum_of_many(12, 32, 15, 36, 40));
            factorial_recursion(5);
            Console.Write(prime_number(5));
            Print_prime_numer_below_n(n);
            Print_prime_numer_until_n(10);
        }
        static float Maximum_of_many(float a, params float[] string_of_num)
        {
            float compare_num = string_of_num[0];
            foreach (int i in string_of_num)
            {
                if (i > compare_num) 
                {
                    compare_num = i;
                }
            }
            return Math.Max(a, compare_num);
        }
        static float Maximum_of_three(float a, float b, float c)
        {
            float max;
            if (a > b)
                if (a > c) max = a;
                else max = c;
            else if (b < c) max = c;
            else max = b;
            return max;
        }
        static long factorial_recursion(int n)
        {
            if (n == 0) return 1;
            return n*factorial_recursion(n-1);
        }
        static bool prime_number(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false; 
                }
            }
            return true;    
        }
        static void Print_prime_numer_below_n(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if(prime_number(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void Print_prime_numer_until_n(int n)
        {
            int count = 0;
            int number = 1;
            while (count <= n)
            {
                if(prime_number(number))
                {
                    Console.WriteLine($"{count}: {number}");
                    count++;
                }
                number++;
            }
        }
    }
}