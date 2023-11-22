using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;
using UngDungHenHo.BS_layer;
using UngDungHenHo.Forms;
using UngDungHenHo.models;

namespace UngDungHenHo.UserControls
{
    public partial class UCSearch : UserControl
    {
        public UCSearch()
        {
            InitializeComponent();
        }
        private DataTable dtTimKiem;
        public int index;
        public Panel TaoKetQuaTimKiem(NguoiDung a, byte[] image, int vitri)
        {
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Width = 355;
            panel.Height = 72;
            panel.Location = new Point(16, vitri * 100);
            // Tạo PictureBox
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Dock = DockStyle.Left;
            pictureBox.Height = 100; // Thiết lập kích thước phù hợp
            using (MemoryStream ms = new MemoryStream(image))
            {
                Image imageData = Image.FromStream(ms);
                pictureBox.Image = imageData;
            }
            Label lbl = new Label();
            lbl.Text = a.Name;
            lbl.MaximumSize = new Size(400, int.MaxValue);
            lbl.Font = new Font("MS Reference Sans Serif", 10.2f, FontStyle.Bold);
            Size textSize = TextRenderer.MeasureText(lbl.Text, lbl.Font, lbl.MaximumSize, TextFormatFlags.WordBreak);
            lbl.AutoSize = true;
            lbl.Size = textSize;
            lbl.Dock = DockStyle.Right;
            panel.Click += new EventHandler(Panel_Click);
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(lbl);
            //lbl.Location = new Point(16, 20 * vitri + 20);
            panel.Tag = a.Id;
            return panel;
        }
        private void Panel_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện click tại đây
            Panel panel = sender as Panel;
            index = int.Parse(panel.Tag.ToString());
            FKqTimKiem form = new FKqTimKiem(index);
            form.ShowDialog();
        }
        public void LoadTimKiem()
        {
            this.pnlSearch.Controls.Clear();
            try
            {
                // Tìm
                BLSearch blsearch = new BLSearch();
                string error = string.Empty;
                dtTimKiem = blsearch.TimKiemND(txtTimKiem.Text, ref error);
                // Kiểm tra 
                if (dtTimKiem.Rows.Count == 0)
                {
                    MessageBox.Show("Người dùng không tồn tại. Vui lòng nhập lại!");
                    txtTimKiem.Focus();
                    return;
                }

                int vitri = 1;
                foreach (DataRow r in dtTimKiem.Rows)
                {
                    NguoiDung temp = new NguoiDung(int.Parse(r["ID_DangNhap"].ToString()), r["HoTen"].ToString());
                    byte[] imageData;
                    if (r["AnhDaiDien"] == DBNull.Value)
                    {
                        imageData = BLSearch.BitmapToByteArray(Properties.Resources.anhnguoidungkhongco);
                        Panel Nguoidung = TaoKetQuaTimKiem(temp, imageData, vitri);
                        this.pnlSearch.Controls.Add(Nguoidung);
                    }
                    else
                    {
                        // Xử lý khi không có hình ảnh
                        imageData = (byte[])r["AnhDaiDien"];
                        Panel Nguoidung = TaoKetQuaTimKiem(temp, imageData, vitri);
                        this.pnlSearch.Controls.Add(Nguoidung);
                    }
                    vitri++;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadTimKiem();
        }
    }
}
