using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using UngDungHenHo.BS_layer;
using UngDungHenHo.models;
using UngDungHenHo.Custom_Control;
using UngDungHenHo.Forms;

namespace UngDungHenHo.UserControls
{
    public partial class UCHome : UserControl
    {
        int panelSize = 700;
        Panel[] panels;
        Label[] lbHoTens;
        Label[] lbBaoCaos;
        PictureBox[] pcboxthichs;
        PictureBox[] pcboxkhongthichs;

        private bool isDragging = new bool();
        private Point offset = new Point();
        Point pointtemp;
        BLHome dbHome = null;
        DataTable dtND = null;
        public UCHome()
        {
            InitializeComponent();

            pnlListNguoiDungs.BackColor = Color.WhiteSmoke;


            listnguoidung();


        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparams = base.CreateParams;
                handleparams.ExStyle |= 0x02000000;
                return handleparams;
            }
        }



        public void AddScrollBar(Panel panel)
        {
            VScrollBar vsb = new VScrollBar();
            vsb.Dock = DockStyle.Right;
            vsb.Visible = false;
            panel.Controls.Add(vsb);
        }

        private void UCHome_Load(object sender, EventArgs e)
        {

        }
        private void listnguoidung()
        {

            dbHome = new BLHome();
            dtND = dbHome.LayDanhSachNguoiDung();
            int tongnguoidung = dtND.Rows.Count;
            panels = new Panel[tongnguoidung];
            lbHoTens = new Label[tongnguoidung];
            lbBaoCaos = new Label[tongnguoidung];
            pcboxthichs = new PictureBox[tongnguoidung];
            pcboxkhongthichs = new PictureBox[tongnguoidung];
            Label[] lbSoThich = new Label[tongnguoidung];
            DataTable dtSoThich = new DataTable();

            for (int i = 0; i < tongnguoidung; i++)
            {
                panels[i] = new Panel();
                panels[i].AutoScroll = true;
                AddScrollBar(panels[i]);
          

                panels[i].Size = new Size(panelSize, panelSize);
                panels[i].Location = new Point((pnlListNguoiDungs.Size.Width - panelSize) / 2, 0);
                string stsothich = "Sở Thích: \n \n";

                dtSoThich = dbHome.LayDanhSoThichNguoiDung(Convert.ToInt32(dtND.Rows[i][0]));
                if (dtSoThich.Rows.Count > 0)
                {
                    stsothich = stsothich + dtSoThich.Rows[0][0].ToString();
                }

                for (int j = 1; j < dtSoThich.Rows.Count; j++)
                {
                    stsothich = stsothich + " " + dtSoThich.Rows[j][0].ToString();
                }



                lbSoThich[i] = new Label();
                lbSoThich[i].Text = stsothich;
                themsukien(lbSoThich[i], i);
                panels[i].Controls.Add(lbSoThich[i]);

                themsukien(panels[i], i);
                listbaiviet(panels[i], Convert.ToInt32(dtND.Rows[i][0]), i, lbSoThich[i]);



                if (i == 0 || i == 1)
                {
                    taohoten(panels[i], dtND.Rows[i][1].ToString(), i);
                    taothichvakhongthich(panels[i], i);
                    pnlListNguoiDungs.Controls.Add(panels[i]);
                }
            }
            pointtemp.X = panels[0].Location.X;
            pointtemp.Y = panels[0].Location.Y;
        }


        private void listbaiviet(Panel pnlNguoiDung, int idNguoiDung, int tagnguoidung, Label lbSoThich)
        {
            DataTable dtBaiVietNguoiDung = dbHome.LayDanhSachBaiVietNguoiDung(idNguoiDung);




            int tongbaiviet = dtBaiVietNguoiDung.Rows.Count;
            Panel[] pnlbaiviet = new Panel[tongbaiviet];
            Label[] lbNoiDung = new Label[tongbaiviet];



            for (int i = 0; i < tongbaiviet; i++)
            {

                pnlbaiviet[i] = new Panel();
                pnlbaiviet[i].Size = pnlNguoiDung.Size;
                pnlbaiviet[i].BackColor = Color.Yellow;

                PictureBox picPhim = new PictureBox();
                object rawValue = dtBaiVietNguoiDung.Rows[i][2];
                if (rawValue != DBNull.Value)
                {
                    byte[] HinhAnh = (byte[])rawValue;
                    using (MemoryStream ms = new MemoryStream(HinhAnh))
                    {
                        Image hinhAnh = Image.FromStream(ms);
                        picPhim.Image = hinhAnh;
                    }

                }
                else
                {
                    picPhim.Image = UngDungHenHo.Properties.Resources.anhnguoidungkhongco;


                }
                picPhim.SizeMode = PictureBoxSizeMode.StretchImage;
                picPhim.Size = pnlbaiviet[i].Size;
                pnlbaiviet[i].Controls.Add(picPhim);


                lbNoiDung[i] = new Label();
                lbNoiDung[i].Width = pnlbaiviet[i].Width;
                lbNoiDung[i].Height = pnlbaiviet[i].Height / 10;
                lbNoiDung[i].Text = "Mô tả bản thân: \n \n" + dtBaiVietNguoiDung.Rows[i][1].ToString();
                themsukien(lbNoiDung[i], i);

                pnlNguoiDung.Controls.Add(lbNoiDung[i]);




                if (i == 0)
                {
                    pnlbaiviet[i].Location = new Point(0, 0);

                    lbSoThich.Width = pnlbaiviet[i].Width;
                    lbSoThich.Height = pnlbaiviet[i].Height / 10;
                    lbSoThich.Location = new Point(pnlbaiviet[i].Left, pnlbaiviet[i].Bottom + 10);
                    lbNoiDung[i].Location = new Point(pnlbaiviet[i].Left, lbSoThich.Bottom + 10);

                }
                else
                {
                    pnlbaiviet[i].Location = new Point(pnlbaiviet[i - 1].Left, lbNoiDung[i - 1].Bottom + 50);
                    lbNoiDung[i].Location = new Point(pnlbaiviet[i].Left, pnlbaiviet[i].Bottom + 10);
                }


                themsukien(picPhim, tagnguoidung);
                themsukien(pnlbaiviet[i], tagnguoidung);

                pnlNguoiDung.Controls.Add(pnlbaiviet[i]);

            }

        }


