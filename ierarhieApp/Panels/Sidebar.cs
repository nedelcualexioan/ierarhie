using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ierarhieApp.Panels
{
    public class Sidebar : Panel
    {
        private PictureBox pctLogo;
        private Label lblInfo;

        private PictureBox pctAdd;

        private int y = 247;

        public Sidebar(Control par)
        {
            this.Parent = par;

            Dock = DockStyle.Left;
            Width = 200;
            BackColor = Color.FromArgb(15, 30, 39);
            BorderStyle = BorderStyle.FixedSingle;
            AutoScroll = true;

            Initialize();
        }

        private void Initialize()
        {
            pctLogo = new PictureBox
            {
                Parent = this,
                Size = new Size(79, 79),
                ImageLocation = Application.StartupPath + @"\images\logo.png",
                Top = 3,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            pctLogo.Left = (pctLogo.Parent.Width - pctLogo.Width) / 2;

            lblInfo = new Label
            {
                Parent = this,
                AutoSize = false,
                Size = new Size(this.Width, 21),
                Font = new Font("Segoe UI Semibold", 12F),
                ForeColor = Color.FromArgb(49, 119, 160),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Choose listed images",
                Location = new Point(0, 106)
            };

            pctAdd = new PictureBox
            {
                Parent = this,
                Size = new Size(156, 140),
                ImageLocation = Application.StartupPath + @"\images\add.png",
                Top = 101,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand
            };
            pctAdd.Left = (pctAdd.Parent.Width - pctAdd.Width) / 2;
            pctAdd.SendToBack();

            pctAdd.Click += new EventHandler(pctAdd_Click);
        }

        private void pctAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                PictureBox pct = new PictureBox
                {
                    Parent = this,
                    Size = new Size(115, 115),
                    ImageLocation = dialog.FileName,
                    Top = y,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                pct.AllowDrop = true;

                pct.Left = (pct.Parent.Width - pct.Width) / 2;

                pct.DragDrop += pct_DragDrop;
                pct.DragEnter += pct_DragEnter;
                pct.MouseDown += pct_MouseDown;

                y += 120;
            }
        }

        private void pct_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pct = sender as PictureBox;

            var data = e.Data.GetData(DataFormats.FileDrop);

            if (data != null)
            {
                var fileNames = data as string[];

                if (fileNames.Length > 0)
                {
                    pct.Image = Image.FromFile(fileNames[0]);
                }
            }
        }

        private void pct_MouseDown(object sender, MouseEventArgs e)
        {

            PictureBox pc = sender as PictureBox;

            if (e.Button == MouseButtons.Left)
            {
                pc.DoDragDrop(pc.Image, DragDropEffects.Copy); 
            }
        }

        private void pct_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void events()
        {
            foreach (Control c in this.Controls)
            {

                if (c is UserPanel p && p.BorderStyle == BorderStyle.None)
                {
                    c.AllowDrop = true;

                    c.DragEnter += pnl_DragEnter;
                    c.DragDrop += pnl_DragDrop;
                }

            }
        }

        private void pnl_DragEnter(object sender, DragEventArgs e)
        {

            if(e.Data.GetData(DataFormats.Bitmap) && (e.AllowedEffect.d))

        }

        private void pnl_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pct = sender as PictureBox;


            pct.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
        }
    }
}