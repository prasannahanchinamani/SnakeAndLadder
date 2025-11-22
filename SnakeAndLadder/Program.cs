using System;
using System.Collections.Generic;

namespace SnakeAndLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int winningPosition = 100;
            int player1 = 0, player2 = 0;
            int diceCount = 0;
            bool player1Turn = true;

            Dictionary<int, int> snakes = new Dictionary<int, int>
            {
                {99, 7}, {95, 75}, {92, 88}, {89, 26}, {74, 53}
            };

            Dictionary<int, int> ladders = new Dictionary<int, int>
            {
                {2, 38}, {7, 14}, {8, 31}, {15, 26}, {21, 42}
            };

            Console.WriteLine("Snake & Ladder Game - Two Players");
            Console.WriteLine("First to reach 100 wins.\n");

            while (player1 < winningPosition && player2 < winningPosition)
            {
                Console.WriteLine(player1Turn ? "Player 1 turn" : "Player 2 turn");
                Console.ReadLine();

                int diceRoll = random.Next(1, 7);
                diceCount++;
                Console.WriteLine($"Dice rolled: {diceRoll}");

                if (player1Turn)
                {
                    int newPos = player1 + diceRoll;
                    if (newPos <= winningPosition) player1 = newPos;

                    if (snakes.ContainsKey(player1))
                    {
                        Console.WriteLine($"Snake at {player1}! Slide down to {snakes[player1]}.");
                        player1 = snakes[player1];
                    }
                    else if (ladders.ContainsKey(player1))
                    {
                        Console.WriteLine($"Ladder at {player1}! Climb up to {ladders[player1]}.");
                        player1 = ladders[player1];
                        Console.WriteLine($"Player 1 Position: {player1}\n");
                        if (player1 < winningPosition) continue; // ladder → extra turn
                    }

                    Console.WriteLine($"Player 1 Position: {player1}\n");
                }
                else
                {
                    int newPos = player2 + diceRoll;
                    if (newPos <= winningPosition) player2 = newPos;

                    if (snakes.ContainsKey(player2))
                    {
                        Console.WriteLine($"Snake at {player2}! Slide down to {snakes[player2]}.");
                        player2 = snakes[player2];
                    }
                    else if (ladders.ContainsKey(player2))
                    {
                        Console.WriteLine($"Ladder at {player2}! Climb up to {ladders[player2]}.");
                        player2 = ladders[player2];
                        Console.WriteLine($"Player 2 Position: {player2}\n");
                        if (player2 < winningPosition) continue; // ladder → extra turn
                    }

                    Console.WriteLine($"Player 2 Position: {player2}\n");
                }

                player1Turn = !player1Turn;
            }

            if (player1 == winningPosition)
                Console.WriteLine($" Player 1 wins in {diceCount} rolls!");
            else
                Console.WriteLine($" Player 2 wins in {diceCount} rolls!");
        }
    }
}