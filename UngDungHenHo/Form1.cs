using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UngDungHenHo.UserControls;

namespace UngDungHenHo
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private void SetSelected(object sender)
        {
            foreach(Control ctr in pnlHeader.Controls)
            {
                if(ctr is IconPictureBox)
                {
                    ((IconPictureBox)ctr).ForeColor = Color.FromArgb(184, 184, 184);
                }
            }
            ((IconPictureBox)sender).ForeColor = Color.FromArgb(66, 66, 66);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SetSelected(sender);
            this.pnlBody.Controls.Clear();
            SetSelected(sender);
        }

        private void btnChatting_Click(object sender, EventArgs e)
        {
            SetSelected(sender);
            this.pnlBody.Controls.Clear();
            this.pnlBody.Controls.Add(new UCChatting());
        }

        private void btnFinding_Click(object sender, EventArgs e)
        {
            SetSelected(sender);
            this.pnlBody.Controls.Clear();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            SetSelected(sender);
            this.pnlBody.Controls.Clear();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            SetSelected(sender);
            this.pnlBody.Controls.Clear();
        }
        private void ChangeStatehover(object sender, bool state, Color currColor)
        {
            IconPictureBox icp = sender as IconPictureBox;
            if(icp.ForeColor != currColor)
            {
                if(state==true)
                {
                    icp.ForeColor = Color.FromArgb(130, 129, 129);
                }else
                {
                    icp.ForeColor = Color.FromArgb(184, 184, 184);
                }
            }
        }
        private void Menu_MouseLeave(object sender, EventArgs e)
        {

            ChangeStatehover(sender, false, Color.FromArgb(66, 66, 66));
        }

        private void Menu_Hover(object sender, MouseEventArgs e)
        {
            ChangeStatehover(sender, true, Color.FromArgb(66, 66, 66));
        }
    }
}
