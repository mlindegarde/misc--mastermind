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
            Console.WriteLine(Result);
            RenderFooter("Press ENTER to continue: ");
        }
        #endregion
    }
}
