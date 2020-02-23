using System;
using System.Threading.Tasks;
using Lamar;
using Mastermind.Views;
using Serilog;

namespace Mastermind.Presenters
{
    public abstract class BasePresenter<TView, TPresenter> : IPresenter
        where TView : class, IView<TPresenter>
        where TPresenter : class, IPresenter
    {
        #region Properties
        public TView View { get; }
        protected IContainer Container { get; }
        protected ILogger Logger { get; }

        public abstract string DefaultInput { get; }
        #endregion

        #region Constructor
        protected BasePresenter(
            TView view, 
            IContainer container, 
            ILogger logger)
        {
            View = view;
            View.Presenter = this as TPresenter;

            Container = container;
            Logger = logger;
        }
        #endregion

        #region IPresenter Implementation
        public virtual IPresenter Present()
        {
            View.Render();

            string input = Console.ReadLine();

            if (String.IsNullOrEmpty(input))
                input = DefaultInput;

            return OnUserInput(input);
        }
        #endregion

        #region Utility Methods
        protected abstract IPresenter OnUserInput(string input);
        #endregion
    }
}
