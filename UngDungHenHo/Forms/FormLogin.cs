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

namespace UngDungHenHo.Forms
{
    public partial class FormLogin : Form
    {
        public BLLogin bLLogin;

        public FormLogin()
        {
            InitializeComponent();
            this.RemoveErrorMsg();
            bLLogin = new BLLogin();
            this.lblLogin.BackColor = Color.FromArgb(255, 200, 221);
            this.lblUsername.BackColor = Color.FromArgb(255, 200, 221);
            this.lblPassword.BackColor = Color.FromArgb(255, 200, 221);
            this.lblForgetPass.BackColor = Color.FromArgb(255, 200, 221);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.RemoveErrorMsg();
            if (!this.CheckFill())
                return;
            TaiKhoan account = new TaiKhoan();
            account.Username = this.txtUsername.Text.Trim();
            account.Password = this.txtPassword.Text.Trim();
            FormMain.account = bLLogin.TryLogin(account);
            if (FormMain.account.Id != "-1")
            {
                MessageBox.Show($"Welcome {FormMain.account.Id}", "Login succeed");
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password", "Error");
                this.lblUsernameError.Text = "Wrong username or password";
                this.lblPasswordError.Text = "Wrong username or password";
            }
        }

        private bool CheckFill()
        {
            bool result = true;
            if(this.txtUsername.Text.Trim() == "")
            {
                this.lblUsernameError.Text = "Please enter a username";
                result = false;
            }
            if(this.txtPassword.Text.Trim() == "")
            {
                this.lblPasswordError.Text = "Please enter a password";
                result = false;
            }
            return result;
        }

        private void RemoveErrorMsg()
        {
            this.lblUsernameError.Text = "";
            this.lblPasswordError.Text = "";
        }
    }
}
