using Lamar;
using Serilog;

namespace Mastermind.Application
{
    public class MastermindServiceRegistry : ServiceRegistry
    {
        public MastermindServiceRegistry()
        {
            Scan(
                s =>
                {
                    s.TheCallingAssembly();
                    //s.AssembliesAndExecutablesFromApplicationBaseDirectory(a => a.FullName.StartsWith("Mastermind."));
                    s.WithDefaultConventions();
                });

            For<ILogger>().Use(
                new LoggerConfiguration()
                    .WriteTo.Console().MinimumLevel.Verbose()
                    .CreateLogger()).Singleton();
        }
    }
}
