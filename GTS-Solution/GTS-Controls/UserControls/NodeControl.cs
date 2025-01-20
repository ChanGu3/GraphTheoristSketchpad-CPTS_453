using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTS_UserInput;

namespace GTS_Controls
{
    [ToolboxItem(true)]
    public partial class NodeControl : UserControl
    {
        public event EventHandler? OnNodeClicked;

        private int circleRadius = 10;
        private Color circleColor = Color.DimGray;
        private bool isPickedUp = false;
        private bool isHovering = false;
        private bool isMouseDown = false;
        public NodeControl()
        {
            AddListeners();

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.CircleDiameter, this.CircleDiameter);
            this.Region = new Region(path);
            InitializeComponent();
            this.Size = new Size(this.CircleDiameter, this.CircleDiameter);
            this.Invalidate();
        }

        #region Properties 

        #region FIELDS
        /// <summary>
        /// Get and sets the circleRadius
        /// </summary>
        [Browsable(true), Category("Fields")]
        public int CircleRadius
        {
            get => circleRadius;
            set
            {
                circleRadius = value;

                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, this.CircleDiameter, this.CircleDiameter);
                this.Region = new Region(path);
                this.Size = new Size(this.CircleDiameter, this.CircleDiameter);
                this.Invalidate();
            }
        }

        /// <summary>
        /// Get and sets the color of the Circle
        /// </summary>
        [Browsable(true), Category("Fields")]
        public Color CircleColor
        {
            get => circleColor;
            set
            {
                circleColor = value;
                this.Invalidate();
            }
        }
        #endregion

        /// <summary>
        /// Gets the circles diameter
        /// </summary>

        public int CircleDiameter
        {
            get => circleRadius * 2;
        }

        /// <summary>
        /// the origin of the control relative to another control
        /// </summary>
        public Point CenterOrigin
        {
            get => new Point(this.Location.X + circleRadius, this.Location.Y + circleRadius);
        }

        #endregion

        /// <summary>
        /// adds listener on instantiation
        /// </summary>
        private void AddListeners()
        {
            // UserInput.Instance.AddKeyDownListener(Keys.Space, OnSpaceInput);

        }

        /// <summary>
        /// removes all listeners after disposing instance
        /// </summary>
        private void RemoveListeners()
        {

        }

        /// <summary>
        /// painting the circle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush myDrawingBrush = new SolidBrush(this.circleColor);

            g.FillEllipse(myDrawingBrush, new RectangleF(0f, 0f, 2f * circleRadius, 2 * circleRadius));
        }

        /// <summary>
        /// mouse clicking inside of the control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (UserInput.Instance.GetInputKeyDataIsDown(Keys.ControlKey))
            {
                this.isPickedUp = true;
                return;
            }

            if (!this.isMouseDown)
            {
                this.isMouseDown = true;
                this.OnNodeClicked?.Invoke(this, new EventArgs());
            }
        }

        private void NodeControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.isPickedUp)
            {
                this.isPickedUp = false;
                return;
            }

            if (!this.isMouseDown)
            {
                this.isMouseDown = false;
            }
        }

        /// <summary>
        /// mouse cursor entering the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeControl_MouseEnter(object sender, EventArgs e)
        {   
            if (!this.isHovering) { this.isHovering = true; }
        }

        /// <summary>
        /// mouse cursor leaving the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeControl_MouseLeave(object sender, EventArgs e)
        {
            if (!this.isHovering) { this.isHovering = true; }
        }

        private void NodeControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isHovering)
            {
                // change the cursor on controlkey and when not picked up only
                if (UserInput.Instance.GetInputKeyDataIsDown(Keys.ControlKey) && !this.isPickedUp)
                {
                    this.Cursor = Cursors.SizeAll;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }

                MoveControl();
            }
        }

        private void MoveControl()
        {
            if (isPickedUp)
            {
                if (this.Parent is null) { throw new InvalidOperationException("cannot move object as it is not a child of a parent control"); }


                // upper left point of Control
                Point upperLeftControl = this.Parent.PointToClient(Control.MousePosition);

                this.Location = new Point(upperLeftControl.X - this.circleRadius, upperLeftControl.Y - this.circleRadius);
                this.Invalidate();
            }
        }

        private void SetLocationOriginToCursorPoint()
        {

        }

        /*
        [I CAN USE THIS LATER FOR MAKING PICKING UP NODES CLOSEST TO EACH OTHER]
        /// <summary>
        /// whether the curser is hovering the radius of the circle or not.
        /// </summary>
        /// <returns> true when hovering. </returns>
        private bool IsCurserHovering()
        {
            
            Point curserToLocation = this.PointToClient(Control.MousePosition);

            float distance = MathF.Sqrt(MathF.Pow(curserToLocation.X - circleRadius, 2) + MathF.Pow(curserToLocation.Y - circleRadius, 2));
            if (distance <= circleRadius)
            {
                return true;
            }

            return false;
        }
        */
    }


}
