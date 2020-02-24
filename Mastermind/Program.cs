using System;
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

            if(!settings.AreValid())
                throw new ApplicationException("The settings are not valid, double check those");

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

        #region Program Entry Point
        static void Main()
        {
            Program program = new Program();

            try
            {
                program.Init();
                program.Run();
            }
            catch(ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Uh oh, I'm not really sure how we got here...");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
