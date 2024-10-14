using System;
using System.IO;

class WordleGame
{
    // Nested class to hold player information
    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        public void UpdateScore()
        {
            Score += 10; // Increase score for correct guesses
        }
    }

    static Player player;
    static string[] words; // Array of possible words
    static string[] guesses = new string[6]; // Array to store player guesses
    static string[,] feedback = new string[6, 5]; // Multidimensional array for feedback (6 attempts, 5 letters)
    static int attemptCount = 0; // Counter for attempts
    static string[] lastAnswers = new string[10]; // Array to store the last 10 answers
    static int answerCount = 0; // Counter for last answers

    static void Main(string[] args)
    {
        LoadWords("wordlist.txt"); // Load words from the text file
        SetupPlayer();
        PlayGame();
        SaveGameData();
    }

    static void LoadWords(string filePath)
    {
        try
        {
            words = File.ReadAllLines(filePath); // Read all lines from the file into the array
            if (words.Length == 0)
            {
                throw new Exception("No words found in the file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading words: " + ex.Message);
            Environment.Exit(1); // Exit if there's an error
        }
    }

    static void SetupPlayer()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        player = new Player(name);
    }

    static void PlayGame()
    {
        Random random = new Random();
        string targetWord = words[random.Next(words.Length)]; // Select a random word
        Console.WriteLine("Welcome to Wordle! Guess the 5-letter word.");

        while (attemptCount < 6)
        {
            GetPlayerGuess();
            if (ValidateGuess(guesses[attemptCount], targetWord))
            {
                Console.WriteLine("Congratulations! You've guessed the word!");
                player.UpdateScore();
                AddToLastAnswers(targetWord);
                return;
            }
            attemptCount++;
        }

        Console.WriteLine($"Sorry! The correct word was: {targetWord}");
        AddToLastAnswers(targetWord);
    }

    static void GetPlayerGuess()
    {
        try
        {
            Console.Write($"Attempt {attemptCount + 1}: ");
            string guess = Console.ReadLine().ToLower();
            if (guess.Length != 5)
            {
                throw new ArgumentOutOfRangeException("Guess must be exactly 5 letters.");
            }

            guesses[attemptCount] = guess; // Store the guess
            ProvideFeedback(guesses[attemptCount]);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid word.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static bool ValidateGuess(string guess, string targetWord)
    {
        return guess == targetWord;
    }

    static void ProvideFeedback(string guess)
    {
        for (int i = 0; i < guess.Length; i++)
        {
            if (guess[i] == targetWord[i])
            {
                feedback[attemptCount, i] = "🟩"; // Correct letter in the correct position
            }
            else if (targetWord.Contains(guess[i]))
            {
                feedback[attemptCount, i] = "🟨"; // Correct letter in the wrong position
            }
            else
            {
                feedback[attemptCount, i] = "⬜"; // Incorrect letter
            }
        }

        // Display feedback
        Console.WriteLine("Feedback: " + string.Join(" ", feedback[attemptCount, 0], feedback[attemptCount, 1], feedback[attemptCount, 2], feedback[attemptCount, 3], feedback[attemptCount, 4]));
    }

    static void AddToLastAnswers(string answer)
    {
        if (answerCount < 10)
        {
            lastAnswers[answerCount] = answer;
            answerCount++;
        }
        else
        {
            // Shift answers
            for (int i = 1; i < lastAnswers.Length; i++)
            {
                lastAnswers[i - 1] = lastAnswers[i];
            }
            lastAnswers[9] = answer; // Add new answer
        }
    }

    static void SaveGameData()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("WordleGameData.txt"))
            {
                writer.WriteLine("Player Name: " + player.Name);
                writer.WriteLine("Score: " + player.Score);
                writer.WriteLine("Last Answers:");
                for (int i = 0; i < lastAnswers.Length; i++)
                {
                    if (!string.IsNullOrEmpty(lastAnswers[i]))
                    {
                        writer.WriteLine(lastAnswers[i]);
                    }
                }
            }
            Console.WriteLine("Game data saved to WordleGameData.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving game data: " + ex.Message);
        }
    }
}
