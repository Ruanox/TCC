using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DSDSDS
{
    public class aluninhos
    {
        public string Nome { get; set; }
        public string PosicaoTatica { get; set; }
        public Point Posicao { get; set; }

        public aluninhos(string nome)
        {
            Nome = nome;
            PosicaoTatica = "";
            Posicao = new Point(100, 100);
        }
    }
}
