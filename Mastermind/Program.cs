using Lamar;
using Mastermind.Application;
using Mastermind.Presenters;

namespace Mastermind
{
    class Program
    {
        #region Member Variables
        private IContainer _container;
        #endregion

        #region Methods
        private void Init()
        {
            _container = new Container(new MastermindServiceRegistry());
        }

        private void Run()
        {
            IPresenter presenter = _container.GetInstance<MainMenuPresenter>();

            while(presenter != null)
                presenter = presenter.Present();
        }
        #endregion

        static void Main()
        {
            Program program = new Program();

            program.Init();
            program.Run();
        }
    }
}
