using System.ComponentModel;
using GTS_GraphEngine;
using GTS_Controls.UserControls.MenuControls;

namespace GTS_Controls
{
    [ToolboxItem(true)]
    public partial class GraphDisplay : UserControl
    {
        public event Action<SelectedItems, AbstractGraphGTS<VertexUserControl>?>? ItemSelected;
        private AbstractGraphGTS<VertexUserControl>? graphGTS = null;
        private SelectedItems selectedItems = new SelectedItems();

        public event Action<int>? SetOrder;
        public event Action<int>? SetSize;
        public event Action<int>? SetComponents;
        public event Action<(List<int>, List<List<int>>)>? OpenAdjMatrix;
        public event Action<Dictionary<VertexGTS<VertexUserControl>, (VertexGTS<VertexUserControl>?, float)>, string>? OpenShortestPath;
        ///
        /// edge id, edge object
        ///
        Dictionary<int, EdgeUserControl> controlEdges = new();

        // private bool isSpaceDown = false;

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
            int vertexID = this.graphGTS!.AddVertex();
            VertexUserControl nodeControl = new VertexUserControl(vertexID);
            this.graphGTS.Vertexes[vertexID].Data = nodeControl;
            this.graphGTS.Vertexes[vertexID].Data.Move += UpdatePanelOnGraphInteraction;
            this.graphGTS.Vertexes[vertexID].Data.MouseDown += OnSelectItem_Down;

            nodeControl.Parent = this.panelGraph;
            nodeControl.Location = spawnLocation;
            nodeControl.Name = $"nodeControl{vertexID}";

            this.panelGraph.Controls.Add(nodeControl);
            nodeControl.BringToFront();

            SetComponents?.Invoke(this.graphGTS!.ComponentCount);
            this.SetOrder?.Invoke(this.graphGTS!.Order);
            return nodeControl;
        }

        public EdgeUserControl CreateLoop(Control Parent, int vertexID, bool isDirected, int weight)
        {
            int edgeID = this.graphGTS!.AddLoop(vertexID, isDirected, weight);
            EdgeUserControl edgeUserControl = new EdgeUserControl(edgeID, true, isDirected);
            edgeUserControl.MouseDown += OnSelectItem_Down;
            this.controlEdges.Add(edgeID, edgeUserControl);
            edgeUserControl.Parent = Parent;
            edgeUserControl.Location = Parent.Location;
            edgeUserControl.Size = Parent.Size;
            edgeUserControl.Name = $"Edge: {vertexID}->{vertexID}";
            Parent.Controls.Add(edgeUserControl);
            // lineUserControl.BringToFront();

            VertexUserControl vertex = this.graphGTS.Vertexes[vertexID].Data;

            int edgeCount = this.graphGTS.EdgeCountLoopVertex(vertexID);

            edgeUserControl.CurveHeight = 4 * (edgeCount + 1);

            edgeUserControl.UpdateLinePoints(
                new Point(vertex.CenterOrigin.X - (vertex.CircleRadius / 2), vertex.CenterOrigin.Y),
                new Point(vertex.CenterOrigin.X + (vertex.CircleRadius / 2), vertex.CenterOrigin.Y));

            UpdatePanelOnGraphInteraction(this, new EventArgs());

            this.SetSize?.Invoke(this.graphGTS!.Size);
            SetComponents?.Invoke(this.graphGTS!.ComponentCount);
            return edgeUserControl;
        }

        public EdgeUserControl CreateEdge(Control Parent, int startID, int endID, bool isDirected, int weight)
        {
            int edgeID = this.graphGTS!.AddEdge(startID, endID, isDirected, weight);
            EdgeUserControl edgeUserControl = new EdgeUserControl(edgeID, false, isDirected);
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
                float multiplier = 2;
                if (edgeCount % 2 == 0)
                {
                    if (edgeCount / 2 == 1) { multiplier = 1.5f; }

                    edgeUserControl.CurveHeight = 0.075f * ((int)(edgeCount / 2) * multiplier + 1);
                }
                else
                {
                    if ((int)(edgeCount / 2) == 1) { multiplier = 1.5f; }

                    edgeUserControl.CurveHeight = -0.075f * ((int)(edgeCount / 2) * multiplier + 1);
                }
            }

            edgeUserControl.UpdateLinePoints(this.graphGTS.Vertexes[startID].Data.CenterOrigin, this.graphGTS.Vertexes[endID].Data.CenterOrigin);
            UpdatePanelOnGraphInteraction(this, new EventArgs());

