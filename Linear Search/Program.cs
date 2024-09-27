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
            int[] numbers = new int[10];
            InputArry(numbers);
            BubbleSort(numbers);
            Console.Write("the array you put in: ");
            PrintArray(numbers);
            Console.WriteLine("input sentence: ");
            string sentence = Console.ReadLine();
            Console.WriteLine("input words: ");
            string word = Console.ReadLine();
            if(!SearchLinear(sentence, word))
                Console.WriteLine("The words doesn't exist in this sentence");
            else
                Console.WriteLine("The words exists in this sentence");
        }
        static int[] InputArry(int[] numbers)
        {
            
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"input number for index {i}: \n");
                bool res = int.TryParse(Console.ReadLine(), out numbers[i]);
                if (res == false)
                {
                    Console.Write("wrong format, enter again: \n");
                    i--;
                } 
            }
            return numbers;
        }
        static int[] BubbleSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j+1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            return numbers;
        }
        static void PrintArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]+" ");
            }
            Console.WriteLine();
        }
        static bool SearchLinear(string sentence, string word)
        {
            char[] s = sentence.ToCharArray();
            char[] w = word.ToCharArray();
            for (int i = 0; i <= s.Length - w.Length; i++)
            {
                bool find = true;
                for (int j = 0; j < w.Length; j++)
                {
                    if (s[i + j] != w[j] && char.ToLower(s[i + j]) != char.ToLower(w[j]))
                    {
                        find = false;
                        break;
                    }
                    if (find)
                    {
                        return true;
                    }

                }
            }
            return false;
        }
    }
}