using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class excluir_professor : Form
    {
        excluir_prof papa = new excluir_prof();
        consultar ss = new consultar();

        public excluir_professor()
        {
            InitializeComponent();

            panel_vazio.Visible = true;

            // =====================================================
            // CONFIGURAÇÃO DO DATAGRIDVIEW
            // =====================================================

            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;

            dataGridView1.ScrollBars = ScrollBars.Both;

            // =====================================================
            // FONTE
            // =====================================================

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Regular);

            // =====================================================
            // TAMANHO
            // =====================================================

            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.RowTemplate.Height = 30;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;
        }

        // =====================================================
        // LOAD
        // =====================================================

        private void excluir_professor_Load(object sender, EventArgs e)
        {
        }

        // =====================================================
        // BOTÃO VOLTAR
        // =====================================================

        private void label9_Click(object sender, EventArgs e)
        {
            Hide();

            Add_prof_ jairo = new Add_prof_();
            jairo.Show();
        }

        // =====================================================
        // BOTÃO VOLTAR / PAINEL
        // =====================================================

        private void buttonPanel1_Click(object sender, EventArgs e)
        {
            Hide();

            Add_prof_ jairo = new Add_prof_();
            jairo.Show();
        }

        // =====================================================
        // BOTÃO EXCLUIR
        // =====================================================

        private void label12_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se alguma linha foi selecionada
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Selecione um professor para excluir.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // =================================================
                // PEGA O ID DO PROFESSOR
                // =================================================

                int idProfessor = Convert.ToInt32(
                    dataGridView1.SelectedRows[0]
                    .Cells["id_professor"].Value
                );

                papa.setId_professor(idProfessor);

                // =================================================
                // CONFIRMAÇÃO
                // =================================================

                DialogResult resposta = MessageBox.Show(
                    "Tem certeza que deseja excluir este professor?\n\n" +
                    "Os horários relacionados a ele também serão excluídos.",
                    "Confirmar exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resposta == DialogResult.Yes)
                {
                    // =================================================
                    // EXECUTA A EXCLUSÃO
                    // =================================================

                    papa.excluir();

                    MessageBox.Show(
                        "Professor excluído com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // =================================================
                    // ATUALIZA A TABELA
                    // =================================================

                    DataTable dados = ss.Consultar();

                    if (dados != null && dados.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dados;

                        dataGridView1.Visible = true;
                        panel_vazio.Visible = false;

                        configurarColunas();
                    }
                    else
                    {
                        dataGridView1.DataSource = null;

                        dataGridView1.Visible = false;
                        panel_vazio.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao excluir professor:\n\n" +
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // BOTÃO BUSCAR
        // =====================================================

        private void label10_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dados = ss.Consultar();

                if (dados != null && dados.Rows.Count > 0)
                {
                    panel_vazio.Visible = false;
                    dataGridView1.Visible = true;

                    dataGridView1.DataSource = dados;

                    dataGridView1.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.MultiSelect = false;
                    dataGridView1.ReadOnly = true;

                    // Configura aparência das colunas
                    configurarColunas();
                }
                else
                {
                    dataGridView1.DataSource = null;

                    dataGridView1.Visible = false;
                    panel_vazio.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao buscar professores:\n\n" +
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // CONFIGURAÇÃO DAS COLUNAS
        // =====================================================

        private void configurarColunas()
        {
            // =================================================
            // ID
            // =================================================

            if (dataGridView1.Columns.Contains("id_professor"))
            {
                dataGridView1.Columns["id_professor"].HeaderText = "ID";
                dataGridView1.Columns["id_professor"].Width = 70;
            }

            // =================================================
            // USUÁRIO
            // =================================================

            if (dataGridView1.Columns.Contains("usuario"))
            {
                dataGridView1.Columns["usuario"].HeaderText = "Usuário";
                dataGridView1.Columns["usuario"].Width = 140;
            }

            // =================================================
            // CPF
            // =================================================

            if (dataGridView1.Columns.Contains("cpf"))
            {
                dataGridView1.Columns["cpf"].HeaderText = "CPF";
                dataGridView1.Columns["cpf"].Width = 150;
            }

            // =================================================
            // E-MAIL
            // =================================================

            if (dataGridView1.Columns.Contains("email"))
            {
                dataGridView1.Columns["email"].HeaderText = "E-mail";
                dataGridView1.Columns["email"].Width = 220;
            }

            // =================================================
            // SENHA
            // =================================================

            if (dataGridView1.Columns.Contains("senha"))
            {
                dataGridView1.Columns["senha"].HeaderText = "Senha";
                dataGridView1.Columns["senha"].Width = 110;
            }

            // =================================================
            // TELEFONE
            // =================================================

            if (dataGridView1.Columns.Contains("telefone"))
            {
                dataGridView1.Columns["telefone"].HeaderText = "Telefone";
                dataGridView1.Columns["telefone"].Width = 160;
            }

            // =================================================
            // BAIRRO
            // =================================================

            if (dataGridView1.Columns.Contains("bairro"))
            {
                dataGridView1.Columns["bairro"].HeaderText = "Bairro";
                dataGridView1.Columns["bairro"].Width = 170;
            }

            // =================================================
            // RUA
            // =================================================

            if (dataGridView1.Columns.Contains("rua"))
            {
                dataGridView1.Columns["rua"].HeaderText = "Rua";
                dataGridView1.Columns["rua"].Width = 200;
            }

            // =================================================
            // NÚMERO DA CASA
            // =================================================

            if (dataGridView1.Columns.Contains("num_casa"))
            {
                dataGridView1.Columns["num_casa"].HeaderText = "Nº Casa";
                dataGridView1.Columns["num_casa"].Width = 100;
            }

            // =================================================
            // ALINHAMENTO
            // =================================================

            foreach (DataGridViewColumn coluna in dataGridView1.Columns)
            {
                coluna.HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                coluna.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;
            }

            // ID centralizado
            if (dataGridView1.Columns.Contains("id_professor"))
            {
                dataGridView1.Columns["id_professor"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}