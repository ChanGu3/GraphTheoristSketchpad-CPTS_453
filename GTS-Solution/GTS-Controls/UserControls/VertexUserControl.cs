using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace GTS_Controls
{
    [ToolboxItem(true)]
    public partial class VertexUserControl : DraggableUserControl
    {
        // create a static mutex to allow only one click at a time
        int vertexID;

        // public event EventHandler? OnNodeClicked;

        private int circleRadius = 15;
        private int controlSize = 0;
        private Color circleColor = Color.Gray;
        private bool isHighlighted = false;
        private Control? labelForForms;

        // currentlabel
        private Control? nameLabel;
        private Font nameFont = new Font("Arial Black", 20f, FontStyle.Regular, GraphicsUnit.Pixel);
        bool isShowingName = false;

        public VertexUserControl(int vertexID, Control parent) : base()
        {
            this.Name = $"V{vertexID}";
            this.Parent = parent;
            this.Parent.Controls.Add(this);
            this.BringToFront();

            this.vertexID = vertexID;
            InitializeComponent();
            this.SetUpControls();


            controlSize = this.Diameter * 2;
            this.Size = new Size(controlSize, controlSize);

            this.ResetRegion();
        }

        public GraphicsPath NameFontPath
        {
            get
            {
                GraphicsPath nameLabelPath = new();
                Font font = this.nameFont;
                nameLabelPath.AddString(this.Name, font.FontFamily, (int)font.Style, font.Size, new Point(0, 0), StringFormat.GenericDefault);

                return nameLabelPath;
            }
        }

        public bool IsShowingName
        {
            get => isShowingName;
        }

        public bool IsHighlighted
        {
            get => isHighlighted;
            set => isHighlighted = value;
        }

        /*
        public Control Label
        {
            get => label;
            set => label = value;
        }
        */

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
            get => new Point(this.Location.X + (this.Size.Width / 2), this.Location.Y + (this.Size.Height / 2));
        }

        #endregion

        private void SetUpControls()
        {

            /// NameLabel
            ///
            this.nameLabel = new DoubleBufferedPanel();

            //this.nameLabel.Text = this.Name;
            this.nameLabel.ForeColor = Color.White;

            // Apply the text path as the region
            // nameLabelPath.Widen(new Pen(Color.White, 1));
            this.nameLabel.Region = new Region(this.NameFontPath);

            this.nameLabel.Parent = this.Parent;
            this.nameLabel.Name = $"labelName";
            this.nameLabel.Paint +=
                (sender, e) =>
                {
                    e.Graphics.FillPath(new SolidBrush(Color.White), this.NameFontPath);
                };


            this.Parent?.Controls.Add(this.nameLabel);
            this.nameLabel.Size = this.Parent!.Size;

            this.nameLabel.BringToFront();

            // END
        }

        private void ResetRegion()
        {
            GraphicsPath path = new();
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
                graphics.FillEllipse(brushHighlight, new RectangleF(coordinateDistance * 1.5f, coordinateDistance * 1.5f, this.Diameter / 2, this.Diameter / 2));
            }

            if (isShowingName)
            {
                this.nameLabel!.Location = new Point(this.CenterOrigin.X - (int)(this.circleRadius * 2.5f), this.CenterOrigin.Y - (int)(this.circleRadius * 2.5f));
            }
        }

        public void AddLabel(string label)
        {
            this.labelForForms = new Label();
            this.labelForForms.Text = label;
            this.labelForForms.Font = new Font(this.labelForForms.Font.FontFamily, this.labelForForms.Font.Size + 8f, this.labelForForms.Font.Style);
            this.labelForForms.ForeColor = Color.White;

            this.labelForForms.Parent = this.Parent;
            this.labelForForms.Location = new Point(this.CenterOrigin.X - (int)(this.circleRadius * 2.5f), this.CenterOrigin.Y - (int)(this.circleRadius * 2.5f));
            this.labelForForms.Name = $"label{label}";

            this.Parent?.Controls.Add(this.labelForForms);

            //region creation
            GraphicsPath path = new GraphicsPath();
            Font font = (this.labelForForms as Label)!.Font;
            path.AddString(label, font.FontFamily, (int)font.Style, font.Size, new Point(0, 0), StringFormat.GenericDefault);

            //path.Widen(new Pen(Color.Black, 1f));

            // Apply the text path as the region
            this.labelForForms.Region = new Region(path);
            this.labelForForms.Paint +=
            (sender, e) =>
            {
                e.Graphics.FillPath(new SolidBrush(Color.White), path);
            };

            this.labelForForms.BringToFront();
        }

        public void RemoveLabel()
        {
            this.Parent?.Controls.Remove(this.labelForForms);
            this.labelForForms?.Dispose();
        }

        public void RemoveFromGraph()
        {
            this.Parent?.Controls.Remove(this.nameLabel);
            this.nameLabel?.Dispose();

            this.Parent?.Controls.Remove(this);
            this.Dispose(true);
        }

        public void ResetNameLabelRegion()
        {
            // Apply the text path as the region
            this.nameLabel!.Region = new Region(this.NameFontPath);
        }

        public void ShowNameLabel()
        {
            this.isShowingName = true;
            this.nameLabel!.Show();
        }

        public void HideNameLabel()
        {
            this.isShowingName = false;
            this.nameLabel!.Hide();
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
