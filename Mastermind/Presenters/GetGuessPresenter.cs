using System.Threading.Tasks;
using Lamar;
using Mastermind.Model;
using Mastermind.Views;
using Serilog;

namespace Mastermind.Presenters
{
    public class GetGuessPresenter : BasePresenter<GetGuessView,GetGuessPresenter>
    {
        #region Properties
        public override string DefaultInput => "Q";

        public Game Game { get; set; }
        #endregion

        #region Constructor
        public GetGuessPresenter(
            GetGuessView view,
            IContainer container,
            ILogger logger)
            : base(view, container, logger)
        {
        }
        #endregion

        #region Base Class Overrides
        public override Task<IPresenter> PresentAsync()
        {
            View.Game = Game;

            return base.PresentAsync();
        }

        protected override Task<IPresenter> OnUserInputAsync(string input)
        {
            DisplayResultPresenter presenter = Container.GetInstance<DisplayResultPresenter>();
            presenter.Game = Game;
            presenter.Result = Game.TryCombination(input);

            return Task.FromResult((IPresenter)presenter);
        }
        #endregion
    }
}
