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
            // Hard coding things is bad, let's load the numbers outlined in the
            // programming exercise from a configuration file.
            Settings settings =
                new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build()
                    .Get<Settings>();

            // If we are going to let people mess with the config, we should probably
            // make sure it's valid before moving forward.
            if(!settings.AreValid())
                throw new ApplicationException("The settings are not valid, double check those");

            // Setup the IoC container (using Lamar which is the successor to 
            // StructureMap).
            _container = new Container(new MastermindServiceRegistry(settings));
        }

        private void Run()
        {
            // Let the IoC container take care of injecting the things the Game object
            // needs to run.
            Game game = _container.GetInstance<Game>();

            game.Init();
            game.DisplayRules();

            while (!game.IsOver)
            {
                game.Play();
            }

            game.DisplayResults();

            if (!game.WasSuccessful)
                game.ShowHowItsDone(); // <-- run the Solver

            // Give the user a moment to accept the outcome... for better or worse.
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
                // This should only happen with the application settings are not valid.
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                // If we ended up here, then I got something wrong.
                Console.WriteLine("Uh oh, I'm not really sure how we got here...");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        #endregion
    }
}
