using System;
using System.Diagnostics;

namespace Project_Guess_A_Number
{
    internal class Program
    {
        private static int currentLevel = 1;
        private static TimeSpan bestTime = TimeSpan.FromHours(24); // Set to 24 hours initially

        static void Main(string[] args)
        {
            PlayGame();
        }

        static void PlayGame()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            if (currentLevel <= 5)
            {
                int minRange = 1;
                int maxRange = GetMaxRangeForLevel(currentLevel);

                Random randomNumber = new Random();
                int computerNumber = randomNumber.Next(minRange, maxRange + 1);

                while (true)
                {
                    Console.Write("Level ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(currentLevel);
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
                            currentLevel++;
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
                    PlayGame();
                }
                else
                {
                    timer.Stop();
                    TimeSpan totalTime = timer.Elapsed;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Congratulations! You've completed all levels in {totalTime:hh\\:mm\\:ss} time.");

                    if (totalTime < bestTime)
                    {
                        bestTime = totalTime;
                        Console.WriteLine($"Your best time record is {bestTime:hh\\:mm\\:ss} !");
                    }

                    Console.ResetColor();
                    PlayAgain();
                }
            }
        }

        static int GetMaxRangeForLevel(int level)
        {
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
                PlayGame();
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