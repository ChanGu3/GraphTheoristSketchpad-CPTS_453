namespace GTS_Controls.UserControls.MenuControls
{
    partial class VertexSelectMenu
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
            button4 = new Button();
            panel1 = new Panel();
            button1 = new Button();
            comboBoxDirected = new ComboBox();
            textBox1 = new TextBox();
            textBoxWeightValue = new TextBox();
            button2 = new Button();
            textBox4 = new TextBox();
            button3 = new Button();
            textBox5 = new TextBox();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Control;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 16F);
            textBox3.Location = new Point(25, 18);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(190, 29);
            textBox3.TabIndex = 7;
            textBox3.Text = "Vertex Select Menu";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // button4
            // 
            button4.Location = new Point(25, 90);
            button4.Name = "button4";
            button4.Size = new Size(138, 26);
            button4.TabIndex = 10;
            button4.Text = "Change Vertex Color...";
            button4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Location = new Point(176, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(29, 26);
            panel1.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(15, 136);
            button1.Name = "button1";
            button1.Size = new Size(83, 52);
            button1.TabIndex = 12;
            button1.Text = "Add Loop...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddLoop_Click;
            // 
            // comboBoxDirected
            // 
            comboBoxDirected.FormattingEnabled = true;
            comboBoxDirected.Items.AddRange(new object[] { "True", "False" });
            comboBoxDirected.Location = new Point(164, 136);
            comboBoxDirected.Name = "comboBoxDirected";
            comboBoxDirected.Size = new Size(64, 23);
            comboBoxDirected.TabIndex = 13;
            comboBoxDirected.Text = "False";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(104, 168);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(49, 16);
            textBox1.TabIndex = 14;
            textBox1.Text = "Weight:";
            // 
            // textBoxWeightValue
            // 
            textBoxWeightValue.Location = new Point(149, 165);
            textBoxWeightValue.Name = "textBoxWeightValue";
            textBoxWeightValue.Size = new Size(79, 23);
            textBoxWeightValue.TabIndex = 15;
            // 
            // button2
            // 
            button2.Location = new Point(75, 265);
            button2.Name = "button2";
            button2.Size = new Size(101, 23);
            button2.TabIndex = 16;
            button2.Text = "Remove Vertex";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.ControlDark;
            textBox4.Location = new Point(15, 53);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(99, 23);
            textBox4.TabIndex = 17;
            textBox4.Text = "Degree: [{count}]";
            // 
            // button3
            // 
            button3.Location = new Point(49, 223);
            button3.Name = "button3";
            button3.Size = new Size(147, 23);
            button3.TabIndex = 18;
            button3.Text = "Open Shortest Distances";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Control;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Location = new Point(106, 139);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(49, 16);
            textBox5.TabIndex = 19;
            textBox5.Text = "Directed?";
            // 
            // VertexSelectMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox5);
            Controls.Add(button3);
            Controls.Add(textBox4);
            Controls.Add(button2);
            Controls.Add(textBoxWeightValue);
            Controls.Add(textBox1);
            Controls.Add(comboBoxDirected);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(panel1);
            Controls.Add(textBox3);
            Name = "VertexSelectMenu";
            Size = new Size(250, 620);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private Button button4;
        private Panel panel1;
        private Button button1;
        private ComboBox comboBoxDirected;
        private TextBox textBox1;
        private TextBox textBoxWeightValue;
        private Button button2;
        private TextBox textBox4;
        private Button button3;
        private TextBox textBox5;
    }
}
