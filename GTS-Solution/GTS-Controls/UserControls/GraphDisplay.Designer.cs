using System.ComponentModel;

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
            components = new Container();
            panelGraph = new DoubleBufferedPanel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            createVertexToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelGraph
            // 
            panelGraph.AllowDrop = true;
            panelGraph.AutoSize = true;
            panelGraph.BackColor = SystemColors.GradientActiveCaption;
            panelGraph.BorderStyle = BorderStyle.Fixed3D;
            panelGraph.Dock = DockStyle.Fill;
            panelGraph.Location = new Point(0, 0);
            panelGraph.Name = "panelGraph";
            panelGraph.Size = new Size(1301, 822);
            panelGraph.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { createVertexToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(144, 26);
            // 
            // createVertexToolStripMenuItem
            // 
            createVertexToolStripMenuItem.Name = "createVertexToolStripMenuItem";
            createVertexToolStripMenuItem.Size = new Size(143, 22);
            createVertexToolStripMenuItem.Text = "Create Vertex";
            createVertexToolStripMenuItem.Click += CreateVertex_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // GraphDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(panelGraph);
            DoubleBuffered = true;
            Name = "GraphDisplay";
            Size = new Size(1301, 822);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DoubleBufferedPanel panelGraph;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem createVertexToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
    }
}
