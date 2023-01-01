using CommandLine;

namespace GUI.Cli
{
    public class CLIOptions
    {
        [Option('l', Required = true, HelpText = "Left file path")]
        public string? Left { get; set; }

        [Option('c', Required = false, HelpText = "Center file path")]
        public string? Center { get; set; }

        [Option('r', Required = true, HelpText = "Right file path")]
        public string? Right { get; set; }

        [Option('o', Required = false, HelpText = "Path to output merge result")]
        public string? Output { get; set; }
    }
}
