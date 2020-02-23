using System;
using Mastermind.Presenters;

namespace Mastermind.Views
{
    public abstract class BaseView<TPresenter> : IView<TPresenter>
        where TPresenter : IPresenter
    {
        #region Constants
        private const string PrimaryDivider =
            "==========================================================";

        private const string SecondaryDivider =
            "----------------------------------------------------------";

        protected ConsoleColor PromptColor = ConsoleColor.Yellow;
        protected ConsoleColor MenuColor = ConsoleColor.DarkYellow;
        protected ConsoleColor DefaultColor = ConsoleColor.White;
        #endregion

        #region Properties
        public abstract string Title { get; }
        public TPresenter Presenter { get; set; }
        #endregion

        #region IView Implementation
        public abstract void Render();

        public void RenderError(string errorMessage)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            Clear();
            RenderHeader($"{Title} - ERROR");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = defaultColor;

            RenderFooter("Press ENTER to continue: ");
        }
        #endregion

        #region Utility Methods
        public void Clear()
        {
            Console.Clear();
        }

        public void RenderHeader(string header)
        {
            Console.ForegroundColor = MenuColor;
            Console.WriteLine(header);
            Console.ForegroundColor = DefaultColor;
            RenderPrimaryDivider();
            Console.WriteLine();
        }

        public void Pause()
        {
            Console.ForegroundColor = PromptColor;
            Console.WriteLine();
            Console.Write("Press ENTER to continue");

            Console.ReadLine();

            Console.WriteLine();
            Console.ForegroundColor = DefaultColor;
        }

        public void RenderFooter(string message)
        {
            Console.WriteLine();
            RenderPrimaryDivider();
            Console.ForegroundColor = PromptColor;
            Console.Write(message);
            Console.ForegroundColor = DefaultColor;
        }

        public void RenderPrimaryDivider()
        {
            Console.ForegroundColor = MenuColor;
            Console.WriteLine(PrimaryDivider);
            Console.ForegroundColor = DefaultColor;
        }

        public void RenderSecondaryDivider()
        {
            Console.ForegroundColor = MenuColor;
            Console.WriteLine(SecondaryDivider);
            Console.ForegroundColor = DefaultColor;
        }
        #endregion
    }
}
