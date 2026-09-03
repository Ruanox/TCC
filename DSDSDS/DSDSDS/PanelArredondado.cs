using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DSDSDS
{
    public class PanelArredondado : Panel
    {
        private int raio = 20;

        public int Raio
        {
            get => raio;
            set
            {
                raio = value;
                AtualizarRegiao();
                Invalidate();
            }
        }

        public Color CorBorda { get; set; } =
            Color.FromArgb(230, 230, 230);

        public int EspessuraBorda { get; set; } = 1;

        public PanelArredondado()
        {
            DoubleBuffered = true;

            BackColor = Color.White;

            Padding = new Padding(20);

            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true
            );

            AtualizarRegiao();
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);

            AtualizarRegiao();
            Invalidate();
        }

        private GraphicsPath CriarCaminho()
        {
            int r = Math.Min(Raio, Math.Min(Width, Height) / 2);

            Rectangle area = new Rectangle(
                0,
                0,
                Width - 1,
                Height - 1
            );

            GraphicsPath caminho = new GraphicsPath();

            caminho.AddArc(
                area.X,
                area.Y,
                r * 2,
                r * 2,
                180,
                90
            );

            caminho.AddArc(
                area.Right - r * 2,
                area.Y,
                r * 2,
                r * 2,
                270,
                90
            );

            caminho.AddArc(
                area.Right - r * 2,
                area.Bottom - r * 2,
                r * 2,
                r * 2,
                0,
                90
            );

            caminho.AddArc(
                area.X,
                area.Bottom - r * 2,
                r * 2,
                r * 2,
                90,
                90
            );

            caminho.CloseFigure();

            return caminho;
        }

        private void AtualizarRegiao()
        {
            if (Width <= 0 || Height <= 0)
                return;

            using (GraphicsPath caminho = CriarCaminho())
            {
                Region = new Region(caminho);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath caminho = CriarCaminho())
            {
                using (SolidBrush fundo =
                       new SolidBrush(BackColor))
                {
                    g.FillPath(fundo, caminho);
                }

                if (EspessuraBorda > 0)
                {
                    using (Pen borda =
                           new Pen(
                               CorBorda,
                               EspessuraBorda))
                    {
                        g.DrawPath(borda, caminho);
                    }
                }
            }
        }
    }
}