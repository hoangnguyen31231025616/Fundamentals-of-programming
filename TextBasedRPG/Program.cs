using System;
using System.IO;
using System.Threading;
using System.Collections.Generic; // Cần thiết cho danh sách trong CombatLog

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
        private DateTime startTime;

        // Mảng các thông điệp động viên được hiển thị ngẫu nhiên khi người chơi đánh bại Monster
        private string[] specialMessages =
        {
            "You're unstoppable!",
            "Keep going, warrior!",
            "The monsters fear you now!",
            "Another one bites the dust!",
            "Victory is yours!"
        };

        public Game()
        {
            player = new Player();
            startTime = DateTime.Now; // Theo dõi thời gian khi trò chơi bắt đầu
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("||====================================||");
            Console.WriteLine("||                                    ||");
            Console.WriteLine("||     TEXT-BASED DUNGEON CRAWLER     ||");
            Console.WriteLine("||                                    ||");
            Console.WriteLine("||====================================||");

            // Try-catch để nhập tên người dùng
            try
            {
                Console.Write("Please enter player's name: ");
                player.Username = Console.ReadLine(); // nhập tên
                if (string.IsNullOrWhiteSpace(player.Username))
                {
                    player.Username = "Unknown"; // username sẽ là "Unkonwn" nếu để trống
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while i: " + ex.Message);
                return; // Thoát khỏi trò chơi nếu có lỗi
            }

            Console.Clear();

            int floor = 1;
            while (player.HP > 0)
            {
                ResetPlayerHealth(); // Phục hồi điểm HP khi bắt đầu mỗi tầng mới

                Console.WriteLine("+ ===================== +");
                Console.WriteLine($"||    floor {floor}           ||");
                Console.WriteLine("+ ===================== +");

                Monster[] monsters = GenerateWave(floor); // Tạo ra một Wave Monster mới 
                Console.WriteLine($"A wave of {monsters.Length} monster(s) approached!");

                foreach (Monster monster in monsters)
                {
                    Console.WriteLine($"A wild {monster.Name} appeared with {monster.HP} HP!");
                    Battle(monster);
                    if (player.HP <= 0)
                    {
                        break;
                    }
                }

                if (player.HP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("DEFEATED!");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();

                    // In Combatlog trước khi thoát
                    player.Stats.Log.PrintLog();
                    break;
                }

                totalFloorsPassed++;
                UpgradeStats();

                Console.WriteLine("Continue to the next floor? (y/n)");
                string continueChoice = Console.ReadLine();
                if (continueChoice.ToLower() != "y")
                {
                    Console.Clear();
                    break;
                }
                Console.Clear();
                floor++; // Tăng số tầng, để tiến tới tầng tiếp tiếp
            }
            ExportGameData(); // để xuất dữ liệu trò chơi sang file TXT
        }

        private Monster[] GenerateWave(int floor)
        {
            // Tạo ra nhiều Monster hơn khi người chơi tiến lên các tầng cao hơn
            int waveSize = random.Next(1, 4) + floor / 2; // công thức tính số Monster trong 1 Wave
            Monster[] monsters = new Monster[waveSize];
            for (int i = 0; i < waveSize; i++)
            {
                monsters[i] = new Monster(random.Next(1, 11) + floor); //mảng để lưu trữ Monster xuất hiện trên sàn
            }
            return monsters;
        }

        private void Battle(Monster monster)
        {
            while (monster.HP > 0 && player.HP > 0)
            {
                ShowStats(monster); // Hiển thị số liệu thống kê hiện tại, bao gồm số liệu thống kê 
                Console.WriteLine("1: Attack\n2: Heal\n3: Show battle'log\nChoose action: ");
                string choice = Console.ReadLine();
                if (choice == "3")
                {
                    Console.WriteLine("============================");
                    player.Stats.Log.PrintLog(); // Hiển thị nhật ký chiến đấu
                    Console.WriteLine("============================");
                    Console.ReadLine();
                    Console.Clear();
                    continue; // cho phép người chơi tiếp tục chọn tùy chọn chiến đấu
                }
                if (choice == "1")
                {
                    Attack(monster); // Người chơi tấn công Monster
                    if (monster.HP > 0) // Monster chỉ tấn công lại nếu nó vẫn còn sống
                    {
                        MonsterAttack(monster);
                    }
                }
                else if (choice == "2")
                {
                    Heal(); // Người chơi hồi máu
                    if (monster.HP > 0) // Monster chỉ tấn công lại nếu nó vẫn còn sống
                    {
                        MonsterAttack(monster);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid choice! Please select 1, 2 or 3.");
                    Console.ResetColor();
                    Thread.Sleep(1000); // Tạm dừng một lát trước khi tiếp tục
                }
            }

            if (monster.HP <= 0)
            {
                Console.WriteLine($"{monster.Name} defeated!");
                player.Stats.TotalDamageDealt += player.STR; // Theo dõi sát thương gây ra
                player.Score++; // Điểm tăng thêm khi đánh bại 1 Monster

                // Ghi lại thông tin Monster bị đánh bại 
                player.Stats.Log.AddAction($"Defeated {monster.Name}.");

                //Hiển thị một thông báo đặc biệt ngẫu nhiên từ mảng sau khi đánh bại Monster
                int randomIndex = random.Next(specialMessages.Length);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(specialMessages[randomIndex]); // Hiển thị một thông báo đặc biệt ngẫu nhiên

                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void Attack(Monster monster)
        {
            FlashScreen(ConsoleColor.Red); // Kích hoạt hoạt ảnh tấn công bằng cách nhấp nháy màn hình màu đỏ

            monster.HP -= player.STR;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You dealt {player.STR} damage to {monster.Name}.");
            Console.ResetColor();

            // Ghi lại cuộc tấn công
            player.Stats.Log.AddAction($"Player attacked {monster.Name} for {player.STR} damage.");
        }

        private void FlashScreen(ConsoleColor flashColor)
        {
            // Tạo hiệu ứng nhấp nháy trên màn hình để chỉ thị trực quan các hành động như tấn công hoặc hồi điểm HP
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor originalForeground = Console.ForegroundColor;

            Console.BackgroundColor = flashColor;
            Console.Clear();
            Thread.Sleep(200);

            Console.BackgroundColor = originalBackground;
            Console.ForegroundColor = originalForeground;
            Console.Clear();
            Thread.Sleep(200); // Tạm dừng sau khi nhấp nháy
        }

        private void Heal()
        {
            if (player.MP > 0)
            {
                FlashScreen(ConsoleColor.Green); // Kích hoạt hoạt ảnh hồi điểm HP bằng cách nhấp nháy màn hình màu xanh

                player.HP += player.HealAmount; // Hồi điểm HP dựa vào HealAmount
                player.MP--;
                player.Stats.TotalHealingDone += player.HealAmount; // Đã hoàn thành việc hồi điểm HP
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"You healed for {player.HealAmount} HP. Current HP: {player.HP}, MP: {player.MP}");
                Console.ResetColor();

                // Ghi lại hành động hồi điểm HP vào Combatlog
                player.Stats.Log.AddAction($"Player healed for {player.HealAmount} HP.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;// Kích hoạt hoạt ảnh KHÔNG thể hồi điểm HP bằng cách nhấp nháy màn hình màu đỏ đậm
                Console.WriteLine("Not enough MP to heal!"); //thông báo
                Console.ResetColor();
            }
        }

        private void MonsterAttack(Monster monster)
        {
            int damage = monster.Type.Strength; //Sử dụng điểm Strength của Monster làm sát thương
            player.HP -= damage; // Trừ sát thương vào điểm HP của người chơi

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{monster.Name} attacks you for {damage} damage. Your current HP: {player.HP}");
            Console.ResetColor();

            // Ghi lại cuộc tấn công của Monster
            player.Stats.Log.AddAction($"{monster.Name} attacked player for {damage} damage.");
        }


        private void ShowStats(Monster monster) //hiển thị Stat hiện tại của người chơi
        {
            Console.WriteLine($"Player Stats - HP: {player.HP}/{player.MaxHP}, MP: {player.MP}, STR: {player.STR}, Heal Amount: {player.HealAmount}");
            Console.WriteLine($"Monster Stats - {monster.Name} HP: {monster.HP}");
            Console.WriteLine($"Monster Rank: {monster.Type.TypeName}, Strength: {monster.Type.Strength}");
        }

        private void UpgradeStats()
        {
            Console.WriteLine("Choose a stat to upgrade:\n 1: HP\n 2: MP\n 3: STR\n 4: Heal Amount\n Other key: No upgrade");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    player.MaxHP += 2;
                    player.HP = player.MaxHP;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Max HP upgraded and restored to full!"); //thông báo điểm HP của người chơi được nâng cấp (+2)
                    break;
                case "2":
                    player.MP += 1;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("MP upgraded!"); //thông báo điểm MP của người chơi được nâng cấp (+1)
                    break;
                case "3":
                    player.STR += 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("STR upgraded!"); //thông báo điểm STR của người chơi được nâng cấp (+1)
                    break;
                case "4":
                    player.HealAmount += 2;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Heal Amount upgraded!"); //thông báo lượng hồi điểm HP (heal amount) của người chơi được nâng cấp (+1)
                    break;
                default:
                    Console.WriteLine("no upgrade was made."); //nếu chọn sai thì sẽ không có gì xảy ra và không nâng cấp
                    break;
            }
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(); // Chờ Player muốn tiếp tục hay không
        }

        private void ResetPlayerHealth()
        {
            player.HP = player.MaxHP; //reset điểm HP hiện tại thành điểm HP tối đa (sau khi được nâng cấp chỉ số)
            Console.ForegroundColor = ConsoleColor.Cyan; // thông báo hồi phục điểm HP sau khi bước qua tầng mới bằng cách hiện chữ màu xanh nhạt
            Console.WriteLine($"Your HP has been restored to {player.HP} for the new floor."); //
            Console.ResetColor();
        }

        private void ExportGameData()
        {
            try
            {
                // Tính tổng thời gian chơi
                TimeSpan playtime = DateTime.Now - startTime;

                // Ghi dữ liệu trò chơi vào một tệp văn bản TXT
                using (StreamWriter writer = new StreamWriter("gamedata.txt"))
                {
                    writer.WriteLine($"Username: {player.Username}");
                    writer.WriteLine($"Score: {player.Score}");
                    writer.WriteLine($"Total floors passed: {totalFloorsPassed}");
                    writer.WriteLine($"Playtime: {playtime}");

                    //Viết thêm số liệu thống kê của người chơi
                    writer.WriteLine($"Total Damage Dealt: {player.Stats.TotalDamageDealt}");
                    writer.WriteLine($"Total Damage Received: {player.Stats.TotalDamageReceived}");
                    writer.WriteLine($"Total Healing Done: {player.Stats.TotalHealingDone}");
                }

                // Thông báo cho người chơi về việc xuất dữ liệu trò chơi
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Game data has been exported to 'gamedata.txt'.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while exporting your savedata " + ex.Message);
                return; // Thoát khỏi trò chơi nếu có lỗi
            }
        }
    }

    class Player
    {
        public string Username { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int MP { get; set; }
        public int STR { get; set; }
        public int HealAmount { get; set; }
        public int Score { get; set; }
        public PlayerStats Stats { get; set; }

        public Player()
        {
            // chỉ số cơ bản của Player
            MaxHP = 20;
            HP = MaxHP;
            MP = 5;
            STR = 5;
            HealAmount = 10;
            Score = 0;
            Stats = new PlayerStats(); // Khởi tạo số liệu thống kê của người chơi
        }
    }

    class Monster
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public MonsterType Type { get; set; }

        private static string[] names = { "Goblin", "Orc", "Troll", "Slime", "Skeleton", "Zombie" }; //mảng tên các Monster có thể có

        public Monster(int health)
        {
            Name = names[new Random().Next(names.Length)]; // Chọn tên Monster ngẫu nhiên
            HP = health; // Đặt điểm HP của Monster dựa trên mức floor
            Type = new MonsterType();
        }
    }

    //  lớp MonsterType xác định loại Monster và cấp độ sức mạnh của nó
    class MonsterType
    {
        public string TypeName { get; set; }
        public int Strength { get; set; }

        private static string[] types = { "Common", "Uncommon", "Rare", "Epic", "Legendary" }; //mảng phân chia Type của Monster

        public MonsterType()
        {
            Random random = new Random();
            TypeName = types[random.Next(types.Length)];
            Strength = random.Next(1, 8); // Ngẫu nhiên điểm Strength mà Monster có thể có
        }
    }

    // Lớp PlayerStats chứa nhiều số liệu thống kê của người chơi và một lớp CombatLog lồng nhau
    class PlayerStats
    {
        public int TotalDamageDealt { get; set; }
        public int TotalDamageReceived { get; set; }
        public int TotalHealingDone { get; set; }
        public CombatLog Log { get; set; }

        public PlayerStats()
        {
            Log = new CombatLog(); // Khởi tạo combat log
        }

        // Lớp lồng nhau (nested class) để theo dõi các hành động chiến đấu
        public class CombatLog
        {
            private List<string> actions; // Danh sách (list) để lưu trữ các hành động chiến đấu

            public CombatLog()
            {
                actions = new List<string>(); // Khởi tạo danh sách
            }

            public void AddAction(string action)
            {
                actions.Add(action); // Thêm một hành động vào Combatlog
            }

            public void PrintLog()
            {
                Console.WriteLine("Combat Log:");
                foreach (var action in actions) // In tất cả các hành động được lưu trữ trong Combatlog
                {
                    Console.WriteLine(action);
                }
            }
        }
    }
}
