namespace GTS_Controls.UserControls.MenuControls
{
    public partial class TwoVertexSelectMenu : UserControl
    {
        // bool = directed value, int = weight
        public event Action<bool, int>? AddEdge;
        public TwoVertexSelectMenu()
        {
            InitializeComponent();
            this.textBoxWeightValue.KeyPress += On_WeightKeyPress;
            this.comboBoxDirected.SelectedIndex = 1;

        }

        private void AddEdge_Click(object sender, EventArgs e)
        {
            this.AddEdge?.Invoke(this.comboBoxDirected.Text == "True", (this.textBoxWeightValue.Text == "") ? 0 : Convert.ToInt32(this.textBoxWeightValue.Text));
        }

        public void On_WeightKeyPress(object? sender, KeyPressEventArgs e)
        {
            //Avoid non numbercharacters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void ActivateWeightInput()
        {
            this.textBoxWeightTag.Show();
            this.textBoxWeightValue.Show();
            this.textBoxWeightTag.Enabled = true;
            this.textBoxWeightValue.Enabled = true;
        }

        public void DeactivateWeightInput()
        {
            this.textBoxWeightTag.Hide();
            this.textBoxWeightValue.Hide();
            this.textBoxWeightTag.Enabled = false;
            this.textBoxWeightValue.Enabled = false;
        }
        public void ActivateIsDirected()
        {
            this.textBoxIsDirected.Show();
            this.comboBoxDirected.Show();
            this.textBoxIsDirected.Enabled = true;
            this.comboBoxDirected.Enabled = true;
        }

        public void DeactivateIsDirected()
        {
            this.textBoxIsDirected.Hide();
            this.comboBoxDirected.Hide();
            this.textBoxIsDirected.Enabled = false;
            this.comboBoxDirected.Enabled = false;
        }
    }
}
