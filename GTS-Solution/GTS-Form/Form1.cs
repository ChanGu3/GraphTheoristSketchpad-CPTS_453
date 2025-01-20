using System.Diagnostics;
using GTS_UserInput;

namespace GTS_Form
{
    public partial class FormGTS : Form
    {
        private UserInput userInput;

        public FormGTS()
        {
            this.userInput = new UserInput(this);
            InitializeComponent();
            // this.userInput.OnSpaceDown += SomeListener;

        }

        void SomeListener(object? sender, EventArgs e)
        {
        }
    }
}
