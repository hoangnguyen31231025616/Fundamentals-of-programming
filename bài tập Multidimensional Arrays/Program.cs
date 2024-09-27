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
            Console.Write("input row: \n");
            int row = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[row][];
            //string DisplayArray = FixedJaggedArray(array);
            //Console.Write(DisplayArray);
            RandomJaggedArray(row, array);
            PrintArray(array);
            Console.WriteLine("primes in array: ");
            PrintPrimeArray(array);
            SortAllArrays(array);
        }
        static void PrintArray(int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                    Console.Write(a[i][j] + "\t");
                Console.WriteLine();
            }
        }
        static string FixedJaggedArray(int[][] array)
        {
            array = new int[4][]
            {
                new int[] {1, 1, 1, 1, 1},
                new int[] {2, 2},
                new int[] {3, 3, 3},
                new int[] {4, 4}
            };
            string display = string.Empty;
            foreach(int[]row in array)
            {
                foreach(int collumn in row)
                {
                    display+= collumn + " ";
                }
                display+= "\n";
            }
            return display;
        }
        static void RandomJaggedArray(int row, int[][] array)
        {
            Random rng = new Random();
            for (int i = 0; i < row; i++)
            {
                Console.WriteLine($"Input collumn of the row {i}th: ");
                int collumn = Convert.ToInt32(Console.ReadLine());
                array[i] = new int[collumn];
                for (int j = 0; j < collumn; j++)
                    array[i][j] =rng.Next(10, 50);
            }
        }
        static bool IsPrime(int number)
        {
            int i;  
            for (i = 2; i <= number - 1; i++)  
            {  
                if (number % i == 0)  
                {
                    return false;  
                }  
            }  
            if (i == number)  
            {  
                return true;  
            }  
            return false; 
        } 
        static void PrintPrimeArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (IsPrime(array[i][j]))
                    {
                        Console.Write(array[i][j] + " ");
                    }
                }
            }
        }
        static void SortEachArray(int[] row)
        {  
            for (int i = 0; i < row.Length; i++)
            {
                for (int j = 0; j < row.Length; j++)
                {
                    if (row[i] < row[j])
                    {
                        int temp = row[i];
                        row[i] = row[j];
                        row[j] = temp;
                    }
                }
            }
        }
        static int[][] SortAllArrays(int[][] array)
        {
            for (int i=0; i < array.Length; i++)
            {
                SortEachArray(array[i]);
            }
        return array;
        } 
    }
}
