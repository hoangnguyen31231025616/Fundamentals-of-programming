using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2
{
    internal class Bai_tap_multiarray1
    {
        public static void Ma4in(string[] args)
        {
            Console.Write("Enter the number of rows: ");
            int rows = int.Parse(Console.ReadLine());
            int[][] a = new int[rows][];
            while (true)
            {
                int sel = menu();
                switch (sel)
                {
                    case 0: Console.WriteLine("Bye"); return;
                    case 1: InputRandom(a, rows); break;
                    case 2: PrintArray(a); break;
                    case 3: Max(a, rows); break;
                    case 4: Sort(a); break;
                    case 5: PrintPrime(a); break;
                    case 6:
                       {
                         Console.WriteLine("The number u want to search: ");
                         int ele = int.Parse(Console.ReadLine());
                         Check_And_Print(a, ele);
                         break;
                       }
                }
            }
        }
        static void InputRandom(int[][] a, int rows)
        {
            Random rnd = new Random();
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Enter the number of columns for row {i}: ");
                int cols = int.Parse(Console.ReadLine());
                a[i] = new int[cols];
                for (int j = 0; j < a[i].Length; j++)
                {
                    a[i][j] = rnd.Next(0, 50);
                }
            }
        }
        static int[][] InputFromUser(int[][] a, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Enter the columns for row {i}: ");
                int cols = int.Parse(Console.ReadLine());
                a[i] = new int[cols];
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write($"Enter the {j} column in row {i}: ");
                    int n = int.Parse(Console.ReadLine());
                    a[i][j] = n;
                }
            }
            return a;
        }
        static void PrintArray(int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write($"\t{a[i][j]}");
                }
                Console.WriteLine();
            }
        }
        static void Max(int[][] a, int rows)
        {
            int[] maxrows = new int[rows];
            for (int i = 0; i < a.Length; i++)
            {
                int max = a[i][0];
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (a[i][j] > max)
                    {
                        max = a[i][j];
                    }
                }
                Console.WriteLine($"The biggest number of row {i}: {max} ");
                maxrows[i] = max;
            }
            int maxarray = maxrows[0];
            for (int i = 0; i < rows; i++)
            {
                if (maxrows[i] > maxarray)
                {
                    maxarray = maxrows[i];
                }
            }
            Console.WriteLine($"The biggest number of array: {maxarray}");
        }

        static void BubbleSort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
        }
            static void Sort(int[][] a)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = 0; j < a[i].Length; j++)
                    {
                        BubbleSort(a[i]);
                    }
                }
                PrintArray(a);
            }
        static bool CheckPrime(int a)
        {
            if (a < 2)
            {
                return false; 
            }
            for (int i = 2; i <= a / 2; i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static void PrintPrime(int[][] a)
        {
            int n = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (CheckPrime(a[i][j]))
                    {
                        Console.WriteLine($"{a[i][j]} appears at row [{i}] column [{j}]");
                        n++;
                    }
                }
            }
            if (n == 0)
            Console.WriteLine("No exist prime number!");
        }
        static void Check_And_Print(int[][] a, int ele)
        {
            int n = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (ele == a[i][j])
                    {
                       Console.WriteLine($"{ele} appears at row [{i}] column [{j}]");
                        n++;
                    }
                }
            }
            if (n == 0)
            {
                Console.WriteLine("The number doesn't exist in the array");
            } 
        }

            static int menu()
            {
                Console.WriteLine("\t\t\t\t\tMENU!!!");
                Console.WriteLine("Choose 1 - 3: ");
                Console.WriteLine("0.Exit");
                Console.WriteLine("1. Random");
                Console.WriteLine("2. Print");
                Console.WriteLine("3. Max");
                Console.WriteLine("4. Sort ASC");
                Console.WriteLine("5.Check Prime");
                Console.WriteLine("6.Check and Print");
                Console.Write("The number u wanna choose: ");
                int sel = 0;
                while (true)
                {
                    bool c = int.TryParse(Console.ReadLine(), out sel);
                    if (c && sel >= 0 && sel <=6)
                    {
                        break;
                    }
                    else { Console.WriteLine("Please enter again!"); }
                }
                return sel;
            }
        }
    }