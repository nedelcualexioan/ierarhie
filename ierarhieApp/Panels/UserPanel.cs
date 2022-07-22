using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace ierarhieApp.Panels
{
    public class UserPanel : Panel
    {
        private PictureBox pctUser;
        private TextBox txtUser;

        private UserPanel left;
        private UserPanel right;

        public PictureBox PctUser
        {
            get => pctUser;
        }

        public UserPanel Left
        {
            get => left;
            set => left = value;
        }

        public UserPanel Right
        {
            get => right;
            set => right = value;
        }

        public UserPanel(Control parent)
        {
            
            this.Size = new Size(136, 112);
            this.Parent = parent;

            pctUser = new PictureBox
            {
                Parent = this,
                ImageLocation = Application.StartupPath + @"\images\user.png",
                Size = new Size(84, 75),
                SizeMode = PictureBoxSizeMode.Zoom,
                Top = 3
            };
            pctUser.Left = (pctUser.Parent.Width - pctUser.Width) / 2;

            txtUser = new TextBox
            {
                Parent = this,
                Top = 82,
                Size = new Size(118, 23),
                Font = new Font("Segoe UI", 9F),
                TextAlign = HorizontalAlignment.Center
            };
            txtUser.Left = (txtUser.Parent.Width - txtUser.Width) / 2;
        }
        
    }
}