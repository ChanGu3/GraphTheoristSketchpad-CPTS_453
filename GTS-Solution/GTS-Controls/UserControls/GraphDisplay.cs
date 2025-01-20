using System.Diagnostics;

namespace GTS_Controls
{
    public partial class GraphDisplay : UserControl
    {
        public GraphDisplay()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

            List<NodeControl> nodes = new List<NodeControl>();
            nodes.Add(this.nodeControl1);
            nodes.Add(this.nodeControl2);

            foreach (NodeControl node in nodes)
            {
                node.OnNodeClicked += Function;
            }
        }

        /*
        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myDrawingPen = new Pen(Color.OrangeRed);

            Brush myDrawingBrush = new SolidBrush(Color.OrangeRed);

            new RectangleF();
            g.FillRectangle(myDrawingBrush, new RectangleF(50f, 50f, 100f, 100f));

            

            g.FillEllipse(myDrawingBrush, new RectangleF(200f, 200f, 50f, 50f));
        }
        */
    
        public void Function(object? sender, EventArgs e)
        {
            if (sender is NodeControl node)
            {
                Debug.WriteLine(node.Name);
                // node.
            }
            else
            {
                throw new Exception("sender was not a node something went wrong.");
            }
        }

    }
}
