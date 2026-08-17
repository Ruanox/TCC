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
    public class CustomPanel : Panel
    {
        private int borderRadius = 15;
        private int shadowSize = 8;
        private Color shadowColor = Color.FromArgb(35, 0, 0, 0);
        private Color borderColor = Color.Transparent;
        private int borderSize = 0;

        [Category("Custom")]
        [Description("Define o arredondamento dos cantos.")]
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

        [Category("Custom")]
        [Description("Define o tamanho da sombra.")]
        public int ShadowSize
        {
            get => shadowSize;
            set
            {
                shadowSize = Math.Max(0, value);
                Invalidate();
            }
        }

        [Category("Custom")]
        [Description("Define a cor da sombra.")]
        public Color ShadowColor
        {
            get => shadowColor;
            set
            {
                shadowColor = value;
                Invalidate();
            }
        }

        [Category("Custom")]
        [Description("Define a cor da borda.")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("Custom")]
        [Description("Define a espessura da borda.")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = Math.Max(0, value);
                Invalidate();
            }
        }

        public CustomPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;

            BackColor = Color.White;

            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true
            );
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Área do painel
            Rectangle rect = new Rectangle(
                ShadowSize,
                ShadowSize,
                Width - ShadowSize * 2 - 1,
                Height - ShadowSize * 2 - 1
            );

            if (rect.Width <= 0 || rect.Height <= 0)
                return;

            // SOMBRA
            if (ShadowSize > 0)
            {
                Rectangle shadowRect = new Rectangle(
                    rect.X + 3,
                    rect.Y + 4,
                    rect.Width,
                    rect.Height
                );

                using (GraphicsPath shadowPath =
                    CreateRoundRectangle(shadowRect, BorderRadius))
                using (SolidBrush shadowBrush =
                    new SolidBrush(ShadowColor))
                {
                    g.FillPath(shadowBrush, shadowPath);
                }
            }

            // PAINEL
            using (GraphicsPath path =
                CreateRoundRectangle(rect, BorderRadius))
            using (SolidBrush brush =
                new SolidBrush(BackColor))
            {
                g.FillPath(brush, path);

                // BORDA
                if (BorderSize > 0 &&
                    BorderColor != Color.Transparent)
                {
                    using (Pen pen =
                        new Pen(BorderColor, BorderSize))
                    {
                        g.DrawPath(pen, path);
                    }
                }
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
                90
            );

            path.AddArc(
                rect.Right - diameter,
                rect.Y,
                diameter,
                diameter,
                270,
                90
            );

            path.AddArc(
                rect.Right - diameter,
                rect.Bottom - diameter,
                diameter,
                diameter,
                0,
                90
            );

            path.AddArc(
                rect.X,
                rect.Bottom - diameter,
                diameter,
                diameter,
                90,
                90
            );

            path.CloseFigure();

            return path;
        }

        private void UpdateRegion()
        {
            if (Width <= 0 || Height <= 0)
                return;

            using (GraphicsPath path =
                CreateRoundRectangle(
                    new Rectangle(
                        0,
                        0,
                        Width,
                        Height
                    ),
                    BorderRadius))
            {
                Region = new Region(path);
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);

            UpdateRegion();
            Invalidate();
        }
    }
}
