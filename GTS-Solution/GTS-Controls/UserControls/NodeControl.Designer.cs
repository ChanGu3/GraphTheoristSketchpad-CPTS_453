namespace GTS_Controls
{
    partial class NodeControl
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
            this.RemoveListeners();

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
            SuspendLayout();
            // 
            // NodeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.None;
            DoubleBuffered = true;
            Name = "NodeControl";
            Size = new Size(50, 50);
            Paint += NodeControl_Paint;
            MouseDown += NodeControl_MouseDown;
            MouseEnter += NodeControl_MouseEnter;
            MouseLeave += NodeControl_MouseLeave;
            MouseMove += NodeControl_MouseMove;
            MouseUp += NodeControl_MouseUp;
            ResumeLayout(false);
        }

        #endregion
    }
}
