using System;
using Mastermind.Application;
using Mastermind.Presenters;

namespace Mastermind.Views
{
    public class NewGameView : BaseView<NewGamePresenter>
    {
        #region Member Variables
        private readonly Settings _settings;
        #endregion

        #region Properties
        public override string Title => "MASTERMIND INSTRUCTIONS";
        #endregion

        #region Constructor
        public NewGameView(Settings settings)
        {
            _settings = settings;
        }
        #endregion

        #region Base Class Overrides
        public override void Render()
        {
            Clear();
            RenderHeader(Title);
            Console.WriteLine("Welcome to Mastermind.");
            Console.WriteLine();
            Console.WriteLine($"In this game you will have {_settings.GuessLimit} guesses to attempt");
            Console.WriteLine($"to guess the {_settings.CombinationLength} digit combination.");
            Console.WriteLine();
            Console.WriteLine($"The digits you enter must be between {_settings.MinimumDigit} and {_settings.MaximumDigit}.");
            Console.WriteLine("If you enter a digit that is both correct and in");
            Console.WriteLine("the correct position you will see a '+' in the");
            Console.WriteLine("response from Mastermind.  If you enter a digit");
            Console.WriteLine("that is correct, but in the wrong position you");
            Console.WriteLine("will see a '-' in the response.");
            RenderFooter($"Are you ready to play [{Presenter.DefaultInput}]: ");
        }
        #endregion
    }
}
