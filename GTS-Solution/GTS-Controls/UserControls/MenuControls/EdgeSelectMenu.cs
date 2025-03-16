using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTS_Controls.UserControls.MenuControls
{
    public partial class EdgeSelectMenu : UserControl
    {
        public event Action? RemoveEdge;
        public event Action<Color>? ColorChanged;
        private int weightCount = 0;
        public EdgeSelectMenu()
        {
            InitializeComponent();
        }

        public Color EdgeColor
        {
            get => this.panelEdgeColor.BackColor;
            set => this.panelEdgeColor.BackColor = value;
        }

        public int WeightCount
        {
            set
            {
                weightCount = value;
                this.textBoxWeightCount.Text = $"Weight: {value}";
            }
        }

        private void RemoveEdge_Click(object sender, EventArgs e)
        {
            RemoveEdge?.Invoke();
        }

        private void ChangeColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    this.EdgeColor = colorDialog.Color;
                    ColorChanged?.Invoke(colorDialog.Color);
                }
            }
        }

        public void ActivateWeightVisual()
        {
            this.textBoxWeightCount.Show();
            this.textBoxWeightCount.Enabled = true;
        }

        public void DeactivateWeightVisual()
        {
            this.textBoxWeightCount.Hide();
            this.textBoxWeightCount.Enabled = false;
        }
    }
}
