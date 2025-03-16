using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GTS_Controls
{
    public static class ControlsAlgo
    {

        /// <summary>
        /// finding a control relative to another one using location on the form.
        /// Note: (Location using form is actual relative to the desktop)
        /// </summary>
        /// <param name="control"> the control we want to know relative to the other control. </param>
        /// <param name="relativeControl"> the new top left origin from control. </param>
        /// <returns> point relative to new top left origin. </returns>
        public static Point GetRelativePosition(Control control, Control relativeControl)
        {
            int x = control.Location.X - relativeControl.Location.X;
            int y = control.Location.Y - relativeControl.Location.Y;

            return new Point(x, y);
        }

        /*
        public static void DeactivateControl(Control control)
        {
            control.Enter += Focus_DeactivateControl;
            control.MouseMove += Keep_Mouse_Default;
            control.MouseHover += Keep_Mouse_Default;
            control.MouseDown += Keep_Mouse_Default;

        }

        public static void Focus_DeactivateControl(object? sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        public static void Keep_Mouse_Default(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        */
    }
}