            this.SetSize?.Invoke(this.graphGTS!.Size);
            this.SetComponents?.Invoke(this.graphGTS!.ComponentCount);
            return edgeUserControl;
        }

        private void UpdatePanelOnGraphInteraction(object? sender, EventArgs e)
        {
            this.panelGraph.Refresh();
            this.panelGraph.Invalidate();


            foreach (EdgeUserControl edge in this.controlEdges.Values)
            {
                VertexUserControl vertexFrom = this.graphGTS!.Edges[edge.EdgeID].VertexFrom.Data;
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
                this.ItemSelected?.Invoke(selectedItems, this.graphGTS);
            }
        }

        private void CreateVertex_Click(object? sender, EventArgs e)
        {
            contextMenuStrip1.Close();
            CreateVertex(mouseLocation);
        }

        private void OnSelectItem_Down(object? sender, MouseEventArgs e)
        {
            if (sender is VertexUserControl || sender is EdgeUserControl)
            {
                this.selectedItems.AddSelectedItem(sender);

                UpdatePanelOnGraphInteraction(sender, e);

                this.ItemSelected?.Invoke(selectedItems, this.graphGTS);
            }
        }

        #region GraphCreateReset
        public void On_CreateGraph(string GraphName, bool isDirected)
        {
            if (this.graphGTS == null)
            {
                if (GraphName == "graph")
                {
                    this.graphGTS = new GraphGTS<VertexUserControl>(isDirected);

                    this.panelGraph.Enabled = true;
                    this.panelGraph.Show();
                }
                else if (GraphName == "weighted_graph")
                {
                    this.graphGTS = new GraphGTSWeighted<VertexUserControl>(isDirected);

                    this.panelGraph.Enabled = true;
                    this.panelGraph.Show();
                }

                SetComponents?.Invoke(0);
                this.SetSize?.Invoke(0);
                this.SetOrder?.Invoke(0);
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

                SetComponents?.Invoke(0);
                this.SetSize?.Invoke(0);
                this.SetOrder?.Invoke(0);

                this.selectedItems.Clear();
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
            CreateEdge(this.panelGraph, selectedItems.VertexUserControls!.First().VertexID, selectedItems.VertexUserControls!.Last().VertexID, isDirected, weight);
        }
        #endregion

        #region VertexSelectmenu
        public void On_AddLoop(bool isDirected, int weight)
        {
            // should not break since they will exist
            CreateLoop(this.panelGraph, selectedItems.VertexUserControls!.First().VertexID, isDirected, weight);
        }

        public void On_RemoveVertex()
        {
            // should have only one vertex here
            int vertexID = this.selectedItems.VertexUserControls!.Dequeue().VertexID;

            this.panelGraph.Controls.Remove(this.graphGTS!.Vertexes[vertexID].Data);

            this.graphGTS.Vertexes[vertexID].Data.Dispose();
            this.graphGTS?.TryRemoveVertex(vertexID);

            this.controlEdges = this.controlEdges.Where(
                (controlEdge) =>
                {
                    if (this.graphGTS!.Edges.ContainsKey(controlEdge.Key))
                    {
                        return true;
                    }
                    else
                    {
                        this.panelGraph.Controls.Remove(controlEdge.Value);
                        controlEdge.Value.Dispose();
                        return false;
                    }

                }).ToDictionary();

            this.SetComponents?.Invoke(this.graphGTS!.ComponentCount);
            this.SetSize?.Invoke(this.graphGTS!.Size);
            this.SetOrder?.Invoke(this.graphGTS!.Order);

            UpdatePanelOnGraphInteraction(this, new EventArgs());
            this.ItemSelected?.Invoke(selectedItems, this.graphGTS);
        }

        public void On_VertexColorChange(Color color)
        {
            this.selectedItems.VertexUserControls!.Peek().Color = color;
        }

        public void On_OpenShortestPath()
        {
            if (this.graphGTS is GraphGTSWeighted<VertexUserControl> graphWeighted)
            {
                Dictionary<VertexGTS<VertexUserControl>, (VertexGTS<VertexUserControl>?, float)> information = graphWeighted.GetShortestPaths(this.selectedItems.VertexUserControls!.Peek().VertexID);

                string vertexNameFrom = "";

                int i = 0;
                foreach (VertexGTS<VertexUserControl> vertex in information.Keys)
                {
                    if (this.selectedItems.VertexUserControls!.Peek().VertexID == vertex.VertexID)
                    {
                        vertexNameFrom = $"V{i}";
                    }
                    vertex.Data.AddLabel($"V{i}");
                    i++;
                }

                foreach (EdgeUserControl edge in this.controlEdges.Values)
                {
                    edge.AddLabel($"W: {this.graphGTS.Edges[edge.EdgeID].Weight}");
                }

                this.OpenShortestPath?.Invoke(information, vertexNameFrom);
            }
        }

        public void On_CloseShortestPath(object? sender, FormClosedEventArgs e)
        {
            foreach (VertexGTS<VertexUserControl> vertex in this.graphGTS!.Vertexes.Values)
            {
                vertex.Data.RemoveLabel();
            }

            foreach (EdgeUserControl edge in this.controlEdges.Values)
            {
                edge.RemoveLabel();
            }
        }
        #endregion

        #region EdgeSelectMenu
        public void On_RemoveEdge()
        {
            int edgeID = this.selectedItems.EdgeUserControl!.EdgeID;

            this.panelGraph.Controls.Remove(this.selectedItems.EdgeUserControl);
            this.selectedItems.EdgeUserControl!.Dispose();
            this.selectedItems.Clear();

            int FromVertexID = this.graphGTS!.Edges[edgeID].VertexFrom.VertexID;
            int ToVertexID = this.graphGTS.Edges[edgeID].VertexTo.VertexID;

            if (this.graphGTS!.Edges[edgeID].VertexTo == this.graphGTS.Edges[edgeID].VertexFrom)
            {
                this.graphGTS!.RemoveLoop(edgeID);

                // reset loops in display
                int i = 1;
                foreach (EdgeGTS<VertexUserControl> edge in this.graphGTS!.EdgesInLoopVertex(FromVertexID))
                {

                    this.controlEdges![edge.EdgeID].CurveHeight = 4 * (i + 1);

                    VertexUserControl vertex = this.graphGTS.Vertexes[FromVertexID].Data;

                    this.controlEdges![edge.EdgeID].UpdateLinePoints(
                        new Point(vertex.CenterOrigin.X - (vertex.CircleRadius / 2), vertex.CenterOrigin.Y),
                        new Point(vertex.CenterOrigin.X + (vertex.CircleRadius / 2), vertex.CenterOrigin.Y));

                    i++;
                }
            }
            else
            {
                this.graphGTS!.RemoveEdge(edgeID);

                // Reset lines in display
                int i = 1;
                foreach (EdgeGTS<VertexUserControl> edge in this.graphGTS!.EdgesBetweenVertices(FromVertexID, ToVertexID))
                {
                    if (i == 1)
                    {
                        this.controlEdges![edge.EdgeID].CurveHeight = 0;
                    }
                    else
                    {
                        float multiplier = 2;

                        if (i % 2 == 0)
                        {
                            if (i / 2 == 1) { multiplier = 1.5f; }

                            this.controlEdges![edge.EdgeID].CurveHeight = 0.075f * ((int)(i / 2) * multiplier + 1);
                        }
                        else
                        {
                            if ((int)(i / 2) == 1) { multiplier = 1.5f; }

                            this.controlEdges![edge.EdgeID].CurveHeight = -0.075f * ((int)(i / 2) * multiplier + 1);
                        }
                    }
                    this.controlEdges![edge.EdgeID].UpdateLinePoints(this.graphGTS.Vertexes[FromVertexID].Data.CenterOrigin, this.graphGTS.Vertexes[ToVertexID].Data.CenterOrigin);

                    i++;
                }
            }

            this.controlEdges?.Remove(edgeID);
            UpdatePanelOnGraphInteraction(this, new EventArgs());
            this.SetComponents?.Invoke(this.graphGTS!.ComponentCount);
            this.SetSize?.Invoke(this.graphGTS!.Size);
            this.ItemSelected?.Invoke(selectedItems, this.graphGTS);
        }

        public void On_EdgeColorChange(Color color)
        {
            this.selectedItems.EdgeUserControl!.Color = color;
        }
        #endregion

        #region NoSelectMenu
        public void On_RevealBridges(Color color)
        {
            foreach (EdgeGTS<VertexUserControl> edge in this.graphGTS!.GetBridges())
            {
                this.controlEdges[edge.EdgeID].Color = color;
            }
        }

        public void On_CheckBiPartiteness(object? sender, EventArgs e)
        {
            if (sender is NoSelectMenu noSelectMenu)
            {
                (bool, (List<VertexGTS<VertexUserControl>>, List<VertexGTS<VertexUserControl>>)?) bipartiteList = this.graphGTS!.IsBipartite();

                noSelectMenu.IsBipartite = bipartiteList.Item1;

                if (bipartiteList.Item2 is not null)
                {
                    foreach (VertexGTS<VertexUserControl> vertex in this.graphGTS!.Vertexes.Values)
                    {
                        vertex.Data.Color = Color.Gray;
                    }

                    foreach (VertexGTS<VertexUserControl> vertexColor1 in bipartiteList.Item2.Value.Item1)
                    {
                        vertexColor1.Data.Color = Color.Blue;
                    }

                    foreach (VertexGTS<VertexUserControl> vertexColor2 in bipartiteList.Item2.Value.Item2)
                    {
                        vertexColor2.Data.Color = Color.Green;
                    }
                }
            }
        }

        public void On_ResetObjectColors()
        {
            foreach (VertexGTS<VertexUserControl> vertex in this.graphGTS!.Vertexes.Values)
            {
                vertex.Data.Color = Color.Gray;
            }

            foreach (EdgeUserControl edge in this.controlEdges.Values)
            {
                edge.Color = Color.Black;
            }
        }

        public void On_OpenAdjacencyMatrix()
        {
            (List<int>, List<List<int>>) information = this.graphGTS!.GetAdjacenyMatrix();

            int i = 0;
            foreach (int vertexID in information.Item1)
            {
                this.graphGTS!.Vertexes[vertexID].Data.AddLabel($"V{i}");
                i++;
            }

            this.OpenAdjMatrix?.Invoke(information);
        }

        public void On_CloseAdjacencyMatrix(object? sender, FormClosedEventArgs e)
        {
            foreach (VertexGTS<VertexUserControl> vertex in this.graphGTS!.Vertexes.Values)
            {
                vertex.Data.RemoveLabel();
            }

        }
        #endregion

    }
}
