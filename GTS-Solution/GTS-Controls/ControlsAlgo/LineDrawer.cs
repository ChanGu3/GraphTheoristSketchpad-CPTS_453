using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS_Controls
{
    internal class LineDrawer
    {
        private Color color = Color.Black;

        public LineDrawer() 
        { 
        }

        public Color Color
        {
            get => color;
            set => color = value;
        }



        private void CreateLineFromTwoNodes(NodeControl node1, NodeControl node2, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen penBlack = new Pen(Color.Black, 5);

            g.DrawLine(penBlack, node1.CenterOrigin, node2.CenterOrigin);
        }
    }
}
