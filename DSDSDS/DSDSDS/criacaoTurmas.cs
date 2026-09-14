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

                int idAluno =
                    Convert.ToInt32(linha.Cells["id_aluno"].Value);

                linha.Cells["Selecionar"].Value =
                    alunosSelecionados.Contains(idAluno);
            }

            AtualizarContador();
        }

        private void dgvAlunos_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e)
        {
            if (dgvAlunos.IsCurrentCellDirty)
            {
                dgvAlunos.CommitEdit(
                    DataGridViewDataErrorContexts.Commit
                );
            }
        }

        private void dgvAlunos_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (restaurandoSelecao)
                return;

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvAlunos.Columns[e.ColumnIndex].Name != "Selecionar")
                return;

            DataGridViewRow linha =
                dgvAlunos.Rows[e.RowIndex];

            if (linha.Cells["id_aluno"].Value == null)
                return;

            int idAluno =
                Convert.ToInt32(
                    linha.Cells["id_aluno"].Value
                );

            bool selecionado =
                Convert.ToBoolean(
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

                int idAluno =
                    Convert.ToInt32(
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

        private void criacaoTurmas_Load_1(
            object sender,
            EventArgs e)
        {
            cmdHorarioTurmas.Items.Clear();
            cmbHorarioFinal.Items.Clear();

            string[] horarios =
            {
                "08:00",
                "09:00",
                "10:00",
                "11:00",
                "12:00",
                "14:00",
                "15:00",
                "16:00",
                "17:00",
                "18:00",
                "19:00",
                "20:00",
                "21:00"
            };

            foreach (string horario in horarios)
            {
                cmdHorarioTurmas.Items.Add(horario);
                cmbHorarioFinal.Items.Add(horario);
            }

            CarregarAlunos();
        }

        private void txtPesquisarAluno_TextChanged(
            object sender,
            EventArgs e)
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

        private void lblSalvarTurma_Click(
            object sender,
            EventArgs e)
        {
            string nomeTurma =
                txtbox_NomeTurma.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomeTurma))
            {
                MessageBox.Show(
                    "Digite o nome da turma.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (cmbTurno.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Selecione o turno da turma.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (cmdHorarioTurmas.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Selecione o horário inicial dos treinos.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (cmbHorarioFinal.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Selecione o horário final dos treinos.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string horarioInicio =
                cmdHorarioTurmas.Text.Trim();

            string horarioFim =
                cmbHorarioFinal.Text.Trim();

            DateTime inicio =
                DateTime.Parse(horarioInicio);

            DateTime fim =
                DateTime.Parse(horarioFim);

            if (fim <= inicio)
            {
                MessageBox.Show(
                    "O horário final deve ser maior que o horário inicial.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            List<int> dias =
                new List<int>();

            if (chkSegunda.Checked)
                dias.Add(1);

            if (chkTerca.Checked)
                dias.Add(2);

            if (chkQuarta.Checked)
                dias.Add(3);

            if (chkQuinta.Checked)
                dias.Add(4);

            if (chkSexta.Checked)
                dias.Add(5);

            if (chkSabado.Checked)
                dias.Add(6);

            if (dias.Count == 0)
            {
                MessageBox.Show(
                    "Selecione pelo menos um dia da semana.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (alunosSelecionados.Count == 0)
            {
                MessageBox.Show(
                    "Selecione pelo menos um aluno.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int idTurno;

            string nomeTurno =
                cmbTurno.Text.Trim();

            if (nomeTurno.Equals(
                "Manha",
                StringComparison.OrdinalIgnoreCase))
            {
                idTurno = 1;
            }
            else if (nomeTurno.Equals(
                "Tarde",
                StringComparison.OrdinalIgnoreCase))
            {
                idTurno = 2;
            }
            else if (nomeTurno.Equals(
                "Noite",
                StringComparison.OrdinalIgnoreCase))
            {
                idTurno = 3;
            }
            else
            {
                MessageBox.Show(
                    "Turno inválido.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int idadeTurma =
                Convert.ToInt32(
                    numIdadeTurma.Value
                );

            try
            {
                criarTurma objCriarTurma =
                    new criarTurma();

                objCriarTurma.Criar(
                    nomeTurma,
                    idadeTurma,
                    idTurno,
                    horarioInicio,
                    horarioFim,
                    dias,
                    alunosSelecionados
                );

                MessageBox.Show(
                    "Turma criada com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                txtbox_NomeTurma.Clear();

                cmbTurno.SelectedIndex = -1;

                cmdHorarioTurmas.SelectedIndex = -1;

                cmbHorarioFinal.SelectedIndex = -1;

                chkSegunda.Checked = false;
                chkTerca.Checked = false;
                chkQuarta.Checked = false;
                chkQuinta.Checked = false;
                chkSexta.Checked = false;
                chkSabado.Checked = false;

                alunosSelecionados.Clear();

                foreach (DataGridViewRow linha in dgvAlunos.Rows)
                {
                    if (linha.Cells["Selecionar"] != null)
                    {
                        linha.Cells["Selecionar"].Value =
                            false;
                    }
                }

                AtualizarContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao criar a turma:\n\n" +
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void lbl_Modalidade_Click(
            object sender,
            EventArgs e)
        {

        }

        private void buttonPanel1_Paint(
            object sender,
            PaintEventArgs e)
        {

        }

        private void Horarios_Load(
            object sender,
            EventArgs e)
        {

        }

        private void cmbProfessor_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {

        }
    }
}