using System.CommandLine;
using System.CommandLine.Invocation;

namespace SwitchStateSample
{
    public enum AppMode
    {
        Tuple
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rootCommand = new RootCommand("Sample showing switch expressions")
            {
                new Option("--mode", "select the mode to run the application")
                {
                    Argument = new Argument<AppMode>(defaultValue: () => AppMode.Tuple)
                },
            };

            rootCommand.Handler = CommandHandler.Create<AppMode>(async (mode) =>
            {
                var runner = new TrafficLightRunner();

                switch (mode)
                {
                    case AppMode.Tuple:
                        await runner.UseTuplesAsync();
                        break;
                }
            });

            rootCommand.Invoke(args);
        }
    }
}
