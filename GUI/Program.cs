using CommandLine;
using CommandLine.Text;
using GUI.Cli;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var parsedArguments = Parser.Default.ParseArguments<CLIOptions>(args);
            if (!args.Any())
            {
                MessageBox.Show($"Please specify command arguments. {Environment.NewLine}{HelpText.AutoBuild(parsedArguments)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ApplicationConfiguration.Initialize();

            parsedArguments.MapResult(
              (CLIOptions options) =>
              {
                  Log.LogErrors(() => Application.Run(new TwoWayCompare(options)));
                  return 0;
              },
              errors =>
              {
                  var errorText = HelpText.AutoBuild(parsedArguments, h => HelpText.DefaultParsingErrorsHandler(parsedArguments, h));
                  MessageBox.Show($"Please, correctly specify command arguments. {Environment.NewLine}{errorText}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return 1;
              });
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

        }
    }
}