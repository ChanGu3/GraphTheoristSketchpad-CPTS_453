using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTS_UserInput;

namespace GTS_Controls
{
    [ToolboxItem(true)]
    public partial class VertexUserControl : DraggableUserControl
    {
        // create a static mutex to allow only one click at a time
        int vertexID;

        public event EventHandler? OnNodeClicked;

        private int circleRadius = 15;
        private int controlSize = 0;
        private Color circleColor = Color.DimGray;
        private bool isHighlighted = false;

        public VertexUserControl(int vertexID) : base()
        {
            this.vertexID = vertexID;
            InitializeComponent();

            controlSize = this.Diameter * 2;
            this.Size = new Size(controlSize, controlSize); 
            
            this.ResetRegion();
        }

        public bool IsHighlighted
        {
            get => isHighlighted;
            set => isHighlighted = value;
        }

        #region Properties 

        #region FIELDS
        /// <summary>
        /// Get and sets the circleRadius
        /// </summary>
        [Browsable(true), Category("NodeUser Properties")]
        public int CircleRadius 
        {
            get => circleRadius;
            set
            {
                circleRadius = value;

                controlSize = this.Diameter * 2;
                this.Size = new Size(controlSize, controlSize);
                
                this.ResetRegion();

                this.Invalidate();
            }
        }

        /// <summary>
        /// Get and sets the color of the Circle
        /// </summary>
        [Browsable(true), Category("Fields")]
        public Color Color
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
        /// vertexID to link to graph.
        /// </summary>
        public int VertexID
        {
            get => vertexID;
        }

        /// <summary>
        /// Gets the circles diameter
        /// </summary>

        public int Diameter
        {
            get => circleRadius * 2;
        }

        /// <summary>
        /// the origin of the control relative to another control
        /// </summary>
        public Point CenterOrigin
        {
            get => new Point(this.Location.X + (this.Size.Width/2), this.Location.Y + (this.Size.Height / 2));
        }

        #endregion

        private void ResetRegion()
        {
            GraphicsPath path = new GraphicsPath();
            // Getting the x and y for the distance to make to create circle correctly from top left position
            int coordinateDistance = controlSize / 4;
            path.AddEllipse(new RectangleF(coordinateDistance, coordinateDistance, this.Diameter, this.Diameter));
            this.Region = new Region(path);
        }

        /// <summary>
        /// painting the circle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Brush myDrawingBrush = new SolidBrush(this.circleColor);
            // Getting the x and y for the distance to make to create circle correctly from top left position
            int coordinateDistance = controlSize / 4;

            graphics.FillEllipse(myDrawingBrush, new RectangleF(coordinateDistance, coordinateDistance, this.Diameter, this.Diameter));

            if (this.isHighlighted)
            {
                Brush brushHighlight = new SolidBrush(Color.White);
                graphics.FillEllipse(brushHighlight, new RectangleF(coordinateDistance * 1.5f, coordinateDistance * 1.5f, this.Diameter/2, this.Diameter/2));
            }
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
