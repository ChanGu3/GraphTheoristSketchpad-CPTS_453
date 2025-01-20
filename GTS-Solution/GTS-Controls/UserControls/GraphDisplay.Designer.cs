namespace GTS_Controls
{
    partial class GraphDisplay
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
            nodeControl1 = new NodeControl();
            nodeControl2 = new NodeControl();
            SuspendLayout();
            // 
            // nodeControl1
            // 
            nodeControl1.BackColor = Color.Transparent;
            nodeControl1.BackgroundImageLayout = ImageLayout.None;
            nodeControl1.CircleRadius = 10;
            nodeControl1.Location = new Point(152, 208);
            nodeControl1.Name = "nodeControl1";
            nodeControl1.Size = new Size(20, 20);
            nodeControl1.TabIndex = 0;
            // 
            // nodeControl2
            // 
            nodeControl2.BackColor = Color.Transparent;
            nodeControl2.BackgroundImageLayout = ImageLayout.None;
            nodeControl2.CircleRadius = 75;
            nodeControl2.Location = new Point(178, 208);
            nodeControl2.Name = "nodeControl2";
            nodeControl2.Size = new Size(150, 150);
            nodeControl2.TabIndex = 1;
            // 
            // GraphDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(nodeControl2);
            Controls.Add(nodeControl1);
            DoubleBuffered = true;
            Name = "GraphDisplay";
            Size = new Size(800, 450);
            ResumeLayout(false);
        }

        #endregion

        private NodeControl nodeControl1;
        private NodeControl nodeControl2;
    }
}
