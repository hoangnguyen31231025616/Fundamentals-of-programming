using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2
{
    internal class Bai_tap_buoi_6
    {
        public static void Main(string[] args)
        {
            object[][][] a = new object[3][][];
            while (true)
            {
                int sel = menu();
                switch (sel)
                {
                    case 0:Console.WriteLine("Bye");return;
                    case 1:InputData(a); break;
                    case 2:PrintArray(a); break;
                    case 3:
                        {
                            Console.WriteLine("Enter a ID u wanna search: ");
                            string ele = Console.ReadLine();
                            Search_And_Print(a, ele);
                            break;
                        }
                    case 4: MaxTask(a); break;
                    
                }
            }

        }
        static void InputData(object[][][] a)
        {
            a[0] = new object[5][];
            a[1] = new object[3][];
            a[2] = new object[6][];
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"Hay nhap du lieu cho nhom {i + 1}: ");
                for(int j = 0; j < a[i].Length; j++)
                {
                    a[i][j] = new object[3];
                    Console.WriteLine($"Thanh vien thu {j+1}:");
                    Console.Write("ID: ");
                    string id = Console.ReadLine();
                    a[i][j][0] = id;
                    Console.Write("Ten: ");
                    string name = Console.ReadLine();
                    a[i][j][1] = name;
                    Console.Write("So nhiem vu da hoan thanh: ");
                    int task = int.Parse(Console.ReadLine());
                    a[i][j][2] = task;
                }
            }

        }

        static void PrintArray(object[][][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    for (int k = 0; k < a[i][j].Length; k++)
                    {
                        Console.Write(a[i][j][k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        static void Search_And_Print(object[][][] a, string ele)
        {
            int n = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    if ((string)a[i][j][0] == ele)
                    {
                        Console.WriteLine($"ID:{ele}, Ten: {a[i][j][1]}, So nhiem vu da hoan thanh: {a[i][j][2]} ");
                        n=1;
                    }
                }
            }
            if (n == 0)
                Console.WriteLine("The ID doesn't exist in array!");
        }
        static void MaxTask(object[][][] a)
        {
            int maxtaskgroup = 0;
            int[] max_task= new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    if ((int)a[i][j][2] > maxtaskgroup)
                    {
                        maxtaskgroup=(int)a[i][j][2];
                    }
                }
                max_task[i]= maxtaskgroup;
            }
            int max = 0;
            for (int i = 0; i < max_task.Length; i++) 
            {
                
                if(max_task[i] > 0)
                        
                    
                {
                    max= max_task[i];
                }
                
            }
            Console.WriteLine("The members have the highest number of task:");
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    if ((int)a[i][j][2] == max)
                    {
                        Console.WriteLine($"ID:{a[i][j][0]}, Ten: {a[i][j][1]}, So nhiem vu da hoan thanh: {a[i][j][2]} ");                     
                    }
                }
            }

        }
        static int menu()
        {
            Console.WriteLine("\t\t\t\tMENU!!!");
            Console.WriteLine("Choose <1-6>");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Input");
            Console.WriteLine("2.Print");
            Console.WriteLine("3.SearchID");
            Console.WriteLine("4.FindMaxTask");

            int sel = 0; 
            while (true)
            {
                
                bool c = int.TryParse(Console.ReadLine(), out sel);
                if (c && sel >= 0 && sel <= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter again!");
                }
            }
            return sel;
        }
    }
}