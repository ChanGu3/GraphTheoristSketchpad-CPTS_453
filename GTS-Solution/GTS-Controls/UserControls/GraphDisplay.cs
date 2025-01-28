using GTS_UserInput;
using System.ComponentModel;
using System.Diagnostics;

namespace GTS_Controls
{
    [ToolboxItem(true)]
    public partial class GraphDisplay : UserControl
    {
        List<NodeControl> nodeControls = new List<NodeControl>();
        private bool isSpaceDown = false;

        public GraphDisplay()
        {
            InitializeComponent();

            CreateNode();
            CreateNode();
            CreateNode();
            CreateNode();
            CreateNode();
            
            foreach (NodeControl node in nodeControls)
            {
                node.OnNodeClicked += ShowNodeInDebug;
                node.Move += UpdateUserControlOnNodeMove;
                node.Move += UpdatePanelOnNodeMove;
            }

            this.panelGraph.Paint += panelGraph_Paint;
        }

        private void panelGraph_Paint(object? sender, PaintEventArgs e)
        {
            CreateLineFromTwoNodes(nodeControls[0], nodeControls[1], e);
        }

        private void CreateLineFromTwoNodes(NodeControl node1, NodeControl node2, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen penBlack = new Pen(Color.Black, 5);
            g.DrawLine(penBlack, node1.CenterOrigin, node2.CenterOrigin);
        }

        private void CreateNode()
        {
            NodeControl nodeControl = new NodeControl();
            nodeControl.Parent = this;
            nodeControl.Location = this.Location;
            nodeControl.Name = $"nodeControl{nodeControls.Count}";

            this.Controls.Add(nodeControl);
            nodeControl.BringToFront();

            nodeControls.Add(nodeControl);
        }

        
        private void UpdateUserControlOnNodeMove(object? sender, EventArgs e)
        {
            this.Refresh();
            this.Invalidate();
        }
        

        private void UpdatePanelOnNodeMove(object? sender, EventArgs e)
        {
            this.panelGraph.Invalidate();
        }

        private void ShowNodeInDebug(object? sender, EventArgs e)
        {
            if (sender is NodeControl node)
            {
                Debug.WriteLine(node.Name);
            }
        }
    }
}
