using System;

namespace SnakeAndLadder
{
    class Program
    {
        static void Main(string[] args)
        {

            int playerPosition = 0;
            Console.WriteLine("Player Starting Position");
            Random random = new Random();
            int diceRoll = random.Next(1, 7);
            Console.WriteLine($"Dice rolled: {diceRoll}");

        }
    }
}