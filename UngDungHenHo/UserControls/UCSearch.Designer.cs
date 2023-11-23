namespace UngDungHenHo.UserControls
{
    partial class UCSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSearch));
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboSoThich = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.BackgroundImage")));
            this.btnTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTimKiem.Location = new System.Drawing.Point(683, 22);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(30, 30);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Location = new System.Drawing.Point(279, 106);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(378, 657);
            this.pnlSearch.TabIndex = 4;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(124, 22);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 30);
            this.txtTimKiem.TabIndex = 3;
            this.txtTimKiem.Text = "Tìm kiếm người dùng";
            this.txtTimKiem.Click += new System.EventHandler(this.txtTimKiem_Click);
            // 
            // cboSoThich
            // 
            this.cboSoThich.FormattingEnabled = true;
            this.cboSoThich.Location = new System.Drawing.Point(441, 22);
            this.cboSoThich.Name = "cboSoThich";
            this.cboSoThich.Size = new System.Drawing.Size(135, 24);
            this.cboSoThich.TabIndex = 6;
            this.cboSoThich.Text = "Sở thích";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.listBox1.Location = new System.Drawing.Point(118, 308);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(94, 36);
            this.listBox1.TabIndex = 7;
            // 
            // UCSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cboSoThich);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.txtTimKiem);
            this.Name = "UCSearch";
            this.Size = new System.Drawing.Size(1015, 784);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboSoThich;
        private System.Windows.Forms.ListBox listBox1;
    }
}
