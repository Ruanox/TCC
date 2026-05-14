using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class frm_cadastrar : Form
    {
        public frm_cadastrar()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_aluno_Click(object sender, EventArgs e)
        {
            this.Hide();
            aluno aluno = new aluno();
            aluno.Show();


        }

        private void btn_professor_Click(object sender, EventArgs e)
        {
            this.Hide();
            professor professor = new professor();
            professor.Show();
        }

        private void frm_cadastrar_Load(object sender, EventArgs e)
        {

        }
    }
}
