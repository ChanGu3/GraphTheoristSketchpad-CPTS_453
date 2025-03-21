﻿using GTS_Controls.UserControls.MenuControls;
using GTS_GraphEngine;

namespace GTS_Controls.UserControls
{
    public partial class MenuControl : UserControl
    {
        #region CreateGraphMenuVariables
        public event Action<string, bool>? CreateGraphClicked;
        public event EventHandler? ResetGraph;
        private CreateGraphMenu createGraphControl = new();
        #endregion


        #region NoSelectMenuVariables
        public event Action<Color>? RevealBridges;
        public event EventHandler? CheckBiPartiteness;
        public event Action? ResetObjectColors;
        public event Action? OpenAdjMatrix;
        public event Action<bool>? VertexNameVis;
        public event Action<bool>? EdgeWeightVis;
        NoSelectMenu noSelectMenu = new();
        #endregion

        #region VertexSelectMenuVariables
        // bool = directed value, int = weight
        public event Action<bool, int>? AddLoop;
        public event Action? RemoveVertex;
        public event Action? OpenShortestPath;
        public event Action<string>? ChangeVertexName;
        VertexSelectMenu vertexSelectMenu = new();
        #endregion

        #region TwoVertexSelectMenuVariables
        // bool = directed value, int = weight
        public event Action<bool, int>? AddEdge;
        TwoVertexSelectMenu twoVertexSelectMenu = new();
        #endregion

        #region EdgeSelectMenuVariables
        public event Action? RemoveEdge;
        public event Action<Color>? EdgeColorChanged;
        public event Action<Color>? VertexColorChanged;
        EdgeSelectMenu edgeSelectMenu = new();
        #endregion

        public MenuControl()
        {
            InitializeComponent();
            this.button1.Enabled = false;
            this.button1.Hide();
            this.button1.Click += OnResetGraphClicked;

            //NOSELECTMENU
            this.noSelectMenu.RevealBridges += On_RevealBridges;
            this.noSelectMenu.CheckBiPartiteness += On_CheckBiPartiteness;
            this.noSelectMenu.ResetObjectColors += On_ResetObjectColors;
            this.noSelectMenu.OpenAdjMatrix += On_OpenAdjacencyMatrix;
            this.noSelectMenu.VertexNameVis += On_VertexNameVisibilityOption;
            this.noSelectMenu.EdgeWeightVis += On_EdgeWeightVisibilityOption;
            InitializeOnGroupBoxMain(noSelectMenu);
            HideOnGroupBoxMain(noSelectMenu);

            //VERTEXSELECTMENU
            this.vertexSelectMenu.AddLoop += On_AddLoop;
            this.vertexSelectMenu.RemoveVertex += On_RemoveVertex;
            this.vertexSelectMenu.ColorChanged += On_VertexColorChange;
            this.vertexSelectMenu.OpenShortestPath += On_OpenShortestPath;
            this.vertexSelectMenu.ChangeVertexName += On_ChangeVertexName;
            InitializeOnGroupBoxMain(vertexSelectMenu);
            HideOnGroupBoxMain(vertexSelectMenu);

            //TWOVERTEXSELECTMENU
            this.twoVertexSelectMenu.AddEdge += OnAddEdge;
            InitializeOnGroupBoxMain(twoVertexSelectMenu);
            HideOnGroupBoxMain(twoVertexSelectMenu);

            //EDGESELECTMENU
            this.edgeSelectMenu.RemoveEdge += On_RemoveEdge;
            this.edgeSelectMenu.ColorChanged += On_EdgeColorChange;
            InitializeOnGroupBoxMain(edgeSelectMenu);
            HideOnGroupBoxMain(edgeSelectMenu);

            //CREATEGRAPHMENU (NOT HIDING BECAUSE ITS FIRST MENU)
            createGraphControl.GraphClicked += OnCreateGraphClicked;
            InitializeOnGroupBoxMain(createGraphControl);
        }

        #region MenuControl
        public void InitializeOnGroupBoxMain(Control control)
        {
            control.Parent = this.groupBoxMain;
            control.Location = new Point(this.groupBoxMain.Location.X + 20, this.groupBoxMain.Location.Y + 25);
            control.Name = $"{control.GetType()}";

            this.groupBoxMain.Controls.Add(control);
            control.BringToFront();
        }

        public void HideOnGroupBoxMain(Control control)
        {
            control.Enabled = false;
            control.Hide();
        }

        public void ShowOnGroupBoxMain(Control control)
        {
            control.Enabled = true;
            control.Show();
        }
        #endregion

