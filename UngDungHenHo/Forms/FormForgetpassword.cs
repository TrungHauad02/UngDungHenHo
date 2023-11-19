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
        bool isCheckOTP = false;
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
            if(isCheckOTP)
            {
                if (blForgetpass.ChangPass(this.txtUsername.Text.Trim(), this.txtMail.Text.Trim()))
                    MessageBox.Show("Change password succeed");
                else
                    MessageBox.Show("Error");
                return;
            }
            if(blForgetpass.CheckCode(this.txtOTP.Text.Trim()))
            {      
                this.lblOTP.Visible = false;
                this.txtOTP.Visible = false;
                this.btnSendCode.Visible = false;
                this.txtUsername.ReadOnly = true;

                this.lblMail.Text = "Password";

                this.txtMail.Font = new Font("Wingdings", 30, FontStyle.Regular);
                this.txtMail.PasswordChar = 'l';
                this.txtMail.Text = "";

                this.btnExit.Location = new Point(this.btnExit.Location.X, 420);
                this.btnSubmit.Location = new Point(this.btnSubmit.Location.X, 420);
                
                isCheckOTP = true;
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
                MessageBox.Show($"Error: Cannot sent email or your username is wrong");
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
