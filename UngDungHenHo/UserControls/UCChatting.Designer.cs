namespace UngDungHenHo.UserControls
{
    partial class UCChatting
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlNoiDungChat = new System.Windows.Forms.Panel();
            this.pnlChatContent = new System.Windows.Forms.Panel();
            this.pnlChatEnter = new System.Windows.Forms.Panel();
            this.btnSendMessages = new FontAwesome.Sharp.IconPictureBox();
            this.rtxtEnterContentChat = new System.Windows.Forms.RichTextBox();
            this.pnlChatHeader = new System.Windows.Forms.Panel();
            this.lblTenNguoiChat = new System.Windows.Forms.Label();
            this.pbAnhNguoiChat = new System.Windows.Forms.PictureBox();
            this.pnlNguoiDung = new System.Windows.Forms.Panel();
            this.pnlNguoiDungs = new System.Windows.Forms.Panel();
            this.pnlHeaderNguoiDung = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnlNoiDungChat.SuspendLayout();
            this.pnlChatEnter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSendMessages)).BeginInit();
            this.pnlChatHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnhNguoiChat)).BeginInit();
            this.pnlNguoiDung.SuspendLayout();
            this.pnlHeaderNguoiDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNoiDungChat
            // 
            this.pnlNoiDungChat.AutoScroll = true;
            this.pnlNoiDungChat.Controls.Add(this.pnlChatContent);
            this.pnlNoiDungChat.Controls.Add(this.pnlChatEnter);
            this.pnlNoiDungChat.Controls.Add(this.pnlChatHeader);
            this.pnlNoiDungChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDungChat.Location = new System.Drawing.Point(268, 0);
            this.pnlNoiDungChat.Name = "pnlNoiDungChat";
            this.pnlNoiDungChat.Size = new System.Drawing.Size(747, 784);
            this.pnlNoiDungChat.TabIndex = 1;
            // 
            // pnlChatContent
            // 
            this.pnlChatContent.AutoScroll = true;
            this.pnlChatContent.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlChatContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChatContent.Location = new System.Drawing.Point(0, 61);
            this.pnlChatContent.Name = "pnlChatContent";
            this.pnlChatContent.Size = new System.Drawing.Size(747, 649);
            this.pnlChatContent.TabIndex = 2;
            this.pnlChatContent.VisibleChanged += new System.EventHandler(this.pnlChatContent_VisibleChanged);
            // 
            // pnlChatEnter
            // 
            this.pnlChatEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.pnlChatEnter.Controls.Add(this.btnSendMessages);
            this.pnlChatEnter.Controls.Add(this.rtxtEnterContentChat);
            this.pnlChatEnter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChatEnter.Location = new System.Drawing.Point(0, 710);
            this.pnlChatEnter.Name = "pnlChatEnter";
            this.pnlChatEnter.Size = new System.Drawing.Size(747, 74);
            this.pnlChatEnter.TabIndex = 1;
            // 
            // btnSendMessages
            // 
            this.btnSendMessages.BackColor = System.Drawing.Color.Transparent;
            this.btnSendMessages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendMessages.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.btnSendMessages.IconColor = System.Drawing.Color.White;
            this.btnSendMessages.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSendMessages.IconSize = 43;
            this.btnSendMessages.Location = new System.Drawing.Point(657, 14);
            this.btnSendMessages.Name = "btnSendMessages";
            this.btnSendMessages.Size = new System.Drawing.Size(49, 43);
            this.btnSendMessages.TabIndex = 1;
            this.btnSendMessages.TabStop = false;
            this.btnSendMessages.Click += new System.EventHandler(this.btnSendMessages_Click);
            // 
            // rtxtEnterContentChat
            // 
            this.rtxtEnterContentChat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rtxtEnterContentChat.Location = new System.Drawing.Point(65, 14);
            this.rtxtEnterContentChat.Name = "rtxtEnterContentChat";
            this.rtxtEnterContentChat.Size = new System.Drawing.Size(549, 43);
            this.rtxtEnterContentChat.TabIndex = 0;
            this.rtxtEnterContentChat.Text = "";
            // 
            // pnlChatHeader
            // 
            this.pnlChatHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.pnlChatHeader.Controls.Add(this.lblTenNguoiChat);
            this.pnlChatHeader.Controls.Add(this.pbAnhNguoiChat);
            this.pnlChatHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChatHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlChatHeader.Name = "pnlChatHeader";
            this.pnlChatHeader.Size = new System.Drawing.Size(747, 61);
            this.pnlChatHeader.TabIndex = 0;
            // 
            // lblTenNguoiChat
            // 
            this.lblTenNguoiChat.AutoSize = true;
            this.lblTenNguoiChat.Font = new System.Drawing.Font("Montserrat Extra Bold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNguoiChat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTenNguoiChat.Location = new System.Drawing.Point(101, 22);
            this.lblTenNguoiChat.Name = "lblTenNguoiChat";
            this.lblTenNguoiChat.Size = new System.Drawing.Size(14, 21);
            this.lblTenNguoiChat.TabIndex = 1;
            this.lblTenNguoiChat.Text = " ";
            // 
            // pbAnhNguoiChat
            // 
            this.pbAnhNguoiChat.Location = new System.Drawing.Point(20, 5);
            this.pbAnhNguoiChat.Name = "pbAnhNguoiChat";
            this.pbAnhNguoiChat.Size = new System.Drawing.Size(58, 50);
            this.pbAnhNguoiChat.TabIndex = 0;
            this.pbAnhNguoiChat.TabStop = false;
            // 
            // pnlNguoiDung
            // 
            this.pnlNguoiDung.AutoScroll = true;
            this.pnlNguoiDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.pnlNguoiDung.Controls.Add(this.pnlNguoiDungs);
            this.pnlNguoiDung.Controls.Add(this.pnlHeaderNguoiDung);
            this.pnlNguoiDung.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNguoiDung.Location = new System.Drawing.Point(0, 0);
            this.pnlNguoiDung.Name = "pnlNguoiDung";
            this.pnlNguoiDung.Size = new System.Drawing.Size(268, 784);
            this.pnlNguoiDung.TabIndex = 0;
            // 
            // pnlNguoiDungs
            // 
            this.pnlNguoiDungs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNguoiDungs.Location = new System.Drawing.Point(0, 100);
            this.pnlNguoiDungs.Name = "pnlNguoiDungs";
            this.pnlNguoiDungs.Size = new System.Drawing.Size(268, 684);
            this.pnlNguoiDungs.TabIndex = 1;
            // 
            // pnlHeaderNguoiDung
            // 
            this.pnlHeaderNguoiDung.Controls.Add(this.iconPictureBox1);
            this.pnlHeaderNguoiDung.Controls.Add(this.label1);
            this.pnlHeaderNguoiDung.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderNguoiDung.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderNguoiDung.Name = "pnlHeaderNguoiDung";
            this.pnlHeaderNguoiDung.Size = new System.Drawing.Size(268, 100);
            this.pnlHeaderNguoiDung.TabIndex = 0;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.FacebookMessenger;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 65;
            this.iconPictureBox1.Location = new System.Drawing.Point(31, 22);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(67, 65);
            this.iconPictureBox1.TabIndex = 1;
            this.iconPictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat Extra Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.label1.Location = new System.Drawing.Point(123, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chat";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.Timer_scroll_check);
            // 
            // UCChatting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNoiDungChat);
            this.Controls.Add(this.pnlNguoiDung);
            this.Name = "UCChatting";
            this.Size = new System.Drawing.Size(1015, 784);
            this.VisibleChanged += new System.EventHandler(this.UCChatting_VisibleChanged);
            this.pnlNoiDungChat.ResumeLayout(false);
            this.pnlChatEnter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSendMessages)).EndInit();
            this.pnlChatHeader.ResumeLayout(false);
            this.pnlChatHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnhNguoiChat)).EndInit();
            this.pnlNguoiDung.ResumeLayout(false);
            this.pnlHeaderNguoiDung.ResumeLayout(false);
            this.pnlHeaderNguoiDung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlNoiDungChat;
        private System.Windows.Forms.Panel pnlChatEnter;
        private FontAwesome.Sharp.IconPictureBox btnSendMessages;
        private System.Windows.Forms.RichTextBox rtxtEnterContentChat;
        private System.Windows.Forms.Panel pnlChatHeader;
        private System.Windows.Forms.Panel pnlChatContent;
        private System.Windows.Forms.Label lblTenNguoiChat;
        private System.Windows.Forms.PictureBox pbAnhNguoiChat;
        private System.Windows.Forms.Panel pnlNguoiDung;
        private System.Windows.Forms.Panel pnlNguoiDungs;
        private System.Windows.Forms.Panel pnlHeaderNguoiDung;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}
