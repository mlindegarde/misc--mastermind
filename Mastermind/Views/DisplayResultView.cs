using System;
using Mastermind.Model;
using Mastermind.Presenters;

namespace Mastermind.Views
{
    public class DisplayResultView : BaseView<DisplayResultPresenter>
    {
        #region Properties
        public override string Title => "RESULTS";

        public Result Result { get; set; }
        #endregion

        #region Base Class Overrides
        public override void Render()
        {
            Clear();
            RenderHeader(Title);
            Console.WriteLine("Key:");
            Console.WriteLine("\t'+' = You guessed a digit exactly correct");
            Console.WriteLine("\t'-' = You guessed a digit correctly, but");
            Console.WriteLine("\t      have the position wrong");
            Console.WriteLine();
            RenderSecondaryDivider();
            Console.WriteLine($"GUESS: {Result.Guess}");
            Console.WriteLine($"RESULT: {Result}");
            RenderFooter("Press ENTER to continue: ");
        }
        #endregion
    }
}
