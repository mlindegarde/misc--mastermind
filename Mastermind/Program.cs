using Lamar;
using Mastermind.Ai;
using Mastermind.Application;
using Mastermind.Model;

namespace Mastermind
{
    class Program
    {
        #region Member Variables
        private IContainer _container;
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

            _container = new Container(new MastermindServiceRegistry(_settings));
        }

        private void Run()
        {
            Game game = _container.GetInstance<Game>();

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
