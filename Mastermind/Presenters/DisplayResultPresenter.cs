using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lamar;
using Mastermind.Model;
using Mastermind.Views;
using Serilog;

namespace Mastermind.Presenters
{
    public class DisplayResultPresenter : BasePresenter<DisplayResultView, DisplayResultPresenter>
    {
        #region Properties
        public override string DefaultInput => "Y";

        public Game Game { get; set; }
        public Result Result { get; set; }
        #endregion

        #region Constructor
        public DisplayResultPresenter(
            DisplayResultView view,
            IContainer container,
            ILogger logger)
            : base(view, container, logger)
        {
        }
        #endregion

        #region Base Class Overrides
        public override Task<IPresenter> PresentAsync()
        {
            View.Result = Result;

            return base.PresentAsync();
        }

        protected override Task<IPresenter> OnUserInputAsync(string input)
        {
            Regex confirmRegEx = new Regex(@"^yep|yes|yeah|y$", RegexOptions.IgnoreCase);

            if (confirmRegEx.IsMatch(input))
            {
                GetGuessPresenter presenter = Container.GetInstance<GetGuessPresenter>();
                presenter.Game = Game;

                return Task.FromResult((IPresenter)presenter);
            }

            return Task.FromResult((IPresenter)Container.GetInstance<MainMenuPresenter>());
        }
        #endregion
    }
}
