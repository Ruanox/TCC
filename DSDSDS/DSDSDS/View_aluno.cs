using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class View_aluno : Form
    {
        public View_aluno()
        {
            InitializeComponent();

            panel_vazio.Visible = true;

            // Configurações gerais da tabela
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            // Permite selecionar uma linha inteira
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Não deixa várias linhas selecionadas
            dataGridView1.MultiSelect = false;

            // Barra horizontal e vertical
            dataGridView1.ScrollBars = ScrollBars.Both;

            // Estilo
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Regular);

            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.RowTemplate.Height = 30;

            // Ajuste das colunas
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;
        }

        // =========================================================
        // BUSCAR / VISUALIZAR ALUNOS
        // =========================================================

        private void label10_Click(object sender, EventArgs e)
        {
            try
            {
                alunos aluno = new alunos();

                DataTable tabela = aluno.consultar();

                dataGridView1.DataSource = tabela;

                panel_vazio.Visible = false;

                configurarColunas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao consultar os alunos:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // CONFIGURAÇÃO DAS COLUNAS
        // =========================================================

        private void configurarColunas()
        {
            // -----------------------------------------------------
            // ID
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("id_aluno"))
            {
                dataGridView1.Columns["id_aluno"].HeaderText = "ID";
                dataGridView1.Columns["id_aluno"].Width = 70;
            }

            // -----------------------------------------------------
            // USUÁRIO
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("usuario"))
            {
                dataGridView1.Columns["usuario"].HeaderText = "Usuário";
                dataGridView1.Columns["usuario"].Width = 130;
            }

            // -----------------------------------------------------
            // CPF
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("cpf"))
            {
                dataGridView1.Columns["cpf"].HeaderText = "CPF";
                dataGridView1.Columns["cpf"].Width = 130;
            }

            // -----------------------------------------------------
            // SENHA
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("senha"))
            {
                dataGridView1.Columns["senha"].HeaderText = "Senha";
                dataGridView1.Columns["senha"].Width = 100;
            }

            // -----------------------------------------------------
            // NOME DO RESPONSÁVEL
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("nome_responsavel"))
            {
                dataGridView1.Columns["nome_responsavel"].HeaderText =
                    "Responsável";

                dataGridView1.Columns["nome_responsavel"].Width = 170;
            }

            // -----------------------------------------------------
            // TELEFONE DO RESPONSÁVEL
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("telefone_responsavel"))
            {
                dataGridView1.Columns["telefone_responsavel"].HeaderText =
                    "Telefone Resp.";

                dataGridView1.Columns["telefone_responsavel"].Width = 160;
            }

            // -----------------------------------------------------
            // CPF DO RESPONSÁVEL
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("cpf_responsavel"))
            {
                dataGridView1.Columns["cpf_responsavel"].HeaderText =
                    "CPF Resp.";

                dataGridView1.Columns["cpf_responsavel"].Width = 150;
            }

            // -----------------------------------------------------
            // BAIRRO
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("bairro"))
            {
                dataGridView1.Columns["bairro"].HeaderText = "Bairro";
                dataGridView1.Columns["bairro"].Width = 150;
            }

            // -----------------------------------------------------
            // MENOR DE IDADE
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("menor_de_idade"))
            {
                dataGridView1.Columns["menor_de_idade"].HeaderText =
                    "Menor de idade";

                dataGridView1.Columns["menor_de_idade"].Width = 130;
            }

            // -----------------------------------------------------
            // TURMA / IDADE
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("turma_idade"))
            {
                dataGridView1.Columns["turma_idade"].HeaderText =
                    "Turma / Idade";

                dataGridView1.Columns["turma_idade"].Width = 130;
            }

            // -----------------------------------------------------
            // DATA DE NASCIMENTO
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("data_nasc"))
            {
                dataGridView1.Columns["data_nasc"].HeaderText =
                    "Nascimento";

                dataGridView1.Columns["data_nasc"].Width = 120;
            }

            // -----------------------------------------------------
            // RUA
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("rua"))
            {
                dataGridView1.Columns["rua"].HeaderText = "Rua";
                dataGridView1.Columns["rua"].Width = 180;
            }

            // -----------------------------------------------------
            // NÚMERO DA CASA
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("num_casa"))
            {
                dataGridView1.Columns["num_casa"].HeaderText =
                    "Nº Casa";

                dataGridView1.Columns["num_casa"].Width = 90;
            }

            // -----------------------------------------------------
            // TELEFONE
            // -----------------------------------------------------

            if (dataGridView1.Columns.Contains("telefone"))
            {
                dataGridView1.Columns["telefone"].HeaderText =
                    "Telefone";

                dataGridView1.Columns["telefone"].Width = 150;
            }

            // =====================================================
            // ALINHAMENTO
            // =====================================================

            foreach (DataGridViewColumn coluna in dataGridView1.Columns)
            {
                coluna.HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                coluna.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;
            }

            // ID centralizado
            if (dataGridView1.Columns.Contains("id_aluno"))
            {
                dataGridView1.Columns["id_aluno"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            // Menor de idade centralizado
            if (dataGridView1.Columns.Contains("menor_de_idade"))
            {
                dataGridView1.Columns["menor_de_idade"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // =========================================================
        // VOLTAR / NOVO ALUNO
        // =========================================================

        private void label9_Click(object sender, EventArgs e)
        {
            Hide();

            ALN_ADD lak = new ALN_ADD();

            lak.Show();
        }

        // =========================================================
        // LOAD
        // =========================================================

        private void View_aluno_Load(object sender, EventArgs e)
        {
        }
    }
}