using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS_Controls
{
    [ToolboxItem(true)]
    internal class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
           this.DoubleBuffered = true;
        }
    }
}
