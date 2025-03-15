﻿using GTS_UserInput;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTS_Controls
{
    [ToolboxItem(true)]
    public partial class EdgeUserControl : ClickableUserControl
    {
        int edgeID;

        public event EventHandler? OnBent;

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

        public EdgeUserControl(int edgeID, bool isLoop) : base()
        {
            this.isLoop = isLoop;
            this.edgeID = edgeID;

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


        private float PointDistance(PointF pointStart, PointF pointEnd)
        {
            float newDisx = pointEnd.X - pointStart.X;
            float newDisy = pointEnd.Y - pointStart.Y;
            return MathF.Sqrt(newDisx * newDisx + newDisy * newDisy);
        }

        private PointF PointDirection(PointF pointStart, PointF pointEnd)
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
           
            if(this.startPoint != PointF.Empty && this.endPoint != PointF.Empty)
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

        private void SetRegion()
        {
            // no region set when line doesn't exist
            if (this.startPoint != this.endPoint)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddBezier(startPoint, this.Control1, this.Control2, endPoint);
                Pen pen = new Pen(Color.Transparent, this.lineWidth);
                path.Widen(pen);
                this.Region = new Region(path);
            }
        }

        private void LineUserControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            // graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen = new Pen(this.color, this.lineWidth);
            graphics.DrawBezier(pen, startPoint, this.Control1, this.Control2, endPoint);

            if (isHighlighted)
            {
                Pen penHighlight = new Pen(Color.White, this.lineWidth/2);
                graphics.DrawBezier(penHighlight, startPoint, this.Control1, this.Control2, endPoint);
            }
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

public static Point BezierPoint(float t, PointF startPoint, PointF control1, PointF control2, PointF endPoint)
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
