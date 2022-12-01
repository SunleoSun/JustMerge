using CommandLine;

namespace GUI.Cli
{
    [Verb("Merge", HelpText = "Merge three files")]
    public class Options3Files
    {
        public Options3Files(string leftFile, string centerFile, string rightFile, string output)
        {
            Left = leftFile;
            Center = centerFile;
            Right = rightFile;
            Output = output;
        }

        [Value(0, HelpText = "Left file path", Required = true)]
        public string Left { get; set; }

        [Value(1, HelpText = "Center file path", Required = true)]
        public string Center { get; set; }

        [Value(2, HelpText = "Right file path", Required = true)]
        public string Right { get; set; }

        [Option('o', "output", Required = false, HelpText = "Set output to verbose messages.")]
        public string Output { get; set; }
    }
}
