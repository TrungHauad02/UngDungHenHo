
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungHenHo.BS_layer;
using UngDungHenHo.models;

namespace UngDungHenHo.Forms
{
    public partial class FormSuaProfile : Form
    {
        BLProfile blProfile = new BLProfile();
        public int idDangNhap;
        private bool isChonHinh = false;
        private byte[] imageDataForm;
        public FormSuaProfile(int iddangnhap)
        {
            InitializeComponent();
            this.idDangNhap = iddangnhap;
            LoadProfile(idDangNhap);

        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            byte[] imageData;
            dlg.Filter = "Hình ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            dlg.InitialDirectory = @"D:\";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;

                fileName = dlg.FileName;
                using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        imageData = reader.ReadBytes((int)stream.Length);
                    }
                }
                pbAnhDaiDien.Image = Image.FromFile(fileName);
                pbAnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;
                isChonHinh = true;
            }
        }
        private void LoadProfile(int nguoiDungId)
        {
            DataTable nguoiDungInfo = blProfile.GetNguoiDungInfoById(nguoiDungId);

            if (nguoiDungInfo.Rows.Count > 0)
            {
                DataRow row = nguoiDungInfo.Rows[0];

                string hoTen = row["HoTen"].ToString();
                DateTime ngaySinh = Convert.ToDateTime(row["NgaySinh"]);
                string moTa = row["MoTaCaNhan"].ToString();

                txtHoTen.Text = hoTen;
                dtpNgaySinh.Text = ngaySinh.ToString();
                txtMoTa.Text = moTa.ToString();

                if (row["AnhDaiDien"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])row["AnhDaiDien"];
                    this.imageDataForm = imageData;
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
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                int nguoiDungID = idDangNhap;
                string hoTen = txtHoTen.Text; // Lấy giá trị từ TextBox hoTen
                DateTime ngaySinh = dtpNgaySinh.Value; // Lấy giá trị từ DateTimePicker dtpNgaySinh

                byte[] HinhAnh = imageDataForm;
                if (isChonHinh)
                    HinhAnh = ImageToByteArray(pbAnhDaiDien.Image);
                string moTaCaNhan = txtMoTa.Text; // Lấy giá trị từ TextBox moTa

                blProfile.UpdateInfoNguoiDung(nguoiDungID, hoTen, ngaySinh, HinhAnh, moTaCaNhan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
        private byte[] ImageToByteArray(Image img)
        {
            MemoryStream memoryStream = new MemoryStream();
            img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
