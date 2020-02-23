using System.Threading.Tasks;
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

        private async Task RunAsync()
        {
            IPresenter presenter = _container.GetInstance<MainMenuPresenter>();

            while(presenter != null)
                presenter = await presenter.PresentAsync();
        }
        #endregion

        static async Task Main()
        {
            Program program = new Program();

            program.Init();
            await program.RunAsync();
        }
    }
}
