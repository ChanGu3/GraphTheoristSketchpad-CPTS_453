namespace GTS_Controls.UserControls.MenuControls
{
    partial class EdgeSelectMenu
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
            panelEdgeColor = new Panel();
            button1 = new Button();
            textBoxWeightCount = new TextBox();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ActiveBorder;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 16F);
            textBox3.Location = new Point(35, 21);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(173, 29);
            textBox3.TabIndex = 7;
            textBox3.Text = "Edge Select Menu";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // button4
            // 
            button4.Location = new Point(35, 101);
            button4.Name = "button4";
            button4.Size = new Size(126, 26);
            button4.TabIndex = 8;
            button4.Text = "Change Edge Color...";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ChangeColor_Click;
            // 
            // panelEdgeColor
            // 
            panelEdgeColor.BackColor = Color.Blue;
            panelEdgeColor.Location = new Point(179, 101);
            panelEdgeColor.Name = "panelEdgeColor";
            panelEdgeColor.Size = new Size(29, 26);
            panelEdgeColor.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(60, 174);
            button1.Name = "button1";
            button1.Size = new Size(126, 23);
            button1.TabIndex = 10;
            button1.Text = "Remove Edge";
            button1.UseVisualStyleBackColor = true;
            button1.Click += RemoveEdge_Click;
            // 
            // textBoxWeightCount
            // 
            textBoxWeightCount.BackColor = SystemColors.ControlLightLight;
            textBoxWeightCount.BorderStyle = BorderStyle.FixedSingle;
            textBoxWeightCount.Location = new Point(13, 56);
            textBoxWeightCount.Name = "textBoxWeightCount";
            textBoxWeightCount.ReadOnly = true;
            textBoxWeightCount.Size = new Size(92, 23);
            textBoxWeightCount.TabIndex = 18;
            textBoxWeightCount.Text = "Weight: 0";
            // 
            // EdgeSelectMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxWeightCount);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(panelEdgeColor);
            Controls.Add(textBox3);
            Name = "EdgeSelectMenu";
            Size = new Size(250, 620);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private Button button4;
        private Panel panelEdgeColor;
        private Button button1;
        private TextBox textBoxWeightCount;
    }
}
