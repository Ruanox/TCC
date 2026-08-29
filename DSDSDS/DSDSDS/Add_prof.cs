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
    public partial class Add_prof_ : Form
    {
        public Add_prof_()
        {
            InitializeComponent();
        }
        inserir_professor ds = new inserir_professor();
        private void btn_pronto_Click(object sender, EventArgs e)
        {
            try
            {
                ds.setUsuario(txtbox_nome.Text);
                ds.setSenha(txtbox_senha.Text);
                ds.setCpf(long.Parse(txtbox_cpf.Text));
                ds.setBairro(txtbox_bairro.Text);
                ds.setEmail(txtbox_email.Text);
                ds.setTelefone(txtbox_tel.Text);
                ds.inserir();
            }

            finally
            {
                MessageBox.Show("Professor cadastrado com sucesso!!");
            }
        }

        private void Add_prof__Load(object sender, EventArgs e)
        {

        }

        private void buttonPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_voltar_menu_Click(object sender, EventArgs e)
        {
            Hide();
            entrada_escola jamilson = new entrada_escola();
            jamilson.Show();
        }

        private void btn_opcoes_Click(object sender, EventArgs e)
        {
         

        }
    }
}
