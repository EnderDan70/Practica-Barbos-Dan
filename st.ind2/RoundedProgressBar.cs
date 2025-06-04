using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace st.ind2
{
    public partial class RoundedProgressBar : Control
    {
        private int minimum = 0;
        private int maximum = 100;
        private int value = 0;
        private Color barColor = Color.White;
        private Color trackColor = Color.FromArgb(220, 40, 40);
        private Color borderColor = Color.White;

        [Category("Behavior")]
        [DefaultValue(0)]
        public int Minimum
        {
            get => minimum;
            set
            {
                if (value < 0) value = 0;
                if (value > maximum) value = maximum;
                minimum = value;
                if (this.value < minimum) this.value = minimum;
                Invalidate();
            }
        }

        [Category("Behavior")]
        [DefaultValue(100)]
        public int Maximum
        {
            get => maximum;
            set
            {
                if (value < minimum) value = minimum;
                maximum = value;
                if (this.value > maximum) this.value = maximum;
                Invalidate();
            }
        }

        [Category("Behavior")]
        [DefaultValue(0)]
        public int Value
        {
            get => this.value;
            set
            {
                int v = Math.Max(minimum, Math.Min(maximum, value));
                if (this.value != v)
                {
                    this.value = v;
                    Invalidate();
                }
            }
        }

        [Category("Appearance")]
        public Color BarColor
        {
            get => barColor;
            set { barColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color TrackColor
        {
            get => trackColor;
            set { trackColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        public RoundedProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            this.Height = 14;
            this.Width = 300;
            this.MinimumSize = new Size(30, 10);
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int radius = this.Height - 2;
            Rectangle rect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);

            // Draw track (background)
            using (Brush trackBrush = new SolidBrush(trackColor))
            using (GraphicsPath trackPath = RoundedRect(rect, radius))
                g.FillPath(trackBrush, trackPath);

            // Draw progress
            float percent = (maximum > minimum) ? (float)(value - minimum) / (maximum - minimum) : 0f;
            int progressWidth = (int)(rect.Width * percent);
            if (progressWidth > 0)
            {
                Rectangle progressRect = new Rectangle(rect.X, rect.Y, progressWidth, rect.Height);
                using (Brush barBrush = new SolidBrush(barColor))
                using (GraphicsPath barPath = RoundedRect(progressRect, radius))
                    g.FillPath(barBrush, barPath);
            }

            // Draw border
            using (Pen pen = new Pen(borderColor, 1))
            using (GraphicsPath borderPath = RoundedRect(rect, radius))
                g.DrawPath(pen, borderPath);
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius;
            GraphicsPath path = new GraphicsPath();
            if (diameter > 0)
            {
                path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
                path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
                path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();
            }
            else
            {
                path.AddRectangle(bounds);
            }
            return path;
        }
    }
}
