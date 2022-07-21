using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ierarhieApp.Panels;

namespace ierarhieApp.Forms
{
    public partial class FrmHome : Form
    {
        private Panel pnlSidebar;
        private Panel pnlHeader;
        private Panel pnlMain;

        public Size HeaderSize
        {
            get => pnlHeader.Size;
        }

        public Size SidebarSize
        {
            get => pnlSidebar.Size;
        }


        public FrmHome(int nodes)
        {
            InitializeComponent();

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.BackColor = Color.FromArgb(29, 52, 72);

            Initialize(nodes);

            this.Load += FrmHome_Load;
        }

        private void Initialize(int nodes)
        {

            pnlHeader = new Header(this);

            pnlSidebar = new Sidebar(this);

            pnlMain = new Home(this, nodes);


        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
