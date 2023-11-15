using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UngDungHenHo.UserControls
{
    public partial class UCLogin : UserControl
    {
        public UCLogin()
        {
            InitializeComponent();
            this.lblLogin.BackColor = Color.FromArgb(80, 162, 210, 255);
            this.lblUsername.BackColor = Color.FromArgb(80, 162, 210, 255);
            this.lblPassword.BackColor = Color.FromArgb(80, 162, 210, 255);
            this.lblForgetPass.BackColor = Color.FromArgb(80, 162, 210, 255);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
