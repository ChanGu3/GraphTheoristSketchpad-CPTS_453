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
            graphDisplay1 = new GraphDisplay();
            menuControl1 = new GTS_Controls.UserControls.MenuControl();
            textBoxOrder = new TextBox();
            textBoxSize = new TextBox();
            textBoxComponents = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Desktop;
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1462, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.BackColor = SystemColors.ControlLightLight;
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, loadToolStripMenuItem });
            fileToolStripMenuItem.Enabled = false;
            fileToolStripMenuItem.Font = new Font("Lucida Sans", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            fileToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
            fileToolStripMenuItem.ImageTransparentColor = Color.Black;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            fileToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            toolStripMenuItem1.Text = "Save...";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(180, 22);
            loadToolStripMenuItem.Text = "Load...";
            // 
            // graphDisplay1
            // 
            graphDisplay1.BorderStyle = BorderStyle.Fixed3D;
            graphDisplay1.Location = new Point(12, 58);
            graphDisplay1.Name = "graphDisplay1";
            graphDisplay1.Size = new Size(1154, 690);
            graphDisplay1.TabIndex = 3;
            // 
            // menuControl1
            // 
            menuControl1.Location = new Point(1172, 37);
            menuControl1.Name = "menuControl1";
            menuControl1.Size = new Size(281, 711);
            menuControl1.TabIndex = 4;
            // 
            // textBoxOrder
            // 
            textBoxOrder.BackColor = SystemColors.Window;
            textBoxOrder.BorderStyle = BorderStyle.None;
            textBoxOrder.Font = new Font("Segoe UI", 14F);
            textBoxOrder.Location = new Point(54, 27);
            textBoxOrder.Name = "textBoxOrder";
            textBoxOrder.Size = new Size(125, 25);
            textBoxOrder.TabIndex = 5;
            textBoxOrder.Text = "Order: 0";
            // 
            // textBoxSize
            // 
            textBoxSize.BorderStyle = BorderStyle.None;
            textBoxSize.Font = new Font("Segoe UI", 14F);
            textBoxSize.Location = new Point(207, 27);
            textBoxSize.Name = "textBoxSize";
            textBoxSize.Size = new Size(125, 25);
            textBoxSize.TabIndex = 6;
            textBoxSize.Text = "Size: 0";
            // 
            // textBoxComponents
            // 
            textBoxComponents.BorderStyle = BorderStyle.None;
            textBoxComponents.Font = new Font("Segoe UI", 14F);
            textBoxComponents.Location = new Point(373, 27);
            textBoxComponents.Name = "textBoxComponents";
            textBoxComponents.Size = new Size(178, 25);
            textBoxComponents.TabIndex = 7;
            textBoxComponents.Text = "Components: 0";
            // 
            // FormGTS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1462, 762);
            Controls.Add(textBoxComponents);
            Controls.Add(textBoxSize);
            Controls.Add(textBoxOrder);
            Controls.Add(menuControl1);
            Controls.Add(graphDisplay1);
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
        private GraphDisplay graphDisplay1;
        private GTS_Controls.UserControls.MenuControl menuControl1;
        private TextBox textBoxOrder;
        private TextBox textBoxSize;
        private TextBox textBoxComponents;
    }
}
