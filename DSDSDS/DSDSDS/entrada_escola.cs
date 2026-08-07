using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class entrada_escola : Form
    {
        public entrada_escola()
        {
            InitializeComponent();
        }

        private void entrada_escola_Load(object sender, EventArgs e)
        {

        }

        private void btn_escola_Click(object sender, EventArgs e)
        {
            entrada_escola k = new entrada_escola();
            k.Show();
        }
        inserir_professor ds = new inserir_professor();
        private void btn_pronto_Click(object sender, EventArgs e)
        {
            this.Hide();
            entrada_escola d = new entrada_escola();
            d.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Add_aluno nka = new Add_aluno();
            nka.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Add_prof_ asasas = new Add_prof_();
            asasas.Show();


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
