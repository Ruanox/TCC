using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class excluir_aluno : Form
    {
        public excluir_aluno()
        {
            InitializeComponent();

            panel_vazio.Visible = true;

            // Configurações da tabela
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;

            dataGridView1.ScrollBars = ScrollBars.Both;

            // Fonte
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Regular);

            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.RowTemplate.Height = 30;

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
            if (dataGridView1.Columns.Contains("id_aluno"))
            {
                dataGridView1.Columns["id_aluno"].HeaderText = "ID";
                dataGridView1.Columns["id_aluno"].Width = 70;
            }

            if (dataGridView1.Columns.Contains("usuario"))
            {
                dataGridView1.Columns["usuario"].HeaderText = "Usuário";
                dataGridView1.Columns["usuario"].Width = 130;
            }

            if (dataGridView1.Columns.Contains("cpf"))
            {
                dataGridView1.Columns["cpf"].HeaderText = "CPF";
                dataGridView1.Columns["cpf"].Width = 130;
            }

            if (dataGridView1.Columns.Contains("senha"))
            {
                dataGridView1.Columns["senha"].HeaderText = "Senha";
                dataGridView1.Columns["senha"].Width = 100;
            }

            if (dataGridView1.Columns.Contains("nome_responsavel"))
            {
                dataGridView1.Columns["nome_responsavel"].HeaderText =
                    "Responsável";

                dataGridView1.Columns["nome_responsavel"].Width = 170;
            }

            if (dataGridView1.Columns.Contains("telefone_responsavel"))
            {
                dataGridView1.Columns["telefone_responsavel"].HeaderText =
                    "Telefone Resp.";

                dataGridView1.Columns["telefone_responsavel"].Width = 160;
            }

            if (dataGridView1.Columns.Contains("cpf_responsavel"))
            {
                dataGridView1.Columns["cpf_responsavel"].HeaderText =
                    "CPF Resp.";

                dataGridView1.Columns["cpf_responsavel"].Width = 150;
            }

            if (dataGridView1.Columns.Contains("bairro"))
            {
                dataGridView1.Columns["bairro"].HeaderText = "Bairro";
                dataGridView1.Columns["bairro"].Width = 150;
            }

            if (dataGridView1.Columns.Contains("menor_de_idade"))
            {
                dataGridView1.Columns["menor_de_idade"].HeaderText =
                    "Menor de idade";

                dataGridView1.Columns["menor_de_idade"].Width = 130;
            }

            if (dataGridView1.Columns.Contains("turma_idade"))
            {
                dataGridView1.Columns["turma_idade"].HeaderText =
                    "Turma / Idade";

                dataGridView1.Columns["turma_idade"].Width = 130;
            }

            if (dataGridView1.Columns.Contains("data_nasc"))
            {
                dataGridView1.Columns["data_nasc"].HeaderText =
                    "Nascimento";

                dataGridView1.Columns["data_nasc"].Width = 120;
            }

            if (dataGridView1.Columns.Contains("rua"))
            {
                dataGridView1.Columns["rua"].HeaderText = "Rua";
                dataGridView1.Columns["rua"].Width = 180;
            }

            if (dataGridView1.Columns.Contains("num_casa"))
            {
                dataGridView1.Columns["num_casa"].HeaderText =
                    "Nº Casa";

                dataGridView1.Columns["num_casa"].Width = 90;
            }

            if (dataGridView1.Columns.Contains("telefone"))
            {
                dataGridView1.Columns["telefone"].HeaderText =
                    "Telefone";

                dataGridView1.Columns["telefone"].Width = 150;
            }

            // Alinhamento dos títulos
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
        // EXCLUIR ALUNO
        // =========================================================

        private void label12_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Selecione um aluno para excluir.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                int idAluno = Convert.ToInt32(
                    dataGridView1.CurrentRow
                        .Cells["id_aluno"]
                        .Value
                );

                DialogResult resposta = MessageBox.Show(
                    "Deseja realmente excluir o aluno selecionado?",
                    "Confirmar exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resposta == DialogResult.Yes)
                {
                    excluir_alunos excluir = new excluir_alunos();

                    excluir.setIdAluno(idAluno);

                    excluir.excluir();

                    MessageBox.Show(
                        "Aluno excluído com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Atualiza a tabela automaticamente
                    alunos aluno = new alunos();

                    dataGridView1.DataSource = aluno.consultar();

                    configurarColunas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao excluir aluno:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // LOAD
        // =========================================================

        private void excluir_aluno_Load(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Hide();
            ALN_ADD ad = new ALN_ADD();
            ad.Show();
        }
    }
}