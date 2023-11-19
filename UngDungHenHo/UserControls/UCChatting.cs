using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Windows.Forms;
using UngDungHenHo.BS_layer;
using UngDungHenHo.models;
using UngDungHenHo;
using _21110713_PhamHuuTuan_Timer;
using System.Runtime.InteropServices.WindowsRuntime;

namespace UngDungHenHo.UserControls
{
    public partial class UCChatting : UserControl
    {
        int idDangNhap = 2;
        BLChatting blchat = new BLChatting();
        List<NguoiDung> listNguoiDungs = new List<NguoiDung>();
        private int idNguoiDungSelected = 0;
        List<TinNhan> listtinnhans = new List<TinNhan>();
        Thread thr = null;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer checkscroll = new System.Windows.Forms.Timer();

        
        public UCChatting()
        {
            InitializeComponent();
            timer.Interval = (100);
            timer.Tick += new EventHandler(timer1_Tick);
            checkscroll.Interval = (100);
            checkscroll.Tick += new EventHandler(Timer_scroll_check);
            
            AddScrollBar(this.pnlNguoiDung);
            AddScrollBar(this.pnlChatContent);
            LoadNguoiDung();     
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparams = base.CreateParams;
                handleparams.ExStyle |= 0x02000000;
                return handleparams;
            }
        }
        public Panel TaoNguoiDung(int index, string ten, Point loc,object heximg)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(268, 89);
            Label lbl = new Label();
            PictureBox pictureBox = new PictureBox();

            lbl.Text = ten;
            lbl.Font = new Font("MS Reference Sans Serif", 8.0f, FontStyle.Bold);
            lbl.Location = new Point(94, 34);
            pictureBox.Location = new Point(10, 14);
            pictureBox.Size = new Size(60,60);
            if(heximg !=DBNull.Value)
            {
                byte[] HinhAnh = (byte[])heximg;
                using (MemoryStream ms = new MemoryStream(HinhAnh))
                {
                    Image hinhAnh = Image.FromStream(ms);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Image = hinhAnh;
                }
            }
            
            lbl.AutoSize = true;
            lbl.Tag=index;
            pnl.Tag = index;
            pictureBox.Tag = index;
            pnl.Location = loc;
            pnl.BackColor = Color.FromArgb(252, 252, 252);
            lbl.Click += new EventHandler(NguoiDung_Click);
            pictureBox.Click += new EventHandler(NguoiDung_Click);
            pnl.Click += new EventHandler(NguoiDung_Click);
            pnl.Cursor = Cursors.Hand;
            lbl.Cursor = Cursors.Hand;
            pictureBox.Cursor = Cursors.Hand;
            pnl.MouseMove += new MouseEventHandler(NguoiDung_MouseMove);
            pictureBox.MouseMove += new MouseEventHandler(NguoiDung_MouseMove);
            lbl.MouseMove += new MouseEventHandler(NguoiDung_MouseMove);
            pnl.MouseLeave += new EventHandler(NguoiDung_MouseLeave);
            pictureBox.MouseLeave += new EventHandler(NguoiDung_MouseLeave);

