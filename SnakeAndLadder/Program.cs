using System;
using System.Collections.Generic;

namespace SnakeAndLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int playerPosition = 0;
            int winningPosition = 100;

            Dictionary<int, int> snakes = new Dictionary<int, int>
            {
                {99, 7}, {95, 75}, {92, 88}, {89, 26}, {74, 53}
            };

            Dictionary<int, int> ladders = new Dictionary<int, int>
            {
                {2, 38}, {7, 14}, {8, 31}, {15, 26}, {21, 42}
            };

            while (playerPosition < winningPosition)
            {
                Console.WriteLine("Press ENTER to roll the dice...");
                Console.ReadLine();

                int diceRoll = random.Next(1, 7);
                Console.WriteLine($"Dice rolled: {diceRoll}");

                int newPosition = playerPosition + diceRoll;

                if (newPosition > winningPosition)
                {
                    Console.WriteLine("Oops! You need exact roll to win.");
                }
                else
                {
                    playerPosition = newPosition;

                    if (snakes.ContainsKey(playerPosition))
                    {
                        Console.WriteLine($"Snake at {playerPosition}! Slide down to {snakes[playerPosition]}.");
                        playerPosition = snakes[playerPosition];
                    }
                    else if (ladders.ContainsKey(playerPosition))
                    {
                        Console.WriteLine($"Ladder at {playerPosition}! Climb up to {ladders[playerPosition]}.");
                        playerPosition = ladders[playerPosition];
                    }
                    else
                    {
                        Console.WriteLine("No Play — stay at same position.");
                    }
                }

                Console.WriteLine($"Current Position: {playerPosition}\n");

                if (playerPosition == winningPosition)
                {
                    Console.WriteLine("🎉 Congratulations! You reached 100 and won the game!");
                    break;
                }
            }
        }
    }
}