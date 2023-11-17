﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungHenHo.BS_layer;
using UngDungHenHo.models;

namespace UngDungHenHo.Forms
{
    public partial class FormSignIn : Form
    {
        private BLSignIn signIn;
        private TaiKhoan account { get; set; }
        public FormSignIn()
        {
            InitializeComponent();
            this.RemoveErrorMsg();
            signIn = new BLSignIn();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.RemoveErrorMsg();
            if (!this.CheckFill())
                return;
            NguoiDung nguoiDung = new NguoiDung();
            nguoiDung.Name = this.txtFullname.Text;
            nguoiDung.Sex = this.rdbMale.Checked ? 1 : 0;
            nguoiDung.Date = dtpDate.Value;
            nguoiDung.Email = this.txtEmail.Text;
            nguoiDung.Username = this.txtUsername.Text;
            nguoiDung.Password = this.txtPassword.Text;
            nguoiDung.Role = "user";
            account = signIn.TrySignIn(nguoiDung);
        }

        private bool CheckFill()
        {
            bool result = true;
            if (this.txtFullname.Text.Trim() == "")
            {
                this.lblErrorFullname.Text = "Please enter fullname";
                result = false;
            }
            if(this.dtpDate.Value > DateTime.Now)
            {
                this.lblErrorDate.Text = "Please enter correct date";
                result = false;
            }
            if(this.txtPhone.Text.Trim() == "")
            {
                this.lblErrorPhone.Text = "Please enter phone number";
                result = false;
            }
            if(Regex.IsMatch(this.txtPhone.Text.Trim(), @"^\d+$"))
            {
                this.lblErrorPhone.Text = "phone must contains only numeric characters";
                result = false;
            }
            if(this.txtEmail.Text.Trim().Contains("@gmail.com"))
            {
                this.lblErrorEmail.Text = "Email must contains @gmail.com";
                result = false;
            }
            if(this.txtUsername.Text.Trim() == "")
            {
                this.lblErrorUsername.Text = "Please enter username";
                result = false;
            }
            if (this.txtPassword.Text.Trim() == "")
            {
                this.lblErrorPassword.Text = "Please enter password";
                result = false;
            }

            return result;
        }
        
        private void RemoveErrorMsg()
        {
            this.lblErrorFullname.Text = "";
            this.lblErrorDate.Text = "";
            this.lblErrorPhone.Text = "";
            this.lblErrorPhone.Text = "";
            this.lblErrorPhone.Text = "";
            this.lblErrorEmail.Text = "";
            this.lblErrorUsername.Text = "";
            this.lblErrorPassword.Text = "";
        }

    }
}
