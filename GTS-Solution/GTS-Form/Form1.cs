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

            //CreateGraphMenu
            this.menuControl1.CreateGraphClicked += this.graphDisplay1.On_CreateGraph;
            
            // MenuControl
            this.graphDisplay1.ItemSelected += this.menuControl1.On_SelectSwitch;
            this.menuControl1.ResetGraph += this.graphDisplay1.On_ResetGraph;

            // TwoVertexSelectMenu
            this.menuControl1.AddEdge += this.graphDisplay1.On_AddEdge;

            // VertexSelectMenu
            this.menuControl1.AddLoop += this.graphDisplay1.On_AddLoop;
        }
    }
}
