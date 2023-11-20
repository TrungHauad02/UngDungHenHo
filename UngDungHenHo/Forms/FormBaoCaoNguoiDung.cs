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
    public partial class FormBaoCaoNguoiDung : Form
    {

        BLBaoCaoNguoiDung dbBaoCao = new BLBaoCaoNguoiDung();
        int IdNguoiDungBaoCao;
        int IdNguoiDungBiBaoCao;
        String HoTenBiBaoCao;
        public FormBaoCaoNguoiDung(int IDNguoiDungBaoCao, int IDNguoiDungBiBaoCao, string hoTenBiBaoCao)
        {
            InitializeComponent();
            this.IdNguoiDungBaoCao = IDNguoiDungBaoCao;
            this.IdNguoiDungBiBaoCao = IDNguoiDungBiBaoCao;
            this.HoTenBiBaoCao = hoTenBiBaoCao;
            
        }

        private void FormBaoCaoNguoiDung_Load(object sender, EventArgs e)
        {
            this.txtHoTen.Text = HoTenBiBaoCao;
            this.txtHoTen.Enabled = false;
            txtNoiDungBaoCao.Focus();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            dbBaoCao.TaoBaoCaoNguoiDung(IdNguoiDungBaoCao, IdNguoiDungBiBaoCao, DateTime.Now, txtNoiDungBaoCao.Text);
            this.Close();
        }
    }
}
