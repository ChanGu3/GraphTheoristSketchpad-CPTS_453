using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Numerics;

namespace GTS_Controls
{
    [ToolboxItem(true)]
    public partial class EdgeUserControl : ClickableUserControl
    {
        int edgeID;

        // public event EventHandler? OnBent;

        // clickable specific fields
        protected Cursor bendCursor = Cursors.SizeAll;

        // dragging fields
        protected bool isBending = false;

        private Color color = Color.Black;
        private PointF startPoint = Point.Empty;
        private PointF endPoint = PointF.Empty;
        private PointF control1 = Point.Empty;
        private PointF control2 = Point.Empty;
        private PointF perp = Point.Empty; // direction perpendicular to both vertexes incident to edge
        private float curveHeight = 0f; // every 0.001f
        private float lineWidth = 4f;
        private bool isLoop;
        private bool isHighlighted = false;
        private bool isDirected = false;
        private Control? label;

        // add arrow to the path of a region with the bezier (On the middle)
        // for painting use the same arrow on the middle.

        public EdgeUserControl(int edgeID, bool isLoop, bool isDirected) : base()
        {
            this.isLoop = isLoop;
            this.edgeID = edgeID;
            this.isDirected = isDirected;

            InitializeComponent();

            // this.Region = new Region();
            // this.Region.MakeEmpty();
        }

        public int EdgeID
        {
            get => edgeID;
        }

        public float CurveHeight
        {
            get => curveHeight;
            set => curveHeight = value;
        }

        public bool IsHighlighted
        {
            get => isHighlighted;
            set => isHighlighted = value;
        }

        public Point MiddleOfEdge
        {
            get => BezierPoint(0.5f, this.startPoint, this.control1, this.control2, this.endPoint);
        }

        /// <summary>
        /// Cursor For when clicking Control.
        /// </summary>
        [Browsable(true), Category("Bending Properties")]
        public Cursor BendCursor
        {
            get => bendCursor;
            set => bendCursor = value;
        }

        #region PROPERTIES

        [Browsable(true), Category("LineUser Properties")]
        public Color Color
        {
            get => color;
            set
            {
                color = value;
                this.SetRegion();
                this.Invalidate();
            }
        }

        [Browsable(true), Category("LineUser Properties")]
        public PointF StartPoint
        {
            get => startPoint;
            set
            {
                startPoint = value;
                this.SetRegion();
                this.Invalidate();
            }
        }


        [Browsable(true), Category("LineUser Properties")]
        public PointF EndPoint
        {
            get => endPoint;
            set
            {
                endPoint = value;
                this.SetRegion();
                this.Invalidate();
            }
        }

        /// <summary>
        /// starts control
        /// </summary>
        [Browsable(true), Category("LineUser Properties")]
        public PointF Control1
        {
            get => control1;
        }

        /// <summary>
        /// ends control
        /// </summary>
        [Browsable(true), Category("LineUser Properties")]
        public PointF Control2
        {
            get => control2;
        }


        [Browsable(true), Category("LineUser Properties")]
        public float LineWidth
        {
            get => lineWidth;
            set
            {
                lineWidth = value;
                this.SetRegion();
                this.Invalidate();
            }
        }

        #endregion


        private static float PointDistance(PointF pointStart, PointF pointEnd)
        {
            float newDisx = pointEnd.X - pointStart.X;
            float newDisy = pointEnd.Y - pointStart.Y;
            return MathF.Sqrt(newDisx * newDisx + newDisy * newDisy);
        }

        private static PointF PointDirection(PointF pointStart, PointF pointEnd)
        {
            return new PointF(pointEnd.X - pointStart.X, pointEnd.Y - pointStart.Y);
        }

        private void UpdateControlPoints(PointF midPoint, PointF perp, float height)
        {
            int offsetLoop = 0;

            if (this.isLoop)
            {
                offsetLoop = 1;
            }

            // Place control points symmetrically along perpendicular line
            control1 = new PointF(
                midPoint.X + perp.X * height * 0.5f - (100 * offsetLoop),
                midPoint.Y + perp.Y * height * 0.5f
            );
            control2 = new PointF(
                midPoint.X + perp.X * height * 0.5f + (100 * offsetLoop),
                midPoint.Y + perp.Y * height * 0.5f
            );
        }

