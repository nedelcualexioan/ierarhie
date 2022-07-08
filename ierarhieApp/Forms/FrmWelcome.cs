using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ierarhieApp.Forms
{
    public partial class FrmWelcome : Form
    {
        private PictureBox pctLogo;
        private Button btnNew;
        private Button btnHistory;
        private Button btnLogout;

        private Label lblWelcome;
        private PictureBox pctLoading;

        private Timer timer;

        private Label lblEnter;
        private TextBox txtNodes;

        private PictureBox pctDone;

        public FrmWelcome()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(18, 34, 47);
            this.Size = new Size(571, 405);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            Initialize();

        }

        private void Initialize()
        {

            pctLogo = new PictureBox
            {
                Parent = this,
                Location = new Point(12, 12),
                ImageLocation = Application.StartupPath + @"\images\logo.png",
                Size = new Size(79, 79),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            btnNew = new Button
            {
                Parent = this,
                Location = new Point(12, 130),
                Size = new Size(79, 43),
                Image = Image.FromFile(Application.StartupPath + @"\images\plus.png"),
                ImageAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ForeColor = Color.FromArgb(69, 162, 224),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                FlatAppearance = { BorderSize = 0 },
                Text = " New"
            };

            btnHistory = new Button
            {
                Parent = this,
                Location = new Point(12, 179),
                Size = new Size(144, 43),
                Image = Image.FromFile(Application.StartupPath + @"\images\file.png"),
                ImageAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ForeColor = Color.FromArgb(69, 162, 224),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = btnNew.Font,
                Text = " My hierarchies"
            };

            btnLogout = new Button
            {
                Parent = this,
                Location = new Point(477, 5),
                Size = new Size(81, 43),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(69, 162, 224),
                Text = "Logout",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };

            lblWelcome = new Label
            {
                Parent = this,
                Location = new Point(0, 9),
                AutoSize = false,
                Size = new Size(this.Width, 28),
                Text = "WELCOME",
                Font = new Font("Segoe UI Semibold", 12F),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = btnHistory.ForeColor
            };
            lblWelcome.SendToBack();

            pctLoading = new PictureBox
            {
                Parent = this,
                ImageLocation = Application.StartupPath + @"\images\loading.gif",
                Location = new Point(162, 89),
                Size = new Size(396, 236),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            lblEnter = new Label
            {
                Parent = this,
                AutoSize = true,
                Location = new Point(194, 141),
                Font = new Font("Segoe UI Semilight", 12F),
                Text = "Enter the number of elements",
                ForeColor = lblWelcome.ForeColor
            };

            txtNodes = new TextBox
            {
                Parent = this,
                AutoSize = true,
                Location = new Point(200, 165),
                Font = new Font("Segoe UI Semilight", 9.75f),
                Size = new Size(196, 25),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = this.BackColor,
                TextAlign = HorizontalAlignment.Center,
                ForeColor = Color.White
            };

            timer = new Timer();

            pctDone = new PictureBox
            {
                Parent = this,
                ImageLocation = Application.StartupPath + @"\images\done.png",
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(63, 56),
                Location = new Point(265, 196),
                Cursor = Cursors.Hand
            };

            btnNew.Click += btnNew_Click;

            pctDone.Click += pctDone_Click;

            pctLoading.Hide();
            lblEnter.Hide();
            txtNodes.Hide();
            pctDone.Hide();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pctLoading.Show();

            timer.Interval = 3800;
            timer.Enabled = true;
            timer.Start();

            timer.Tick += timer_Tick;
        }

        private void FrmWelcome_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Enabled = false;

            pctLoading.Hide();

            lblEnter.Show();
            txtNodes.Show();
            pctDone.Show();
        }

        private void pctDone_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");

            if (regex.IsMatch(txtNodes.Text))
            {

                FrmWelcome_FormClosed();
            }
            else
            {
                MessageBox.Show("Numbers only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmWelcome_FormClosed()
        {

            FrmHome home = new FrmHome(int.Parse(txtNodes.Text));

            home.ShowDialog();

            this.Close();

           

            

            this.Hide();

            
            
        }
    }
}
