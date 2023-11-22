using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungHenHo.BS_layer;

namespace UngDungHenHo.Forms
{
    public partial class FKqTimKiem : Form
    {
        BLSearch BLSearch = new BLSearch();
        public FKqTimKiem(int idNguoiDung)
        {
            InitializeComponent();
            buttons = new Button[] { button1, button2, button3, button4 };
            int nguoiDungId = idNguoiDung;
            LoadNguoiDung(nguoiDungId);
            LoadGhepDoiButtons(nguoiDungId); // Thay thế 1 bằng ID_NguoiDung1 thực tế của bạn
        }
/*        public int ChuyenID(int idNguoiDung)
        {
            DataTable NguoiDung = BLSearch.GetNguoiDungInfoById(idNguoiDung);
            DataRow row = NguoiDung.Rows[0];
            int nguoiDungId = int.Parse(row["ID_NguoiDung"].ToString());
            return nguoiDungId;
        }*/

        BLProfile blProfile = new BLProfile();
        private Button[] buttons = new Button[4]; // Mảng các button
        private int currentButtonIndex = 0; // Chỉ số hiện tại của button được xử lý

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
                    // Xử lý khi không có hình ảnh
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
            DataTable baiVietTable = blProfile.GetBaiVietByNguoiDungId(nguoiDungId);

            if (baiVietTable.Rows.Count > 0)
            {
                DataRow baiVietRow = baiVietTable.Rows[0];

                // Kiểm tra và hiển thị nội dung bài viết
                if (baiVietRow["NoiDung"] != DBNull.Value)
                {
                    lbStatus.Text = baiVietRow["NoiDung"].ToString();
                }
                else
                {
                    // Xử lý khi không có nội dung bài viết
                }

                DateTime thoiGianDang = Convert.ToDateTime(baiVietRow["ThoiGianDang"]);
                grBaiViet.Text = $"Bài viết (Đăng vào {thoiGianDang.ToString("dd/MM/yyyy HH:mm:ss")})";

                // Kiểm tra và hiển thị hình ảnh trong bài viết
                if (baiVietRow["HinhAnh"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])baiVietRow["HinhAnh"];
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(ms);
                        pictureBox2.Image = image;
                    }
                }
                else
                {
                    // Xử lý khi không có hình ảnh trong bài viết
                }
            }
            else
            {
                // Xử lý khi không có thông tin bài viết
            }

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
        private void btnGhepDoi_Click(object sender, EventArgs e)
        {
            FKqTimKiem fKqTimKiem = new FKqTimKiem(Int32.Parse((sender as Button).Tag.ToString()));
            fKqTimKiem.ShowDialog();
        }
    }
}
