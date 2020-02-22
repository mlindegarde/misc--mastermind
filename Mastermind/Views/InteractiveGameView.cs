using System;
using Mastermind.Presenters;

namespace Mastermind.Views
{
    public class InteractiveGameView : BaseView<InteractiveGamePresenter>
    {
        #region Properties
        public override string Title => "INTERACTIVE GAME";
        #endregion

        #region Base Class Overrides
        public override void Render()
        {
            Clear();
            RenderHeader(Title);
            Console.WriteLine("Welcome to the interactive version of Mastermind");
            Console.WriteLine("Please enter a guess");
            RenderSecondaryDivider();
        }
        #endregion

        #region UI Methods
        public void RenderPrompt()
        {
            Console.WriteLine();
            Console.ForegroundColor = PromptColor;
            Console.Write("GUESS: ");
            Console.ForegroundColor = DefaultColor;
        }
        #endregion
    }
}
