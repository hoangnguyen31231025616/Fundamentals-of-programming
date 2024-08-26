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
            game_egine();
        }
        static void game_egine()
        {
            int bank_account = 1000;
            int replay_value = 0;
            Console.WriteLine($"your bank account: {bank_account}");
            do
            {
                replay_value++;
                Random rnd = new Random();
                int computer_num = rnd.Next(1, 100);
                Console.WriteLine(computer_num);
                int player_num;
                for(int i = 0; i < 5; i++)
                {
                    Console.WriteLine("input your number from 1 to 100: ");
                    player_num = Convert.ToInt32(Console.ReadLine());
                    if (player_num == computer_num)
                        {
                        Console.WriteLine("--> you win");
                        bank_account+=55;
                        break;
                        }
                        else if (player_num > computer_num)
                        Console.WriteLine("- your number is higher than computer's number");
                            else Console.WriteLine("- your number is lower than computer's number");
                        if (i == 4) 
                            {
                            Console.WriteLine("--> you lose");
                            bank_account-=50;
                            }
                }
                Console.Write("Do you want to try again? <Y/N>: ");
                string respond = "" + Console.ReadLine();
                string result = respond.ToUpper();
                if (result == "N")
                    {
                    Console.Write($"your current bank account: {bank_account}");
                    Console.ReadLine();
                    Console.Write($"you have played {replay_value} time(s)");
                    Console.ReadLine();
                    break;
                    }
            }
            while (true);
        }
    }
}