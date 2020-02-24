using Mastermind.Ai;
using Mastermind.Application;
using Mastermind.Model;

namespace Mastermind
{
    class Program
    {
        #region Member Variables
        private Settings _settings;
        #endregion

        #region Methods
        private void Init()
        {
            _settings =
                new Settings
                {
                    CombinationLength = 4,
                    MinimumDigit = 1,
                    MaximumDigit = 6,
                    GuessLimit = 10
                };
        }

        private void Run()
        {
            Game game = new Game(_settings, new InputValidator(_settings), new Solver());

            game.Init();
            game.DisplayRules();

            while (!game.IsOver)
            {
                game.Play();
            }

            game.DisplayResults();

            if (!game.WasSuccessful)
                game.ShowHowItsDone();

            game.PauseForEffect();
        }
        #endregion

        static void Main()
        {
            Program program = new Program();

            program.Init();
            program.Run();
        }
    }
}
