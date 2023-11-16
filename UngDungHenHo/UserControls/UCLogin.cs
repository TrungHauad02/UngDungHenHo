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
    public partial class UCLogin : UserControl
    {
        public event EventHandler SignInClicked;
        public BLLogin bLLogin;
        TaiKhoan account;
        public UCLogin()
        {
            InitializeComponent();
            bLLogin = new BLLogin();
            this.lblLogin.BackColor = Color.FromArgb(255, 200, 221);
            this.lblUsername.BackColor = Color.FromArgb(255, 200, 221);
            this.lblPassword.BackColor = Color.FromArgb(255, 200, 221);
            this.lblForgetPass.BackColor = Color.FromArgb(255, 200, 221);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            SignInClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            account = new TaiKhoan();
            account.Username = this.txtUsername.Text.Trim();
            account.Password = this.txtPassword.Text.Trim();
            account = bLLogin.TryLogin(account);
            if (account.Id != "-1")
            {
                MessageBox.Show($"Welcome {account.Id}", "Login succeed");
            }
            else
            {
                MessageBox.Show("Wrong username or password", "Error");
            }
        }
    }
}
