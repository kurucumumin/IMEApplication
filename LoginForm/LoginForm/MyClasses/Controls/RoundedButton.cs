

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LoginForm.MyClasses
{
    class RoundedButton : Button
    {
        [Description("Corner Radius"), Category("Data"), DefaultValue("1")]
        public int CornerRadius
        {
            get;
            set;
        } 
        //we can use this to modify the color of the border 
        public Color BorderColor = Color.LightGray;
        //we can use this to modify the border size
        public int BorderSize = 0;
        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.White;
            FlatAppearance.BorderColor = BorderColor;
            FlatAppearance.BorderSize = BorderSize;
            Font = new Font("VAGRounded-Light",
            30F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            ForeColor = Color.FromArgb(84, 33, 107);

            this.MouseDown += new MouseEventHandler(ButtonLastest_MouseDown);
            this.MouseUp += new MouseEventHandler(ButtonLastest_MouseUp);
        }

        void ButtonLastest_MouseUp(object sender, MouseEventArgs e)
        {
            ForeColor = Color.FromArgb(84, 33, 107);
            BackColor = Color.White;
        }

        void ButtonLastest_MouseDown(object sender, MouseEventArgs e)
        {
            BackColor = Color.FromArgb(84, 33, 107);
            ForeColor = Color.White;

        }
        int top;
        int left;
        int right;
        int bottom;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            // to draw the control using base OnPaint
            base.OnPaint(pevent);
            //to modify the corner radius
            int CornerRadius = this.CornerRadius;

            Pen DrawPen = new Pen(BorderColor);
            GraphicsPath gfxPath_mod = new GraphicsPath();

            top = 0;
            left = 0;
            right = Width;
            bottom = Height;

            gfxPath_mod.AddArc(left, top, CornerRadius, CornerRadius, 180, 90);
            gfxPath_mod.AddArc(right - CornerRadius, top, CornerRadius, CornerRadius, 270, 90);
            gfxPath_mod.AddArc(right - CornerRadius, bottom - CornerRadius,
                CornerRadius, CornerRadius, 0, 90);
            gfxPath_mod.AddArc(left, bottom - CornerRadius, CornerRadius, CornerRadius, 90, 90);

            gfxPath_mod.CloseAllFigures();

            pevent.Graphics.DrawPath(DrawPen, gfxPath_mod);

            int inside = 1;

            Pen newPen = new Pen(BorderColor, BorderSize);
            GraphicsPath gfxPath = new GraphicsPath();
            gfxPath.AddArc(left + inside + 1, top + inside, CornerRadius, CornerRadius, 180, 100);

            gfxPath.AddArc(right - CornerRadius - inside - 2,
                top + inside, CornerRadius, CornerRadius, 270, 90);
            gfxPath.AddArc(right - CornerRadius - inside - 2,
                bottom - CornerRadius - inside - 1, CornerRadius, CornerRadius, 0, 90);

            gfxPath.AddArc(left + inside + 2,
            bottom - CornerRadius - inside, CornerRadius, CornerRadius, 95, 95);
            pevent.Graphics.DrawPath(newPen, gfxPath);

            this.Region = new Region(gfxPath_mod);
        }
    }
}
