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
    public partial class VertexSelectMenu : UserControl
    {
        // bool = directed value, int = weight
        public event Action<bool, int>? AddLoop;
        public VertexSelectMenu()
        {
            InitializeComponent();
            this.textBoxWeightValue.KeyPress += On_WeightKeyPress;
        }

        public void On_WeightKeyPress(object? sender, KeyPressEventArgs e)
        {
            //Avoid non numbercharacters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AddLoop_Click(object sender, EventArgs e)
        {
            this.AddLoop?.Invoke(this.comboBoxDirected.Text == "True", (this.textBoxWeightValue.Text == "") ? 0 : Convert.ToInt32(this.textBoxWeightValue.Text));
        }
    }
}
