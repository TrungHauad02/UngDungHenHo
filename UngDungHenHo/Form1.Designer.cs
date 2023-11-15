namespace UngDungHenHo
{
    partial class FormMain
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnProfile = new FontAwesome.Sharp.IconPictureBox();
            this.btnUser = new FontAwesome.Sharp.IconPictureBox();
            this.btnFinding = new FontAwesome.Sharp.IconPictureBox();
            this.btnChatting = new FontAwesome.Sharp.IconPictureBox();
            this.btnHome = new FontAwesome.Sharp.IconPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChatting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlBody);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Location = new System.Drawing.Point(411, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1015, 912);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.panel3);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 853);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1015, 59);
            this.pnlFooter.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(98)))), ((int)(((byte)(99)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1015, 5);
            this.panel3.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnProfile);
            this.pnlHeader.Controls.Add(this.btnUser);
            this.pnlHeader.Controls.Add(this.btnFinding);
            this.pnlHeader.Controls.Add(this.btnChatting);
            this.pnlHeader.Controls.Add(this.btnHome);
            this.pnlHeader.Controls.Add(this.panel1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1015, 69);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.White;
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.btnProfile.IconChar = FontAwesome.Sharp.IconChar.IdBadge;
            this.btnProfile.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.btnProfile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProfile.IconSize = 64;
            this.btnProfile.Location = new System.Drawing.Point(821, 0);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(68, 64);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.TabStop = false;
            this.btnProfile.UseGdi = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            this.btnProfile.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.btnProfile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Menu_Hover);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.White;
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.btnUser.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnUser.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.btnUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUser.IconSize = 64;
            this.btnUser.Location = new System.Drawing.Point(642, 0);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(68, 64);
            this.btnUser.TabIndex = 4;
            this.btnUser.TabStop = false;
            this.btnUser.UseGdi = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            this.btnUser.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.btnUser.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Menu_Hover);
            // 
            // btnFinding
            // 
            this.btnFinding.BackColor = System.Drawing.Color.White;
            this.btnFinding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinding.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.btnFinding.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnFinding.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.btnFinding.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFinding.IconSize = 64;
            this.btnFinding.Location = new System.Drawing.Point(467, 0);
            this.btnFinding.Name = "btnFinding";
            this.btnFinding.Size = new System.Drawing.Size(68, 64);
            this.btnFinding.TabIndex = 3;
            this.btnFinding.TabStop = false;
            this.btnFinding.UseGdi = true;
            this.btnFinding.Click += new System.EventHandler(this.btnFinding_Click);
            this.btnFinding.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.btnFinding.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Menu_Hover);
            // 
            // btnChatting
            // 
            this.btnChatting.BackColor = System.Drawing.Color.White;
            this.btnChatting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChatting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.btnChatting.IconChar = FontAwesome.Sharp.IconChar.Rocketchat;
            this.btnChatting.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.btnChatting.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChatting.IconSize = 64;
            this.btnChatting.Location = new System.Drawing.Point(287, 0);
            this.btnChatting.Name = "btnChatting";
            this.btnChatting.Size = new System.Drawing.Size(68, 64);
            this.btnChatting.TabIndex = 2;
            this.btnChatting.TabStop = false;
            this.btnChatting.UseGdi = true;
            this.btnChatting.Click += new System.EventHandler(this.btnChatting_Click);
            this.btnChatting.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.btnChatting.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Menu_Hover);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnHome.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btnHome.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHome.IconSize = 64;
            this.btnHome.Location = new System.Drawing.Point(113, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(68, 64);
            this.btnHome.TabIndex = 1;
            this.btnHome.TabStop = false;
            this.btnHome.UseGdi = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnHome.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.btnHome.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Menu_Hover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(98)))), ((int)(((byte)(99)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 5);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(98)))), ((int)(((byte)(99)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1015, 5);
            this.panel2.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 69);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1015, 784);
            this.pnlBody.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(180)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(1712, 911);
            this.Controls.Add(this.pnlMain);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.pnlMain.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChatting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox btnHome;
        private FontAwesome.Sharp.IconPictureBox btnChatting;
        private FontAwesome.Sharp.IconPictureBox btnFinding;
        private FontAwesome.Sharp.IconPictureBox btnUser;
        private FontAwesome.Sharp.IconPictureBox btnProfile;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlBody;
    }
}

