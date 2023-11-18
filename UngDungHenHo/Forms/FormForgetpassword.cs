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
    public partial class FormForgetpassword : Form
    {
        BLForgetpass blForgetpass;
        public FormForgetpassword()
        {
            InitializeComponent();
            blForgetpass = new BLForgetpass();
            ClearErrorMsg();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.txtOTP.Text.Trim() == "")
            { 
                this.lblErrorOTP.Text = "Enter a OTP"; 
                return; 
            }
            if(blForgetpass.CheckCode(this.txtOTP.Text.Trim()))
            {
                Label lblPassword = new Label();
                lblPassword.Location = this.lblMail.Location;
                lblPassword.Text = "Password:";
                lblPassword.Size = this.lblMail.Size;
                lblPassword.Font = this.lblMail.Font;
                lblPassword.ForeColor = this.lblMail.ForeColor;
                lblPassword.BackColor = this.lblMail.BackColor;
                this.lblMail.Visible = false;
                this.lblOTP.Visible = false;
                this.txtOTP.Visible = false;
                this.btnSendCode.Visible = false;
                this.txtUsername.ReadOnly = true;
                this.btnExit.Location = new Point(this.btnExit.Location.X, this.btnExit.Location.Y - 100);
                this.btnSubmit.Location = new Point(this.btnSubmit.Location.X, this.btnSubmit.Location.Y - 100);
            }
            else
            {
                this.lblErrorOTP.Text = "Wrong OTP";
                return;
            }
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            if(!CheckFill())
                return;
            if(blForgetpass.SendCode(this.txtUsername.Text, this.txtMail.Text))
                MessageBox.Show("Email sent successfully!");
            else
                MessageBox.Show($"Error");
        }

        private bool CheckFill()
        {
            bool result = true;
            if (this.txtUsername.Text.Trim() == "")
            {
                this.lblErrorUsername.Text = "Please enter your username";
                result = false;
            }
            if (this.txtMail.Text.Trim() == "")
            {
                this.lblErrorMail.Text = "Please enter your phone number";
                result = false;
            }
            if (!this.txtMail.Text.Trim().Contains("@gmail.com"))
            {
                this.lblErrorMail.Text = "Email must contains @gmail.com";
                result = false;
            }
            return result;
        }

        private void ClearErrorMsg()
        {
            this.lblErrorUsername.Text = "";
            this.lblErrorOTP.Text = "";
            this.lblErrorMail.Text = "";
        }
    }
}
