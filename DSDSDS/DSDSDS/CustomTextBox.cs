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
    public class CustomTextBox : TextBox
    {
        private int borderRadius = 10;
        private int borderSize = 1;

        private Color borderColor = Color.FromArgb(220, 220, 220);
        private Color focusBorderColor = Color.FromArgb(225, 30, 60);
        private Color placeholderColor = Color.Gray;

        private string placeholderText = "";
        private bool isFocused = false;

        [Category("Custom")]
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
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = Math.Max(0, value);
                Invalidate();
            }
        }

        [Category("Custom")]
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
        public Color FocusBorderColor
        {
            get => focusBorderColor;
            set
            {
                focusBorderColor = value;
                Invalidate();
            }
        }

        [Category("Custom")]
        public Color PlaceholderColor
        {
            get => placeholderColor;
            set
            {
                placeholderColor = value;
                Invalidate();
            }
        }

        [Category("Custom")]
        public string PlaceholderText
        {
            get => placeholderText;
            set
            {
                placeholderText = value;
                Invalidate();
            }
        }

        public CustomTextBox()
        {
            BorderStyle = BorderStyle.None;

            BackColor = Color.White;
            ForeColor = Color.FromArgb(40, 40, 40);

            Font = new Font(
                "Segoe UI",
                10F
            );

            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true
            );
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            UpdateRegion();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            UpdateRegion();
            Invalidate();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            isFocused = true;

            Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            isFocused = false;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode =
                SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(
                0,
                0,
                Width - 1,
                Height - 1
            );

            Color currentBorderColor =
                isFocused
                    ? focusBorderColor
                    : borderColor;

            using (GraphicsPath path =
                CreateRoundRectangle(
                    rect,
                    borderRadius))
            {
                // Fundo
                using (SolidBrush brush =
                    new SolidBrush(BackColor))
                {
                    e.Graphics.FillPath(
                        brush,
                        path
                    );
                }

                // Borda
                if (borderSize > 0)
                {
                    using (Pen pen =
                        new Pen(
                            currentBorderColor,
                            borderSize))
                    {
                        e.Graphics.DrawPath(
                            pen,
                            path
                        );
                    }
                }
            }

            // Placeholder
            if (string.IsNullOrEmpty(Text) &&
                !string.IsNullOrEmpty(placeholderText) &&
                !isFocused)
            {
                using (SolidBrush brush =
                    new SolidBrush(placeholderColor))
                {
                    e.Graphics.DrawString(
                        placeholderText,
                        Font,
                        brush,
                        10,
                        (Height - Font.Height) / 2
                    );
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
            if (Width <= 0 ||
                Height <= 0)
                return;

            using (GraphicsPath path =
                CreateRoundRectangle(
                    new Rectangle(
                        0,
                        0,
                        Width,
                        Height
                    ),
                    borderRadius))
            {
                Region = new Region(path);
            }
        }
    }
}
