namespace UngDungHenHo.Forms
{
    partial class FormBaoCaoNguoiDung
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
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtNoiDungBaoCao = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(151, 20);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoTen.Multiline = true;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(164, 26);
            this.txtHoTen.TabIndex = 18;
            // 
            // txtNoiDungBaoCao
            // 
            this.txtNoiDungBaoCao.Location = new System.Drawing.Point(151, 132);
            this.txtNoiDungBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.txtNoiDungBaoCao.Multiline = true;
            this.txtNoiDungBaoCao.Name = "txtNoiDungBaoCao";
            this.txtNoiDungBaoCao.Size = new System.Drawing.Size(357, 126);
            this.txtNoiDungBaoCao.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(158)))), ((int)(((byte)(179)))));
            this.label10.Location = new System.Drawing.Point(11, 20);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Họ tên  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(158)))), ((int)(((byte)(179)))));
            this.label1.Location = new System.Drawing.Point(11, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nội dung báo cáo";
            // 
            // FormBaoCaoNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 434);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNoiDungBaoCao);
            this.Controls.Add(this.txtHoTen);
            this.Name = "FormBaoCaoNguoiDung";
            this.Text = "FormBaoCaoNguoiDung";
            this.Load += new System.EventHandler(this.FormBaoCaoNguoiDung_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtNoiDungBaoCao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
    }
}