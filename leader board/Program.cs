using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalCSharp
{
    internal class trò_chơi_đoán_số
    {
        public static void Main(string[] args)
        {
            object[,] matrix1 = new object[5, 2];

            for (int i = 0; i < 5; i++)
            {
                    for (int j = 0; j < 2; j++)
                    {
                        matrix1[i, j] = Console.ReadLine();  
                    }
            }
            for (int a = 0; a < 10; a++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.WriteLine("Element({0},{1})={2}", i, j, matrix1[i, j]);
                    }
                }
            }
            Console.Clear();
        }
    }
}