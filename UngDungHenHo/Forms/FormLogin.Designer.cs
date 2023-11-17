namespace UngDungHenHo.Forms
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.lblSignIn = new System.Windows.Forms.Label();
            this.lblForgetPass = new System.Windows.Forms.LinkLabel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblUsernameError = new System.Windows.Forms.Label();
            this.lblPasswordError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSignIn
            // 
            this.lblSignIn.AutoSize = true;
            this.lblSignIn.BackColor = System.Drawing.Color.Transparent;
            this.lblSignIn.Font = new System.Drawing.Font("Segoe UI", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignIn.Location = new System.Drawing.Point(864, 1);
            this.lblSignIn.Name = "lblSignIn";
            this.lblSignIn.Size = new System.Drawing.Size(118, 45);
            this.lblSignIn.TabIndex = 17;
            this.lblSignIn.Text = "SignIn";
            // 
            // lblForgetPass
            // 
            this.lblForgetPass.ActiveLinkColor = System.Drawing.Color.Red;
            this.lblForgetPass.AutoSize = true;
            this.lblForgetPass.BackColor = System.Drawing.Color.Transparent;
            this.lblForgetPass.DisabledLinkColor = System.Drawing.Color.Black;
            this.lblForgetPass.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgetPass.LinkColor = System.Drawing.Color.Black;
            this.lblForgetPass.Location = new System.Drawing.Point(18, 695);
            this.lblForgetPass.Name = "lblForgetPass";
            this.lblForgetPass.Size = new System.Drawing.Size(264, 41);
            this.lblForgetPass.TabIndex = 16;
            this.lblForgetPass.TabStop = true;
            this.lblForgetPass.Text = "Forget Password?";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(458, 652);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(195, 84);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Location = new System.Drawing.Point(705, 652);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(195, 84);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(224)))), ((int)(((byte)(254)))));
            this.txtPassword.Font = new System.Drawing.Font("Wingdings", 30F);
            this.txtPassword.Location = new System.Drawing.Point(296, 543);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = 'l';
            this.txtPassword.Size = new System.Drawing.Size(604, 63);
            this.txtPassword.TabIndex = 13;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(224)))), ((int)(((byte)(254)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(296, 402);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(604, 65);
            this.txtUsername.TabIndex = 12;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.Black;
            this.lblPassword.Location = new System.Drawing.Point(14, 543);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(249, 62);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Location = new System.Drawing.Point(14, 402);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(260, 62);
            this.lblUsername.TabIndex = 10;
            this.lblUsername.Text = "Username:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 45F, System.Drawing.FontStyle.Bold);
            this.lblLogin.ForeColor = System.Drawing.Color.Black;
            this.lblLogin.Location = new System.Drawing.Point(126, 154);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(271, 100);
            this.lblLogin.TabIndex = 9;
            this.lblLogin.Text = "LOGIN";
            // 
            // lblUsernameError
            // 
            this.lblUsernameError.AutoSize = true;
            this.lblUsernameError.BackColor = System.Drawing.Color.White;
            this.lblUsernameError.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblUsernameError.ForeColor = System.Drawing.Color.Red;
            this.lblUsernameError.Location = new System.Drawing.Point(290, 474);
            this.lblUsernameError.Name = "lblUsernameError";
            this.lblUsernameError.Size = new System.Drawing.Size(186, 35);
            this.lblUsernameError.TabIndex = 21;
            this.lblUsernameError.Text = "Error username";
            // 
            // lblPasswordError
            // 
            this.lblPasswordError.AutoSize = true;
            this.lblPasswordError.BackColor = System.Drawing.Color.White;
            this.lblPasswordError.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordError.Location = new System.Drawing.Point(290, 609);
            this.lblPasswordError.Name = "lblPasswordError";
            this.lblPasswordError.Size = new System.Drawing.Size(184, 35);
            this.lblPasswordError.TabIndex = 22;
            this.lblPasswordError.Text = "Error password";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(224)))), ((int)(((byte)(254)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(997, 737);
            this.Controls.Add(this.lblPasswordError);
            this.Controls.Add(this.lblUsernameError);
            this.Controls.Add(this.lblSignIn);
            this.Controls.Add(this.lblForgetPass);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblLogin);
            this.DoubleBuffered = true;
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSignIn;
        private System.Windows.Forms.LinkLabel lblForgetPass;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblUsernameError;
        private System.Windows.Forms.Label lblPasswordError;
    }
}