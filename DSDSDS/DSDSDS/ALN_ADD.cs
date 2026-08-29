using System;
using System.Globalization;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class ALN_ADD : Form
    {
        inserir_aluno pu = new inserir_aluno();

        public ALN_ADD()
        {
            InitializeComponent();

            // O painel do responsável começa escondido
            panel_resp.Visible = false;
        }

        // =========================================================
        // BOTÃO PRONTO
        // Verifica a data e decide se precisa mostrar o responsável
        // =========================================================
        private void btn_pronto_Click(object sender, EventArgs e)
        {
            DateTime dataNascimento;

            // Verifica se a data foi preenchida corretamente
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

            // Impede datas futuras
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

            // Calcula a idade
            int idade = CalcularIdade(dataNascimento);

            // Se for menor de 18 anos
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

            // Se for maior de idade
            panel_resp.Visible = false;

            CadastrarAluno();
        }


        // =========================================================
        // CALCULA A IDADE ATRAVÉS DA DATA DE NASCIMENTO
        // =========================================================
        private int CalcularIdade(DateTime dataNascimento)
        {
            DateTime hoje = DateTime.Today;

            int idade = hoje.Year - dataNascimento.Year;

            // Verifica se a pessoa já fez aniversário neste ano
            if (dataNascimento.Date > hoje.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }


        // =========================================================
        // CADASTRAR ALUNO
        // =========================================================
        private void CadastrarAluno()
        {
            try
            {
                DateTime dataNascimento;

                // Verifica novamente a data
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

                // Impede datas futuras
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


                // =================================================
                // DADOS DO ALUNO
                // =================================================

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

                // =================================================
                // DADOS DO RESPONSÁVEL
                // =================================================

                pu.setNomeResponsavel(txtbox_nome_resp.Text);
                pu.setCpfResponsavel(txtbox_cpf_resp.Text);
                pu.setTelefoneResponsavel(txtbox_tel_resp.Text);


                // =================================================
                // INSERE NO BANCO
                // =================================================

                pu.inserir();


                MessageBox.Show(
                    "Aluno cadastrado com sucesso!!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                // Limpa os campos
                LimparCampos();

                // Esconde o painel do responsável
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


        // =========================================================
        // BOTÃO CONFIRMAR
        // =========================================================
        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            DateTime dataNascimento;

            // Verifica a data
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

            // Verifica se a data é futura
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

            // Calcula a idade
            int idade = CalcularIdade(dataNascimento);


            // =====================================================
            // SE FOR MENOR DE IDADE
            // =====================================================

            if (idade < 18)
            {
                // Verifica nome do responsável
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


                // Verifica CPF do responsável
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


                // Verifica telefone do responsável
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


            // =====================================================
            // CADASTRA
            // =====================================================

            CadastrarAluno();
        }


        // =========================================================
        // LIMPAR CAMPOS
        // =========================================================
        private void LimparCampos()
        {
            txtbox_nome.Clear();
            txtbox_cpf.Clear();
            txtbox_senha.Clear();
            txtbox_bairro.Clear();

            // Limpa a MaskedTextBox
            txtbox_aniversario.Clear();

            txtbox_nome_resp.Clear();
            txtbox_cpf_resp.Clear();
            txtbox_tel_resp.Clear();
            txtbox_rua.Clear();
            txtbox_numCasa.Clear();

        }


        // =========================================================
        // BOTÃO VOLTAR
        // =========================================================
        private void btn_voltar_menu_Click(object sender, EventArgs e)
        {
            Hide();

            entrada_escola freefire = new entrada_escola();

            freefire.Show();
        }


        // =========================================================
        // EVENTOS QUE JÁ EXISTIAM NO SEU PROJETO
        // =========================================================

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
    }
}