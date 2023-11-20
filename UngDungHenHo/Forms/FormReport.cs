using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungHenHo.BS_layer;

namespace UngDungHenHo.Forms
{
    public partial class FormReport : Form
    {
        BLReport blReport = new BLReport();
        public FormReport()
        {
            InitializeComponent();
        }


        private void btnXem_Click(object sender, EventArgs e)
        {
            dgv_Report.DataSource = blReport.LayNoiDungBaoCao();
            dgv_Report.ReadOnly = true;
        }

        private void btnDSChan_Click(object sender, EventArgs e)
        {
            FormBlock formBlock = new FormBlock();
            formBlock.Show();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int idBaoCao = int.Parse(txtIDBaoCao.Text);
            int idQuanTri = int.Parse(txtIDQuantri.Text);
            DateTime thoiGianPhanHoi = Convert.ToDateTime(datePhanHoi.Text);
            string noiDungPhanHoi = txtNoiDung.Text;
            try
            {
                dgv_Report.DataSource = blReport.CapNhatNoiDungPhanHoi(idBaoCao, idQuanTri, thoiGianPhanHoi, noiDungPhanHoi);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }

        }

        public void LoadData()
        {
            dgv_Report.DataSource = blReport.LayNoiDungBaoCao();
            dgv_Report.Refresh();
        }

        private void dgv_Report_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_Report.Rows.Count)
            {
                DataGridViewRow selectedRow = dgv_Report.Rows[e.RowIndex];
                txtIDBaoCao.Text = selectedRow.Cells["ID_BaoCao"].Value.ToString();
                txtIDQuantri.Text = selectedRow.Cells["ID_QuanTri"].Value.ToString();
                datePhanHoi.Text = selectedRow.Cells["ThoiGianPhanHoi"].Value.ToString();
                txtNoiDung.Text = selectedRow.Cells["NoiDungPhanHoi"].Value.ToString();
            }
        }
    }
}
