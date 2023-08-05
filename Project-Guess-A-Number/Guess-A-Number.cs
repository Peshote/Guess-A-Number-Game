using System;

namespace Project_Guess_A_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayGame(); // Start the game
        }

        static void PlayGame()
        {
            Random randomNumber = new Random();
            int computerNumber = randomNumber.Next(1, 101);

            while (true)
            {
                Console.Write("Guess a number (1-100): ");

                string playerInput = Console.ReadLine();
                bool isValid = int.TryParse(playerInput, out int playerNumber);

                if (isValid)
                {
                    if (playerNumber == computerNumber)
                    {
                        Console.WriteLine("You guessed it!");
                        PlayAgain(); // Ask if the player wants to play again
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
                Console.WriteLine();
                PlayGame(); // Start a new game
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for playing!");
            }
        }
    }
}