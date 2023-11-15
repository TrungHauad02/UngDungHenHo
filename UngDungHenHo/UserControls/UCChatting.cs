using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungHenHo.BS_layer;
using UngDungHenHo.models;

namespace UngDungHenHo.UserControls
{
    public partial class UCChatting : UserControl
    {
        int idDangNhap = 2;
        BLChatting blchat = new BLChatting();
        List<NguoiDung> listNguoiDungs = new List<NguoiDung>();
        private int idNguoiDungSelected = 0;
        List<TinNhan> listtinnhans = new List<TinNhan>();
        public UCChatting()
        {
            InitializeComponent();
            AddScrollBar(this.pnlNguoiDungs);
            AddScrollBar(this.pnlChatContent);
           
            LoadNguoiDung();
            
        }
        private Label TaoTinNhan(int index, string content, Color color,int pre_height,int margin,int type)
        {
            Label lbl = new Label();
            lbl.Text = content;
            lbl.Tag = index;
            lbl.BackColor = color;
            lbl.MaximumSize = new Size(400, int.MaxValue); 
            lbl.Font = new Font("MS Reference Sans Serif", 10.2f, FontStyle.Bold);
            Size textSize = TextRenderer.MeasureText(lbl.Text, lbl.Font, lbl.MaximumSize, TextFormatFlags.WordBreak);
            lbl.AutoSize = true;
            lbl.Size = textSize;
     
            if (type == 1)
            {
                lbl.Location = new Point(16, pre_height + (margin)*index);
            }
            else if(type == 0)
            {
                lbl.Location = new Point(this.pnlChatContent.Width - lbl.Size.Width-22-16, pre_height + (margin ) * index);
            }
            return lbl;
        }
        
        public Panel TaoNguoiDung(int index, string ten, Point loc)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(268, 89);
            Label lbl = new Label();
            lbl.Text = ten;
            lbl.Font = new Font("MS Reference Sans Serif", 8.0f, FontStyle.Bold);
            lbl.Location = new Point(94, 34);
            lbl.AutoSize = true;
            lbl.Tag=index;
            pnl.Tag = index;
            pnl.Location = loc;
            pnl.BackColor = Color.FromArgb(252, 252, 252);
            lbl.Click += new EventHandler(NguoiDung_Click);
            pnl.Click += new EventHandler(NguoiDung_Click);
            pnl.Cursor = Cursors.Hand;
            lbl.Cursor = Cursors.Hand;
            pnl.MouseMove += new MouseEventHandler(NguoiDung_MouseMove);
            lbl.MouseMove += new MouseEventHandler(NguoiDung_MouseMove);
            pnl.MouseLeave += new EventHandler(NguoiDung_MouseLeave);

            pnl.Controls.Add(lbl);
            return pnl;
        }
        private void NguoiDung_Click(object sender, EventArgs e)
        {
            
            setSelected(sender, Color.FromArgb(173, 173, 173), this.pnlNguoiDungs);
            if(sender is Label)
            {
                this.idNguoiDungSelected = int.Parse((sender as Label).Tag.ToString());
            }
            else
            {
                this.idNguoiDungSelected = int.Parse((sender as Panel).Tag.ToString());
            }
            this.pnlChatContent.Controls.Clear();
            this.lblTenNguoiChat.Text = this.listNguoiDungs[ this.idNguoiDungSelected].Name.ToString();

            loadDoanChat(idDangNhap, this.idNguoiDungSelected+1);
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
                    Panel ndpnl = TaoNguoiDung(index, ten, new Point(0, (89 + 5) * indexvitri));
                    this.pnlNguoiDungs.Controls.Add(ndpnl);
                    indexvitri++;
                }
                listNguoiDungs.Add(nd);
               
                index++;
            }
            dt.Dispose();
        }
        public void loadDoanChat(int id_gui, int id_nhan)
        {
            this.listtinnhans.Clear();
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
            foreach(DataRow dr in res.Rows)
            {
                Label tin = null;
                if ((int.Parse(dr["ID_NguoiGui"].ToString())) == id_gui && (int.Parse(dr["ID_NguoiNhan"].ToString()) == id_nhan ))
                {
                    tin = TaoTinNhan(index, dr["NoiDung"].ToString(), Color.FromArgb(72, 160, 232), currentHeight, 10, 0);
                }
                else if ((int.Parse(dr["ID_NguoiGui"].ToString()) == id_nhan) && (int.Parse(dr["ID_NguoiNhan"].ToString()) == id_gui))
                {   
                    tin = TaoTinNhan(index, dr["NoiDung"].ToString(), Color.FromArgb(201, 201, 201), currentHeight, 10, 1);
                }
                currentHeight += tin.Height;
                index++;
                this.pnlChatContent.Controls.Add(tin);
                
            }
            pnlChatContent.VerticalScroll.Value = pnlChatContent.VerticalScroll.Maximum;
            if (pnlChatContent.Controls.Count >= 1){
                pnlChatContent.ScrollControlIntoView(pnlChatContent.Controls[pnlChatContent.Controls.Count - 1]);
            }
            tingui.Dispose();
            tinnhan.Dispose();
            doanchat.Dispose();
            res.Dispose();
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
            if (sender is IconPictureBox)
            {
                par = ((IconPictureBox)sender).Parent as Panel;
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
    }
}
