using System;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class Add_prof_ : Form
    {
        inserir_professor ds = new inserir_professor();

        public Add_prof_()
        {
            InitializeComponent();
        }

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
                ds.setRua(txtxbox_rua.Text);
                ds.setCidade(txtbox_Cidade.Text);
                ds.setEstado(txtbox_Estado.Text);
                ds.setNum_casa(int.Parse(txtbox_numCasa.Text));

                ds.inserir();

                MessageBox.Show(
                    "Professor cadastrado com sucesso!!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao cadastrar professor:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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

        private void btn_view_Click(object sender, EventArgs e)
        {
            Hide();

            ver_professores paparazi = new ver_professores();
            paparazi.Show();
        }

        private void btn_trash_Click(object sender, EventArgs e)
        {
            Hide();

            excluir_professor ss = new excluir_professor();
            ss.Show();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Hide();

            edit_professor ad = new edit_professor();
            ad.Show();
        }
    }
}