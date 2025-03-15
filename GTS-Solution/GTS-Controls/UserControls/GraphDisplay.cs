using GTS_UserInput;
using System.ComponentModel;
using System.Diagnostics;
using GTS_GraphEngine;
using System.Runtime.CompilerServices;
using GTS_Controls.UserControls.MenuControls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GTS_Controls
{
    [ToolboxItem(true)]
    public partial class GraphDisplay : UserControl
    {
        public event Action<SelectedItems>? ItemSelected; 
        AbstractGraphGTS<VertexUserControl>? graphGTS = null;
        SelectedItems selectedItems = new SelectedItems();

        ///
        /// edge id, edge object
        ///
        Dictionary<int, EdgeUserControl> controlEdges = new();

        private bool isSpaceDown = false;

        public GraphDisplay()
        {
            InitializeComponent();
            this.Listeners();
            this.panelGraph.Enabled = false;
            this.panelGraph.Hide();
        }

        private VertexUserControl CreateVertex(Point spawnLocation)
        {
            // setup graph link to control
            int vertexID = this.graphGTS.AddVertex();
            VertexUserControl nodeControl = new VertexUserControl(vertexID);
            this.graphGTS.Vertexes[vertexID].Data = nodeControl;
            this.graphGTS.Vertexes[vertexID].Data.Move += UpdatePanelOnGraphInteraction;
            this.graphGTS.Vertexes[vertexID].Data.MouseDown += OnSelectItem_Down;

            nodeControl.Parent = this.panelGraph;
            nodeControl.Location = spawnLocation;
            nodeControl.Name = $"nodeControl{vertexID}";

            this.panelGraph.Controls.Add(nodeControl);
            nodeControl.BringToFront();

            return nodeControl;
        }

        public EdgeUserControl CreateLoop(Control Parent, int vertexID, bool isDirected)
        {
            int edgeID = this.graphGTS.AddLoop(vertexID, isDirected);
            EdgeUserControl lineUserControl = new EdgeUserControl(edgeID, true);
            this.controlEdges.Add(edgeID, lineUserControl);
            lineUserControl.Parent = Parent;
            lineUserControl.Location = Parent.Location;
            lineUserControl.Size = Parent.Size;
            lineUserControl.Name = $"Edge: {vertexID}->{vertexID}";
            Parent.Controls.Add(lineUserControl);
            // lineUserControl.BringToFront();

            VertexUserControl vertex = this.graphGTS.Vertexes[vertexID].Data;

            int edgeCount = this.graphGTS.EdgeCountLoopVertex(vertexID);

            lineUserControl.CurveHeight = 4 * (edgeCount + 1);

            lineUserControl.UpdateLinePoints(
                new Point(vertex.CenterOrigin.X - (vertex.CircleRadius / 2), vertex.CenterOrigin.Y),
                new Point(vertex.CenterOrigin.X + (vertex.CircleRadius / 2), vertex.CenterOrigin.Y));

            UpdatePanelOnGraphInteraction(this, new EventArgs());

            return lineUserControl;
        }

        public EdgeUserControl CreateEdge(Control Parent, int startID, int endID)
        {
            int edgeID = this.graphGTS.AddEdge(startID, endID, false);
            EdgeUserControl edgeUserControl = new EdgeUserControl(edgeID, false);
            edgeUserControl.MouseDown += OnSelectItem_Down;
            this.controlEdges.Add(edgeID, edgeUserControl);
            edgeUserControl.Parent = Parent;
            // lineUserControl.Location = Parent.Location;
            edgeUserControl.Size = Parent.Size;
            edgeUserControl.Name = $"Edge: {startID}->{endID}";
            Parent.Controls.Add(edgeUserControl);
            // lineUserControl.BringToFront();

            int edgeCount = this.graphGTS.EdgeCountBetweenVertices(startID, endID);

            if (edgeCount == 1)
            {
                edgeUserControl.CurveHeight = 0;
            }
            else
            {
                float height = 0.05f;
                if (edgeCount % 2 == 0)
                {

                    if ((edgeCount / 2) == 1) { height = 0.1f / 2; }

                    edgeUserControl.CurveHeight = height * ((edgeCount / 2) + 1);
                }
                else
                {
                    if ((edgeCount / 2) == 1) { height = 0.1f / 2; }

                    edgeUserControl.CurveHeight = -height * ((edgeCount / 2) + 1);
                }
            }

            edgeUserControl.UpdateLinePoints(this.graphGTS.Vertexes[startID].Data.CenterOrigin, this.graphGTS.Vertexes[endID].Data.CenterOrigin);
            UpdatePanelOnGraphInteraction(this, new EventArgs());

            return edgeUserControl;
        }

        private void UpdatePanelOnGraphInteraction(object? sender, EventArgs e)
        {
            this.panelGraph.Refresh();
            this.panelGraph.Invalidate();


            foreach (EdgeUserControl edge in this.controlEdges.Values)
            {
                VertexUserControl vertexFrom = this.graphGTS.Edges[edge.EdgeID].VertexFrom.Data;
                VertexUserControl vertexTo = this.graphGTS.Edges[edge.EdgeID].VertexTo.Data;

                if (vertexTo == vertexFrom)
                {
                    edge.UpdateLinePoints(
                        new Point(vertexFrom.CenterOrigin.X - (vertexFrom.CircleRadius / 2), vertexFrom.CenterOrigin.Y),
                        new Point(vertexFrom.CenterOrigin.X + (vertexFrom.CircleRadius / 2), vertexFrom.CenterOrigin.Y));
                }
                else
                {
                    edge.UpdateLinePoints(
                        new Point(vertexFrom.CenterOrigin.X, vertexFrom.CenterOrigin.Y),
                        new Point(vertexTo.CenterOrigin.X, vertexTo.CenterOrigin.Y));
                }
            }
        }

        public void Listeners()
        {
            this.panelGraph.MouseDown += OnPanel_MouseDown;
        }

        private Point mouseLocation = Point.Empty;
        private void OnPanel_MouseDown(object? sender, MouseEventArgs e)
        {
            //Debug.WriteLine($"Mouse button: {e.Button}, Location: {e.Location}");
            if (e.Button == MouseButtons.Right)
            {
                this.mouseLocation = e.Location;
                contextMenuStrip1.Show(this, e.Location);
            }
            else if (e.Button == MouseButtons.Left)
            {
                this.selectedItems.Clear();
                UpdatePanelOnGraphInteraction(sender, e);
                this.ItemSelected?.Invoke(selectedItems);
            }
        }
        
        private void CreateVertex_Click(object? sender, EventArgs e)
        {
            contextMenuStrip1.Close();
            CreateVertex(mouseLocation);
        }
    
        private void OnSelectItem_Down(object? sender, MouseEventArgs e)
        {
            if(sender is VertexUserControl || sender is EdgeUserControl)
            {
                this.selectedItems.AddSelectedItem(sender);

                UpdatePanelOnGraphInteraction(sender, e);

                this.ItemSelected?.Invoke(selectedItems);
            }
        }

        #region GraphCreateReset
        public void On_CreateGraph(string GraphName)
        {
            if (this.graphGTS == null)
            { 
                if (GraphName == "graph")
                {
                    this.graphGTS = new GraphGTS<VertexUserControl>();

                    this.panelGraph.Enabled = true;
                    this.panelGraph.Show();
                }
                else if(GraphName == "weighted_graph")
                {
                    this.graphGTS = new GraphGTSWeighted<VertexUserControl>();

                    this.panelGraph.Enabled = true;
                    this.panelGraph.Show();
                }
            }
        }
    
        public void On_ResetGraph(object? sender, EventArgs e)
        {
            this.panelGraph.Enabled = false;
            this.panelGraph.Hide();
            
            if (graphGTS is not null)
            {
                foreach (EdgeUserControl edge in controlEdges.Values)
                {
                    this.Controls.Remove(edge);
                    edge.Dispose();
                }

                foreach (VertexGTS<VertexUserControl> vertex in graphGTS.Vertexes.Values)
                {
                    this.Controls.Remove(vertex.Data);
                    vertex.Data.Dispose();
                }

                this.controlEdges.Clear();
                this.graphGTS = null;
            }

            UpdatePanelOnGraphInteraction(sender, e);
        }
        #endregion

        #region TwoVertexSelectmenu
        public void On_AddEdge(bool isDirected, int weight)
        {
            // should not break since they will exist
            CreateEdge(this.panelGraph, selectedItems.VertexUserControls!.First().VertexID, selectedItems.VertexUserControls!.Last().VertexID);
        }
        #endregion

        #region TwoVertexSelectmenu
        public void On_AddLoop(bool isDirected, int weight)
        {
            // should not break since they will exist
            CreateLoop(this.panelGraph, selectedItems.VertexUserControls!.First().VertexID, isDirected);
        }
        #endregion
    }
}
