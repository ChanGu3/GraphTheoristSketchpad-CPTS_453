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
            textBoxWeightValue = new TextBox();
            textBoxWeightTag = new TextBox();
            comboBoxDirected = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ActiveBorder;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 16F);
            textBox3.Location = new Point(3, 14);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(238, 29);
            textBox3.TabIndex = 7;
            textBox3.Text = "Two Vertex Select Menu";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.ActiveBorder;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Location = new Point(105, 72);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(49, 16);
            textBox5.TabIndex = 24;
            textBox5.Text = "Directed?";
            // 
            // textBoxWeightValue
            // 
            textBoxWeightValue.Location = new Point(160, 98);
            textBoxWeightValue.Name = "textBoxWeightValue";
            textBoxWeightValue.Size = new Size(79, 23);
            textBoxWeightValue.TabIndex = 23;
            // 
            // textBoxWeightTag
            // 
            textBoxWeightTag.BackColor = SystemColors.ActiveBorder;
            textBoxWeightTag.BorderStyle = BorderStyle.None;
            textBoxWeightTag.Location = new Point(105, 101);
            textBoxWeightTag.Name = "textBoxWeightTag";
            textBoxWeightTag.ReadOnly = true;
            textBoxWeightTag.Size = new Size(49, 16);
            textBoxWeightTag.TabIndex = 22;
            textBoxWeightTag.Text = "Weight:";
            textBoxWeightTag.TextAlign = HorizontalAlignment.Center;
            // 
            // comboBoxDirected
            // 
            comboBoxDirected.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDirected.FormattingEnabled = true;
            comboBoxDirected.Items.AddRange(new object[] { "True", "False" });
            comboBoxDirected.Location = new Point(160, 69);
            comboBoxDirected.Name = "comboBoxDirected";
            comboBoxDirected.Size = new Size(79, 23);
            comboBoxDirected.TabIndex = 21;
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
            Controls.Add(textBoxWeightValue);
            Controls.Add(textBoxWeightTag);
            Controls.Add(comboBoxDirected);
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
        private TextBox textBoxWeightValue;
        private TextBox textBoxWeightTag;
        private ComboBox comboBoxDirected;
        private Button button1;
    }
}
