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
using System.Windows.Forms;
using UngDungHenHo.BS_layer;
using UngDungHenHo.models;
namespace UngDungHenHo.UserControls
{
    public partial class UCHome : UserControl
    {
        private bool[] isDragging = new bool[3];
        private Point[] offset = new Point[3];
        BLHome dbHome = null;
        DataTable dtND = null;
        public UCHome()
        {
            InitializeComponent();
        
            this.pnlListNguoiDungs.Controls.Add(AddScrollBar());

            listnguoidung();

        }


       
        public VScrollBar AddScrollBar()
        {
            VScrollBar vsb = new VScrollBar();
            vsb.Dock = DockStyle.Right;
            vsb.Visible = false;
            return vsb;
          
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



        Panel[] panels = new Panel[100];
        private void listnguoidung()
        {

            dbHome = new BLHome();
            dtND = dbHome.LayDanhSachNguoiDung();
            int tongnguoidung = dtND.Rows.Count;


            for (int i = 0; i < tongnguoidung; i++)
            {
                panels[i] = new Panel();

                panels[i].BackColor = Color.Red;
                panels[i].Width = pnlListNguoiDungs.Width-200;
                panels[i].Height = pnlListNguoiDungs.Height-200;
                panels[i].Left = pnlListNguoiDungs.Left + 200;
                panels[i].Top = pnlListNguoiDungs.Top +200;
                VScrollBar vsb = new VScrollBar();
                vsb.Dock = DockStyle.Right;
                vsb.Visible = false;
                listbaiviet(panels[i], Convert.ToInt32(dtND.Rows[i][0]), dtND.Rows[i][1].ToString(), i);

                panels[i].Controls.Add(vsb);

                /*              
                                panels[i].Tag = i;
                                panels[i].MouseDown += new MouseEventHandler(this.PanelMouseDownHandler);
                                panels[i].MouseMove += new MouseEventHandler(this.PanelMouseMoveHandler);
                                panels[i].MouseUp += new MouseEventHandler(this.PanelMouseUpHandler);*/

    
                pnlListNguoiDungs.Controls.Add(panels[i]);
            }
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            

        private void listbaiviet(Panel pnlNguoiDung, int idNguoiDung, string HoTen, int tagnguoidung)
        {
            DataTable dtBaiVietNguoiDung = dbHome.LayDanhSachBaiVietNguoiDung(idNguoiDung);
            int tongbaiviet = dtBaiVietNguoiDung.Rows.Count;
            Panel[] pnlbaiviet = new Panel[tongbaiviet];


          
            Label lbHoTen = new Label();
            Label[] lbNoiDung = new Label[tongbaiviet];
            lbHoTen.Text = "tui tên " + HoTen;

            lbHoTen.Width = pnlNguoiDung.Width/5;
            lbHoTen.Height = pnlNguoiDung.Height / 5;
            lbHoTen.Top = pnlNguoiDung.Top - 200;    

            pnlNguoiDung.Controls.Add(lbHoTen);

            for (int i = 0; i < tongbaiviet; i++)
            {

                pnlbaiviet[i] = new Panel();
                pnlbaiviet[i].Width = pnlNguoiDung.Width-100;
                pnlbaiviet[i].Height = pnlNguoiDung.Height;
                pnlbaiviet[i].BackColor = Color.Yellow; 

                lbNoiDung[i] = new Label();
                lbNoiDung[i].Width  = pnlbaiviet[i].Width/5;
                lbNoiDung[i].Height = pnlbaiviet[i].Height / 5;


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
         

                    
                    picPhim.Width = pnlbaiviet[i].Width-100;
                    picPhim.Height = pnlbaiviet[i].Height;
                    picPhim.SizeMode = PictureBoxSizeMode.StretchImage;

                    pnlbaiviet[i].Controls.Add(picPhim);
                }
                picPhim.Width = pnlbaiviet[i].Width;
                picPhim.Width = pnlbaiviet[i].Height;

                    


                lbNoiDung[i].Text = "Mô tả " + dtBaiVietNguoiDung.Rows[i][1].ToString();
                lbNoiDung[i].Location = new Point(10, pnlNguoiDung.Height - 20);
                pnlbaiviet[i].Controls.Add(lbNoiDung[i]);
               
                pnlbaiviet[i].Tag = tagnguoidung;
                pnlbaiviet[i].MouseDown += new MouseEventHandler(this.PanelMouseDownHandler);
                pnlbaiviet[i].MouseMove += new MouseEventHandler(this.PanelMouseMoveHandler);
                pnlbaiviet[i].MouseUp += new MouseEventHandler(this.PanelMouseUpHandler);
            
                pnlNguoiDung.Controls.Add(pnlbaiviet[i]);
               
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
              
                Point newLocation = new Point(panels[tag].Left + e.X - offset[tag].X, panels[tag].Top + e.Y - offset[tag].Y);
                if (panels[tag].Location != newLocation)
                {
   
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
