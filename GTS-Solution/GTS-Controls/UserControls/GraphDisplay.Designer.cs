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
            panelGraph = new Panel();
            SuspendLayout();
            // 
            // panelGraph
            // 
            panelGraph.AllowDrop = true;
            panelGraph.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelGraph.AutoScroll = true;
            panelGraph.BackColor = SystemColors.GradientActiveCaption;
            panelGraph.BorderStyle = BorderStyle.Fixed3D;
            panelGraph.Location = new Point(0, 0);
            panelGraph.Name = "panelGraph";
            panelGraph.Size = new Size(800, 450);
            panelGraph.TabIndex = 2;
            panelGraph.Paint += panelGraph_Paint;
            // 
            // GraphDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelGraph);
            DoubleBuffered = true;
            Name = "GraphDisplay";
            Size = new Size(800, 450);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelGraph;
    }
}
