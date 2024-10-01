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
            //Console.Write("input value to delete: ");
            //int value_to_delete = Convert.ToInt32(Console.ReadLine());
            //int[] changed_numbers = RemoveSpecificElement(ref numbers, value_to_delete);
            //for(int i = 0; i < changed_numbers.Length; i++)
            //{
            //    Console.Write(numbers[i] + " ");
            //}
            //Console.WriteLine();
            Console.WriteLine();
            int[] temp_numbers = new int[count];
            numbers.CopyTo(temp_numbers, 0);
            MaxMinOfArray(temp_numbers);
            Console.WriteLine();
            int [] reversed_number = ReverseArray(numbers, 0, (numbers.Length-1));
            Console.Write("reversed array: ");
            PrintArray(reversed_number);
            RemoveDupe(numbers, numbers);
            
            
        }
        static void PrintArray(int[] numbers)
        {
            foreach (int i in numbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
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
                    for (int j = i; j < numbers.Length - 1; j++)
                    {
                    numbers[j] = numbers[j+1];
                    }
                    Array.Resize(ref numbers, numbers.Length-1);
                    i--;
                }
            }
            return numbers;
        }  
        static void MaxMinOfArray(int[] numbers)
        {
            BubbleSort(numbers);
            int max = numbers[0];
            int min = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)  
            {
                max = numbers[i];  
            }
            if (numbers[i] < min)  
            {
                min = numbers[i];  
            }
        }
        Console.WriteLine($"Maximum element is : {max}");
        Console.WriteLine($"Minimum element is : {min}");
        }
        static int[] ReverseArray(int[] numbers, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                int temp = numbers[startIndex];
                numbers[startIndex] = numbers[endIndex];
                numbers[endIndex] = temp;
                startIndex++;
                endIndex--;
            }
            return numbers;
        }
        static void FindDupe(int[] numbers,ref int[] temp_numbers)
        {
            int index = 0;
            Console.Write("\nThe duplicate values: \n");
            bool[] CheckPrint = new bool[100];
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {

                    if (numbers[j] == numbers[i])
                    {
                        
                        if (!CheckPrint[numbers[i]])
                        {
                            temp_numbers[index] = numbers[i];
                            index++;
                            CheckPrint[numbers[i]] = true;
                        }
                        break;
                    }
                }
            }
            Array.Resize( ref temp_numbers, index);    
            PrintArray(temp_numbers);
        }
        static void RemoveDupe(int[] numbers, int[] temp_numbers)
        {
            FindDupe(numbers,ref temp_numbers);
            for (int i = 0; i < temp_numbers.Length; i++)
            {
                RemoveSpecificElement(ref numbers,temp_numbers[i]);
            }           
            PrintArray(numbers);
        }
        static void BubbleSort(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < n-i-1; j ++)
                {
                    if (numbers[j] > numbers[j+1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
        }
        static void SelectionSort(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n; i++)
            {
                int index = i;
                int min = numbers[i];
                for (int j = i+1; j < n; j++)
                {
                    if (numbers[j] < numbers[index])
                    {
                        index = j;
                        min = numbers[j];
                    }
                }
                int temp = numbers[index];
                numbers[index] = numbers[i];
                numbers[i] = temp;
            }
        }
        static void InsertionSort(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 1; i < n ; i++)
            {
                int key = numbers[i];
                int j = i -1;
                while (i >= 0 && numbers[j] > key)
                {
                    numbers[j+1] = numbers[j];
                    j = j-1;
                }
                numbers[j+1] = key;
            }
        }
    }
}
