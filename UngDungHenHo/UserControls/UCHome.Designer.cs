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
            this.SuspendLayout();
            // 
            // pnlListNguoiDungs
            // 
            this.pnlListNguoiDungs.Location = new System.Drawing.Point(0, 0);
            this.pnlListNguoiDungs.Margin = new System.Windows.Forms.Padding(4);
            this.pnlListNguoiDungs.Name = "pnlListNguoiDungs";
            this.pnlListNguoiDungs.Size = new System.Drawing.Size(1015, 784);
            this.pnlListNguoiDungs.TabIndex = 0;
            this.pnlListNguoiDungs.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlListNguoiDungs_Paint);
            // 
            // UCHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlListNguoiDungs);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCHome";
            this.Size = new System.Drawing.Size(1015, 784);
            this.Load += new System.EventHandler(this.UCHome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlListNguoiDungs;
    }
}
