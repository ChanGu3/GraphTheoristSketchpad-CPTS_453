namespace GTS_Controls.UserControls.MenuControls
{
    partial class CreateGraphMenu
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
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            textBox5 = new TextBox();
            comboBoxDirected = new ComboBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ActiveBorder;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 16F);
            textBox1.Location = new Point(49, 18);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(150, 29);
            textBox1.TabIndex = 0;
            textBox1.Text = "Create A Graph!";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(38, 147);
            button1.Name = "button1";
            button1.Size = new Size(171, 54);
            button1.TabIndex = 1;
            button1.Text = "Graph";
            button1.UseVisualStyleBackColor = true;
            button1.Click += GraphButton_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14F);
            button2.Location = new Point(38, 249);
            button2.Name = "button2";
            button2.Size = new Size(171, 54);
            button2.TabIndex = 2;
            button2.Text = "Weighted Graph";
            button2.UseVisualStyleBackColor = true;
            button2.Click += WeightedGraph_Click;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.ActiveBorder;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Location = new Point(54, 87);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(49, 16);
            textBox5.TabIndex = 21;
            textBox5.Text = "Directed?";
            // 
            // comboBoxDirected
            // 
            comboBoxDirected.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDirected.FormattingEnabled = true;
            comboBoxDirected.Items.AddRange(new object[] { "True", "False" });
            comboBoxDirected.Location = new Point(109, 84);
            comboBoxDirected.Name = "comboBoxDirected";
            comboBoxDirected.Size = new Size(79, 23);
            comboBoxDirected.TabIndex = 20;
            // 
            // CreateGraphMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox5);
            Controls.Add(comboBoxDirected);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "CreateGraphMenu";
            Size = new Size(250, 650);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private TextBox textBox5;
        private ComboBox comboBoxDirected;
    }
}
