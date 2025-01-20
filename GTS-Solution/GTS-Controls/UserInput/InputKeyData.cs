using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS_UserInput
{
    public partial class UserInput
    {
        private class InputKeyData
        {
            public event EventHandler? OnKeyDown;
            public event EventHandler? OnKeyUp;

            private bool isDown = false;

            public bool IsDown
            {
                get => isDown; 
                set => isDown = value;
            }

            /// <summary>
            /// invokes the Key up for key
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void InvokeKeyUp(object? sender, EventArgs e)
            {
                this.OnKeyUp?.Invoke(sender, e);
            }

            /// <summary>
            /// invokes the Key down for key
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void InvokeKeyDown(object? sender, EventArgs e)
            {
                this.OnKeyDown?.Invoke(sender, e);
            }
        }
    }
}