        public void UpdateLinePoints(Point currentStartPoint, Point currentEndPoint)
        {
            // Scaling
            float currentDistance = PointDistance(currentStartPoint, currentEndPoint);

            if (this.startPoint != PointF.Empty && this.endPoint != PointF.Empty)
            {
                if (currentDistance > 0)
                {
                    float initialDistance = PointDistance(this.startPoint, this.endPoint);

                    PointF midPoint = new PointF(
                        (currentStartPoint.X + currentEndPoint.X) / 2,
                        (currentStartPoint.Y + currentEndPoint.Y) / 2);

                    // Angle
                    PointF currentDirection = PointDirection(currentStartPoint, currentEndPoint);
                    Vector2 tempPerp = new Vector2(-currentDirection.Y, currentDirection.X);
                    tempPerp = Vector2.Normalize(tempPerp);
                    this.perp = new PointF(tempPerp.X, tempPerp.Y);

                    float currentCurveHeight = this.curveHeight * currentDistance;

                    UpdateControlPoints(midPoint, this.perp, currentCurveHeight);
                }
                else
                {
                    this.control1 = startPoint;
                    this.control2 = endPoint;
                }
            }
            else // happens when first time edge exists as previous points are empty
            {
                this.control1 = currentStartPoint;
                this.control2 = currentEndPoint;
            }

            this.startPoint = currentStartPoint;
            this.endPoint = currentEndPoint;

            this.SetRegion();
            this.Invalidate();
        }


        //Transparency instead of region?
        /*
        this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        this.BackColor = Color.Transparent;
        this.Size = new Size(200, 2); // Thin horizontal control

            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                // Prevent default background painting to allow transparency
            }

            for moue over and cliking events stop clicking on trasparent parts and caculate the distance 
            between curve and mouse for events.
        */

        private void SetRegion()
        {
            // no region set when line doesn't exist
            if (this.startPoint != this.endPoint)
            {
                GraphicsPath path = new GraphicsPath();

                // Line of Edge
                path.AddBezier(startPoint, this.Control1, this.Control2, endPoint);
                Pen pen = new Pen(Color.Transparent, this.lineWidth);


                if (isDirected)
                {
                    // Arrow Point
                    Point tip = BezierPoint(0.5f, this.startPoint, this.control1, this.control2, this.endPoint);
                    (PointF, PointF) pointPair = CalculateArrowHeadPoints(tip, 17, GetDirectionInRadians(this.startPoint, this.endPoint));
                    path.AddLine(tip, pointPair.Item1);
                    path.AddLine(tip, pointPair.Item2);
                }

                path.Widen(pen);
                this.Region = new Region(path);
            }
        }

        private void LineUserControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            //graphics.SmoothingMode = SmoothingMode.HighSpeed;

            // Line of Edge
            Pen pen = new Pen(this.color, this.lineWidth);
            graphics.DrawBezier(pen, startPoint, this.Control1, this.Control2, endPoint);

            Point tip = Point.Empty;
            (PointF, PointF) pointPair = (PointF.Empty, PointF.Empty);
            if (isDirected)
            {
                // Arrow Point
                tip = BezierPoint(0.5f, this.startPoint, this.control1, this.control2, this.endPoint);
                pointPair = CalculateArrowHeadPoints(tip, 17, GetDirectionInRadians(this.startPoint, this.endPoint));
                graphics.DrawLine(pen, tip, pointPair.Item1);
                graphics.DrawLine(pen, tip, pointPair.Item2);
            }

            // Highlighting when selected
            if (isHighlighted)
            {
                // Line of Edge
                Pen penHighlight = new Pen(Color.White, this.lineWidth / 2);
                graphics.DrawBezier(penHighlight, startPoint, this.Control1, this.Control2, endPoint);

                if (isDirected)
                {
                    // Arrow Point
                    graphics.DrawLine(penHighlight, tip, pointPair.Item1);
                    graphics.DrawLine(penHighlight, tip, pointPair.Item2);
                }
            }
        }

        private static Point BezierPoint(float t, PointF startPoint, PointF control1, PointF control2, PointF endPoint)
        {
            float x = (float)(
                Math.Pow(1 - t, 3) * startPoint.X +
                3 * Math.Pow(1 - t, 2) * t * control1.X +
                3 * (1 - t) * Math.Pow(t, 2) * control2.X +
                Math.Pow(t, 3) * endPoint.X
            );

            float y = (float)(
                Math.Pow(1 - t, 3) * startPoint.Y +
                3 * Math.Pow(1 - t, 2) * t * control1.Y +
                3 * (1 - t) * Math.Pow(t, 2) * control2.Y +
                Math.Pow(t, 3) * endPoint.Y
            );

            return new Point((int)x, (int)y);
        }

        private static (PointF, PointF) CalculateArrowHeadPoints(Point tip, int length, double tipAngle)
        {
            Point p1 = new Point(
                tip.X - (int)(length * Math.Cos(tipAngle + Math.PI / 6)),
                tip.Y - (int)(length * Math.Sin(tipAngle + Math.PI / 6))
            );
            Point p2 = new Point(
                tip.X - (int)(length * Math.Cos(tipAngle - Math.PI / 6)),
                tip.Y - (int)(length * Math.Sin(tipAngle - Math.PI / 6))
            );

            return (p1, p2);
        }

        private static double GetDirectionInRadians(PointF From, PointF To)
        {
            PointF direction = PointDirection(From, To);
            Vector2 directionV = new Vector2(direction.X, direction.Y);
            directionV = Vector2.Normalize(directionV);
            return Math.Atan2(direction.Y, direction.X);
        }

