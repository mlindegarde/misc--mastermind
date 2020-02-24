using Lamar;
using Serilog;

namespace Mastermind.Application
{
    public class MastermindServiceRegistry : ServiceRegistry
    {
        #region Constructor
        public MastermindServiceRegistry(Settings settings)
        {
            // Simple IoC configuration preferring convention over explicit
            // configuration.
            Scan(
                s =>
                {
                    s.TheCallingAssembly();
                    s.WithDefaultConventions();
                });

            For<Settings>().Use(settings).Singleton();

            For<ILogger>().Use(
                new LoggerConfiguration()
                    .MinimumLevel.Is(settings.MinimumLogLevel)
                    .WriteTo.Console()
                    .CreateLogger());
        }
        #endregion
    }
}
