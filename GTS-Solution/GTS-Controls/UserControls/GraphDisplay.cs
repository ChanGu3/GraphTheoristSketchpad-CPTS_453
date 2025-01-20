using GTS_UserInput;
using System.Diagnostics;

namespace GTS_Controls
{
    public partial class GraphDisplay : UserControl
    {
        List<NodeControl> nodeControls = new List<NodeControl>();
        private bool isSpaceDown = false;

        public GraphDisplay()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

            UserInput.Instance.AddKeyDownListener(Keys.Space, SpacePressed);

            CreateNode();
            CreateNode();
            CreateNode();
            CreateNode();
            CreateNode();

            foreach (NodeControl node in nodeControls)
            {
                node.OnNodeClicked += Function;
            }
        }

        public void CreateNode()
        {
            NodeControl nodeControl = new NodeControl();
            nodeControl.Parent = panelGraph;
            nodeControl.Location = this.Location;
            nodeControl.BackColor = Color.Transparent;
            nodeControl.BackgroundImageLayout = ImageLayout.None;
            nodeControl.CircleColor = Color.DimGray;
            nodeControl.Name = "nodeControl";
            nodeControl.TabIndex = 0;
            nodeControl.BringToFront();
            nodeControls.Add(nodeControl);
        }

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

        private void panelGraph_Paint(object sender, PaintEventArgs e)
        {
            if (isSpaceDown)
            {
                CreateLineFromTwoNodes(nodeControls[0], nodeControls[1], e);
            }

            isSpaceDown = false;
        }

        private void CreateLineFromTwoNodes(NodeControl node1, NodeControl node2, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen penBlack = new Pen(Color.Black);

            g.DrawLine(penBlack, node1.CenterOrigin, node2.CenterOrigin);
        }

        private void SpacePressed(object? sender, EventArgs e)
        {
            isSpaceDown = true;
            this.Refresh();
        }
    }
}
