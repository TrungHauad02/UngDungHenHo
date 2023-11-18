namespace UngDungHenHo.UserControls
{
    partial class UCHome
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
            this.pnlListNguoiDungs = new System.Windows.Forms.Panel();
            this.pnltong = new System.Windows.Forms.Panel();
            this.pnlListNguoiDungs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlListNguoiDungs
            // 
            this.pnlListNguoiDungs.Controls.Add(this.pnltong);
            this.pnlListNguoiDungs.Location = new System.Drawing.Point(3, 3);
            this.pnlListNguoiDungs.Name = "pnlListNguoiDungs";
            this.pnlListNguoiDungs.Size = new System.Drawing.Size(873, 502);
            this.pnlListNguoiDungs.TabIndex = 0;
            // 
            // pnltong
            // 
            this.pnltong.Location = new System.Drawing.Point(396, 402);
            this.pnltong.Name = "pnltong";
            this.pnltong.Size = new System.Drawing.Size(114, 100);
            this.pnltong.TabIndex = 1;
            this.pnltong.Paint += new System.Windows.Forms.PaintEventHandler(this.pnltong_Paint);
            // 
            // UCHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlListNguoiDungs);
            this.Name = "UCHome";
            this.Size = new System.Drawing.Size(925, 508);
            this.Load += new System.EventHandler(this.UCHome_Load);
            this.pnlListNguoiDungs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlListNguoiDungs;
        private System.Windows.Forms.Panel pnltong;
    }
}
