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
            sum_of_list(12, 32, 15, 90);
            Console.WriteLine("enter N you want to print string of prime numbers until primed of N: ");
            int primeTillN = int.Parse(Console.ReadLine());
            Print_prime_numer_until_n(primeTillN);
            Console.WriteLine("enter N you want to print string of prime numbers below Nth primed number(s): ");
            int primeBelowN = int.Parse(Console.ReadLine());
            Print_prime_numer_below_n(primeBelowN);
            Console.WriteLine("enter number you want to factor: ");
            int factor = int.Parse(Console.ReadLine());
            factorial_recursion(factor);
            Console.WriteLine("enter number you want to check if it is primed or not: ");
            int prime = int.Parse(Console.ReadLine());
            Console.Write(prime_number(prime));
            Console.WriteLine(Maximum_of_three(5,7,8));
            Console.WriteLine(Maximum_of_many(12, 32, 15, 36, 40)); 
            Console.WriteLine("enter string you want to reverse");
            string start_string = Console.ReadLine();
            reverse_string(start_string);
            Console.WriteLine("input number you want to check if it is perfect or not: ");
            int number = int.Parse(Console.ReadLine());
            bool checkperfect = check_perfect(number);
            if (checkperfect == true) 
            {
                Console.WriteLine("this is a perfect number");
            }
            else Console.WriteLine("this is not a PERFECT number");
            print_perfect_from_1_1000();
            Console.WriteLine("Input string to check for pangrams: ");
            string InputString = Console.ReadLine();
            bool checkpangram = IsPangram(InputString);
            if (checkpangram == true)
            {
                Console.WriteLine("this is a pangram");
            }
            else Console.WriteLine("this is NOT a pangram");
        }
        static float sum_of_list(params float[] List_of_number)
        {
            float sum = 0;
            foreach (int i in List_of_number)
            {
                sum+=List_of_number[i];
            }
            return sum;
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
        static void reverse_string(string start_string)
        {  
            char[] characters = start_string.ToCharArray();
            Array.Reverse(characters);
            foreach (char chars in characters)
            {
                Console.Write(chars);
            }
        }
        static bool check_perfect(int number)
        {
            int sum = 0;
            for (int i=1; i < number;i++)
            {
                if (number % i ==0)
                {
                    sum+=i;
                }
            }
            if (sum == number)
                return true;
            else return false;
        }
        static void print_perfect_from_1_1000()
        {
            for(int i=1; i<=10000; i++)
            {
                if(check_perfect(i))
                    Console.WriteLine(i);
            }
        }
        static bool IsPangram(string InputString)
        {
            InputString = InputString.ToLower();
            for (int i = 0; i < 26; i++) 
            {
            char c = Convert.ToChar(i + 97);
                if (!InputString.Contains(c)) 
                {
                return false;
                }
            }
            return true;
        }
    }
}