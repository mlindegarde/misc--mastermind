using System;
using Mastermind.Application;
using Mastermind.Model;
using Mastermind.Presenters;

namespace Mastermind.Views
{
    public class GetGuessView : BaseView<GetGuessPresenter>
    {
        #region Member Variables
        private readonly Settings _settings;
        #endregion

        #region Properties
        public override string Title => "GUESS ";

        public Game Game { get; set; }
        #endregion

        #region Constructor
        public GetGuessView(Settings settings)
        {
            _settings = settings;
        }
        #endregion

        #region Base Class Overrides
        public override void Render()
        {
            Clear();
            RenderHeader($"{Title} #{Game.GuessCount+1}");
            Console.WriteLine($"Please enter a guess that is {_settings.CombinationLength} digits long");
            Console.WriteLine($"Be sure to use digits between {_settings.MinimumDigit} and {_settings.MaximumDigit}.");
            Console.WriteLine();

            if (Game.GuessCount > 0)
            {
                RenderSecondaryDivider();
                Console.WriteLine("Your Guesses so far:");

                foreach(Result result in Game.History)
                {
                    Console.WriteLine($"\t{result.Guess} = {result}");
                }
            }

            RenderFooter("GUESS: ");
        }
        #endregion
    }
}
