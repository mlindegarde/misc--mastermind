using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Lamar;
using Mastermind.Views;
using Serilog;

namespace Mastermind.Presenters
{
    public class MainMenuPresenter : BasePresenter<MainMenuView, MainMenuPresenter>
    {
        #region Properties
        public override string DefaultInput => "0";
        #endregion

        #region Constructor
        public MainMenuPresenter(
            MainMenuView view, 
            IContainer container, 
            ILogger logger)
            : base(view, container, logger)
        {
        }
        #endregion

        #region Base Class Overrides
        [SuppressMessage("ReSharper", "RedundantCast")]
        protected override Task<IPresenter> OnUserInputAsync(string input)
        {
            switch (input)
            {
                case "1": return Task.FromResult((IPresenter)Container.GetInstance<NewGamePresenter>());
                //case "1": return _container.GetInstance<AddStaffToPortalPresenter>();

                default: return Task.FromResult<IPresenter>(null);
            }
        }
        #endregion
    }
}
