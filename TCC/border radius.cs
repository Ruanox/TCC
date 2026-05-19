using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class BotaoArredondado : Button
{
    private int borderRadius = 35; // Ajuste o valor para mais/menos arredondamento

    protected override void OnPaint(PaintEventArgs e)
    {
        GraphicsPath path = new GraphicsPath();
        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

        // Cria o caminho com cantos arredondados
        path.AddArc(rect.X, rect.Y, borderRadius * 2, borderRadius * 2, 180, 90);
        path.AddArc(rect.Width - borderRadius * 2, rect.Y, borderRadius * 2, borderRadius * 2, 270, 90);
        path.AddArc(rect.Width - borderRadius * 2, rect.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
        path.AddArc(rect.X, rect.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
        path.CloseFigure();

        this.Region = new Region(path); // Define a região clicável
        base.OnPaint(e);
    }
}
