using System;
using System.Diagnostics;

namespace Project_Guess_A_Number
{
    internal class Program
    {
        private static int currentLevel = 1;
        private static TimeSpan bestTime = TimeSpan.FromHours(24); // Set to 24 hours initially
        private static Stopwatch timer = new Stopwatch(); // Create a single stopwatch for the entire game

        static void Main(string[] args)
        {
            PlayGame(); // Start the game
        }

        static void PlayGame()
        {
            if (currentLevel == 1)
            {
                timer.Restart(); // Restart the timer for the new game
            }

            if (currentLevel <= 5)
            {
                int minRange = 1;
                int maxRange = GetMaxRangeForLevel(currentLevel); // Determine the maximum range for the current level

                Random randomNumber = new Random();
                int computerNumber = randomNumber.Next(minRange, maxRange + 1); // Generate a random number for the current level

                while (true)
                {
                    Console.Write("Level ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(currentLevel); // Display the current level in cyan color
                    Console.ResetColor();
                    Console.Write($" - Guess a number ({minRange}-{maxRange}): ");

                    string playerInput = Console.ReadLine();
                    bool isValid = int.TryParse(playerInput, out int playerNumber);

                    if (isValid)
                    {
                        if (playerNumber == computerNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("You guessed it!");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Congratulations! You've completed level {currentLevel}.");
                            Console.ResetColor();
                            currentLevel++; // Move to the next level
                            Console.WriteLine();
                            break;
                        }
                        else if (playerNumber > computerNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Too High");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Too Low");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                if (currentLevel <= 5)
                {
                    PlayGame(); // Play the next level
                }
                else
                {
                    timer.Stop(); // Stop the stopwatch
                    TimeSpan totalTime = timer.Elapsed; // Calculate the total time taken

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Congratulations! You've completed all levels in {totalTime:hh\\:mm\\:ss} time.");

                    if (totalTime < bestTime)
                    {
                        bestTime = totalTime; // Update the best time record if needed
                    }

                    Console.WriteLine($"Your best time record is {bestTime:hh\\:mm\\:ss} !");
                    Console.ResetColor();

                    PlayAgain(); // Ask if the player wants to play again
                }
            }
        }

        static int GetMaxRangeForLevel(int level)
        {
            // Determine the maximum range for each level
            switch (level)
            {
                case 1:
                    return 100;
                case 2:
                    return 200;
                case 3:
                    return 500;
                case 4:
                    return 1000;
                case 5:
                    return 2000;
                default:
                    return 100;
            }
        }

        static void PlayAgain()
        {
            string playAgain;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Play again? [y]es or [n]o: ");
                Console.ResetColor();
                playAgain = Console.ReadLine().ToLower();
            } while (playAgain != "y" && playAgain != "yes" && playAgain != "n" && playAgain != "no");

            if (playAgain == "y" || playAgain == "yes")
            {
                currentLevel = 1;
                Console.WriteLine();
                PlayGame(); // Restart the game
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Thank you for playing!");
                Console.ResetColor();
            }
        }
    }
}