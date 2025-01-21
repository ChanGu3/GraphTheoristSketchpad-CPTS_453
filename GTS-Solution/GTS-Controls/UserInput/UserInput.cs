using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace GTS_UserInput
{
    public partial class UserInput
    {
        private static UserInput? instance = null;

        private Dictionary<Keys, InputKeyData>  inputKeyMapping = new Dictionary<Keys, InputKeyData>();

        /// <summary>
        /// creates a Singleton for the userinput
        /// (May Change this later to allow multiple UserInput instances per Form instance for now only need just the one.)
        /// </summary>
        /// <param name="form"> the form being used with the form. </param>
        /// <exception cref="Exception"> when more the one UserInput is created. </exception>
        public UserInput(Form form)
        {
            if (instance == null)
            {
                instance = this;
                AddFormListeners(form);
                InitializeInputKeyMapping();
                return;
            }

            throw new Exception("a UserInput Instance already exists (Singleton)");
        }

        /// <summary>
        /// Gets the instance of the singleton userinput
        /// </summary>
        /// <exception cref="Exception"> when no UserInput is created. </exception>
        public static UserInput? Instance
        {
            get
            {
               if (instance is not null)
               {
                    return instance;
               }
               
               return null;
            }
        }

        /// <summary>
        /// Keycodes supported need to be added here.
        /// </summary>
        private void InitializeInputKeyMapping()
        {
            // Left Ctrl
            this.inputKeyMapping.Add(Keys.ControlKey, new InputKeyData());

            // Space
            this.inputKeyMapping.Add(Keys.Space, new InputKeyData());
        }

        /// <summary>
        /// adding the listeners to all the key presses detection from the form.
        /// </summary>
        /// <param name="form"> form to subscribe to. </param>
        private void AddFormListeners(Form form)
        {
            form.KeyPreview = true;
            form.KeyUp += KeyUp;
            form.KeyDown += KeyDown;
        }

        /// <summary>
        /// adds a listener to a specific keycodes key down event.
        /// </summary>
        /// <param name="keyCode"> the keycode to add and event to. </param>
        /// <param name="listener"> listener to add to event. </param>
        public void AddKeyDownListener(Keys keyCode, EventHandler listener)
        {
            if (!this.inputKeyMapping.ContainsKey(keyCode)) { Debug.WriteLine("KeyCode Not Supported"); return; }

            inputKeyMapping[keyCode].OnKeyDown += listener;
        }

        /// <summary>
        /// adds a listener to a specific keycodes key up event.
        /// </summary>
        /// <param name="keyCode"> the keycode to add and event to. </param>
        /// <param name="listener"> listener to add to event. </param>
        public void AddKeyUpListener(Keys keyCode, EventHandler listener)
        {
            if (!this.inputKeyMapping.ContainsKey(keyCode)) { Debug.WriteLine("KeyCode Not Supported"); return; }

            inputKeyMapping[keyCode].OnKeyUp += listener;
        }

        /// <summary>
        /// removes a listener to a specific keycodes key up event.
        /// </summary>
        /// <param name="keyCode"> the keycode to add and event to. </param>
        /// <param name="listener"> listener to add to event. </param>
        public void RemoveKeyDownListener(Keys keyCode, EventHandler listener)
        {
            if (!this.inputKeyMapping.ContainsKey(keyCode)) { Debug.WriteLine("KeyCode Not Supported"); return; }

            inputKeyMapping[keyCode].OnKeyDown -= listener;
        }

        /// <summary>
        /// removes a listener to a specific keycodes key up event.
        /// </summary>
        /// <param name="keyCode"> the keycode to add and event to. </param>
        /// <param name="listener"> listener to add to event. </param>
        public void RemoveKeyUpListener(Keys keyCode, EventHandler listener)
        {
            if (!this.inputKeyMapping.ContainsKey(keyCode)) { Debug.WriteLine("KeyCode Not Supported"); return; }

            inputKeyMapping[keyCode].OnKeyUp -= listener;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keycode"> key code checking for if it is down. </param>
        /// <returns> true when key is down otherwise false. Note: false if keycode not supported. </returns>
        public bool GetInputKeyDataIsDown(Keys keyCode)
        {
            if (!this.inputKeyMapping.ContainsKey(keyCode)) { Debug.WriteLine("KeyCode Not Supported"); return false; }

            return this.inputKeyMapping[keyCode].IsDown;
        }

        /// <summary>
        /// everytime any key is unpressed up it checks if it is part of the supported keys and if not
        ///     it then just returns doing nothing. Otherwise it sends events and sets the IsDown
        ///     bool to false to a specific InputKeyData that is mapped to that keycode.
        /// </summary>
        /// <param name="sender"> object invoking the event. </param>
        /// <param name="e"> key event argument. </param>
        private void KeyUp(object? sender, KeyEventArgs e)
        {
            if (!this.inputKeyMapping.ContainsKey(e.KeyCode)) { return; }

            if (this.inputKeyMapping[e.KeyCode].IsDown)
            {
                this.inputKeyMapping[e.KeyCode].InvokeKeyUp(this, new EventArgs());
                this.inputKeyMapping[e.KeyCode].IsDown = false;
            }
        }

        /// <summary>
        /// everytime any key is pressed down it checks if it is part of the supported keys and if not
        ///     it then just returns doing nothing. Otherwise it sends events and sets the IsDown
        ///     bool to true to a specific InputKeyData that is mapped to that keycode.
        /// </summary>
        /// <param name="sender"> object invoking the event. </param>
        /// <param name="e"> key event argument. </param>
        private void KeyDown(object? sender, KeyEventArgs e)
        {
            if (!this.inputKeyMapping.ContainsKey(e.KeyCode)) { return; }

            if (!this.inputKeyMapping[e.KeyCode].IsDown)
            {
                this.inputKeyMapping[e.KeyCode].InvokeKeyDown(this, new EventArgs());
                this.inputKeyMapping[e.KeyCode].IsDown = true;
            }
        }
    }
}
