using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class ver_professores : Form
    {
        consultar ss = new consultar();

        public ver_professores()
        {
            InitializeComponent();

            panel_vazio.Visible = true;

            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;

            dataGridView1.ScrollBars = ScrollBars.Both;

            // FONTE
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Regular);

            // TAMANHO
            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.RowTemplate.Height = 30;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;
        }

        // =====================================================
        // BOTÃO BUSCAR / VISUALIZAR
        // =====================================================

        private void label10_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tabela = ss.Consultar();

                dataGridView1.DataSource = tabela;

                panel_vazio.Visible = false;

                configurarColunas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao consultar os professores:\n\n" + ex.Message,
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
            if (dataGridView1.Columns.Contains("id_professor"))
            {
                dataGridView1.Columns["id_professor"].HeaderText = "ID";
                dataGridView1.Columns["id_professor"].Width = 70;
            }

            if (dataGridView1.Columns.Contains("usuario"))
            {
                dataGridView1.Columns["usuario"].HeaderText = "Usuário";
                dataGridView1.Columns["usuario"].Width = 130;
            }

            if (dataGridView1.Columns.Contains("cpf"))
            {
                dataGridView1.Columns["cpf"].HeaderText = "CPF";
                dataGridView1.Columns["cpf"].Width = 140;
            }

            if (dataGridView1.Columns.Contains("email"))
            {
                dataGridView1.Columns["email"].HeaderText = "E-mail";
                dataGridView1.Columns["email"].Width = 200;
            }

            if (dataGridView1.Columns.Contains("senha"))
            {
                dataGridView1.Columns["senha"].HeaderText = "Senha";
                dataGridView1.Columns["senha"].Width = 100;
            }

            if (dataGridView1.Columns.Contains("telefone"))
            {
                dataGridView1.Columns["telefone"].HeaderText = "Telefone";
                dataGridView1.Columns["telefone"].Width = 150;
            }

            if (dataGridView1.Columns.Contains("bairro"))
            {
                dataGridView1.Columns["bairro"].HeaderText = "Bairro";
                dataGridView1.Columns["bairro"].Width = 150;
            }

            if (dataGridView1.Columns.Contains("rua"))
            {
                dataGridView1.Columns["rua"].HeaderText = "Rua";
                dataGridView1.Columns["rua"].Width = 180;
            }

            if (dataGridView1.Columns.Contains("num_casa"))
            {
                dataGridView1.Columns["num_casa"].HeaderText = "Nº Casa";
                dataGridView1.Columns["num_casa"].Width = 100;
            }

            foreach (DataGridViewColumn coluna in dataGridView1.Columns)
            {
                coluna.HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                coluna.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;
            }

            if (dataGridView1.Columns.Contains("id_professor"))
            {
                dataGridView1.Columns["id_professor"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // =====================================================
        // EVENTOS ANTIGOS DO DESIGNER
        // =====================================================

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void buttonPanel2_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void buttonPanel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void ver_professores_Load(
            object sender,
            EventArgs e)
        {
        }
        private void buttonPanel1_Click( object sender,EventArgs e)
        {
        }

        private void label9_Click(object sender,EventArgs e)
        {
            Hide();
            Add_prof_ jairo = new Add_prof_();
            jairo.Show();
        }

    }
}