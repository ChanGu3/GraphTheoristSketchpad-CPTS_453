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
            panelVertexColor = new Panel();
            button1 = new Button();
            comboBoxDirected = new ComboBox();
            textBoxWeightTag = new TextBox();
            textBoxWeightValue = new TextBox();
            button2 = new Button();
            textBoxDegreeCount = new TextBox();
            buttonOpenShortestPath = new Button();
            textBoxIsDirected = new TextBox();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ActiveBorder;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 16F);
            textBox3.Location = new Point(25, 12);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(190, 29);
            textBox3.TabIndex = 7;
            textBox3.Text = "Vertex Select Menu";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // button4
            // 
            button4.Location = new Point(25, 129);
            button4.Name = "button4";
            button4.Size = new Size(138, 26);
            button4.TabIndex = 10;
            button4.Text = "Change Vertex Color...";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ChangeColor_Click;
            // 
            // panelVertexColor
            // 
            panelVertexColor.BackColor = Color.Blue;
            panelVertexColor.Location = new Point(176, 129);
            panelVertexColor.Name = "panelVertexColor";
            panelVertexColor.Size = new Size(29, 26);
            panelVertexColor.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(15, 175);
            button1.Name = "button1";
            button1.Size = new Size(83, 52);
            button1.TabIndex = 12;
            button1.Text = "Add Loop...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddLoop_Click;
            // 
            // comboBoxDirected
            // 
            comboBoxDirected.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDirected.FormattingEnabled = true;
            comboBoxDirected.Items.AddRange(new object[] { "True", "False" });
            comboBoxDirected.Location = new Point(159, 175);
            comboBoxDirected.Name = "comboBoxDirected";
            comboBoxDirected.Size = new Size(79, 23);
            comboBoxDirected.TabIndex = 13;
            // 
            // textBoxWeightTag
            // 
            textBoxWeightTag.BackColor = SystemColors.ActiveBorder;
            textBoxWeightTag.BorderStyle = BorderStyle.None;
            textBoxWeightTag.Location = new Point(104, 207);
            textBoxWeightTag.Name = "textBoxWeightTag";
            textBoxWeightTag.ReadOnly = true;
            textBoxWeightTag.Size = new Size(49, 16);
            textBoxWeightTag.TabIndex = 14;
            textBoxWeightTag.Text = "Weight:";
            // 
            // textBoxWeightValue
            // 
            textBoxWeightValue.Location = new Point(159, 204);
            textBoxWeightValue.Name = "textBoxWeightValue";
            textBoxWeightValue.Size = new Size(79, 23);
            textBoxWeightValue.TabIndex = 15;
            // 
            // button2
            // 
            button2.Location = new Point(75, 304);
            button2.Name = "button2";
            button2.Size = new Size(101, 23);
            button2.TabIndex = 16;
            button2.Text = "Remove Vertex";
            button2.UseVisualStyleBackColor = true;
            button2.Click += RemoveVertex_Click;
            // 
            // textBoxDegreeCount
            // 
            textBoxDegreeCount.BackColor = SystemColors.ControlDark;
            textBoxDegreeCount.Location = new Point(15, 91);
            textBoxDegreeCount.Name = "textBoxDegreeCount";
            textBoxDegreeCount.ReadOnly = true;
            textBoxDegreeCount.Size = new Size(83, 23);
            textBoxDegreeCount.TabIndex = 17;
            textBoxDegreeCount.Text = "Degree: 0";
            // 
            // button3
            // 
            buttonOpenShortestPath.Location = new Point(65, 256);
            buttonOpenShortestPath.Name = "button3";
            buttonOpenShortestPath.Size = new Size(121, 23);
            buttonOpenShortestPath.TabIndex = 18;
            buttonOpenShortestPath.Text = "Open Shortest Path";
            buttonOpenShortestPath.UseVisualStyleBackColor = true;
            buttonOpenShortestPath.Click += OpenShortestPath_Click;
            // 
            // textBox5
            // 
            textBoxIsDirected.BackColor = SystemColors.ActiveBorder;
            textBoxIsDirected.BorderStyle = BorderStyle.None;
            textBoxIsDirected.Location = new Point(104, 178);
            textBoxIsDirected.Name = "textBox5";
            textBoxIsDirected.ReadOnly = true;
            textBoxIsDirected.Size = new Size(49, 16);
            textBoxIsDirected.TabIndex = 19;
            textBoxIsDirected.Text = "Directed?";
            // 
            // VertexSelectMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxIsDirected);
            Controls.Add(buttonOpenShortestPath);
            Controls.Add(textBoxDegreeCount);
            Controls.Add(button2);
            Controls.Add(textBoxWeightValue);
            Controls.Add(textBoxWeightTag);
            Controls.Add(comboBoxDirected);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(panelVertexColor);
            Controls.Add(textBox3);
            Name = "VertexSelectMenu";
            Size = new Size(250, 620);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private Button button4;
        private Panel panelVertexColor;
        private Button button1;
        private ComboBox comboBoxDirected;
        private TextBox textBoxWeightTag;
        private TextBox textBoxWeightValue;
        private Button button2;
        private TextBox textBoxDegreeCount;
        private Button buttonOpenShortestPath;
        private TextBox textBoxIsDirected;
    }
}
