using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lamar;
using Mastermind.Views;
using Serilog;

namespace Mastermind.Presenters
{
    public class InstructionsPresenter : BasePresenter<InstructionsView,InstructionsPresenter>
    {
        #region Properties
        public override string DefaultInput => "Y";
        #endregion

        #region Constructor
        public InstructionsPresenter(
            InstructionsView view,
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

            IPresenter presenter = confirmRegEx.IsMatch(input)
                ? (IPresenter)Container.GetInstance<InteractiveGamePresenter>()
                : Container.GetInstance<MainMenuPresenter>();

            return Task.FromResult(presenter);
        }
        #endregion
    }
}
