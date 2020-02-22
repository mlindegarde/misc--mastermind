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
        //private Combination _combination;
        #endregion

        #region Methods
        private void Init()
        {
            /*
            _combination =
                new CombinationBuilder()
                    .WithLength(4)
                    .UsingDigitsBetween(1, 6);
                    */

            _container = new Container(new MastermindServiceRegistry());
        }

        private async Task RunAsync()
        {
            /*
            int guessCount = 0;

            Result result;

            do
            {
                string guess = Console.ReadLine();

                result = _combination.Try(guess);

                Console.WriteLine(result);
                guessCount++;

            } while(guessCount < 10 && !result.WasRight);

            Solver solver = new Solver();
            Solution solution = solver.Crack(_combination);
            Console.ReadLine();
            */

            IPresenter presenter = _container.GetInstance<MainMenuPresenter>();

            while(presenter != null)
                presenter = await presenter.PresentAsync();
        }
        #endregion

        static async Task Main()
        {
            Program game = new Program();

            game.Init();
            await game.RunAsync();
        }
    }
}
