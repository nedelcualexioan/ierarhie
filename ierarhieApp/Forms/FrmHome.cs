using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ierarhieApp.Forms
{
    public partial class FrmHome : Form
    {
        private Panel pnlSidebar;
        private Panel pnlHeader;

        private PictureBox pctLogo;
        private Label lblInfo;
        private TextBox txtName;

        public FrmHome(int nodes)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.BackColor = Color.FromArgb(29, 52, 72);

            Initialize();

            this.Load += FrmHome_Load;
        }

        private void Initialize()
        {

            pnlHeader = new Panel
            {
                Parent = this,
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(15, 30, 39),
                BorderStyle = BorderStyle.FixedSingle
            };

            pnlSidebar = new Panel
            {
                Parent = this,
                Dock = DockStyle.Left,
                Width = 200,
                BackColor = Color.FromArgb(15, 30, 39),
                BorderStyle = BorderStyle.FixedSingle
            };

            pctLogo = new PictureBox
            {
                Parent = pnlSidebar,
                Size = new Size(79, 79),
                ImageLocation = Application.StartupPath + @"\images\logo.png",
                Top = 3,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            pctLogo.Left = (pctLogo.Parent.Width - pctLogo.Width) / 2;

            lblInfo = new Label
            {
                Parent = pnlSidebar,
                AutoSize = false,
                Size = new Size(pnlSidebar.Width, 21),
                Font = new Font("Segoe UI Semibold", 12F),
                ForeColor = Color.FromArgb(49, 119, 160),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Choose listed images",
                Location = new Point(0, 106)
            };

            txtName = new TextBox
            {
                Parent = pnlHeader,
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

        private void FrmHome_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
