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
using System.Windows.Documents;
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
            AddScrollBar(this.pnlSearch);
            LoadSoThich();
        }
        private DataTable dtTimKiem;
        private DataView dvTimKiem;
        public int index;
        BLSearch blsearch = new BLSearch();
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
            if (txtTimKiem.Text != null || cboSoThich.Text != null ) 
            {
                try
                {
                    // Tìm
                    string error = string.Empty;
                    dtTimKiem = blsearch.TimKiemND(txtTimKiem.Text, cboSoThich.Text);
                    RemoveDuplicateRows(dtTimKiem, "ID_NguoiDung");
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
                        NguoiDung temp = new NguoiDung(int.Parse(r["ID_NguoiDung"].ToString()), r["HoTen"].ToString());
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
            }else
            {
                MessageBox.Show("Bạn hãy nhập thông tin để tìm kiếm!");
            }
            /*
            this.txtTimKiem.Clear();
            this.txtTimKiem.Text= null;
            */
            this.txtTimKiem.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadTimKiem();
        }
        public void AddScrollBar(Panel pnl)
        {
            VScrollBar vsb = new VScrollBar();
            vsb.Dock = DockStyle.Right;
            vsb.Visible = false;
            pnl.Controls.Add(vsb);

        }

        public void LoadSoThich()
        {
            DataTable dtSothich = blsearch.TimKiemSoThich();
            foreach( DataRow dr in dtSothich.Rows) 
            {
                cboSoThich.Items.Add(dr["TenSoThich"].ToString());
            }
        }
        static void RemoveDuplicateRows(DataTable dataTable, string columnName)
        {
            var uniqueRows = dataTable.AsEnumerable()
                .GroupBy(row => row.Field<int>(columnName))
                .Select(group => group.First())
                .CopyToDataTable();

            dataTable.Clear();
            dataTable.Merge(uniqueRows);
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
        }
    }
}
