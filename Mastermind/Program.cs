using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            Result result = game.CheckGuess("4221");

            Solver solver = new Solver();

            Solution solution = solver.Solve(game);


            Console.ReadLine();
        }
    }
}
