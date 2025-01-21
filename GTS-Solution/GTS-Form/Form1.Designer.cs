using GTS_Controls;

namespace GTS_Form
{
    partial class FormGTS
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGTS));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            groupBoxMain = new GroupBox();
            graphDisplay1 = new GraphDisplay();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Desktop;
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.BackColor = SystemColors.ControlLightLight;
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, loadToolStripMenuItem });
            fileToolStripMenuItem.Font = new Font("Lucida Sans", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            fileToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
            fileToolStripMenuItem.ImageTransparentColor = Color.Black;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(109, 22);
            toolStripMenuItem1.Text = "Save...";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(109, 22);
            loadToolStripMenuItem.Text = "Load...";
            // 
            // groupBoxMain
            // 
            groupBoxMain.BackColor = SystemColors.ActiveBorder;
            groupBoxMain.Location = new Point(608, 37);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(180, 401);
            groupBoxMain.TabIndex = 2;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Main Controls";
            // 
            // graphDisplay1
            // 
            graphDisplay1.BorderStyle = BorderStyle.Fixed3D;
            graphDisplay1.Location = new Point(12, 37);
            graphDisplay1.Name = "graphDisplay1";
            graphDisplay1.Size = new Size(580, 401);
            graphDisplay1.TabIndex = 3;
            // 
            // FormGTS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(800, 450);
            Controls.Add(graphDisplay1);
            Controls.Add(groupBoxMain);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormGTS";
            Text = "Graph Theorist Sketchpad";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem loadToolStripMenuItem;
        private GroupBox groupBoxMain;
        private GraphDisplay graphDisplay1;
    }
}
