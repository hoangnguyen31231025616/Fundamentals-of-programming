using System;
using System.IO;
using System.Threading;

namespace TextBasedRoguelikeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

    class Game
    {
        private Player player;
        private Random random = new Random();
        private int totalFloorsPassed;
        private int totalDamageDealt;
        private int totalDamageReceived;
        private int totalHealingDone;
        private DateTime startTime;

        public Game()
        {
            player = new Player();
            startTime = DateTime.Now; // Track when the game starts
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("||====================================||");
            Console.WriteLine("||                                    ||");
            Console.WriteLine("||  THE WORLD'S SIMPLEST ROUGE-LIKE!  ||");
            Console.WriteLine("||                                    ||");
            Console.WriteLine("||====================================||");

            // Try-catch for username input
            try
            {
                Console.Write("Enter your username: ");
                player.Username = Console.ReadLine(); // Input for username
                if (string.IsNullOrWhiteSpace(player.Username))
                {
                    player.Username = "Unknown";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while entering your username: " + ex.Message);
                return; // Exit the game if there's an error
            }

            Console.Clear();

            int floor = 1;
            while (player.HP > 0)
            {
                ResetPlayerHealth(); // Restore HP at the start of each floor

                Console.WriteLine("+ ===================== +");
                Console.WriteLine($"||    Floor {floor}           ||");
                Console.WriteLine("+ ===================== +");

                Monster monster = new Monster(random.Next(1, 11) + floor); // Tougher monster
                Console.WriteLine($"A wild {monster.Name} appears with {monster.HP} HP!");

                Battle(monster);

                if (player.HP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have been defeated!");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    break;
                }

                totalFloorsPassed++;
                UpgradeStats();

                Console.WriteLine("Do you want to continue to the next floor? (y/n)");
                string continueChoice = Console.ReadLine();
                if (continueChoice.ToLower() != "y")
                {
                    Console.Clear();
                    break;
                }
                floor++; // Increment floor for next round
            }
            ExportGameData(); // Call to export game data
        }

        private void Battle(Monster monster)
        {
            while (monster.HP > 0 && player.HP > 0)
            {
                ShowStats(monster); // Show current stats, including monster stats
                Console.WriteLine("1: Attack\n2: Heal\nChoose an action:");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Attack(monster);
                    if (monster.HP > 0) // Monster attacks back only if it's still alive
                    {
                        MonsterAttack(monster);
                    }
                }
                else if (choice == "2")
                {
                    Heal();
                    if (monster.HP > 0) // Monster attacks back only if it's still alive
                    {
                        MonsterAttack(monster);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid choice! Please select 1 or 2.");
                    Console.ResetColor();
                    Thread.Sleep(1000); // Pause for a moment before continuing
                }
            }

            if (monster.HP <= 0)
            {
                Console.WriteLine($"{monster.Name} defeated!");
                totalDamageDealt += player.STR; // Track damage dealt
                player.Score++; // Increment score for defeating a monster
            }
        }

        private void Attack(Monster monster)
        {
            FlashScreen(ConsoleColor.Red); // Trigger attack animation with red flash

            monster.HP -= player.STR;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You dealt {player.STR} damage to {monster.Name}.");
            Console.ResetColor();
        }

        /// <summary>
        /// Simulates an animation by flashing the screen with the specified color briefly.
        /// </summary>
        /// <param name="flashColor">The color to flash the screen with.</param>
        private void FlashScreen(ConsoleColor flashColor)
        {
            // Save the current console colors
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor originalForeground = Console.ForegroundColor;

            // Flash the screen with the specified color
            Console.BackgroundColor = flashColor;
            Console.Clear();
            Thread.Sleep(200); // Flash duration in milliseconds

            // Restore original colors
            Console.BackgroundColor = originalBackground;
            Console.ForegroundColor = originalForeground;
            Console.Clear();
            Thread.Sleep(200); // Pause after flash
        }

        private void Heal()
        {
            if (player.MP > 0)
            {
                FlashScreen(ConsoleColor.Green); // Trigger heal animation with green flash

                player.HP += player.HealAmount; // Heal based on HealAmount
                player.MP--;
                totalHealingDone += player.HealAmount; // Track healing done
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"You healed for {player.HealAmount} HP. Current HP: {player.HP}, MP: {player.MP}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Not enough MP to heal!"); // Warning the player that MP is not enough to proceed the action
                Console.ResetColor();
            }
        }

        private void MonsterAttack(Monster monster)
        {
            int damage = random.Next(1, 4);
            player.HP -= damage;
            totalDamageReceived += damage;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{monster.Name} attacks you for {damage} damage. Your current HP: {player.HP}");
            Console.ResetColor();
        }

        private void ShowStats(Monster monster)
        {
            Console.WriteLine($"Player Stats - HP: {player.HP}/{player.MaxHP}, MP: {player.MP}, STR: {player.STR}, Heal Amount: {player.HealAmount}");
            Console.WriteLine($"Monster Stats - {monster.Name} HP: {monster.HP}");
        }

        private void UpgradeStats()
        {
            Console.WriteLine("Choose a stat to upgrade: 1: HP, 2: MP, 3: STR, 4: Heal Amount");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    player.MaxHP += 2; // Increase MaxHP instead of HP
                    player.HP = player.MaxHP; // Optionally, restore HP to MaxHP upon upgrade
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Max HP upgraded and restored to full!");
                    break;
                case "2":
                    player.MP += 1;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("MP upgraded!");
                    break;
                case "3":
                    player.STR += 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("STR upgraded!");
                    break;
                case "4":
                    player.HealAmount += 2; // Increase healing amount
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Heal Amount upgraded!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, no upgrades made.");
                    break;
            }
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(); // Wait for player to continue
        }

        private void ResetPlayerHealth()
        {
            player.HP = player.MaxHP; // Restore HP to MaxHP
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Your HP has been restored to {player.HP} for the new floor.");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
        }

        private void ExportGameData()
        {
            string filePath = "game_data.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Game Session Data");
                    writer.WriteLine($"Username: {player.Username}");
                    writer.WriteLine($"Date Started: {startTime}");
                    writer.WriteLine($"Date Finished: {DateTime.Now}");
                    writer.WriteLine($"Total Floors Passed: {totalFloorsPassed}");
                    writer.WriteLine($"Total Damage Dealt: {totalDamageDealt}");
                    writer.WriteLine($"Total Damage Received: {totalDamageReceived}");
                    writer.WriteLine($"Total Healing Done: {totalHealingDone}");
                    writer.WriteLine($"Final HP: {player.HP}");
                    writer.WriteLine($"Final MP: {player.MP}");
                    writer.WriteLine($"Final STR: {player.STR}");
                    writer.WriteLine($"Final Heal Amount: {player.HealAmount}");
                    writer.WriteLine($"Score: {player.Score}"); // Output the player's score
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Game data exported to {filePath}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred while exporting game data: " + ex.Message);
                Console.ResetColor();
            }
        }
    }

    class Player
    {
        public int HP { get; set; } = 10;
        public int MaxHP { get; set; } = 10; // New property to track maximum HP
        public int MP { get; set; } = 5;
        public int STR { get; set; } = 5;
        public int HealAmount { get; set; } = 5; // Initial heal amount
        public string Username { get; set; } = "Unknown"; // Player's username
        public int Score { get; set; } = 0; // Score for defeated monsters

        public Player() { }
    }

    class Monster
    {
        public string Name { get; set; }
        public int HP { get; set; }

        public Monster(int strength)
        {
            Name = "Monster";
            HP = strength * 2;
        }
    }
}
