using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTS_Controls.UserControls.MenuControls
{
    public partial class TwoVertexSelectMenu : UserControl
    {
        // bool = directed value, int = weight
        public event Action<bool, int>? AddEdge;
        public TwoVertexSelectMenu()
        {
            InitializeComponent();
            this.weightValueTextBox.KeyPress += On_WeightKeyPress;
        }

        private void AddEdge_Click(object sender, EventArgs e)
        {
            this.AddEdge?.Invoke(this.directedComboBox.Text == "True", (this.weightValueTextBox.Text == "") ? 0 : Convert.ToInt32(this.weightValueTextBox.Text));
        }

        public void On_WeightKeyPress(object? sender, KeyPressEventArgs e)
        {
            //Avoid non numbercharacters
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