        #region CreateGraphMenu
        private void OnCreateGraphClicked(string graphName, bool isDirected)
        {
            this.button1.Enabled = true;
            this.button1.Show();
            HideOnGroupBoxMain(createGraphControl);
            ShowOnGroupBoxMain(noSelectMenu);


            if (isDirected)
            {
                this.vertexSelectMenu.ActivateIsDirected();
                this.twoVertexSelectMenu.ActivateIsDirected();
            }
            else
            {
                this.vertexSelectMenu.DeactivateIsDirected();
                this.twoVertexSelectMenu.DeactivateIsDirected();
            }

            if (graphName == "graph")
            {
                this.vertexSelectMenu.DeactivateWeightInput();
                this.vertexSelectMenu.DeactivateShortestPathButton();
                this.twoVertexSelectMenu.DeactivateWeightInput();
                this.edgeSelectMenu.DeactivateWeightVisual();
                this.noSelectMenu.DeactivateEdgeWeightVisibility();
            }
            else
            {
                this.vertexSelectMenu.ActivateWeightInput();
                this.vertexSelectMenu.ActivateShortestPathButton();
                this.twoVertexSelectMenu.ActivateWeightInput();
                this.edgeSelectMenu.ActivateWeightVisual();
                this.noSelectMenu.ActivateEdgeWeightVisibility();
            }


            CreateGraphClicked?.Invoke(graphName, isDirected);
        }

        private void OnResetGraphClicked(object? sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button1.Hide();
            HideOnGroupBoxMain(noSelectMenu);
            HideOnGroupBoxMain(vertexSelectMenu);
            HideOnGroupBoxMain(twoVertexSelectMenu);
            HideOnGroupBoxMain(edgeSelectMenu);

            ShowOnGroupBoxMain(createGraphControl);

            ResetGraph?.Invoke(sender, e);
        }
        #endregion

        public void On_SelectSwitch(SelectedItems selectedItems, AbstractGraphGTS<VertexUserControl>? graph)
        {
            HideOnGroupBoxMain(noSelectMenu);
            HideOnGroupBoxMain(vertexSelectMenu);
            HideOnGroupBoxMain(twoVertexSelectMenu);
            HideOnGroupBoxMain(edgeSelectMenu);
            if (selectedItems.EdgeUserControl == null && selectedItems.VertexUserControls == null)
            {
                ShowOnGroupBoxMain(noSelectMenu);
            }
            else if (selectedItems.EdgeUserControl != null)
            {
                edgeSelectMenu.EdgeColor = selectedItems.EdgeUserControl.Color;
                edgeSelectMenu.WeightCount = graph!.Edges[selectedItems.EdgeUserControl.EdgeID].Weight;
                ShowOnGroupBoxMain(edgeSelectMenu);
            }
            else if (selectedItems.VertexUserControls?.Count == 1)
            {
                vertexSelectMenu.VertexName = selectedItems.VertexUserControls.Peek().Name;
                vertexSelectMenu.VertexColor = selectedItems.VertexUserControls.Peek().Color;
                vertexSelectMenu.DegreeCount = graph!.Vertexes[selectedItems.VertexUserControls.Peek().VertexID].DegreeCount;
                ShowOnGroupBoxMain(vertexSelectMenu);
            }
            else if (selectedItems.VertexUserControls?.Count == 2)
            {
                ShowOnGroupBoxMain(twoVertexSelectMenu);
            }
        }

        #region NoSelectMenu
        private void On_RevealBridges(Color color)
        {
            this.RevealBridges?.Invoke(color);
        }

        private void On_CheckBiPartiteness(object? sender, EventArgs e)
        {
            CheckBiPartiteness?.Invoke(sender, e);
        }

        private void On_ResetObjectColors()
        {
            ResetObjectColors?.Invoke();
        }

        private void On_OpenAdjacencyMatrix()
        {
            OpenAdjMatrix?.Invoke();
        }

        private void On_VertexNameVisibilityOption(bool isShowingName)
        {
            VertexNameVis?.Invoke(isShowingName);
        }

        private void On_EdgeWeightVisibilityOption(bool isShowingWeight)
        {
            EdgeWeightVis?.Invoke(isShowingWeight);
        }
        #endregion

        #region VertexSelectMenu
        private void On_AddLoop(bool isDirected, int weight)
        {
            this.AddLoop?.Invoke(isDirected, weight);
        }

        private void On_RemoveVertex()
        {
            RemoveVertex?.Invoke();

        }

        private void On_VertexColorChange(Color color)
        {
            this.VertexColorChanged?.Invoke(color);
        }
        private void On_OpenShortestPath()
        {
            this.OpenShortestPath?.Invoke();
        }

        private void On_ChangeVertexName(string newVertexName)
        {
            this.ChangeVertexName?.Invoke(newVertexName);
        }
        #endregion

        #region TwoVertexSelectMenu
        private void OnAddEdge(bool isDirected, int weight)
        {
            this.AddEdge?.Invoke(isDirected, weight);

        }
        #endregion

        #region EdgeSelectMenu
        private void On_RemoveEdge()
        {
            RemoveEdge?.Invoke();
        }

        private void On_EdgeColorChange(Color color)
        {
            this.EdgeColorChanged?.Invoke(color);
        }
        #endregion
    }
}
