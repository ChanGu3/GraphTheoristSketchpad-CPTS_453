namespace GTS_Controls.UserControls
{
    partial class MenuControl
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
            groupBoxMain = new GroupBox();
            button1 = new Button();
            groupBoxMain.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxMain
            // 
            groupBoxMain.BackColor = SystemColors.ActiveBorder;
            groupBoxMain.Controls.Add(button1);
            groupBoxMain.Location = new Point(0, 0);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(280, 710);
            groupBoxMain.TabIndex = 3;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Main Controls";
            // 
            // button1
            // 
            button1.Location = new Point(89, 662);
            button1.Name = "button1";
            button1.Size = new Size(103, 42);
            button1.TabIndex = 0;
            button1.Text = "Reset Graph";
            button1.UseVisualStyleBackColor = true;
            // 
            // MenuControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxMain);
            Name = "MenuControl";
            Size = new Size(281, 711);
            groupBoxMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxMain;
        private Button button1;
    }
}
