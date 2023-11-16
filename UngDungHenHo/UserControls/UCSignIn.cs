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
using UngDungHenHo.models;

namespace UngDungHenHo.UserControls
{
    public partial class UCSignIn : UserControl
    {
        public event EventHandler ExitButtonClicked;
        private BLSignIn signIn;
        
        public UCSignIn()
        {
            InitializeComponent();
            signIn = new BLSignIn();
            //this.lblSignIn.BackColor = Color.FromArgb(128, 255, 200, 221);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {

            NguoiDung nguoiDung = new NguoiDung();
            nguoiDung.Name = this.txtFullname.Text;
            nguoiDung.Sex = this.rdbMale.Checked ? 1 : 0;
            nguoiDung.Date = dtpDate.Value;
            nguoiDung.Email = this.txtEmail.Text;
            nguoiDung.Username = this.txtUsername.Text;
            nguoiDung.Password = this.txtPassword.Text;
            signIn.TrySignIn(nguoiDung);
        }

        private bool CheckTextBox()
        {
            bool result = true;
            if(this.txtFullname.Text.Trim() == "")
            {
                
            }    

            return result;
        }
    }
}