            pnl.Controls.Add(lbl);
            pnl.Controls.Add(pictureBox);
            return pnl;
        }
        private void NguoiDung_Click(object sender, EventArgs e)
        {
            if(thr != null && thr.IsAlive)
            {
                thr.Abort();
            }   
            setSelected(sender, Color.FromArgb(173, 173, 173), this.pnlNguoiDungs);
            if (sender is Label)
            {
                this.idNguoiDungSelected = int.Parse((sender as Label).Tag.ToString());
            }
            else if (sender is PictureBox) {
                this.idNguoiDungSelected = int.Parse((sender as PictureBox).Tag.ToString());
            }
            else
            {
                this.idNguoiDungSelected = int.Parse((sender as Panel).Tag.ToString());
            }
            this.pnlChatContent.Controls.Clear();
            
            this.lblTenNguoiChat.Text = this.listNguoiDungs[this.idNguoiDungSelected].Name.ToString();
            
            if (timer.Enabled)
            {
                timer.Stop();
            }
            if (checkscroll.Enabled)
            {
                checkscroll.Stop();
            }
            checkscroll.Start();
            timer.Start();
            
        }
        private void pnlChatContent_Scroll()
        {

        }
        private void NguoiDung_MouseMove(object sender, MouseEventArgs e)
        {
            Change_StateHover(sender, true, Color.FromArgb(173, 173, 173), Color.FromArgb(224, 222, 222),Color.FromArgb(255,255,255));

        }
        private void NguoiDung_MouseLeave(object sender , EventArgs e)
        {
            Change_StateHover(sender, false, Color.FromArgb(173, 173, 173), Color.FromArgb(224, 222, 222), Color.FromArgb(255, 255, 255));
        }
        public void LoadNguoiDung()
        {
            listNguoiDungs.Clear();
            this.pnlNguoiDungs.Controls.Clear();
            DataTable dt = blchat.LoadNguoiDung();
            int index = 0;
            int indexvitri = 0;
            foreach (DataRow dr in dt.Rows)
            {
                int id =int.Parse(dr["ID_NguoiDung"].ToString());
                string ten = dr["HoTen"].ToString();
                NguoiDung nd = new NguoiDung(id, ten);
                if (index+1 != idDangNhap)
                {
                    Panel ndpnl = TaoNguoiDung(index, ten, new Point(0, (89 + 5) * indexvitri), dr["AnhDaiDien"]);
                    this.pnlNguoiDungs.Controls.Add(ndpnl);
                    indexvitri++;
                }
                listNguoiDungs.Add(nd);
                index++;
            }
            dt.Dispose();
        }
        private Panel TaoTinNhan(int index, string content, Color color, int pre_height, int margin, int type, string datetime)
        {
            Panel pnl = new Panel();
            Label lbl = new Label();
            Label time = new Label();
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(time);
            lbl.Text = content;
            lbl.Tag = index;
            lbl.BackColor = color;
            lbl.MaximumSize = new Size(400, int.MaxValue);
            lbl.Font = new Font("MS Reference Sans Serif", 10.2f, FontStyle.Bold);
            time.Text = datetime;
            time.Tag = index;
            time.BackColor = Color.Transparent;
            time.AutoSize = true;
            time.ForeColor = Color.FromArgb(131, 132, 133);
            pnl.AutoSize = true;
            lbl.AutoSize = true;
            time.AutoSize = true;
            pnl.Size = new Size(lbl.MaximumSize.Width + lbl.Size.Width, lbl.Size.Height);
            if (type == 1)
            {
                pnl.Location = new Point(16, pre_height + margin * index);
                lbl.Location = new Point(0, 0);
                time.Location = new Point(lbl.Location.X + lbl.Size.Width + 5, lbl.Location.Y);
            }

            else if (type == 0)
            {
                pnl.Location = new Point(this.pnlChatContent.Width - pnl.Size.Width - 22 - 16, pre_height + margin * index);
                lbl.Location = new Point(pnl.Size.Width - lbl.Size.Width, 0);
                time.Location = new Point(lbl.Location.X - time.Size.Width - 5, lbl.Location.Y);
            }

            return pnl;
        }

        public void loadDoanChat()
        {

            int id_gui = idDangNhap;
            int id_nhan = this.idNguoiDungSelected + 1;
            this.listtinnhans.Clear();
            this.pnlChatContent.Controls.Clear();
            DataTable tingui = blchat.LayNoiDungTinNhan(id_gui, id_nhan);
            DataTable tinnhan = blchat.LayNoiDungTinNhan(id_nhan, id_gui);
            DataTable doanchat = new DataTable();
            doanchat.Merge(tingui);
            doanchat.Merge(tinnhan);
            DataView dv = new DataView(doanchat);
            dv.Sort = "ID_TinNhan";
            DataTable res = dv.ToTable();
            int index = 0;
            int currentHeight = 0;

            foreach (DataRow dr in res.Rows)
            {
                Panel tin = null;
                if ((int.Parse(dr["ID_NguoiGui"].ToString())) == id_gui && (int.Parse(dr["ID_NguoiNhan"].ToString()) == id_nhan))
                {
                    tin = TaoTinNhan(index, dr["NoiDung"].ToString(), Color.FromArgb(72, 160, 232), currentHeight, 10, 0, DateTime.Parse(dr["ThoiGianGui"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else if ((int.Parse(dr["ID_NguoiGui"].ToString()) == id_nhan) && (int.Parse(dr["ID_NguoiNhan"].ToString()) == id_gui))
                {
                    tin = TaoTinNhan(index, dr["NoiDung"].ToString(), Color.FromArgb(201, 201, 201), currentHeight, 10, 1, DateTime.Parse(dr["ThoiGianGui"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                currentHeight += tin.Size.Height;
                index++;
                
                this.pnlChatContent.Invoke(new MethodInvoker(() =>
                {
                    pnlChatContent.Controls.Add(tin);
                }));

            }
            this.pnlChatContent.Invoke(new MethodInvoker(() =>
            {
                pnlChatContent.VerticalScroll.Value = pnlChatContent.VerticalScroll.Maximum;
                if (pnlChatContent.Controls.Count >= 1)
                {
                    pnlChatContent.ScrollControlIntoView(pnlChatContent.Controls[pnlChatContent.Controls.Count - 1]);
                }
            }));
            tingui.Dispose();
            tinnhan.Dispose();
            doanchat.Dispose();
            res.Dispose();
        }
        
        private void btnSendMessages_Click(object sender, EventArgs e)
        {
            string noidung = this.rtxtEnterContentChat.Text;
            this.rtxtEnterContentChat.ResetText();
            string err = "";
            if(noidung.Trim() != "")
            {
                blchat.ThemTinNhan(idDangNhap, idNguoiDungSelected+1, DateTime.Now, noidung, ref err);
            }
            else
            {
                return;
            }
        }
        public void AddScrollBar(Panel pnl)
        {
            VScrollBar vsb = new VScrollBar();
            vsb.Dock = DockStyle.Right;
            vsb.Visible = false;
            pnl.Controls.Add(vsb);

        }
        private Panel GetParentPanel(object sender)
        {
            Panel par;
            if (sender is PictureBox)
            {
                par = ((PictureBox)sender).Parent as Panel;
            }
            else if (sender is Label)
            {
                par = ((Label)sender).Parent as Panel;
            }
            else
            {
                par = (Panel)sender;
            }
            return par;
        }
        private void Change_StateHover(object sender, bool state, Color currColor, Color color1, Color color2)
        {
            Panel par = GetParentPanel(sender);

            if (par.BackColor != currColor)
            {
                if (state == true)
                {
                    par.BackColor = color1;
                }
                else
                {
                    par.BackColor = color2;
                }

            }
        }
        private void setSelected(object sender, Color BackColor, Panel rootPanel)
        {
            Panel par = GetParentPanel(sender);

            foreach (Control pnl in rootPanel.Controls)
            {
                if (pnl is Panel)
                {
                    pnl.BackColor = Color.Transparent;

                }

            }
            par.BackColor = BackColor;
        }

        private void UCChatting_VisibleChanged(object sender, EventArgs e)
        {
           
            if (this.Visible == false)
            {
                if(thr != null && thr.IsAlive)
                {
                    thr.Join();
                }
                if (timer.Enabled)
                {
                    timer.Dispose();
                }
                if (checkscroll.Enabled)
                {
                    checkscroll.Dispose();
                }
                foreach (Control control in this.Controls)
                {
                    control.Dispose();
                }
                this.Controls.Clear();
               
            }
        }

        private void pnlChatContent_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void Timer_scroll_check(object sender, EventArgs e)
        {

            if (this.pnlChatContent.VerticalScroll.Visible)
            {
                int currentScrollPosition = pnlChatContent.VerticalScroll.Value;
                int lastLocationScrollbar = pnlChatContent.VerticalScroll.Maximum - pnlChatContent.VerticalScroll.LargeChange + 1;

                if (currentScrollPosition == lastLocationScrollbar)
                {
                    timer.Start();
                }
                else
                {
                    timer.Stop();
                }
            }
            else
            {
                timer.Start();
            }

           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            loadDoanChat();
        }
    }
}
