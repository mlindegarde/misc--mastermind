using System;
using Mastermind.Ai;
using Mastermind.Application;
using Mastermind.Model;

namespace Mastermind
{
    class Program
    {
        #region Member Variables
        private Combination _combination;
        #endregion

        #region Methods
        private void Init()
        {
            _combination =
                new CombinationBuilder()
                    .WithLength(4)
                    .UsingDigitsBetween(1, 6);
        }

        private void Run()
        {
            int guessCount = 0;

            Result result = null;

            /*
            do
            {
                string guess = Console.ReadLine();

                result = _safe.TryCombination(guess);

                Console.WriteLine(result);
                guessCount++;

            } while(guessCount < 10 && !result.WasRight);
           */

            Solver solver = new Solver();
            Solution solution = solver.Crack(_combination);
            Console.ReadLine();
        }
        #endregion

        static void Main(string[] args)
        {
            Program game = new Program();

            game.Init();
            game.Run();
        }
    }
}
