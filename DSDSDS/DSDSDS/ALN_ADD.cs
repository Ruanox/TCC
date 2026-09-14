using System;
using System.Globalization;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class ALN_ADD : Form
    {
        inserir_aluno pu = new inserir_aluno();
        controle_modalidade controle = new controle_modalidade();

        public ALN_ADD()
        {
            InitializeComponent();
            panel_resp.Visible = false;
        }

        private void btn_pronto_Click(object sender, EventArgs e)
        {
            DateTime dataNascimento;

            if (!DateTime.TryParseExact(
                txtbox_aniversario.Text,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dataNascimento))
            {
                MessageBox.Show(
                    "Digite uma data de nascimento válida.\n\nExemplo: 15/08/2010",
                    "Data inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtbox_aniversario.Focus();
                return;
            }

            if (dataNascimento > DateTime.Today)
            {
                MessageBox.Show(
                    "A data de nascimento não pode ser uma data futura.",
                    "Data inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtbox_aniversario.Focus();
                return;
            }

            if (!VerificarModalidade(dataNascimento))
            {
                return;
            }

            int idade = CalcularIdade(dataNascimento);

            if (idade < 18)
            {
                panel_resp.Visible = true;

                MessageBox.Show(
                    "O aluno é menor de idade.\n\nPreencha os dados do responsável.",
                    "Responsável necessário",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            panel_resp.Visible = false;

            CadastrarAluno();
        }

        private bool VerificarModalidade(DateTime dataNascimento)
        {
            string mensagem;

            bool permitido = controle.VerificarCadastro(
                1,
                dataNascimento,
                out mensagem
            );

            if (!permitido)
            {
                MessageBox.Show(
                    mensagem,
                    "Cadastro não permitido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            return true;
        }

        private int CalcularIdade(DateTime dataNascimento)
        {
            DateTime hoje = DateTime.Today;

            int idade = hoje.Year - dataNascimento.Year;

            if (dataNascimento.Date > hoje.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }

        private void CadastrarAluno()
        {
            try
            {
                DateTime dataNascimento;

                if (!DateTime.TryParseExact(
                    txtbox_aniversario.Text,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dataNascimento))
                {
                    MessageBox.Show(
                        "Digite uma data de nascimento válida.",
                        "Data inválida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtbox_aniversario.Focus();
                    return;
                }

                if (dataNascimento > DateTime.Today)
                {
                    MessageBox.Show(
                        "A data de nascimento não pode ser uma data futura.",
                        "Data inválida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtbox_aniversario.Focus();
                    return;
                }

                pu.setUsuario(txtbox_nome.Text);
                pu.setData_nasc(dataNascimento);
                pu.setCpf(txtbox_cpf.Text);
                pu.setSenha(txtbox_senha.Text);
                pu.setBairro(txtbox_bairro.Text);
                pu.setRua(txtbox_rua.Text);

                if (!int.TryParse(txtbox_numCasa.Text, out int numCasa))
                {
                    MessageBox.Show(
                        "Digite um número de casa válido.",
                        "Número inválido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtbox_numCasa.Focus();
                    return;
                }

                pu.setNumCasa(numCasa);
                pu.setTelefone(txtbox_telefone.Text);

                if (!decimal.TryParse(
                    txtbox_Peso.Text,
                    NumberStyles.Any,
                    CultureInfo.CurrentCulture,
                    out decimal peso))
                {
                    MessageBox.Show(
                        "Digite um peso válido.",
                        "Peso inválido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtbox_Peso.Focus();
                    return;
                }

                if (!decimal.TryParse(
                    txtbox_Altura.Text,
                    NumberStyles.Any,
                    CultureInfo.CurrentCulture,
                    out decimal altura))
                {
                    MessageBox.Show(
                        "Digite uma altura válida.",
                        "Altura inválida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtbox_Altura.Focus();
                    return;
                }

                pu.setPeso(peso);
                pu.setAltura(altura);

                pu.setNomeResponsavel(txtbox_nome_resp.Text);
                pu.setCpfResponsavel(txtbox_cpf_resp.Text);
                pu.setTelefoneResp(txtbox_tel_resp.Text);

                pu.inserir();

                MessageBox.Show(
                    "Aluno cadastrado com sucesso!!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimparCampos();

                panel_resp.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocorreu um erro ao cadastrar:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            DateTime dataNascimento;

            if (!DateTime.TryParseExact(
                txtbox_aniversario.Text,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dataNascimento))
            {
                MessageBox.Show(
                    "Digite uma data de nascimento válida.",
                    "Data inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtbox_aniversario.Focus();
                return;
            }

            if (dataNascimento > DateTime.Today)
            {
                MessageBox.Show(
                    "A data de nascimento não pode ser uma data futura.",
                    "Data inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtbox_aniversario.Focus();
                return;
            }

            if (!VerificarModalidade(dataNascimento))
            {
                return;
            }

            int idade = CalcularIdade(dataNascimento);

            if (idade < 18)
            {
                if (string.IsNullOrWhiteSpace(txtbox_nome_resp.Text))
                {
                    MessageBox.Show(
                        "Digite o nome do responsável.",
                        "Campo obrigatório",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtbox_nome_resp.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtbox_cpf_resp.Text))
                {
                    MessageBox.Show(
                        "Digite o CPF do responsável.",
                        "Campo obrigatório",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtbox_cpf_resp.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtbox_tel_resp.Text))
                {
                    MessageBox.Show(
                        "Digite o telefone do responsável.",
                        "Campo obrigatório",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtbox_tel_resp.Focus();
                    return;
                }
            }

            CadastrarAluno();
        }

        private void LimparCampos()
        {
            txtbox_nome.Clear();
            txtbox_cpf.Clear();
            txtbox_senha.Clear();
            txtbox_bairro.Clear();
            txtbox_aniversario.Clear();

            txtbox_nome_resp.Clear();
            txtbox_cpf_resp.Clear();
            txtbox_tel_resp.Clear();
            txtbox_rua.Clear();
            txtbox_numCasa.Clear();
            txtbox_telefone.Clear();

            txtbox_Peso.Clear();
            txtbox_Altura.Clear();
        }

        private void btn_voltar_menu_Click(object sender, EventArgs e)
        {
            Hide();

            entrada_escola freefire = new entrada_escola();

            freefire.Show();
        }

        private void txtbox_tel_TextChanged(object sender, EventArgs e)
        {
        }

        private void circularPanel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lbl_tel_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btn_opcoes_Click(object sender, EventArgs e)
        {
        }

        private void txtbox_idade_TextChanged(object sender, EventArgs e)
        {
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            Hide();

            View_aluno las = new View_aluno();
            las.Show();
        }

        private void btn_trash_Click(object sender, EventArgs e)
        {
            Hide();

            excluir_aluno ds = new excluir_aluno();
            ds.Show();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Hide();

            editar_aluno asd = new editar_aluno();
            asd.Show();
        }

        private void ALN_ADD_Load(object sender, EventArgs e)
        {
        }
    }
}