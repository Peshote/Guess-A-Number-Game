using System;

namespace Project_Guess_A_Number
{
    internal class Program
    {
        private static int currentLevel = 1;

        static void Main(string[] args)
        {
            PlayGame();
        }

        static void PlayGame()
        {
            if (currentLevel <= 5)
            {
                int minRange = 1;
                int maxRange = GetMaxRangeForLevel(currentLevel);

                Random randomNumber = new Random();
                int computerNumber = randomNumber.Next(minRange, maxRange + 1);

                while (true)
                {
                    Console.Write($"Level {currentLevel} - Guess a number ({minRange}-{maxRange}): ");

                    string playerInput = Console.ReadLine();
                    bool isValid = int.TryParse(playerInput, out int playerNumber);

                    if (isValid)
                    {
                        if (playerNumber == computerNumber)
                        {
                            Console.WriteLine("You guessed it!");
                            Console.WriteLine($"Congratulations! You've completed level {currentLevel}.");
                            currentLevel++;
                            Console.WriteLine();
                            break;
                        }
                        else if (playerNumber > computerNumber)
                        {
                            Console.WriteLine("Too High");
                        }
                        else
                        {
                            Console.WriteLine("Too Low");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }

                if (currentLevel <= 5)
                {
                    PlayGame();
                }
                else
                {
                    Console.WriteLine("Congratulations! You've completed all levels.");
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
                Console.Write("Play again? [y]es or [n]o: ");
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
                Console.WriteLine("Thank you for playing!");
            }
        }
    }
}