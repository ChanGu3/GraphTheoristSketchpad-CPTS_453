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

        private int circleRadius = 25;
        private Color color = Color.Black;

        public NodeControl()
        {
            AddListeners();

            InitializeComponent();
            this.Size = new Size(this.CircleDiameter, this.CircleDiameter);
        }

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
                this.Invalidate();
            }
        }

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

        private void AddListeners()
        {
            // UserInput.Instance.AddKeyDownListener(Keys.Space, OnSpaceInput);
        }

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
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.CircleDiameter, this.CircleDiameter);
            this.Region = new Region(path);

            Graphics g = e.Graphics;
            Brush myDrawingBrush = new SolidBrush(Color.OrangeRed);

            g.FillEllipse(myDrawingBrush, new RectangleF(0f, 0f, 2f * circleRadius, 2 * circleRadius));
            this.Size = new Size((int)MathF.Ceiling(this.CircleDiameter), (int)MathF.Ceiling(this.CircleDiameter));
        }

        /// <summary>
        /// mouse clicking inside of the control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnNodeClicked?.Invoke(this, new EventArgs());
            
        }

        /// <summary>
        /// mouse cursor entering the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeControl_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeAll;
        }

        /// <summary>
        /// mouse cursor leaving the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeControl_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// mouse cursor hovering the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeControl_MouseHover(object sender, EventArgs e)
        {

        }

        private void MoveControl()
        {

        }

        private void NodeControl_MouseUp(object sender, MouseEventArgs e)
        {

        }

        /*
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
