using System;
using System.Threading.Tasks;
using Lamar;
using Mastermind.Application;
using Mastermind.Model;
using Mastermind.Views;
using Serilog;

namespace Mastermind.Presenters
{
    public class InteractiveGamePresenter : BasePresenter<InteractiveGameView, InteractiveGamePresenter>
    {
        #region Properties
        public override string DefaultInput => "0";
        #endregion

        #region Constructor
        public InteractiveGamePresenter(
            InteractiveGameView view, 
            IContainer container, 
            ILogger logger)
            : base(view, container, logger)
        {
        }
        #endregion

        #region Base Class Overrides
        public override Task<IPresenter> PresentAsync()
        {
            Combination combination =
                new CombinationBuilder()
                    .WithLength(4)
                    .UsingDigitsBetween(1, 6);

            View.Render();

            int guessCount = 0;

            Result result;

            do
            {
                View.RenderPrompt();
                string guess = Console.ReadLine();

                result = combination.Try(guess);

                View.RenderResult(result);
                guessCount++;

            } while (guessCount < 10 && !result.WasRight);

            return Task.FromResult((IPresenter)Container.GetInstance<MainMenuPresenter>());
        }

        protected override Task<IPresenter> OnUserInputAsync(string input)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
