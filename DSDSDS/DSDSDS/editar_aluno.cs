using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class editar_aluno : Form
    {
        alunos ss = new alunos();
        editar_aluno_bd papa = new editar_aluno_bd();

        private bool modoEdicao = false;
        private DataGridViewRow linhaEmEdicao = null;

        public editar_aluno()
        {
            InitializeComponent();

            panel_vazio.Visible = true;
            dataGridView1.Visible = false;

            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;

            dataGridView1.ScrollBars = ScrollBars.Both;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Regular);

            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.RowTemplate.Height = 30;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Hide();

            ALN_ADD asd = new ALN_ADD();
            asd.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dados = ss.consultar();

                if (dados != null && dados.Rows.Count > 0)
                {
                    panel_vazio.Visible = false;
                    dataGridView1.Visible = true;

                    dataGridView1.DataSource = dados;
                    dataGridView1.ReadOnly = true;

                    dataGridView1.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.MultiSelect = false;

                    configurarColunas();

                    if (dataGridView1.Columns.Contains("id_aluno"))
                        dataGridView1.Columns["id_aluno"].ReadOnly = true;
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
                    "Erro ao buscar os alunos:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

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
                dataGridView1.Columns["usuario"].Width = 150;
            }

            if (dataGridView1.Columns.Contains("cpf"))
            {
                dataGridView1.Columns["cpf"].HeaderText = "CPF";
                dataGridView1.Columns["cpf"].Width = 130;
            }

            if (dataGridView1.Columns.Contains("senha"))
            {
                dataGridView1.Columns["senha"].HeaderText = "Senha";
                dataGridView1.Columns["senha"].Width = 130;
            }

            if (dataGridView1.Columns.Contains("nome_responsavel"))
            {
                dataGridView1.Columns["nome_responsavel"].HeaderText =
                    "Nome do Responsável";
                dataGridView1.Columns["nome_responsavel"].Width = 190;
            }

            if (dataGridView1.Columns.Contains("telefone_resp"))
            {
                dataGridView1.Columns["telefone_resp"].HeaderText =
                    "Telefone Responsável";
                dataGridView1.Columns["telefone_resp"].Width = 170;
            }

            if (dataGridView1.Columns.Contains("cpf_responsavel"))
            {
                dataGridView1.Columns["cpf_responsavel"].HeaderText =
                    "CPF Responsável";
                dataGridView1.Columns["cpf_responsavel"].Width = 150;
            }

            if (dataGridView1.Columns.Contains("bairro"))
            {
                dataGridView1.Columns["bairro"].HeaderText = "Bairro";
                dataGridView1.Columns["bairro"].Width = 140;
            }

            if (dataGridView1.Columns.Contains("menor_de_idade"))
            {
                dataGridView1.Columns["menor_de_idade"].HeaderText =
                    "Menor de Idade";
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
                    "Data de Nascimento";
                dataGridView1.Columns["data_nasc"].Width = 160;
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

            if (dataGridView1.Columns.Contains("peso"))
            {
                dataGridView1.Columns["peso"].HeaderText = "Peso (kg)";
                dataGridView1.Columns["peso"].Width = 100;
            }

            if (dataGridView1.Columns.Contains("altura"))
            {
                dataGridView1.Columns["altura"].HeaderText = "Altura (m)";
                dataGridView1.Columns["altura"].Width = 100;
            }

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            try
            {
                if (!modoEdicao)
                {
                    if (dataGridView1.SelectedRows.Count == 0)
                    {
                        MessageBox.Show(
                            "Selecione um aluno para editar.",
                            "Editar aluno",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                    linhaEmEdicao =
                        dataGridView1.SelectedRows[0];

                    dataGridView1.ReadOnly = false;

                    if (dataGridView1.Columns.Contains("id_aluno"))
                        dataGridView1.Columns["id_aluno"].ReadOnly = true;

                    modoEdicao = true;

                    MessageBox.Show(
                        "Modo de edição ativado!\n\n" +
                        "Agora você pode alterar os dados diretamente na tabela.\n\n" +
                        "Clique novamente em Editar para salvar.",
                        "Editar aluno",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                if (linhaEmEdicao == null)
                {
                    MessageBox.Show(
                        "Nenhum aluno foi selecionado.",
                        "Editar aluno",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                dataGridView1.EndEdit();

                int idAluno = Convert.ToInt32(
                    linhaEmEdicao.Cells["id_aluno"].Value
                );

                string usuario = Convert.ToString(
                    linhaEmEdicao.Cells["usuario"].Value
                );

                string cpf = Convert.ToString(
                    linhaEmEdicao.Cells["cpf"].Value
                );

                string senha = Convert.ToString(
                    linhaEmEdicao.Cells["senha"].Value
                );

                string nomeResponsavel = Convert.ToString(
                    linhaEmEdicao.Cells["nome_responsavel"].Value
                );

                string telefoneResp = Convert.ToString(
                    linhaEmEdicao.Cells["telefone_resp"].Value
                );

                string cpfResponsavel = Convert.ToString(
                    linhaEmEdicao.Cells["cpf_responsavel"].Value
                );

                string bairro = Convert.ToString(
                    linhaEmEdicao.Cells["bairro"].Value
                );

                int menorDeIdade = Convert.ToInt32(
                    linhaEmEdicao.Cells["menor_de_idade"].Value
                );

                string turmaIdade = Convert.ToString(
                    linhaEmEdicao.Cells["turma_idade"].Value
                );

                DateTime? dataNascimento = null;

                if (linhaEmEdicao.Cells["data_nasc"].Value != null &&
                    linhaEmEdicao.Cells["data_nasc"].Value != DBNull.Value &&
                    DateTime.TryParse(
                        linhaEmEdicao.Cells["data_nasc"].Value.ToString(),
                        out DateTime dataConvertida
                    ))
                {
                    dataNascimento = dataConvertida;
                }

                string rua = Convert.ToString(
                    linhaEmEdicao.Cells["rua"].Value
                );

                int? numCasa = null;

                if (linhaEmEdicao.Cells["num_casa"].Value != null &&
                    linhaEmEdicao.Cells["num_casa"].Value != DBNull.Value &&
                    int.TryParse(
                        linhaEmEdicao.Cells["num_casa"].Value.ToString(),
                        out int numeroCasa
                    ))
                {
                    numCasa = numeroCasa;
                }

                string telefone = Convert.ToString(
                    linhaEmEdicao.Cells["telefone"].Value
                );

                decimal peso = 0;
                decimal altura = 0;

                if (linhaEmEdicao.Cells["peso"].Value != null &&
                    linhaEmEdicao.Cells["peso"].Value != DBNull.Value)
                {
                    string valorPeso =
                        linhaEmEdicao.Cells["peso"].Value.ToString();

                    if (!decimal.TryParse(
                        valorPeso,
                        NumberStyles.Any,
                        CultureInfo.CurrentCulture,
                        out peso))
                    {
                        decimal.TryParse(
                            valorPeso.Replace(",", "."),
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture,
                            out peso
                        );
                    }
                }

                if (linhaEmEdicao.Cells["altura"].Value != null &&
                    linhaEmEdicao.Cells["altura"].Value != DBNull.Value)
                {
                    string valorAltura =
                        linhaEmEdicao.Cells["altura"].Value.ToString();

                    if (!decimal.TryParse(
                        valorAltura,
                        NumberStyles.Any,
                        CultureInfo.CurrentCulture,
                        out altura))
                    {
                        decimal.TryParse(
                            valorAltura.Replace(",", "."),
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture,
                            out altura
                        );
                    }
                }

                DialogResult resposta = MessageBox.Show(
                    "Deseja salvar as alterações deste aluno?",
                    "Confirmar alteração",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resposta == DialogResult.Yes)
                {
                    papa.alterar(
                        idAluno,
                        usuario,
                        cpf,
                        senha,
                        nomeResponsavel,
                        telefoneResp,
                        cpfResponsavel,
                        bairro,
                        menorDeIdade,
                        turmaIdade,
                        dataNascimento,
                        rua,
                        numCasa,
                        telefone,
                        peso,
                        altura
                    );

                    MessageBox.Show(
                        "Aluno alterado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    dataGridView1.ReadOnly = true;

                    modoEdicao = false;
                    linhaEmEdicao = null;

                    DataTable dados = ss.consultar();

                    if (dados != null && dados.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dados;
                        dataGridView1.Visible = true;
                        panel_vazio.Visible = false;

                        configurarColunas();

                        if (dataGridView1.Columns.Contains("id_aluno"))
                            dataGridView1.Columns["id_aluno"].ReadOnly = true;
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
                    "Erro ao editar aluno:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void editar_aluno_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }
    }
}