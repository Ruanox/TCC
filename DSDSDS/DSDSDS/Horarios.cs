using DSDSDS;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class Horarios : Form
    {
        public Horarios()
        {
            InitializeComponent();

            CarregarProfessores();
            CarregarModalidades();
            CarregarTurnos();
            CarregarDiasSemana();

            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraInicio.ShowUpDown = true;

            dtpHoraFim.Format = DateTimePickerFormat.Custom;
            dtpHoraFim.CustomFormat = "HH:mm";
            dtpHoraFim.ShowUpDown = true;
        }

        private void CarregarProfessores()
        {
            conexao banco = new conexao();

            try
            {
                if (!banco.abrirconexao())
                    return;

                string sql = "SELECT id_professor, usuario FROM professor ORDER BY usuario";

                MySqlCommand cmd = new MySqlCommand(sql, banco.conectar);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable tabela = new DataTable();
                da.Fill(tabela);

                cmbProfessor.DataSource = null;
                cmbProfessor.DisplayMember = "usuario";
                cmbProfessor.ValueMember = "id_professor";
                cmbProfessor.DataSource = tabela;
                cmbProfessor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar os professores:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                banco.fecharconexao();
            }
        }

        private void CarregarModalidades()
        {
            conexao banco = new conexao();

            try
            {
                if (!banco.abrirconexao())
                    return;

                string sql = "SELECT id_modalidade, nome FROM modalidade ORDER BY nome";

                MySqlCommand cmd = new MySqlCommand(sql, banco.conectar);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable tabela = new DataTable();
                da.Fill(tabela);

                cmbModalidade.DataSource = null;
                cmbModalidade.DisplayMember = "nome";
                cmbModalidade.ValueMember = "id_modalidade";
                cmbModalidade.DataSource = tabela;
                cmbModalidade.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar as modalidades:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                banco.fecharconexao();
            }
        }

        private void CarregarTurnos()
        {
            conexao banco = new conexao();

            try
            {
                if (!banco.abrirconexao())
                    return;

                string sql = "SELECT id_turno, nome_turno FROM turno ORDER BY nome_turno";

                MySqlCommand cmd = new MySqlCommand(sql, banco.conectar);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable tabela = new DataTable();
                da.Fill(tabela);

                cmbTurno.DataSource = null;
                cmbTurno.DisplayMember = "nome_turno";
                cmbTurno.ValueMember = "id_turno";
                cmbTurno.DataSource = tabela;
                cmbTurno.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar os turnos:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                banco.fecharconexao();
            }
        }

        private void CarregarDiasSemana()
        {
            conexao banco = new conexao();

            try
            {
                if (!banco.abrirconexao())
                    return;

                string sql = "SELECT id_dia, nome_dia FROM dia_semana ORDER BY id_dia";

                MySqlCommand cmd = new MySqlCommand(sql, banco.conectar);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable tabela = new DataTable();
                da.Fill(tabela);

                cmbDiaSemana.DataSource = null;
                cmbDiaSemana.DisplayMember = "nome_dia";
                cmbDiaSemana.ValueMember = "id_dia";
                cmbDiaSemana.DataSource = tabela;
                cmbDiaSemana.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar os dias da semana:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                banco.fecharconexao();
            }
        }

        private void lbl_cadastrar_Click(object sender, EventArgs e)
        {
            if (cmbModalidade.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma modalidade.");
                return;
            }

            if (cmbProfessor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um professor.");
                return;
            }

            if (cmbTurno.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um turno.");
                return;
            }

            if (cmbDiaSemana.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um dia da semana.");
                return;
            }

            if (dtpHoraInicio.Value.TimeOfDay >= dtpHoraFim.Value.TimeOfDay)
            {
                MessageBox.Show("O horário de término deve ser maior que o horário de início.");
                return;
            }

            int idModalidade = Convert.ToInt32(cmbModalidade.SelectedValue);
            int idProfessor = Convert.ToInt32(cmbProfessor.SelectedValue);
            int idTurno = Convert.ToInt32(cmbTurno.SelectedValue);
            int idDia = Convert.ToInt32(cmbDiaSemana.SelectedValue);

            TimeSpan horaInicio = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan horaFim = dtpHoraFim.Value.TimeOfDay;

            conexao banco = new conexao();

            try
            {
                if (!banco.abrirconexao())
                    return;

                string sql = @"INSERT INTO horario
                    (id_modalidade, id_professor, id_turno, id_dia, hora_inicio, hora_fim)
                    VALUES
                    (@id_modalidade, @id_professor, @id_turno, @id_dia, @hora_inicio, @hora_fim)";

                MySqlCommand cmd = new MySqlCommand(sql, banco.conectar);

                cmd.Parameters.AddWithValue("@id_modalidade", idModalidade);
                cmd.Parameters.AddWithValue("@id_professor", idProfessor);
                cmd.Parameters.AddWithValue("@id_turno", idTurno);
                cmd.Parameters.AddWithValue("@id_dia", idDia);
                cmd.Parameters.AddWithValue("@hora_inicio", horaInicio);
                cmd.Parameters.AddWithValue("@hora_fim", horaFim);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Horário cadastrado com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao salvar o horário:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                banco.fecharconexao();
            }
        }

        private void lbl_Modalidade_Click(object sender, EventArgs e)
        {

        }

        private void buttonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Horarios_Load(object sender, EventArgs e)
        {

        }

        private void cmbProfessor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}