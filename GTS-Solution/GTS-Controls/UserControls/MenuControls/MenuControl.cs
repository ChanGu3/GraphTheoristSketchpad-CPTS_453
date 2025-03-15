using GTS_Controls.UserControls.MenuControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTS_Controls.UserControls
{
    public partial class MenuControl : UserControl
    {
        #region CreateGraphMenuVariables
        public event Action<string>? CreateGraphClicked;
        public event EventHandler? ResetGraph;
        private CreateGraphMenu createGraphControl = new();
        #endregion


        #region NoSelectMenuVariables
        NoSelectMenu noSelectMenu = new();
        #endregion

        #region VertexSelectMenuVariables
        // bool = directed value, int = weight
        public event Action<bool, int>? AddLoop;
        VertexSelectMenu vertexSelectMenu = new();
        #endregion

        #region TwoVertexSelectMenuVariables
        // bool = directed value, int = weight
        public event Action<bool, int>? AddEdge;
        TwoVertexSelectMenu twoVertexSelectMenu = new();
        #endregion

        #region EdgeSelectMenuVariables
        EdgeSelectMenu edgeSelectMenu = new();
        #endregion

        public MenuControl()
        {
            InitializeComponent();
            this.button1.Enabled = false;
            this.button1.Hide();
            this.button1.Click += OnResetGraphClicked;

            //NOSELECTMENU
            InitializeOnGroupBoxMain(noSelectMenu);
            HideOnGroupBoxMain(noSelectMenu);

            //VERTEXSELECTMENU
            this.vertexSelectMenu.AddLoop += OnAddLoop;
            InitializeOnGroupBoxMain(vertexSelectMenu);
            HideOnGroupBoxMain(vertexSelectMenu);

            //TWOVERTEXSELECTMENU
            this.twoVertexSelectMenu.AddEdge += OnAddEdge;
            InitializeOnGroupBoxMain(twoVertexSelectMenu);
            HideOnGroupBoxMain(twoVertexSelectMenu);

            //EDGESELECTMENU
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
        private void OnCreateGraphClicked(string graphName)
        {
            this.button1.Enabled = true;
            this.button1.Show();
            HideOnGroupBoxMain(createGraphControl);
            ShowOnGroupBoxMain(noSelectMenu);

            CreateGraphClicked?.Invoke(graphName);
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

        public void On_SelectSwitch(SelectedItems selectedItems)
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
                ShowOnGroupBoxMain(edgeSelectMenu);
            }
            else if (selectedItems.VertexUserControls?.Count == 1)
            {
                ShowOnGroupBoxMain(vertexSelectMenu);
            }
            else if (selectedItems.VertexUserControls?.Count == 2)
            {
                ShowOnGroupBoxMain(twoVertexSelectMenu);
            }
        }

        #region NoSelectMenu

        #endregion

        #region VertexSelectMenu
        private void OnAddLoop(bool isDirected, int weight)
        {
            this.AddLoop?.Invoke(isDirected, weight);
        }
        #endregion

        #region TwoVertexSelectMenu
        private void OnAddEdge(bool isDirected, int weight)
        {
            this.AddEdge?.Invoke(isDirected, weight);
        }
        #endregion

        #region EdgeSelectMenu

        #endregion
    }
}
