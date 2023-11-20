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
    public partial class FormBlock : Form
    {
        BLReport blBlock = new BLReport();
        public FormBlock()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgv_Block.DataSource = blBlock.LayDSChan();
            dgv_Block.ReadOnly = true;
        }

        private void btnChan_Click(object sender, EventArgs e)
        {
            blBlock.ChanNguoiDung();
        }
    }
}
