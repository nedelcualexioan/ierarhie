using System.Drawing;
using System.Windows.Forms;

namespace ierarhieApp.Panels
{
    public class Header : Panel
    {
        private TextBox txtName;

        public Header(Control par)
        {
            Parent = par;
            Dock = DockStyle.Top;
            Height = 100;
            BackColor = Color.FromArgb(15, 30, 39);
            BorderStyle = BorderStyle.FixedSingle;

            txtName = new TextBox
            {
                Parent = this,
                Font = new Font("Segoe UI", 18F),
                Text = "HIERARCHY NAME",
                Width = 233,
                TextAlign = HorizontalAlignment.Center,
                SelectionStart = 0,
                SelectionLength = 0
            };
            txtName.Left = 743;
            txtName.Top = (txtName.Parent.Height - txtName.Height) / 2;
        }
    }
}