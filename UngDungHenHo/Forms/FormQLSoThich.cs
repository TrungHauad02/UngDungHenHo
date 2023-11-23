using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungHenHo.BS_layer;

namespace UngDungHenHo.Forms
{
    public partial class FormQLSoThich : Form
    {
        BLQLSoThich blQLSoThich = new BLQLSoThich();
        public FormQLSoThich()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgv_QLSoThich.DataSource = blQLSoThich.LaySoThich();
            dgv_QLSoThich.ReadOnly = true;
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenSoThich = txtSoThich.Text;
            try
            {
                int idSoThich = blQLSoThich.ThemSoThich(tenSoThich);
                dgv_QLSoThich.Rows.Add(idSoThich, tenSoThich);
            } catch (Exception ex) { }
            LoadData();

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int idSoThich = int.Parse(txtIDSoThich.Text);
            string tenSoThichMoi = txtSoThich.Text;
            try
            {
                dgv_QLSoThich.DataSource = blQLSoThich.CapNhatSoThich(idSoThich, tenSoThichMoi);
                
            } catch(Exception ex) { }
            LoadData();
        }

        private void dgv_QLSoThich_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_QLSoThich.Rows.Count)
            {
                DataGridViewRow selectedRow = dgv_QLSoThich.Rows[e.RowIndex];
                txtIDSoThich.Text = selectedRow.Cells["ID_SoThich"].Value.ToString();
                txtSoThich.Text = selectedRow.Cells["TenSoThich"].Value.ToString();
            }
        }
    }
}
