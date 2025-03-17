using GTS_Controls;
using GTS_GraphEngine;
using GTS_UserInput;

namespace GTS_Form
{
    public partial class FormGTS : Form
    {
        private UserInput userInput;

        public FormGTS()
        {
            this.userInput = new UserInput(this);

            InitializeComponent();

            //CreateGraphMenu
            this.menuControl1.CreateGraphClicked += this.graphDisplay1.On_CreateGraph;

            // MenuControl
            this.graphDisplay1.ItemSelected += this.menuControl1.On_SelectSwitch;
            this.menuControl1.ResetGraph += this.graphDisplay1.On_ResetGraph;
            this.menuControl1.OpenShortestPath += this.graphDisplay1.On_OpenShortestPath;

            // TwoVertexSelectMenu
            this.menuControl1.AddEdge += this.graphDisplay1.On_AddEdge;

            // VertexSelectMenu
            this.menuControl1.AddLoop += this.graphDisplay1.On_AddLoop;
            this.menuControl1.RemoveVertex += this.graphDisplay1.On_RemoveVertex;
            this.menuControl1.VertexColorChanged += this.graphDisplay1.On_VertexColorChange;

            // EdgeSelectMenu
            this.menuControl1.RemoveEdge += this.graphDisplay1.On_RemoveEdge;
            this.menuControl1.EdgeColorChanged += this.graphDisplay1.On_EdgeColorChange;

            // NoSelectMenu
            this.menuControl1.RevealBridges += this.graphDisplay1.On_RevealBridges;
            this.menuControl1.CheckBiPartiteness += this.graphDisplay1.On_CheckBiPartiteness;
            this.menuControl1.ResetObjectColors += this.graphDisplay1.On_ResetObjectColors;
            this.menuControl1.OpenAdjMatrix += this.graphDisplay1.On_OpenAdjacencyMatrix;

            // Forms Specific
            this.graphDisplay1.OpenAdjMatrix += On_OpenAdjacencyMatrix;
            this.graphDisplay1.OpenShortestPath += On_OpenShortestPath;
            this.graphDisplay1.SetOrder += OnSetOrderOfGraph;
            this.graphDisplay1.SetSize += OnSetSizeOfGraph;
            this.graphDisplay1.SetComponents += OnSetComponentOfGraph;
            OnSetOrderOfGraph(0);
            OnSetSizeOfGraph(0);
            OnSetComponentOfGraph(0);
        }

        public void OnSetOrderOfGraph(int order)
        {
            this.textBoxOrder.Text = $"Order: {order}";
        }

        public void OnSetSizeOfGraph(int size)
        {
            this.textBoxSize.Text = $"Size: {size}";
        }

        private void OnSetComponentOfGraph(int components)
        {
            this.textBoxComponents.Text = $"Components: {components}";
        }

        public void On_OpenAdjacencyMatrix((List<int>, List<List<int>>) adjInformation)
        {
            AdjacencyMatrix adjMatrixForm = new(adjInformation);
            adjMatrixForm.FormClosed += this.graphDisplay1.On_CloseAdjacencyMatrix;
            adjMatrixForm.ShowDialog();
        }

        private void On_OpenShortestPath(Dictionary<VertexGTS<VertexUserControl>, (VertexGTS<VertexUserControl>?, float)> shortestInformation, string vertexNameFrom)
        {
            ShortestPath shortestPathForm = new(shortestInformation, vertexNameFrom);
            shortestPathForm.FormClosed += this.graphDisplay1.On_CloseShortestPath;
            shortestPathForm.ShowDialog();
        }
    }
}
