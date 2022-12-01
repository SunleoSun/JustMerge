using CommandLine;

namespace GUI.Cli
{
    [Verb("Compare", HelpText = "Compare two files")]
    public class Options2Files
    {
        public Options2Files(string leftFile, string rightFile)
        {
            Left = leftFile;
            Right = rightFile;
        }

        [Value(0, HelpText = "Left file path", Required = true)]
        public string Left { get; set; }

        [Value(1, HelpText = "Right file path", Required = true)]
        public string Right { get; set; }
    }
}
