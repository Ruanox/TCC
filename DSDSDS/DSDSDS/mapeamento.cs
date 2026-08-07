using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DSDSDS
{
    public partial class mapeamento : Form
    {
        List<aluninhos> alunos = new List<aluninhos>();

        aluninhos alunoSelecionado = null;

        bool arrastando = false;

        



        public mapeamento()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void mapeamento_Load(object sender, EventArgs e)
        {

        }

        private void AtualizarLista()
        {
            comboBox1.Items.Clear();

            foreach (aluninhos a in alunos)
                comboBox1.Items.Add(a.Nome);

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();

            if (nome == "")
                return;

            alunos.Add(new aluninhos(nome));

            AtualizarLista();

            txtNome.Clear();

            panelQuadra.Invalidate();
        }

    }
}
