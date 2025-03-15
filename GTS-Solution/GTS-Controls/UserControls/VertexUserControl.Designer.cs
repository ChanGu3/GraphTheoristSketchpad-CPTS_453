namespace GTS_Controls
{
    partial class VertexUserControl
    {
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
        protected override void InitializeComponent()
        {
            SuspendLayout();
            // 
            // NodeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.None;
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            Name = "NodeControl";
            Size = new Size(10, 10);
            Paint += NodeControl_Paint;
            ResumeLayout(false);
        }

        #endregion
    }
}
