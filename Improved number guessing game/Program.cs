using System;
using System.IO;

class NumberGuessingGame
{
    static string[,] playerData = new string[10, 2]; // First column: names, second column: high scores
    static int currentPlayerIndex = 0; // Track the current player index
    static int maxNumber;
    static int[] guesses = new int[5]; // Array to store player guesses
    static DateTime[] gameStartDates = new DateTime[10]; // Array to store game start dates
    static int gameCount = 0; // Count of games played

    static void Main(string[] args)
    {
        DisplayTitle();
        SetupPlayer();

        do
        {
            SelectDifficulty();
            PlayGame();
        } while (AskToContinue());

        SaveGameData();
    }

    static void DisplayTitle()
    {
        Console.Clear();
        Console.WriteLine("===================================");
        Console.WriteLine("        NUMBER GUESSING GAME      ");
        Console.WriteLine("===================================\n");
    }

    static void SetupPlayer()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        playerData[currentPlayerIndex, 0] = name; // Store player name
        playerData[currentPlayerIndex, 1] = "0"; // Initialize high score as string
    }

    static void SelectDifficulty()
    {
        Console.WriteLine("Select Difficulty Level:");
        Console.WriteLine("1. Easy (1-10)");
        Console.WriteLine("2. Medium (1-20)");
        Console.WriteLine("3. Hard (1-30)");

        while (true)
        {
            try
            {
                Console.Write("Enter your choice (1-3): ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        maxNumber = 10;
                        return;
                    case 2:
                        maxNumber = 20;
                        return;
                    case 3:
                        maxNumber = 30;
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please select a valid difficulty level.");
                        continue;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }
        }
    }

    static void PlayGame()
    {
        Random random = new Random();
        int targetNumber = random.Next(1, maxNumber + 1);
        Console.WriteLine($"\nGuess a number between 1 and {maxNumber}");

        if (gameCount < 10)
        {
            gameStartDates[gameCount] = DateTime.Now;
            gameCount++;
        }

        for (int attempt = 0; attempt < 5; attempt++)
        {
            if (GetPlayerGuess(attempt, targetNumber)) return; // End the game if guessed correctly
        }
        Console.WriteLine($"The correct number was: {targetNumber}");
        Console.WriteLine($"Your high score: {playerData[currentPlayerIndex, 1]}");
    }

    static bool GetPlayerGuess(int attempt, int targetNumber)
    {
        try
        {
            Console.Write($"Attempt {attempt + 1}: ");
            guesses[attempt] = Convert.ToInt32(Console.ReadLine());
            ValidateGuess(guesses[attempt], targetNumber);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return false; // Continue to next attempt
        }
        catch (OverflowException)
        {
            Console.WriteLine("Number is too large or too small. Please try again.");
            return false; // Continue to next attempt
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            return false; // Continue to next attempt
        }

        return guesses[attempt] == targetNumber; // Return true if guessed correctly
    }

    static void ValidateGuess(int guess, int targetNumber)
    {
        if (guess < 1 || guess > maxNumber)
        {
            throw new ArgumentOutOfRangeException($"Guess must be between 1 and {maxNumber}.");
        }

        if (guess == targetNumber)
        {
            Console.WriteLine("Congratulations! You guessed correctly!");
            int highScore = int.Parse(playerData[currentPlayerIndex, 1]);
            highScore += 10; // Update high score
            playerData[currentPlayerIndex, 1] = highScore.ToString(); // Store as string
        }
        else
        {
            int difference = Math.Abs(guess - targetNumber);
            if (difference <= 2)
            {
                Console.WriteLine("Very close! Try again.");
            }
            else if (difference <= 5)
            {
                Console.WriteLine("Close! But not quite.");
            }
            else
            {
                Console.WriteLine(guess < targetNumber ? "Higher!" : "Lower!");
            }
        }
    }

    static bool AskToContinue()
    {
        Console.WriteLine("\nDo you want to play again? (y/n)");
        string response = Console.ReadLine().ToLower();
        if (response == "y")
        {
            DisplayTitle();
            return true;
        }
        Console.Clear();
        return false;
    }

    static void SaveGameData()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("GameData.txt"))
            {
                writer.WriteLine("Player Information:");
                writer.WriteLine($"Name: {playerData[currentPlayerIndex, 0]}");
                writer.WriteLine($"High Score: {playerData[currentPlayerIndex, 1]}");
                writer.WriteLine("Guesses:");
                foreach (var guess in guesses)
                {
                    writer.WriteLine(guess);
                }

                for (int i = 0; i < gameCount; i++)
                {
                    writer.WriteLine($"Game {i + 1} Start Date: {gameStartDates[i].ToShortDateString()}");
                }
            }
            Console.WriteLine("Game data saved to GameData.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving game data: " + ex.Message);
        }
    }
}
