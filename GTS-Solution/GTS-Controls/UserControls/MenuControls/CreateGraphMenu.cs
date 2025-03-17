namespace GTS_Controls.UserControls.MenuControls
{
    public partial class CreateGraphMenu : UserControl
    {
        public event Action<string, bool>? GraphClicked;

        public CreateGraphMenu()
        {
            InitializeComponent();
            this.comboBoxDirected.SelectedIndex = 1;
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            bool isDirected = false;

            if (comboBoxDirected.Text == "True")
            {
                isDirected = true;
            }

            GraphClicked?.Invoke("graph", isDirected);
        }

        private void WeightedGraph_Click(object sender, EventArgs e)
        {
            bool isDirected = false;

            if (comboBoxDirected.Text == "True")
            {
                isDirected = true;
            }

            GraphClicked?.Invoke("weighted_graph", isDirected);
        }
    }
}
