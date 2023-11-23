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
using UngDungHenHo.models;
using UngDungHenHo.UserControls;

namespace UngDungHenHo.Forms
{
    public partial class FormDangBaiViet : Form
    {
        public int idDangNhap;
        private byte[] imageDataForm;
        BLProfile blProfile = new BLProfile();
        public FormDangBaiViet(int iddangnhap)
        {
            InitializeComponent();
            this.idDangNhap = iddangnhap;
        }
        private bool isChonHinh = false;
        private void btnChonAnh_Click(object sender, EventArgs e)
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
                pbAnhDang.Image = Image.FromFile(fileName);
                pbAnhDang.SizeMode = PictureBoxSizeMode.Zoom;
                isChonHinh = true;
            }
        }

        private void btnDangBai_Click(object sender, EventArgs e)
        {

            try
            {

                int nguoiDungID = idDangNhap;
                string status = txtStatus.Text;

                byte[] HinhAnh = imageDataForm;
                if (isChonHinh)
                    HinhAnh = ImageToByteArray(pbAnhDang.Image);
                DateTime thoiGianDang = DateTime.Now;


                blProfile.InsertBaViet(status, HinhAnh, thoiGianDang, nguoiDungID);
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
    }
}
