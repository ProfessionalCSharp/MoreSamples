using Microsoft.Extensions.CommandLineUtils;
using System;

namespace HttpClientFactorySample
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: false)
            {
                FullName = "HttpClient Factory Sample"
            };
            FactorySample.Register(app);
            TypedClientSample.Register(app);
            PolicySample.Register(app);

            app.Command("help", cmd =>
            {
                cmd.Description = "Get help for the application";
                CommandArgument argument = cmd.Argument("<COMMAND>", "The command to get help for");
                cmd.OnExecute(() =>
                {
                    app.ShowHelp(argument.Value);
                    return 0;
                });
            });
            app.OnExecute(() =>
            {
                app.ShowHelp();
                return 0;
            });
            app.Execute(args);

            Console.WriteLine("bye");
        }
    }
}