        public void AddLabel(string label)
        {
            this.label = new Label();
            this.label.Text = label;
            this.label.Font = new Font(this.label.Font.FontFamily, this.label.Font.Size + 8f, this.label.Font.Style);
            this.label.ForeColor = Color.White;

            this.label.Parent = this.Parent;
            Point middleOfEdge = this.MiddleOfEdge;
            this.label.Location = new Point(middleOfEdge.X, middleOfEdge.Y);
            this.label.Name = $"label{label}";

            this.Parent?.Controls.Add(this.label);

            //region creation
            GraphicsPath path = new GraphicsPath();
            Font font = (this.label as Label)!.Font;
            path.AddString(label, font.FontFamily, (int)font.Style, font.Size, new Point(0, 0), StringFormat.GenericDefault);

            //path.Widen(new Pen(Color.Black, 1f));

            // Apply the text path as the region
            this.label.Region = new Region(path);
            this.label.Paint +=
            (sender, e) =>
            {
                e.Graphics.FillPath(new SolidBrush(Color.White), path);
            };

            this.label.BringToFront();
        }

        public void RemoveLabel()
        {
            this.Parent?.Controls.Remove(this.label);
            this.label?.Dispose();
        }

        /*
        /// <summary>
        /// initializing class specific functions
        /// </summary>
        private void InitializeBendableActions()
        {
            this.MouseDown += this.OnBending_MouseDown;
            this.MouseUp += this.OnBending_MouseUp;
            this.MouseEnter += this.OnBending_MouseEnter;
            this.MouseWheel += this.OnBending_MouseWheel;
        }

        private Point GetMouseDirection(MouseEventArgs e)
        {
            Point mouseDirection = new Point(0, 0);

            if (e.X - this.lastMousePosition.X < 0)
            {
                mouseDirection.X = 1;
            }
            else
            {
                mouseDirection.X = -1;
            }

            if (e.Y - this.lastMousePosition.Y < 0)
            {
                mouseDirection.Y = 1;
            }
            else
            {
                mouseDirection.Y = -1;
            }

            return mouseDirection;
        }


        private Point lastMousePosition;
        /// <summary>
        /// when mouse is moving over the cursor.
        /// </summary>
        private void OnBending_MouseWheel(object? sender, MouseEventArgs e)
        {
            BendingControl(e);
        }

        /// <summary>
        /// moves the control by the origin of the cursor
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        private void BendingControl(MouseEventArgs e)
        {
            if (this.isBending)
            {
                Point mouseDirection = GetMouseDirection(e);

                PointF decision = new PointF(this.perp.X * mouseDirection.X, this.perp.Y * mouseDirection.Y);

                Debug.WriteLine(e.Delta);

                if (e.Delta > 0)
                {
                    this.setCurveHeight = this.setCurveHeight + 0.001f;
                }
                else if (e.Delta < 0)
                {
                    this.setCurveHeight = this.setCurveHeight - 0.001f;
                }

                Point curvePeakPosition = BezierPoint(0.5f, this.startPoint, this.control1, this.control2, this.endPoint);
                Cursor.Position = this.PointToScreen(curvePeakPosition);
                OnBent?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// mouse cursor entering the control
        /// </summary>
        private void OnBending_MouseEnter(object? sender, EventArgs e)
        {
            if (UserInput.Instance!.GetInputKeyDataIsDown(Keys.ControlKey)) { this.Cursor = this.bendCursor; }
        }

        /// <summary>
        /// mouse down inside of the control.
        /// </summary>
        private void OnBending_MouseDown(object? sender, MouseEventArgs e)
        {
            if (this.Cursor == this.bendCursor)
            {
                this.lastMousePosition = e.Location;
                this.isBending = true;

                // sticks cursor onto position
                Point curvePeakPosition = BezierPoint(0.5f, this.startPoint, this.control1, this.control2, this.endPoint);
                Cursor.Position = this.PointToScreen(curvePeakPosition);
            }
        }

        /// <summary>
        /// mouse up inside of the control.
        /// </summary>
        private void OnBending_MouseUp(object? sender, MouseEventArgs e)
        {
            if (this.isBending)
            {
                if (!UserInput.Instance!.GetInputKeyDataIsDown(Keys.ControlKey)) { this.Cursor = this.clickCursor; }

                this.isBending = false;
            }
        }

        /// <summary>
        /// what happens when you press ctr over the control object
        /// </summary>
        /// <param name="sender"> UserInputInstance. </param>
        /// <param name="e"> arguments. </param>
        private void OnControlDown(object? sender, EventArgs e)
        {
            if (this.isClickable)
            {
                this.Cursor = this.bendCursor;
            }
        }

        /// <summary>
        /// what happens when you release ctr over the control object
        /// </summary>
        /// <param name="sender"> UserInputInstance. </param>
        /// <param name="e"> arguments. </param>
        private void OnControlUp(object? sender, EventArgs e)
        {
            if (this.isBending) { return; }

            this.Cursor = this.clickCursor;
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
        */

    }
}
