using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UngDungHenHo.Custom_Control
{
    internal class PictureBox_Custom : PictureBox
    {
        int wh = 50;
        public int BorderRadius
        {
            get { return this.wh; }
            set { this.wh = value; this.Invalidate(); }
        }
        public PictureBox_Custom()
        {

        }
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            GraphicsPath gp = new GraphicsPath();
            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);
            if (wh > 2)
            {
                using (GraphicsPath pathsf = GetFigurePath(rectSurface, wh))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, wh))
                using (Pen pensf = new Pen(this.Parent.BackColor, 2))

                {

                    this.Region = new Region(pathsf);
                    e.Graphics.DrawPath(pensf, pathsf);
                }
            }
            else
            {
                this.Region = new Region(rectSurface);

            }
        }
    }
}
