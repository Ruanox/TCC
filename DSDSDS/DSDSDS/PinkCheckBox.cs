using System.Drawing;
using System.Windows.Forms;

namespace DSDSDS
{
    public class PinkCheckBox : CheckBox
    {
        public PinkCheckBox()
        {
            this.Appearance = Appearance.Normal;
            this.AutoSize = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.DoubleBuffered = true;

            this.Width = 100;
            this.Height = 25;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            int tamanho = 18;

            Rectangle caixa = new Rectangle(
                0,
                (this.Height - tamanho) / 2,
                tamanho,
                tamanho
            );

            if (this.Checked)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(255, 31, 75)))
                {
                    e.Graphics.FillRectangle(brush, caixa);
                }

                using (Pen pen = new Pen(Color.White, 2))
                {
                    e.Graphics.DrawLine(
                        pen,
                        caixa.X + 4,
                        caixa.Y + 9,
                        caixa.X + 8,
                        caixa.Y + 13
                    );

                    e.Graphics.DrawLine(
                        pen,
                        caixa.X + 8,
                        caixa.Y + 13,
                        caixa.X + 15,
                        caixa.Y + 5
                    );
                }
            }
            else
            {
                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    e.Graphics.DrawRectangle(pen, caixa);
                }
            }

            using (Brush brush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.DrawString(
                    this.Text,
                    this.Font,
                    brush,
                    tamanho + 8,
                    (this.Height - this.Font.Height) / 2
                );
            }
        }
    }
}