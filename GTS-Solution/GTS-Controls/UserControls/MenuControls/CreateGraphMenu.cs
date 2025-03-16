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

namespace GTS_Controls.UserControls.MenuControls
{
    public partial class CreateGraphMenu : UserControl
    {
        public event Action<string>? GraphClicked;

        public CreateGraphMenu()
        {
            InitializeComponent();
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            GraphClicked?.Invoke("graph");
        }

        private void WeightedGraph_Click(object sender, EventArgs e)
        {
            GraphClicked?.Invoke("weighted_graph");
        }
    }
}