        private void PanelMouseDownHandler(object sender, MouseEventArgs e)
        {
            int tag = int.Parse((sender as Control).Tag.ToString());
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offset = e.Location;

            }
        }


        private void PanelMouseMoveHandler(object sender, MouseEventArgs e)
        {
            int tag = int.Parse((sender as Control).Tag.ToString());

            if (isDragging)
            {

                Point newLocation = new Point(panels[tag].Left + e.X - offset.X, panels[tag].Top + e.Y - offset.Y);
                if (panels[tag].Location != newLocation)
                {

                    panels[tag].Location = newLocation;
                    lbHoTens[tag].Location = new Point(panels[tag].Left, panels[tag].Top);
                    lbBaoCaos[tag].Location = new Point(panels[tag].Right - lbBaoCaos[tag].Width, panels[tag].Top);
                    pcboxthichs[tag].Location = new Point(TamPanel(panels[tag]).X + 50, TamPanel(panels[tag]).Y + 100);
                    pcboxkhongthichs[tag].Location = new Point(TamPanel(panels[tag]).X - 50, TamPanel(panels[tag]).Y + 100);


                }
            }

        }

        private void PanelMouseUpHandler(object sender, MouseEventArgs e)
        {
            int tag = int.Parse((sender as Control).Tag.ToString());


            if (isDragging)
            {
                int X = panels[tag].Location.X + panels[tag].Width / 2;
                int Y = panels[tag].Location.Y + panels[tag].Height / 2;


                Point mousePosition = new Point(X, Y);


                if (mousePosition.X >= 0 && mousePosition.X <= panels[tag].Width &&
  mousePosition.Y >= 0 && mousePosition.Y <= panels[tag].Height)
                {
                    panels[tag].Location = new Point(pointtemp.X, pointtemp.Y);
                    lbHoTens[tag].Location = new Point(panels[tag].Left, panels[tag].Top);
                    lbBaoCaos[tag].Location = new Point(panels[tag].Right - lbBaoCaos[tag].Width, panels[tag].Top);
                    pcboxthichs[tag].Location = new Point(TamPanel(panels[tag]).X + 50, TamPanel(panels[tag]).Y + 100);
                    pcboxkhongthichs[tag].Location = new Point(TamPanel(panels[tag]).X - 50, TamPanel(panels[tag]).Y + 100);
                }
                else
                {
                    pnlListNguoiDungs.Controls.Remove(panels[tag]);
                    pnlListNguoiDungs.Controls.Remove(lbHoTens[tag]);
                    pnlListNguoiDungs.Controls.Remove(lbBaoCaos[tag]);
                    pnlListNguoiDungs.Controls.Remove(pcboxthichs[tag]);
                    pnlListNguoiDungs.Controls.Remove(pcboxkhongthichs[tag]);

                    if (dtND.Rows.Count > tag + 2)
                    {
                        taohoten(panels[tag + 2], dtND.Rows[tag + 2][1].ToString(), tag + 2);
                        taothichvakhongthich(panels[tag + 2], tag + 2);
                        pnlListNguoiDungs.Controls.Add(panels[tag + 2]);
                        taothichvakhongthich(panels[tag + 2], tag + 2);

                    }
                }



                isDragging = false;

            }
        }
        private void themsukien(Control control, int i)
        {
            control.Tag = i;
            control.MouseDown += new MouseEventHandler(this.PanelMouseDownHandler);
            control.MouseMove += new MouseEventHandler(this.PanelMouseMoveHandler);
            control.MouseUp += new MouseEventHandler(this.PanelMouseUpHandler);
        }





        private void taohoten(Panel pnlNguoiDung, string HoTen, int i)
        {

            lbHoTens[i] = new Label();
            lbHoTens[i].Text = "tui tên " + HoTen;
            lbHoTens[i].Location = new Point(pnlNguoiDung.Left, pnlNguoiDung.Top);
            themsukien(lbHoTens[i], i);
            pnlListNguoiDungs.Controls.Add(lbHoTens[i]);



            lbBaoCaos[i] = new Label();
            lbBaoCaos[i].Text = "Report";
            lbBaoCaos[i].Tag = i;
            lbBaoCaos[i].Location = new Point(pnlNguoiDung.Right - lbBaoCaos[i].Width, pnlNguoiDung.Top);
            lbBaoCaos[i].Click += new EventHandler(this.LabelThichClickHandler);
            pnlListNguoiDungs.Controls.Add(lbBaoCaos[i]);

        }

        private void LabelThichClickHandler(object sender, EventArgs e)
        {
            int tag = int.Parse((sender as Label).Tag.ToString());
            FormBaoCaoNguoiDung newBaoCaoNguoiDung = new FormBaoCaoNguoiDung(1, Convert.ToInt32(dtND.Rows[tag][0]), dtND.Rows[tag][1].ToString());
            newBaoCaoNguoiDung.ShowDialog();
        }

        private void taothichvakhongthich(Panel pnlNguoiDung, int i)
        {
            pcboxthichs[i] = vehinhtronpicturebox(50, new Point(TamPanel(panels[i]).X + 50, TamPanel(panels[i]).Y + 100), UngDungHenHo.Properties.Resources.Eo_circle_teal_heart_svg);
            pcboxkhongthichs[i] = vehinhtronpicturebox(50, new Point(TamPanel(panels[i]).X - 50, TamPanel(panels[i]).Y + 100), UngDungHenHo.Properties.Resources.icon_khongthich);
            pcboxthichs[i].Tag = i;
            pcboxkhongthichs[i].Tag = i;
            pcboxthichs[i].Click += new EventHandler(this.PictureBoxThichClickHandler);
            pcboxkhongthichs[i].Click += new EventHandler(this.PictureBoxKhongThichClickHandler);
            pnlListNguoiDungs.Controls.Add(pcboxthichs[i]);
            pnlListNguoiDungs.Controls.Add(pcboxkhongthichs[i]);
        }

        private PictureBox_Custom vehinhtronpicturebox(int size, Point location, Image hinhanh)
        {

            PictureBox_Custom pcboxhinhtron = new PictureBox_Custom();
            pcboxhinhtron.Size = new Size(size, size);
            pcboxhinhtron.Location = location;
            pcboxhinhtron.BackColor = Color.Transparent;
            pcboxhinhtron.BackgroundImage = hinhanh;
            pcboxhinhtron.BorderRadius = size;
            pcboxhinhtron.BorderStyle = BorderStyle.None;
            pcboxhinhtron.BackgroundImageLayout = ImageLayout.Zoom;


            return pcboxhinhtron;
        }

        private void PictureBoxThichClickHandler(object sender, EventArgs e)
        {
            int tag = -1;
            tag = int.Parse((sender as Control).Tag.ToString());

            if (tag != -1)
            {
                dbHome.ThemNguoiDungThich(1, Convert.ToInt32(dtND.Rows[tag][0]));

                pnlListNguoiDungs.Controls.Remove(panels[tag]);
                pnlListNguoiDungs.Controls.Remove(lbHoTens[tag]);
                pnlListNguoiDungs.Controls.Remove(lbBaoCaos[tag]);
                pnlListNguoiDungs.Controls.Remove(pcboxthichs[tag]);
                pnlListNguoiDungs.Controls.Remove(pcboxkhongthichs[tag]);

                if (dtND.Rows.Count > tag + 2)
                {
                    taohoten(panels[tag + 2], dtND.Rows[tag + 2][1].ToString(), tag + 2);
                    taothichvakhongthich(panels[tag + 2], tag + 2);
                    pnlListNguoiDungs.Controls.Add(panels[tag + 2]);

                }
            }
        }
        private void PictureBoxKhongThichClickHandler(object sender, EventArgs e)
        {

            int tag = -1;
            tag = int.Parse((sender as Control).Tag.ToString());
            if (tag != -1)
            {
                pnlListNguoiDungs.Controls.Remove(panels[tag]);
                pnlListNguoiDungs.Controls.Remove(lbHoTens[tag]);
                pnlListNguoiDungs.Controls.Remove(lbBaoCaos[tag]);
                pnlListNguoiDungs.Controls.Remove(pcboxthichs[tag]);
                pnlListNguoiDungs.Controls.Remove(pcboxkhongthichs[tag]);

                if (dtND.Rows.Count > tag + 2)
                {
                    taohoten(panels[tag + 2], dtND.Rows[tag + 2][1].ToString(), tag + 2);
                    taothichvakhongthich(panels[tag + 2], tag + 2);
                    pnlListNguoiDungs.Controls.Add(panels[tag + 2]);
                }
            }
        }

        private Point TamPanel(Panel panel)
        {

            int panelX = panel.Location.X;
            int panelY = panel.Location.Y;
            int panelWidth = panel.Size.Width;
            int panelHeight = panel.Size.Height;

            int centerX = panelX + panelWidth / 2;
            int centerY = panelY + panelHeight / 2;

            return new Point(centerX, centerY);
        }

     





        private void pnlListNguoiDungs_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
