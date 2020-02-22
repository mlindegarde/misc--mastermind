using System;

namespace Mastermind
{
    class Program
    {
        #region Member Variables
        private Safe _safe;
        #endregion

        #region Methods
        private void Init()
        {
            _safe =
                new Safe(
                    new CombinationBuilder()
                        .WithLength(4)
                        .UsingDigitsBetween(1, 6));
        }

        private void Run()
        {
            int guessCount = 0;

            Result result = null;

            do
            {
                string guess = Console.ReadLine();

                result = _safe.TryCombination(guess);

                Console.WriteLine(result);
                guessCount++;

            } while(guessCount < 10 && !result.WasSuccessful);
           

            Solver solver = new Solver();
            Solution solution = solver.Crack(_safe);
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
