using GTS_UserInput;
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
    public partial class DraggableUserControl : ClickableUserControl
    {
        // clickable specific fields
        protected Cursor dragCursor = Cursors.SizeAll;

        // dragging fields
        protected bool isDragging = false;

        public DraggableUserControl() : base()
        {
            this.DoubleBuffered = true;
            this.AddListeners();
            this.InitializeDraggable();
            // InitializeComponent();
        }

        /// <summary>
        /// Cursor For when clicking Control.
        /// </summary>
        [Browsable(true), Category("Draggable Properties")]
        public Cursor DragCursor
        {
            get => dragCursor;
            set => dragCursor = value;
        }

        /// <summary>
        /// adds listener on instantiation
        /// </summary>
        private void AddListeners()
        {
            UserInput.Instance?.AddKeyDownListener(Keys.ControlKey, OnControlDown);
            UserInput.Instance?.AddKeyUpListener(Keys.ControlKey, OnControlUp);
        }

        /// <summary>
        /// removes all listeners after disposing instance
        /// </summary>
        private void RemoveListeners()
        {
            UserInput.Instance?.RemoveKeyDownListener(Keys.ControlKey, OnControlDown);
            UserInput.Instance?.RemoveKeyUpListener(Keys.ControlKey, OnControlUp);
        }

        /// <summary>
        /// initializing class specific functions
        /// </summary>
        private void InitializeDraggable()
        {
            this.MouseDown += this.OnDraggable_MouseDown;
            this.MouseUp += this.OnDraggable_MouseUp;
            this.MouseEnter += this.OnDraggable_MouseEnter;
            this.MouseMove += this.OnDraggable_MouseMove;
        }

        /// <summary>
        /// when mouse is moving over the cursor.
        /// </summary>
        private void OnDraggable_MouseMove(object? sender, MouseEventArgs e)
        {
            MoveControl();
        }

        /// <summary>
        /// moves the control by the origin of the cursor
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        private void MoveControl()
        {
            if (this.isDragging)
            {
                if (this.Parent is null) { throw new InvalidOperationException("cannot move object as it is not a child of a parent control"); }

                // upper left point of Control
                Point upperLeftControl = this.Parent.PointToClient(Control.MousePosition);

                this.Location = new Point(upperLeftControl.X - (this.Size.Width / 2), upperLeftControl.Y - (this.Size.Height / 2));
            }
        }

        /// <summary>
        /// mouse cursor entering the control
        /// </summary>
        private void OnDraggable_MouseEnter(object? sender, EventArgs e)
        {
            if (UserInput.Instance!.GetInputKeyDataIsDown(Keys.ControlKey)) { this.Cursor = this.dragCursor; }
        }

        /// <summary>
        /// mouse down inside of the control.
        /// </summary>
        private void OnDraggable_MouseDown(object? sender, MouseEventArgs e)
        {
            if (this.Cursor == this.dragCursor)
            {
                this.isDragging = true;
            }
        }

        /// <summary>
        /// mouse up inside of the control.
        /// </summary>
        private void OnDraggable_MouseUp(object? sender, MouseEventArgs e)
        {
            if (this.isDragging)
            {
                if (!UserInput.Instance!.GetInputKeyDataIsDown(Keys.ControlKey)) { this.Cursor = this.clickCursor; }

                this.isDragging = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"> UserInputInstance. </param>
        /// <param name="e"> arguments. </param>
        private void OnControlDown(object? sender, EventArgs e)
        {
            if (this.isClickable)
            {
                this.Cursor = this.dragCursor;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"> UserInputInstance. </param>
        /// <param name="e"> arguments. </param>
        private void OnControlUp(object? sender, EventArgs e)
        {
            if (this.isDragging) { return; }

            this.Cursor = this.clickCursor;
        }
    }
}
