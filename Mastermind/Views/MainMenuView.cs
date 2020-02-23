using System;
using Mastermind.Presenters;

namespace Mastermind.Views
{
    public class MainMenuView : BaseView<MainMenuPresenter>
    {
        #region Properties
        public override string Title => "MAIN MENU";
        #endregion

        #region Base Class Overrides
        public override void Render()
        {
            Clear();
            RenderHeader(Title);
            Console.WriteLine("[1] Play the game interactively");
            Console.WriteLine("[2] Let the computer play itself");
            Console.WriteLine();

            RenderSecondaryDivider();
            Console.WriteLine("[0] Exit");

            RenderFooter($"SELECTION [{Presenter.DefaultInput}]: ");
        }
        #endregion
    }
}
