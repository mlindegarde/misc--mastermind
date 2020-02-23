using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lamar;
using Mastermind.Application;
using Mastermind.Model;
using Mastermind.Views;
using Serilog;

namespace Mastermind.Presenters
{
    public class DisplayResultPresenter : BasePresenter<DisplayResultView, DisplayResultPresenter>
    {
        #region Member Variables
        private Settings _settings;
        #endregion

        #region Properties
        public override string DefaultInput => "";

        public Game Game { get; set; }
        public Result Result { get; set; }
        #endregion

        #region Constructor
        public DisplayResultPresenter(
            DisplayResultView view,
            Settings settings,
            IContainer container,
            ILogger logger)
            : base(view, container, logger)
        {
            _settings = settings;
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
            if(Game.WasWon || Game.GuessCount == _settings.GuessLimit)
            {

            }

            GetGuessPresenter presenter = Container.GetInstance<GetGuessPresenter>();
            presenter.Game = Game;

            return Task.FromResult((IPresenter)presenter);
        }
        #endregion
    }
}
