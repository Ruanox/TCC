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
    public partial class informacao : Form
    {
        public informacao()
        {
            InitializeComponent();
        }

        private void btn_professor_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void informacao_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            MessageBox.Show("Aluno cadastrado com sucesso!");
        }

        private void btn_info_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        login l = new login();
        private void button1_Click_1(object sender, EventArgs e)
        {
            l.setUsuario(txtbox_usuario.Text);
            l.setSenha(txtbox_senha.Text);
            l.consultarLogin();

            int valor = l.consultarLogin();
            if (valor == 1)
            {
                this.Hide();
                entrada_aluno asd = new entrada_aluno();
                asd.Show();
            }
            else
            {
                MessageBox.Show("usuario e senhas Invalidos", "acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_usuario_Click(object sender, EventArgs e)
        {

        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_principal asd = new Form_principal();
            asd.Show();
        }

        private void btn_voltar_menu_Click(object sender, EventArgs e)
        {
            Hide();
            Form_principal pingu = new Form_principal();
            pingu.Show();
        }
    }
}
