using System;
using System.Threading.Tasks;
using Lamar;
using Mastermind.Views;
using Serilog;

namespace Mastermind.Presenters
{
    public class InteractiveGamePresenter : BasePresenter<InteractiveGameView, InteractiveGamePresenter>
    {
        #region Member Variables
        private readonly IContainer _container;
        #endregion

        #region Properties
        protected override string DefaultInput => "0";
        #endregion

        #region Constructor
        public InteractiveGamePresenter(
            InteractiveGameView view, 
            IContainer container, 
            ILogger logger)
            : base(view, logger)
        {
            _container = container;
        }
        #endregion

        #region Base Class Overrides
        public override async Task<IPresenter> PresentAsync()
        {
            InteractiveGameView gameView = View as InteractiveGameView;

            gameView.Render();


            gameView.RenderPrompt();

            string input = Console.ReadLine();

            if(String.IsNullOrEmpty(input))
                input = DefaultInput;

            return await OnUserInputAsync(input);
        }

        protected override Task<IPresenter> OnUserInputAsync(string input)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
