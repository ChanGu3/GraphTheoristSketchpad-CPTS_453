namespace GTS_Controls.UserControls.MenuControls
{
    partial class TwoVertexSelectMenu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox3 = new TextBox();
            textBox5 = new TextBox();
            weightValueTextBox = new TextBox();
            textBox1 = new TextBox();
            directedComboBox = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Control;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 16F);
            textBox3.Location = new Point(3, 14);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(238, 29);
            textBox3.TabIndex = 7;
            textBox3.Text = "Two Vertex Select Menu";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Control;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Location = new Point(107, 72);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(49, 16);
            textBox5.TabIndex = 24;
            textBox5.Text = "Directed?";
            // 
            // weightValueTextBox
            // 
            weightValueTextBox.Location = new Point(150, 98);
            weightValueTextBox.Name = "weightValueTextBox";
            weightValueTextBox.Size = new Size(79, 23);
            weightValueTextBox.TabIndex = 23;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(105, 101);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(49, 16);
            textBox1.TabIndex = 22;
            textBox1.Text = "Weight:";
            // 
            // directedComboBox
            // 
            directedComboBox.FormattingEnabled = true;
            directedComboBox.Items.AddRange(new object[] { "True", "False" });
            directedComboBox.Location = new Point(165, 69);
            directedComboBox.Name = "directedComboBox";
            directedComboBox.Size = new Size(64, 23);
            directedComboBox.TabIndex = 21;
            directedComboBox.Text = "False";
            // 
            // button1
            // 
            button1.Location = new Point(16, 69);
            button1.Name = "button1";
            button1.Size = new Size(83, 52);
            button1.TabIndex = 20;
            button1.Text = "Add Edge...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddEdge_Click;
            // 
            // TwoVertexSelectMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox5);
            Controls.Add(weightValueTextBox);
            Controls.Add(textBox1);
            Controls.Add(directedComboBox);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Name = "TwoVertexSelectMenu";
            Size = new Size(250, 620);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private TextBox textBox5;
        private TextBox weightValueTextBox;
        private TextBox textBox1;
        private ComboBox directedComboBox;
        private Button button1;
    }
}
