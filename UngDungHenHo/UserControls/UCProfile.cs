using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungHenHo.BS_layer;
using UngDungHenHo.Forms;
using UngDungHenHo.models;

namespace UngDungHenHo.UserControls
{
    public partial class UCProfile : UserControl
    {
        int idDangNhap;
        BLProfile blProfile = new BLProfile();
        private Button[] buttons = new Button[4]; // Mảng các button
        private int currentButtonIndex = 0; // Chỉ số hiện tại của button được xử lý


        public UCProfile(int iddangnhap)
        {
            InitializeComponent();
            buttons = new Button[] { button1, button2, button3, button4 };
            this.idDangNhap = iddangnhap;
            LoadNguoiDung(idDangNhap);
            LoadGhepDoiButtons(idDangNhap); // Thay thế 1 bằng ID_NguoiDung1 thực tế của bạn
     
        }
        public void AddScrollBar(Panel panel)
        {
            VScrollBar vsb = new VScrollBar();
            vsb.Dock = DockStyle.Right;
            vsb.Visible = false;
            panel.Controls.Add(vsb);
        }


        public void LoadNguoiDung(int nguoiDungId)
        {
            DataTable nguoiDungInfo = blProfile.GetNguoiDungInfoById(nguoiDungId);

            if (nguoiDungInfo.Rows.Count > 0)
            {
                DataRow row = nguoiDungInfo.Rows[0];

                string hoTen = row["HoTen"].ToString();
                DateTime ngaySinh = Convert.ToDateTime(row["NgaySinh"]);
                int tuoi = DateTime.Now.Year - ngaySinh.Year;
                string moTa = row["MoTaCaNhan"].ToString();

                lbTenTuoi.Text = hoTen + "           " + tuoi.ToString();
                lbMoTa.Text = moTa.ToString();

                if (row["AnhDaiDien"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])row["AnhDaiDien"];
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(ms);
                        pbAnhDaiDien.Image = image;
                    }
                }
                else
                {
                    pbAnhDaiDien.Image = UngDungHenHo.Properties.Resources.anhnguoidungkhongco;
                }
            }
            else
            {
                // Xử lý khi không có dữ liệu người dùng
            }
            DataTable soThichTable = blProfile.GetSoThichByNguoiDung(nguoiDungId);

            // Kiểm tra và hiển thị danh sách sở thích
            if (soThichTable.Rows.Count > 0)
            {
                string soThichText = string.Join(", ", soThichTable.AsEnumerable()
                                            .Select(row => row.Field<string>("TenSoThich")));
                lbSoThich.Text = soThichText;
            }
            listbaiviet(nguoiDungId);

        }
        private void listbaiviet(int nguoiDungId)
        {
            DataTable dtBaiVietNguoiDung = blProfile.GetBaiVietByNguoiDungId(nguoiDungId);
            int tongbaiviet = dtBaiVietNguoiDung.Rows.Count;
            PictureBox[] hinhanhbaiviet = new PictureBox[tongbaiviet];
            Label[] lbNoiDung = new Label[tongbaiviet];
            Label[] thoigiandang = new Label[tongbaiviet];
            Panel baiviet = new Panel();
            baiviet.Location = new Point(181, 382);

            baiviet.Size = new Size(380, 249);

            for (int i = 0; i < tongbaiviet; i++)
            {

                hinhanhbaiviet[i] = new PictureBox();
                thoigiandang[i] = new Label();
                lbNoiDung[i] = new Label();

                if(i ==0)
                {
                    thoigiandang[i].Location = new Point(0, 0);
                    lbNoiDung[i].Location = new Point(4, 28);
                    hinhanhbaiviet[i].Location = new Point(28, 61);
                }
                else
                {
                    thoigiandang[i].Location = new Point(hinhanhbaiviet[i-1].Left, hinhanhbaiviet[i-1].Bottom + 10);
                    lbNoiDung[i].Location = new Point(thoigiandang[i].Left, thoigiandang[i].Bottom + 10);
                    hinhanhbaiviet[i].Location = new Point(thoigiandang[i].Left, lbNoiDung[i].Bottom + 10);

                }
                hinhanhbaiviet[i].Size = new Size(334, 171);
                thoigiandang[i].AutoSize = true;
                lbNoiDung[i].AutoSize = true;



                object rawValue = dtBaiVietNguoiDung.Rows[i][1];
                if (rawValue != DBNull.Value)
                {
                    byte[] HinhAnh = (byte[])rawValue;
                    using (MemoryStream ms = new MemoryStream(HinhAnh))
                    {
                        Image hinhAnh = Image.FromStream(ms);
                        hinhanhbaiviet[i].Image = hinhAnh;
                    }

                }
                else
                {
                    hinhanhbaiviet[i].Image = UngDungHenHo.Properties.Resources.anhnguoidungkhongco;


                }
                hinhanhbaiviet[i].SizeMode = PictureBoxSizeMode.StretchImage;
                lbNoiDung[i].Text = "Nội dung: " + dtBaiVietNguoiDung.Rows[i][0].ToString();
                thoigiandang[i].Text = Convert.ToDateTime(dtBaiVietNguoiDung.Rows[i][2]).ToString();
                baiviet.Controls.Add(hinhanhbaiviet[i]);
                baiviet.Controls.Add(lbNoiDung[i]);
                baiviet.Controls.Add(thoigiandang[i]);
            }
            baiviet.AutoScroll = true;
            AddScrollBar(baiviet);
            baiviet.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(baiviet);

        }

        private void LoadGhepDoiButtons(int idNguoiDung1)
        {
            // Gọi hàm GetInfoByNguoiDung1 để lấy thông tin
            DataTable dt = blProfile.GetInfoByNguoiDung1(idNguoiDung1);

            // Kiểm tra xem DataTable có dữ liệu hay không
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < buttons.Length && i < dt.Rows.Count; i++)
                {
                    // Lấy giá trị từ cột "HoTen" trong DataTable
                    string hoTen = dt.Rows[i]["HoTen"].ToString();

                    buttons[i].Text = hoTen;
                    buttons[i].Visible = true;
                    buttons[i].Tag = dt.Rows[i]["ID_NguoiDung2"].ToString();
                    buttons[i].Click += new EventHandler(btnGhepDoi_Click);
                }

                // Ẩn các button không có thông tin
                for (int i = dt.Rows.Count; i < buttons.Length; i++)
                {
                    buttons[i].Visible = false;
                }
            }
            else
            {
                // Ẩn tất cả các button nếu không có thông tin
                foreach (Button button in buttons)
                {
                    button.Visible = false;
                }
            }
        }

        private void  btnGhepDoi_Click(object sender, EventArgs e)
        {
            FKqTimKiem fKqTimKiem = new FKqTimKiem(Int32.Parse((sender as Button).Tag.ToString()));
            fKqTimKiem.ShowDialog();
        }

        private void UCProfile_Load(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FormSuaProfile formSuaProfile = new FormSuaProfile(idDangNhap);
            formSuaProfile.ShowDialog();
            LoadNguoiDung(idDangNhap);
        }
    }
    
}


