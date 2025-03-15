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
            panel1 = new Panel();
            button1 = new Button();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Control;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 16F);
            textBox3.Location = new Point(35, 21);
            textBox3.Name = "textBox3";
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
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Location = new Point(179, 101);
            panel1.Name = "panel1";
            panel1.Size = new Size(29, 26);
            panel1.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(60, 174);
            button1.Name = "button1";
            button1.Size = new Size(126, 23);
            button1.TabIndex = 10;
            button1.Text = "Remove Edge";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.ControlDark;
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(13, 56);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(115, 23);
            textBox4.TabIndex = 18;
            textBox4.Text = "Weight: [{count}]";
            // 
            // EdgeSelectMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox4);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(panel1);
            Controls.Add(textBox3);
            Name = "EdgeSelectMenu";
            Size = new Size(250, 620);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private Button button4;
        private Panel panel1;
        private Button button1;
        private TextBox textBox4;
    }
}
