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
    public partial class NoSelectMenu : UserControl
    {
        private Color bridgeColor = Color.Red;
        public event Action<Color>? RevealBridges;
        public event EventHandler? CheckBiPartiteness;
        public event Action? ResetObjectColors;
        public event Action? OpenAdjMatrix;

        public NoSelectMenu()
        {
            InitializeComponent();
            this.panelBridgeColor.BackColor = this.bridgeColor;
        }

        public bool IsBipartite
        {
            set
            {
                textBoxIsBipartite.Text = $"Is Bi-Partite: {value}";
            }
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
    }
}
