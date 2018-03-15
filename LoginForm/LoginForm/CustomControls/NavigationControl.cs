using System.Windows.Forms;

namespace LoginForm.CustomControls
{
    public partial class NavigationControl : UserControl
    {
        public FormMain parent;
        public Button pressedButton;
        public System.Drawing.Color idleButtonColor;
        public System.Drawing.Color pressedButtonColor;

        public void ChangeToDefaultDesign()
        {
            if (pressedButton != null)
            {
                pressedButton.BackColor = idleButtonColor;
            }
        }
    }
}
