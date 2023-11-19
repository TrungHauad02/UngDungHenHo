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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UngDungHenHo.UserControls
{
    public partial class UCHome : UserControl
    {
        int panelSize = 500;
        Panel[] panels;
        Panel[] panelhotens;
        PictureBox[] pcboxthichs;
        PictureBox[] pcboxkhongthichs;

        private bool isDragging = new bool();
        private Point offset = new Point();
        BLHome dbHome = null;
        DataTable dtND = null;
  




        public UCHome()
        {
            InitializeComponent();

            pnlListNguoiDungs.Size= new Size(1000,1000);
            pnlListNguoiDungs.BackColor = Color.Green;
            
            
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
            panelhotens = new Panel[tongnguoidung];
            pcboxthichs = new PictureBox[tongnguoidung];
            pcboxkhongthichs = new PictureBox[tongnguoidung];
            for (int i = 0; i < tongnguoidung; i++)
            {
                panels[i] = new Panel();
                panels[i].AutoScroll = true;
                AddScrollBar(panels[i]);
                panels[i].BackColor = Color.Red;
                
                panels[i].Size = new Size(panelSize, panelSize);

                panels[i].Location= new Point(150, 150);
                

                listbaiviet(panels[i], Convert.ToInt32(dtND.Rows[i][0]), i);
                themsukien(panels[i], i);



                if (i==0  || i ==1 )
                    {
                    taohoten(panels[i], dtND.Rows[i][1].ToString(), i);
                    taothichvakhongthich(panels[i], i);
                    pnlListNguoiDungs.Controls.Add(panels[i]);
                    
                }
            }


       

        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            

        private void listbaiviet(Panel pnlNguoiDung, int idNguoiDung, int tagnguoidung)
        {
            DataTable dtBaiVietNguoiDung = dbHome.LayDanhSachBaiVietNguoiDung(idNguoiDung);



            int tongbaiviet = dtBaiVietNguoiDung.Rows.Count;
            Panel[] pnlbaiviet = new Panel[tongbaiviet];
            Label[] lbNoiDung = new Label[tongbaiviet];


            for (int i = 0; i < tongbaiviet; i++)
            {

                pnlbaiviet[i] = new Panel();
                pnlbaiviet[i].Size = pnlNguoiDung.Size - new Size(100, 100);
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
                    picPhim.SizeMode = PictureBoxSizeMode.StretchImage;
                    picPhim.Size = pnlbaiviet[i].Size;
                   
                    /*
                                        picPhim.Size = pnlbaiviet[i].Size - new Size(100, 100);*/
                    /*  picPhim.Location = new Point(100, 100);*/

                    pnlbaiviet[i].Controls.Add(picPhim);
                }

            
                lbNoiDung[i] = new Label();
                lbNoiDung[i].Width = pnlbaiviet[i].Width;
                lbNoiDung[i].Height = pnlbaiviet[i].Height / 5;
                lbNoiDung[i].Text = "Mô tả " + dtBaiVietNguoiDung.Rows[i][1].ToString();

                pnlNguoiDung.Controls.Add(lbNoiDung[i]);

                if (i == 0)
                {
                    pnlbaiviet[i].Location = new Point(50, 50);
            
                }
                else
                {
                    pnlbaiviet[i].Location = new Point(pnlbaiviet[i - 1].Left, lbNoiDung[i - 1].Bottom + 50);
                }
                lbNoiDung[i].Location = new Point(pnlbaiviet[i].Left, pnlbaiviet[i].Bottom+10);

                themsukien(picPhim, tagnguoidung);
                themsukien(pnlbaiviet[i], tagnguoidung);

                pnlNguoiDung.Controls.Add(pnlbaiviet[i]);
               
            }
  
        }


        private void PanelMouseDownHandler(object sender, MouseEventArgs e)
        {



            int  tag = int.Parse((sender as Control).Tag.ToString());
      
         


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
                    panelhotens[tag].Location = new Point(panels[tag].Left, panels[tag].Top);
                    pcboxthichs[tag].Location = new Point(panels[tag].Left + 100, panels[tag].Top + 100);
                    pcboxkhongthichs[tag].Location = new Point(panels[tag].Left + 200, panels[tag].Top + 100);

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


                Point mousePosition =new Point(X,Y);

                // Kiểm tra xem điểm có nằm trong Panel B hay không
                if (mousePosition.X >= 0 && mousePosition.X <= panels[tag+1].Width &&
  mousePosition.Y >= 0 && mousePosition.Y <= panels[tag+1].Height)
                {
                    panels[tag].Location = panels[tag+1].Location;
                    panelhotens[tag].Location = panelhotens[tag+1].Location;
                    pcboxthichs[tag].Location = pcboxthichs[tag + 1].Location;
                    pcboxkhongthichs[tag].Location = pcboxkhongthichs[tag + 1].Location;
                }
                else
                {
                    pnlListNguoiDungs.Controls.Remove(panels[tag]);
                    pnlListNguoiDungs.Controls.Remove(panelhotens[tag]);
                    pnlListNguoiDungs.Controls.Remove(pcboxthichs[tag]);
                    pnlListNguoiDungs.Controls.Remove(pcboxkhongthichs[tag]);
                
                    if (dtND.Rows.Count > tag + 2)
                    {
                        taohoten(panels[tag + 2], dtND.Rows[tag + 2][1].ToString(), tag + 2);
                        taothichvakhongthich(panels[tag + 2], tag + 2);
                        pnlListNguoiDungs.Controls.Add(panels[tag + 2]);



                    }
                }    



                isDragging = false;

            }
        }
        private void ptboxthichvahuy(Panel panel)
        {
            Panel panelA = new Panel();
            panelA.Size = new Size(200, 200);
            panelA.Location = new Point(50, 50);
            panelA.BackColor = Color.LightGray;

            panel.Controls.Add(panelA);

        }
        private void themsukien(Control control, int i)
        {
            control.Tag = i;
            control.MouseDown += new MouseEventHandler(this.PanelMouseDownHandler);
            control.MouseMove += new MouseEventHandler(this.PanelMouseMoveHandler);
            control.MouseUp += new MouseEventHandler(this.PanelMouseUpHandler);
        }
        private void taohoten(Panel pnlNguoiDung,  string HoTen, int i)
        {
            panelhotens[i] = new Panel();
            Label lbHoTen = new Label();
   
            lbHoTen.Text = "tui tên " + HoTen;
            panelhotens[i].Width = lbHoTen.Width = pnlNguoiDung.Width;
            panelhotens[i].Height = lbHoTen.Height = 20;
            panelhotens[i].Location = new Point(pnlNguoiDung.Left, pnlNguoiDung.Top);
            lbHoTen.Location = new Point(0, 0);
            panelhotens[i].BackColor = Color.Orange;
            panelhotens[i].Controls.Add(lbHoTen);
            pnlListNguoiDungs.Controls.Add(panelhotens[i]);

        }
        private void taothichvakhongthich(Panel pnlNguoiDung, int i)
        {
            pcboxthichs[i] = vehinhtronpicturebox(50, new Point(pnlNguoiDung.Left+100, pnlNguoiDung.Top+100),UngDungHenHo.Properties.Resources.icon_thich);
            pcboxkhongthichs[i] = vehinhtronpicturebox(50, new Point(pnlNguoiDung.Left + 200, pnlNguoiDung.Top + 100), UngDungHenHo.Properties.Resources.icon_khongthich);
            pcboxthichs[i].Tag = i;
            pcboxkhongthichs[i].Tag = i;

            pcboxthichs[i].Click += new EventHandler(this.PictureBoxThichClickHandler);
            pcboxkhongthichs[i].Click += new EventHandler(this.PictureBoxKhongThichClickHandler);
            pnlListNguoiDungs.Controls.Add(pcboxthichs[i]);
            pnlListNguoiDungs.Controls.Add(pcboxkhongthichs[i]);
       
        }



        private  PictureBox vehinhtronpicturebox( int size, Point location, Image hinhanh)
        {
      
            PictureBox pcboxhinhtron = new PictureBox();
            pcboxhinhtron.Size = new Size(size, size);
            pcboxhinhtron.Location = location;
            pcboxhinhtron.BackColor = Color.Transparent;
            pcboxhinhtron.BackgroundImage = hinhanh;
            pcboxhinhtron.BackgroundImageLayout = ImageLayout.Stretch;
         

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
                pnlListNguoiDungs.Controls.Remove(panelhotens[tag]);
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
                pnlListNguoiDungs.Controls.Remove(panelhotens[tag]);
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





        private void pnltong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlListNguoiDungs_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
