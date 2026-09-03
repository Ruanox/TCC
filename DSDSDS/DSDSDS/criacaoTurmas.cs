using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class criacaoTurmas : Form
    {
        private DataTable tabelaAlunos;
        private HashSet<int> alunosSelecionados = new HashSet<int>();
        private bool restaurandoSelecao = false;

        public criacaoTurmas()
        {
            InitializeComponent();

            dgvAlunos.CurrentCellDirtyStateChanged -= dgvAlunos_CurrentCellDirtyStateChanged;
            dgvAlunos.CurrentCellDirtyStateChanged += dgvAlunos_CurrentCellDirtyStateChanged;

            dgvAlunos.CellValueChanged -= dgvAlunos_CellValueChanged;
            dgvAlunos.CellValueChanged += dgvAlunos_CellValueChanged;

            dgvAlunos.DataBindingComplete -= dgvAlunos_DataBindingComplete;
            dgvAlunos.DataBindingComplete += dgvAlunos_DataBindingComplete;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cmdTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTurno.SelectedIndex = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void criacaoTurmas_Load(object sender, EventArgs e)
        {

        }

        private void panel_vazio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConfigurarDataGridView()
        {
            dgvAlunos.AllowUserToAddRows = false;
            dgvAlunos.AllowUserToDeleteRows = false;
            dgvAlunos.ReadOnly = false;
            dgvAlunos.MultiSelect = false;
            dgvAlunos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlunos.AutoGenerateColumns = true;

            if (!dgvAlunos.Columns.Contains("Selecionar"))
            {
                DataGridViewCheckBoxColumn colunaSelecionar =
                    new DataGridViewCheckBoxColumn();

                colunaSelecionar.Name = "Selecionar";
                colunaSelecionar.HeaderText = "";
                colunaSelecionar.Width = 45;
                colunaSelecionar.ReadOnly = false;

                dgvAlunos.Columns.Insert(0, colunaSelecionar);
            }

            if (dgvAlunos.Columns.Contains("id_aluno"))
            {
                dgvAlunos.Columns["id_aluno"].HeaderText = "ID";
                dgvAlunos.Columns["id_aluno"].Width = 60;
            }

            if (dgvAlunos.Columns.Contains("usuario"))
            {
                dgvAlunos.Columns["usuario"].HeaderText = "Nome";
                dgvAlunos.Columns["usuario"].Width = 180;
            }

            if (dgvAlunos.Columns.Contains("idade"))
            {
                dgvAlunos.Columns["idade"].HeaderText = "Idade";
                dgvAlunos.Columns["idade"].Width = 70;
            }

            if (dgvAlunos.Columns.Contains("altura"))
            {
                dgvAlunos.Columns["altura"].HeaderText = "Altura";
                dgvAlunos.Columns["altura"].Width = 80;
            }

            if (dgvAlunos.Columns.Contains("peso"))
            {
                dgvAlunos.Columns["peso"].HeaderText = "Peso";
                dgvAlunos.Columns["peso"].Width = 80;
            }

            if (dgvAlunos.Columns.Contains("data_nasc"))
            {
                dgvAlunos.Columns["data_nasc"].Visible = false;
            }

            foreach (DataGridViewColumn coluna in dgvAlunos.Columns)
            {
                if (coluna.Name != "Selecionar" &&
                    coluna.Name != "id_aluno" &&
                    coluna.Name != "usuario" &&
                    coluna.Name != "idade" &&
                    coluna.Name != "altura" &&
                    coluna.Name != "peso")
                {
                    coluna.Visible = false;
                }
            }

            foreach (DataGridViewRow linha in dgvAlunos.Rows)
            {
                if (linha.Cells["id_aluno"].Value == null)
                    continue;

                int idAluno = Convert.ToInt32(linha.Cells["id_aluno"].Value);

                linha.Cells["Selecionar"].Value =
                    alunosSelecionados.Contains(idAluno);
            }

            AtualizarContador();
        }

        private void dgvAlunos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAlunos.IsCurrentCellDirty)
            {
                dgvAlunos.CommitEdit(
                    DataGridViewDataErrorContexts.Commit
                );
            }
        }

        private void dgvAlunos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (restaurandoSelecao)
                return;

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvAlunos.Columns[e.ColumnIndex].Name != "Selecionar")
                return;

            DataGridViewRow linha = dgvAlunos.Rows[e.RowIndex];

            if (linha.Cells["id_aluno"].Value == null)
                return;

            int idAluno = Convert.ToInt32(
                linha.Cells["id_aluno"].Value
            );

            bool selecionado = Convert.ToBoolean(
                linha.Cells["Selecionar"].Value ?? false
            );

            if (selecionado)
            {
                alunosSelecionados.Add(idAluno);
            }
            else
            {
                alunosSelecionados.Remove(idAluno);
            }

            AtualizarContador();
        }

        private void dgvAlunos_DataBindingComplete(
     object sender,
     DataGridViewBindingCompleteEventArgs e)
        {
            if (!dgvAlunos.Columns.Contains("Selecionar"))
                return;

            restaurandoSelecao = true;

            foreach (DataGridViewRow linha in dgvAlunos.Rows)
            {
                if (linha.Cells["id_aluno"].Value == null)
                    continue;

                int idAluno = Convert.ToInt32(
                    linha.Cells["id_aluno"].Value
                );

                linha.Cells["Selecionar"].Value =
                    alunosSelecionados.Contains(idAluno);
            }

            restaurandoSelecao = false;

            AtualizarContador();
        }

        private void AtualizarContador()
        {
            lblSelecionados.Text =
                $"Selecionados: {alunosSelecionados.Count}";
        }

        private int CalcularIdade(DateTime dataNascimento)
        {
            DateTime hoje = DateTime.Today;

            int idade =
                hoje.Year - dataNascimento.Year;

            if (dataNascimento.Date >
                hoje.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }

        private void CarregarAlunos()
        {
            alunosTurma objAlunos =
                new alunosTurma();

            tabelaAlunos =
                objAlunos.consultar();

            if (!tabelaAlunos.Columns.Contains("idade"))
            {
                tabelaAlunos.Columns.Add(
                    "idade",
                    typeof(int)
                );
            }

            foreach (DataRow linha in tabelaAlunos.Rows)
            {
                if (linha["data_nasc"] != DBNull.Value)
                {
                    DateTime dataNascimento =
                        Convert.ToDateTime(
                            linha["data_nasc"]
                        );

                    linha["idade"] =
                        CalcularIdade(dataNascimento);
                }
            }

            dgvAlunos.DataSource =
                tabelaAlunos;

            ConfigurarDataGridView();
        }

        private void criacaoTurmas_Load_1(object sender, EventArgs e)
        {
            CarregarAlunos();
        }

        private void txtPesquisarAluno_TextChanged(object sender, EventArgs e)
        {
            if (tabelaAlunos == null)
                return;

            string pesquisa =
                txtPesquisarAluno.Text.Trim();

            if (string.IsNullOrEmpty(pesquisa))
            {
                tabelaAlunos.DefaultView.RowFilter = "";
            }
            else
            {
                string filtro =
                    pesquisa.Replace("'", "''");

                tabelaAlunos.DefaultView.RowFilter =
                    $"usuario LIKE '%{filtro}%'";
            }

            AtualizarContador();
        }
    }
}