using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Windows.Forms;
using ierarhieApp.Forms;

namespace ierarhieApp.Panels
{
    public class Home : Panel
    {
        private UserPanel pnl;


        public Home(FrmHome par, int nodes)
        {
            this.Parent = par;
            this.Location = new Point(200, 100);

            this.AutoScroll = true;

            

            this.Size = new Size(par.Width - par.SidebarSize.Width, 1080 - par.HeaderSize.Height);


            populate(nodes);

            fix();
            
            events();
        }

        private void populate(int nodes)
        {

            int x = 0, y = 0;
            

            for (int i = 1; i <= nodes; i++)
            {

                for (int j = i; j <= nodes / 2 + 1; j++)
                {
                    //atasez gol

                    UserPanel pnl = new UserPanel(this);

                    pnl.Controls.Clear();

                    pnl.Location = new Point(x, y);
                    pnl.BorderStyle = BorderStyle.FixedSingle;

                    x += pnl.Size.Width;
                }

                for (int k = 1; k <= i * 2 -1; k++)
                {
                    //ataseaz persoana

                    UserPanel pnl = new UserPanel(this);

                    pnl.Location = new Point(x, y);

                    x += pnl.Size.Width;

                }
                for (int j = i; j <= nodes / 2 + 1; j++)
                {
                    //atasez gol

                    UserPanel pnl = new UserPanel(this);

                    pnl.Controls.Clear();

                    pnl.Location = new Point(x, y);
                    pnl.BorderStyle = BorderStyle.FixedSingle;

                    x += pnl.Size.Width;

                }
                //tresc la randul umrator

                y += 125;
                x = 0;
            }
            
        }

        private void fix()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is UserPanel p && p.BorderStyle == BorderStyle.None)
                {

                    if (i + 1 > Controls.Count - 1)
                        return;

                    UserPanel pan = this.Controls[i + 1] as UserPanel;

                    pan.Controls.Clear();
                    pan.BorderStyle = BorderStyle.FixedSingle;

                    i++;
                }
            }
        }

        private void events()
        {
            foreach (Control c in this.Controls)
            {

                if (c is UserPanel p && p.BorderStyle == BorderStyle.None)
                {
                    p.PctUser.AllowDrop = true;

                    p.PctUser.DragEnter += pnl_DragEnter;
                    p.PctUser.DragDrop += pnl_DragDrop;
                }

            }
        }

        private void pnl_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void pnl_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pct = sender as PictureBox;


            pct.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
        }

    }
}