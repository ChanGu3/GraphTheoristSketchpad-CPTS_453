namespace GTS_Controls.UserControls.MenuControls
{
    public partial class NoSelectMenu : UserControl
    {
        private Color bridgeColor = Color.Red;
        public event Action<Color>? RevealBridges;
        public event EventHandler? CheckBiPartiteness;
        public event Action? ResetObjectColors;
        public event Action? OpenAdjMatrix;
        public event Action<bool>? VertexNameVis;
        public event Action<bool>? EdgeWeightVis;

        public NoSelectMenu()
        {
            InitializeComponent();
            this.panelBridgeColor.BackColor = this.bridgeColor;
            this.comboBoxEdgeWeightVis.SelectedIndex = 1;
            this.comboBoxVertexNameVis.SelectedIndex = 1;
        }

        public bool IsBipartite
        {
            set
            {
                textBoxIsBipartite.Text = $"Is Bi-Partite: {value}";
            }
        }

        public void ActivateEdgeWeightVisibility()
        {
            this.textBoxEdgeWeightsVis.Show();
            this.comboBoxEdgeWeightVis.Show();
            this.textBoxEdgeWeightsVis.Enabled = true;
            this.comboBoxEdgeWeightVis.Enabled = true;
        }

        public void DeactivateEdgeWeightVisibility()
        {
            this.textBoxEdgeWeightsVis.Hide();
            this.comboBoxEdgeWeightVis.Hide();
            this.textBoxEdgeWeightsVis.Enabled = false;
            this.comboBoxEdgeWeightVis.Enabled = false;
        }

        private void ChooseBridgeColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    this.bridgeColor = colorDialog.Color;
                }
            }
        }

        private void RevealBridges_Click(object? sender, EventArgs e)
        {
            this.RevealBridges?.Invoke(bridgeColor);
        }

        private void CheckBiPartiteness_Click(object? sender, EventArgs e)
        {
            this.CheckBiPartiteness?.Invoke(this, e);
        }

        private void ResetObjectColors_Click(object sender, EventArgs e)
        {
            ResetObjectColors?.Invoke();
        }

        private void OpenAdjacencyMatrix_Click(object sender, EventArgs e)
        {
            OpenAdjMatrix?.Invoke();
        }

        private void comboBoxVertexNameVis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxVertexNameVis.Text == "Show")
            {
                VertexNameVis?.Invoke(true);
            }
            else
            {
                VertexNameVis?.Invoke(false);
            }
        }

        private void comboBoxEdgeWeightVis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxEdgeWeightVis.Text == "Show")
            {
                EdgeWeightVis?.Invoke(true);
            }
            else
            {
                EdgeWeightVis?.Invoke(false);
            }
        }
    }
}
