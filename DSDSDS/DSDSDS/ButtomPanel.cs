using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DSDSDS
{
    public class ButtonPanel : Panel
    {
        private int borderRadius = 12;
        private Color normalColor = Color.FromArgb(220, 30, 60);
        private Color hoverColor = Color.FromArgb(235, 50, 80);
        private Color pressedColor = Color.FromArgb(190, 20, 45);
        private Color borderColor = Color.Transparent;
        private int borderSize = 0;

        private bool mouseOver = false;
        private bool mouseDown = false;

        [Category("ButtonPanel")]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = Math.Max(0, value);
                UpdateRegion();
                Invalidate();
            }
        }

        [Category("ButtonPanel")]
        public Color NormalColor
        {
            get => normalColor;
            set
            {
                normalColor = value;
                Invalidate();
            }
        }

        [Category("ButtonPanel")]
        public Color HoverColor
        {
            get => hoverColor;
            set
            {
                hoverColor = value;
                Invalidate();
            }
        }

        [Category("ButtonPanel")]
        public Color PressedColor
        {
            get => pressedColor;
            set
            {
                pressedColor = value;
                Invalidate();
            }
        }

        [Category("ButtonPanel")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("ButtonPanel")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = Math.Max(0, value);
                Invalidate();
            }
        }

        public ButtonPanel()
        {
            DoubleBuffered = true;
            Cursor = Cursors.Hand;

            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true
            );

            BackColor = normalColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color currentColor;

            if (mouseDown)
                currentColor = pressedColor;
            else if (mouseOver)
                currentColor = hoverColor;
            else
                currentColor = normalColor;

            Rectangle rect = new Rectangle(
                0,
                0,
                Width - 1,
                Height - 1
            );

            using (GraphicsPath path = CreateRoundRectangle(
                rect,
                borderRadius))
            {
                using (SolidBrush brush =
                    new SolidBrush(currentColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                if (borderSize > 0 &&
                    borderColor != Color.Transparent)
                {
                    using (Pen pen =
                        new Pen(borderColor, borderSize))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            mouseOver = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            mouseOver = false;
            mouseDown = false;

            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
                Invalidate();
            }
        }

        private GraphicsPath CreateRoundRectangle(
            Rectangle rect,
            int radius)
        {
            GraphicsPath path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;

            if (diameter > rect.Width)
                diameter = rect.Width;

            if (diameter > rect.Height)
                diameter = rect.Height;

            path.AddArc(
                rect.X,
                rect.Y,
                diameter,
                diameter,
                180,
                90);

            path.AddArc(
                rect.Right - diameter,
                rect.Y,
                diameter,
                diameter,
                270,
                90);

            path.AddArc(
                rect.Right - diameter,
                rect.Bottom - diameter,
                diameter,
                diameter,
                0,
                90);

            path.AddArc(
                rect.X,
                rect.Bottom - diameter,
                diameter,
                diameter,
                90,
                90);

            path.CloseFigure();

            return path;
        }

        private void UpdateRegion()
        {
            if (Width <= 0 || Height <= 0)
                return;

            using (GraphicsPath path =
                CreateRoundRectangle(
                    new Rectangle(0, 0, Width, Height),
                    borderRadius))
            {
                Region = new Region(path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            UpdateRegion();
            Invalidate();
        }
    }
}
