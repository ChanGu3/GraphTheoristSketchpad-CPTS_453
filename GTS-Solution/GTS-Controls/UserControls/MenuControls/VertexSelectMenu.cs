namespace GTS_Controls.UserControls.MenuControls
{
    public partial class VertexSelectMenu : UserControl
    {
        // bool = directed value, int = weight
        public event Action<bool, int>? AddLoop;

        public event Action? RemoveVertex;
        public event Action<Color>? ColorChanged;
        public event Action? OpenShortestPath;
        public event Action<string>? ChangeVertexName;

        private int degreeCount = 0;
        public VertexSelectMenu()
        {
            InitializeComponent();
            this.textBoxWeightValue.KeyPress += On_WeightKeyPress;
            this.comboBoxDirected.SelectedIndex = 1;
        }

        public Color VertexColor
        {
            get => this.panelVertexColor.BackColor;
            set => this.panelVertexColor.BackColor = value;
        }

        public string VertexName
        {
            set => this.textBoxVertexNameChoice.Text = value;
        }

        public int DegreeCount
        {
            set
            {
                degreeCount = value;
                this.textBoxDegreeCount.Text = $"Degree: {value}";
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

        public void ActivateShortestPathButton()
        {
            this.buttonOpenShortestPath.Show();
            this.buttonOpenShortestPath.Show();
            this.buttonOpenShortestPath.Enabled = true;
            this.buttonOpenShortestPath.Enabled = true;
        }

        public void DeactivateShortestPathButton()
        {
            this.buttonOpenShortestPath.Hide();
            this.buttonOpenShortestPath.Hide();
            this.buttonOpenShortestPath.Enabled = false;
            this.buttonOpenShortestPath.Enabled = false;
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
            DegreeCount = degreeCount + 2;
            this.AddLoop?.Invoke(this.comboBoxDirected.Text == "True", (this.textBoxWeightValue.Text == "") ? 0 : Convert.ToInt32(this.textBoxWeightValue.Text));
        }

        private void RemoveVertex_Click(object sender, EventArgs e)
        {
            RemoveVertex?.Invoke();
        }

        private void ChangeColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    this.VertexColor = colorDialog.Color;
                    ColorChanged?.Invoke(colorDialog.Color);
                }
            }
        }

        private void OpenShortestPath_Click(object sender, EventArgs e)
        {
            this.OpenShortestPath?.Invoke();
        }

        private void TextBoxVertexNameChoice_TextChanged(object sender, EventArgs e)
        {
            this.ChangeVertexName?.Invoke(this.textBoxVertexNameChoice.Text);
        }
    }
}
