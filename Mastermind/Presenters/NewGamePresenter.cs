using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lamar;
using Mastermind.Model;
using Mastermind.Views;
using Serilog;

namespace Mastermind.Presenters
{
    public class NewGamePresenter : BasePresenter<NewGameView,NewGamePresenter>
    {
        #region Properties
        public override string DefaultInput => "Y";
        #endregion

        #region Constructor
        public NewGamePresenter(
            NewGameView view,
            IContainer container,
            ILogger logger)
            : base(view, container, logger)
        {
        }
        #endregion

        #region Base Class Overrides
        protected override Task<IPresenter> OnUserInputAsync(string input)
        {
            Regex confirmRegEx = new Regex(@"^yep|yes|yeah|y$", RegexOptions.IgnoreCase);

            if(confirmRegEx.IsMatch(input))
            {
                GetGuessPresenter presenter = Container.GetInstance<GetGuessPresenter>();
                presenter.Game = Container.GetInstance<Game>();

                return Task.FromResult((IPresenter)presenter);
            }
            
            return Task.FromResult((IPresenter)Container.GetInstance<MainMenuPresenter>());
        }
        #endregion
    }
}
