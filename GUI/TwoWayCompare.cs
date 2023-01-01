using DiffMatchPatch;
using GUI.Cli;
using ScintillaNET;

namespace GUI
{
    public partial class TwoWayCompare : Form
    {
        readonly CLIOptions options;
        private readonly List<Diff> diff;

        public TwoWayCompare(CLIOptions options)
        {
            InitializeComponent();
            this.options = options;
            var file1 = File.ReadAllText(options.Left);
            var file2 = File.ReadAllText(options.Right);
            var diffEngine = new diff_match_patch();
            diff = diffEngine.diff_main(file1, file2);
            diffEngine.diff_cleanupSemantic(diff);
            scintilla2.LexerName = "cpp";
            scintilla1.LexerName = "cpp";


            scintilla2.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            scintilla2.Styles[Style.Cpp.Comment].ForeColor = Color.Green;
            scintilla2.Styles[Style.Cpp.CommentLine].ForeColor = Color.Green;
            scintilla2.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            scintilla2.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            scintilla2.Styles[Style.Cpp.Word2].ForeColor = Color.Purple;
            scintilla2.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21);
            scintilla2.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21);
            scintilla2.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21);
            scintilla2.Styles[Style.Cpp.Identifier].ForeColor = Color.Blue;
            scintilla2.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            scintilla2.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            scintilla2.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;

            scintilla2.Styles[Style.Cpp.CommentDoc].ForeColor = Color.Purple;
            scintilla2.Styles[Style.Cpp.CommentDocKeyword].ForeColor = Color.Red;
            scintilla2.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = Color.Red;
            scintilla2.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.Purple;

            scintilla1.AddText(file1);
            scintilla2.AddText(file2);

            //var style = new Style(scintilla2, scintilla2.Styles.Count);
            //style.BackColor = Color.AliceBlue;
            //scintilla2.Styles.Append(style);
            //scintilla2.StartStyling(5);
            //scintilla2.SetStyling(10, scintilla2.Styles.Count - 1);
            scintilla2.SetSelection(0, 10);
            scintilla2.SetSelectionBackColor(true, Color.Aqua);
            scintilla2.PaintEvent += Scintilla2_PaintEvent;
            
            //scintilla2.Refresh();
        }

        private void Scintilla2_PaintEvent(Graphics gr)
        {
            Pen p = new Pen(SystemColors.ControlDark);
            gr.DrawLine(p, new Point(0, 0), new Point(1000, 1000));
            gr.DrawRectangle(p, 0, 0, 100, 100);
        }

        private void Scintilla2_Paint(object? sender, PaintEventArgs e)
        {
           
        }
    }
}