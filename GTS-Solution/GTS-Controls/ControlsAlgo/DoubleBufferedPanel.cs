using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS_Controls
{
    internal class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
           this.DoubleBuffered = true;
        }
    }
}
