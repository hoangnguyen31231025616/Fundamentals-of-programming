using System;
using System.Collections.Generic;
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
            Console.Write("Input the size of the array: ");
            int count = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[count];
            Random rng = new Random();
            Console.Write("array: ");
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rng.Next(100);
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine(numbers[1]);
            double average = AverageArray(numbers);
            Console.WriteLine($"average of array: {average}");
            Console.Write("Input value you want to check in array: ");
            int value = Convert.ToInt32(Console.ReadLine());
            bool SpecificValue = TestIfSpecificValue(numbers,value);
            if (SpecificValue == true)
            {
                Console.WriteLine("this value exists in this array ");
            }
            else Console.WriteLine("this value DOES NOT exist in this array ");
            Console.Write("input value you want to check for index: ");
            int index = Convert.ToInt32(Console.ReadLine());
            int CheckForIndex = FindIndexOfArray(numbers, index);
            if (CheckForIndex == -1)
            {
                Console.WriteLine("this contain does NOT contain such value");
            }
            else Console.WriteLine($"this value is at {CheckForIndex} index");
            Console.Write("input value to delete: ");
            int value_to_delete = Convert.ToInt32(Console.ReadLine());
            int[] changed_numbers = RemoveSpecificElement(ref numbers, value_to_delete);   
            Console.Write(changed_numbers);
        }
        static double AverageArray(int[] numbers)
        {
            double average;
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            average = sum/numbers.Length;
            return average;
        }
        static bool TestIfSpecificValue(int[] numbers, int value)
        {
            for(int i=0; i< numbers.Length; i++)
            {
                if (numbers[i] == value)
                {
                    return true;
                }
            }
        return false;
        }
        static int FindIndexOfArray(int[] numbers, int value)
        {

            for(int i = 0 ; i < numbers.Length; i++)
            {
                if (numbers[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }
        static int[] RemoveSpecificElement(ref int[] numbers, int value)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == value)
                {
                    for (int j = i; j < numbers.Length; j++)
                    numbers[j] = numbers[j+1];
                }
                Array.Resize(ref numbers, numbers.Length-1);
                i--;
            }
            return numbers;
        }
    }
}
