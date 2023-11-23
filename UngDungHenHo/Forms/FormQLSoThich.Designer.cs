namespace UngDungHenHo.Forms
{
    partial class FormQLSoThich
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIDSoThich = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoThich = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgv_QLSoThich = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QLSoThich)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(349, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quản lý Sở thích";
            // 
            // btnXem
            // 
            this.btnXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.Location = new System.Drawing.Point(49, 352);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(87, 39);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Location = new System.Drawing.Point(300, 352);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(87, 39);
            this.btnCapNhat.TabIndex = 7;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "ID Sở thích";
            // 
            // txtIDSoThich
            // 
            this.txtIDSoThich.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDSoThich.Enabled = false;
            this.txtIDSoThich.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDSoThich.Location = new System.Drawing.Point(175, 152);
            this.txtIDSoThich.Multiline = true;
            this.txtIDSoThich.Name = "txtIDSoThich";
            this.txtIDSoThich.Size = new System.Drawing.Size(100, 29);
            this.txtIDSoThich.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Sở thích";
            // 
            // txtSoThich
            // 
            this.txtSoThich.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoThich.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoThich.Location = new System.Drawing.Point(175, 216);
            this.txtSoThich.Multiline = true;
            this.txtSoThich.Name = "txtSoThich";
            this.txtSoThich.Size = new System.Drawing.Size(129, 29);
            this.txtSoThich.TabIndex = 15;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(197, 352);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(87, 39);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgv_QLSoThich
            // 
            this.dgv_QLSoThich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_QLSoThich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_QLSoThich.Location = new System.Drawing.Point(420, 130);
            this.dgv_QLSoThich.Name = "dgv_QLSoThich";
            this.dgv_QLSoThich.RowHeadersWidth = 51;
            this.dgv_QLSoThich.RowTemplate.Height = 24;
            this.dgv_QLSoThich.Size = new System.Drawing.Size(495, 261);
            this.dgv_QLSoThich.TabIndex = 17;
            this.dgv_QLSoThich.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_QLSoThich_CellClick);
            // 
            // FormQLSoThich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 464);
            this.Controls.Add(this.dgv_QLSoThich);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSoThich);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIDSoThich);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label1);
            this.Name = "FormQLSoThich";
            this.Text = "FormQLSoThich";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QLSoThich)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIDSoThich;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoThich;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgv_QLSoThich;
    }
}