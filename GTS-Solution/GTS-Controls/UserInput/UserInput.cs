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

        public static UserInput Instance
        {
            get
            {
               if (instance is not null)
               {
                    return instance;
               }
               
               throw new Exception("user input has not been created");
            }
        }

        private void InitializeInputKeyMapping()
        {
            // Left Ctrl
            this.inputKeyMapping.Add(Keys.ControlKey, new InputKeyData());

            // Space
            this.inputKeyMapping.Add(Keys.Space, new InputKeyData());
        }

        private void AddFormListeners(Form form)
        {
            form.KeyPreview = true;
            form.KeyUp += KeyUp;
            form.KeyDown += KeyDown;
        }

        public void AddKeyDownListener(Keys keyCode, EventHandler listener)
        {
            if (!this.inputKeyMapping.ContainsKey(keyCode)) { return; }

            inputKeyMapping[keyCode].OnKeyDown += listener;
        }

        public void AddKeyUpListener(Keys keyCode, EventHandler listener)
        {
            if (!this.inputKeyMapping.ContainsKey(keyCode)) { return; }

            inputKeyMapping[keyCode].OnKeyDown += listener;
        }

        public void RemoveKeyDownListener(Keys keyCode, EventHandler listener)
        {
            if (!this.inputKeyMapping.ContainsKey(keyCode)) { return; }

            inputKeyMapping[keyCode].OnKeyDown -= listener;
        }

        public void RemoveKeyUpListener(Keys keyCode, EventHandler listener)
        {
            if (!this.inputKeyMapping.ContainsKey(keyCode)) { return; }

            inputKeyMapping[keyCode].OnKeyDown -= listener;
        }


        private void KeyUp(object? sender, KeyEventArgs e)
        {
            if (!this.inputKeyMapping.ContainsKey(e.KeyCode)) { return; }

            if (this.inputKeyMapping[e.KeyCode].IsDown)
            {
                this.inputKeyMapping[e.KeyCode].InvokeKeyUp(this, new EventArgs());
                this.inputKeyMapping[e.KeyCode].IsDown = false;
            }
        }

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
