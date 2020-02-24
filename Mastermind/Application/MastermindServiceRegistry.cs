using Lamar;
using Mastermind.Model;

namespace Mastermind.Application
{
    public class MastermindServiceRegistry : ServiceRegistry
    {
        #region Constructor
        public MastermindServiceRegistry(Settings settings)
        {
            Scan(
                s =>
                {
                    s.TheCallingAssembly();
                    s.WithDefaultConventions();
                });

            For<Settings>().Use(settings).Singleton();
        }
        #endregion
    }
}
