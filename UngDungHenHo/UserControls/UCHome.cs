using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UngDungHenHo.UserControls
{
    public partial class UCHome : UserControl
    {
        private bool[] isDragging = new bool[10];
        private Point[] offset = new Point[10];
        public UCHome()
        {
            InitializeComponent();
            AddScrollBar();
            listnguoidung();

        }


       
        public void AddScrollBar()
        {
            VScrollBar vsb = new VScrollBar();
            vsb.Dock = DockStyle.Right;
            vsb.Visible = false;
            this.pnlListNguoiDungs.Controls.Add(vsb);
        }

        private void UCHome_Load(object sender, EventArgs e)
        {
           
        }

        private void ResetPanels()
        {
            pnlListNguoiDungs.Controls.Clear();
            for (int i = 0; i < 10; i++)
            {
                pnlListNguoiDungs.Controls.Add(panels[i]);
            }
                

        }


        int tongnguoidung = 10;
        Panel[] panels = new Panel[10];

        private void listnguoidung()
        {


            Random random = new Random();
            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            for (int i = 0; i < tongnguoidung; i++)
            {
                panels[i] = new Panel();
                if (i == 10)
                    panels[i].BackColor = Color.Red;
                else
                    panels[i].BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                panels[i].Width = pnlListNguoiDungs.Width-200;
                panels[i].Height = pnlListNguoiDungs.Height-200;
                panels[i].Tag = i;
                panels[i].MouseDown += new MouseEventHandler(this.PanelMouseDownHandler);
                panels[i].MouseMove += new MouseEventHandler(this.PanelMouseMoveHandler);
                panels[i].MouseUp += new MouseEventHandler(this.PanelMouseUpHandler);
                pnlListNguoiDungs.Controls.Add(panels[i]);
            }
        }
        private void PanelMouseDownHandler(object sender, MouseEventArgs e)
        {


            int tag = 0;
            if (sender is Panel)
            {
                tag = int.Parse((sender as Panel).Tag.ToString());
            }
            if (sender is Label)
            {
                tag = int.Parse((sender as Label).Tag.ToString());
            }


            if (e.Button == MouseButtons.Left)
            {
                isDragging[tag] = true;
                offset[tag] = e.Location;
            }
        }


        private void PanelMouseMoveHandler(object sender, MouseEventArgs e)
        {
            int tag = 0;

            if (sender is Panel)
            {
                tag = int.Parse((sender as Panel).Tag.ToString());
            }   

        if (isDragging[tag])
            {
                Point newLocation = pnlListNguoiDungs.PointToClient(this.PointToScreen(new Point(e.X - offset[tag].X, e.Y - offset[tag].Y)));

                if (panels[tag].Location != newLocation)
                {
                   zz
                    panels[tag].Location = newLocation;

                  
                }
            }
        }

        private void PanelMouseUpHandler(object sender, MouseEventArgs e)
        {
            int tag = 0;
            if (sender is Panel)
            {
                tag = int.Parse((sender as Panel).Tag.ToString());
            }
            if (sender is Label)
            {
                tag = int.Parse((sender as Label).Tag.ToString());
            }

            if (isDragging[tag])
            {
                isDragging[tag] = false;

                if (pnlListNguoiDungs.ClientRectangle.Contains(pnlListNguoiDungs.PointToClient(panels[tag].Location)))
                {
                   
                }
                else
                {

                    pnlListNguoiDungs.Controls.Remove(panels[tag]);

                }

            }
        }

        private void pnltong_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
