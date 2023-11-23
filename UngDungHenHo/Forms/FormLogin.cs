using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
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
            Application.Exit();
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
            if (FormMain.account.Id != -1)
            {
                BLReport bLReport = new BLReport();
                if(!bLReport.LayTrangThaiND(FormMain.account.Id))
                {
                    MessageBox.Show("You are banned" + " because " + bLReport.NDBaoCao(FormMain.account.Id), "Login fail");
                }
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

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            using (FormSignIn formSignIn = new FormSignIn())
            {
                this.Visible = false;
                if (formSignIn.ShowDialog() == DialogResult.OK)
                {
                    this.txtUsername.Text = formSignIn.Account.Username;
                    this.txtPassword.Text = formSignIn.Account.Password;
                }
                this.Visible = true;
            }
        }

        private void lblForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormForgetpassword formForgetpass = new FormForgetpassword();
            this.Visible = false;
            formForgetpass.ShowDialog();
            this.Visible = true;
        }
    }
}
