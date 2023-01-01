using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public class ScintillaOverride : Scintilla
    {
        public event Action<Graphics>? PaintEvent;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 15)
            {
                PaintEvent?.Invoke(this.CreateGraphics());
            }
        }
    }
}
