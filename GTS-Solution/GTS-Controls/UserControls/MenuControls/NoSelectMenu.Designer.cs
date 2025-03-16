namespace GTS_Controls.UserControls.MenuControls
{
    partial class NoSelectMenu
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
            button1 = new Button();
            textBoxIsBipartite = new TextBox();
            button2 = new Button();
            button3 = new Button();
            panelBridgeColor = new Panel();
            textBox3 = new TextBox();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(52, 96);
            button1.Name = "button1";
            button1.Size = new Size(139, 23);
            button1.TabIndex = 0;
            button1.Text = "Check Bi_Partiteness";
            button1.UseVisualStyleBackColor = true;
            button1.Click += CheckBiPartiteness_Click;
            // 
            // textBoxIsBipartite
            // 
            textBoxIsBipartite.BackColor = SystemColors.ControlLightLight;
            textBoxIsBipartite.BorderStyle = BorderStyle.None;
            textBoxIsBipartite.Location = new Point(56, 125);
            textBoxIsBipartite.Name = "textBoxIsBipartite";
            textBoxIsBipartite.ReadOnly = true;
            textBoxIsBipartite.Size = new Size(135, 16);
            textBoxIsBipartite.TabIndex = 1;
            textBoxIsBipartite.Text = "Is Bi-partite: N/A";
            textBoxIsBipartite.TextAlign = HorizontalAlignment.Center;
            // 
            // button2
            // 
            button2.Location = new Point(56, 196);
            button2.Name = "button2";
            button2.Size = new Size(127, 23);
            button2.TabIndex = 2;
            button2.Text = "Reveal Bridges";
            button2.UseVisualStyleBackColor = true;
            button2.Click += RevealBridges_Click;
            // 
            // button3
            // 
            button3.Location = new Point(43, 268);
            button3.Name = "button3";
            button3.Size = new Size(148, 23);
            button3.TabIndex = 3;
            button3.Text = "Open Adjacency Matrix";
            button3.UseVisualStyleBackColor = true;
            button3.Click += OpenAdjacencyMatrix_Click;
            // 
            // panelBridgeColor
            // 
            panelBridgeColor.BackColor = Color.Red;
            panelBridgeColor.Location = new Point(182, 225);
            panelBridgeColor.Name = "panelBridgeColor";
            panelBridgeColor.Size = new Size(29, 26);
            panelBridgeColor.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ActiveBorder;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 16F);
            textBox3.ImeMode = ImeMode.NoControl;
            textBox3.Location = new Point(43, 20);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(162, 29);
            textBox3.TabIndex = 6;
            textBox3.Text = "No Select Menu";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // button4
            // 
            button4.Location = new Point(22, 225);
            button4.Name = "button4";
            button4.Size = new Size(142, 26);
            button4.TabIndex = 0;
            button4.Text = "Choose Bridges Color...";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ChooseBridgeColor_Click;
            // 
            // button5
            // 
            button5.Location = new Point(43, 465);
            button5.Name = "button5";
            button5.Size = new Size(148, 23);
            button5.TabIndex = 7;
            button5.Text = "Reset Object Colors";
            button5.UseVisualStyleBackColor = true;
            button5.Click += ResetObjectColors_Click;
            // 
            // NoSelectMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBox3);
            Controls.Add(panelBridgeColor);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBoxIsBipartite);
            Controls.Add(button1);
            Name = "NoSelectMenu";
            Size = new Size(250, 620);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBoxIsBipartite;
        private Button button2;
        private Button button3;
        private Panel panelBridgeColor;
        private TextBox textBox3;
        private Button button4;
        private Button button5;
    }
}
