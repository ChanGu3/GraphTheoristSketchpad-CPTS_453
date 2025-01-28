using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTS_Controls
{
    [ToolboxItem(false)]
    public partial class ClickableUserControl : UserControl
    {
        // events
        public event EventHandler? OnClicked;

        // clickable specific fields
        protected Cursor clickCursor = Cursors.Hand;

        // mouse fields
        protected bool isMouseDown = false;
        protected bool isClickable = false;

        public ClickableUserControl()
        {
            this.InitializeClickable();
            // InitializeComponent();
        }

        /// <summary>
        /// Cursor For when clicking Control.
        /// </summary>
        [Browsable(true), Category("Clickable Properties")]
        public Cursor ClickCursor
        {
            get => clickCursor;
            set => clickCursor = value;
        }

        /// <summary>
        /// initializing class specific functions
        /// </summary>
        private void InitializeClickable()
        {
            this.MouseDown += this.OnClickable_MouseDown;
            this.MouseUp += this.OnClickable_MouseUp;
            this.MouseEnter += this.OnClickable_MouseEnter;
            this.MouseLeave += this.OnClickable_MouseLeave;
        }

        /// <summary>
        /// mouse clicking down inside of the control.
        /// </summary>
        private void OnClickable_MouseDown(object? sender, MouseEventArgs e)
        {
            if (!this.isMouseDown && this.Cursor == clickCursor)
            {
                this.isMouseDown = true;
                this.OnClicked?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// mouse clicking up inside of the control.
        /// </summary>
        private void OnClickable_MouseUp(object? sender, MouseEventArgs e)
        {
            if (this.isMouseDown && this.Cursor == this.clickCursor)
            {
                this.isMouseDown = false;
            }
        }

        /// <summary>
        /// mouse cursor entering the control
        /// </summary>
        private void OnClickable_MouseEnter(object? sender, EventArgs e)
        {
            this.isClickable = true;
            if (this.Cursor == Cursors.Default) { this.Cursor = this.clickCursor; }
        }

        /// <summary>
        /// mouse cursor leaving the control
        /// </summary>
        private void OnClickable_MouseLeave(object? sender, EventArgs e)
        {
            this.isClickable = false;
            this.Cursor = Cursors.Default;
        }
    }
}
