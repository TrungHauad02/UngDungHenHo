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
    public partial class UCSignIn : UserControl
    {
        public UCSignIn()
        {
            InitializeComponent();
            this.lblSignIn.BackColor = Color.FromArgb(128, 255, 200, 221);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {

        }
    }
}
