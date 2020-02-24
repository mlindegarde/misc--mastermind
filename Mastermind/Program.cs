using Lamar;
using Mastermind.Application;
using Mastermind.Model;
using Microsoft.Extensions.Configuration;

namespace Mastermind
{
    class Program
    {
        #region Member Variables
        private IContainer _container;
        #endregion

        #region Methods
        private void Init()
        {
            Settings settings =
                new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build()
                    .Get<Settings>();

            _container = new Container(new MastermindServiceRegistry(settings));
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
