using GUI.Cli;
using static GUI.Program;

namespace GUI
{
    public partial class TwoWayMerge : Form
    {
        private readonly CLIOptions options;

        public TwoWayMerge(CLIOptions options)
        {
            InitializeComponent();
            this.options = options;
        }
        
    }
}