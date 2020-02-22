using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Lamar;
using Mastermind.Views;
using Serilog;

namespace Mastermind.Presenters
{
    public class MainMenuPresenter : BasePresenter<MainMenuView, MainMenuPresenter>
    {
        #region Member Variables
        private readonly IContainer _container;
        #endregion

        #region Properties
        protected override string DefaultInput => "0";
        #endregion

        #region Constructor
        public MainMenuPresenter(MainMenuView view, IContainer container, ILogger logger)
            : base(view, logger)
        {
            _container = container;
        }
        #endregion

        #region Base Class Overrides
        public override async Task<IPresenter> PresentAsync()
        {
            View.Render();

            string input = Console.ReadLine();

            if (String.IsNullOrEmpty(input))
                input = DefaultInput;

            return await OnUserInputAsync(input);
        }

        [SuppressMessage("ReSharper", "RedundantCast")]
        protected override async Task<IPresenter> OnUserInputAsync(string input)
        {
            switch (input)
            {
                case "1": return _container.GetInstance<InteractiveGamePresenter>();
                //case "1": return _container.GetInstance<AddStaffToPortalPresenter>();

                default: return await Task.FromResult<IPresenter>(null);
            }
        }
        #endregion
    }
}
