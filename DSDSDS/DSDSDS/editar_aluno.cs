using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class editar_aluno : Form
    {
        alunos ss = new alunos();

        // =========================================================
        // CONTROLA O MODO DO BOTÃO EDITAR
        // false = entrar no modo edição
        // true  = salvar alterações
        // =========================================================

        private bool modoEdicao = false;


        public editar_aluno()
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


        // =========================================================
        // VOLTAR / ADICIONAR ALUNO
        // =========================================================

        private void label9_Click(object sender, EventArgs e)
        {
            Hide();

            ALN_ADD asd = new ALN_ADD();

            asd.Show();
        }


        // =========================================================
        // BUSCAR / VISUALIZAR
        // =========================================================

        private void label10_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tabela = ss.consultar();

                dataGridView1.DataSource = tabela;

                panel_vazio.Visible = false;

                configurarColunas();

                // Sempre começa bloqueado
                modoEdicao = false;
                dataGridView1.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao consultar os alunos:\n\n" +
                    ex.Message,
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

            if (dataGridView1.Columns.Contains("telefone_resp"))
            {
                dataGridView1.Columns["telefone_resp"].HeaderText =
                    "Telefone Resp.";

                dataGridView1.Columns["telefone_resp"].Width = 160;
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


            if (dataGridView1.Columns.Contains("id_aluno"))
            {
                dataGridView1.Columns["id_aluno"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }


            if (dataGridView1.Columns.Contains("menor_de_idade"))
            {
                dataGridView1.Columns["menor_de_idade"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
        }


        // =========================================================
        // BOTÃO EDITAR / SALVAR
        // =========================================================

        private void label12_Click(object sender, EventArgs e)
        {
            // =====================================================
            // PRIMEIRO CLIQUE
            // ENTRA NO MODO DE EDIÇÃO
            // =====================================================

            if (!modoEdicao)
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Selecione um aluno para editar.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                modoEdicao = true;

                dataGridView1.ReadOnly = false;

                // O ID NÃO pode ser alterado
                if (dataGridView1.Columns.Contains("id_aluno"))
                {
                    dataGridView1.Columns["id_aluno"].ReadOnly = true;
                }

                MessageBox.Show(
                    "Modo de edição ativado.\n\n" +
                    "Altere os dados do aluno diretamente na tabela " +
                    "e clique em Editar novamente para salvar.",
                    "Editar aluno",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }


            // =====================================================
            // SEGUNDO CLIQUE
            // SALVA AS ALTERAÇÕES
            // =====================================================

            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Selecione um aluno.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Finaliza a edição da célula atual
                dataGridView1.EndEdit();


                DataGridViewRow linha =
                    dataGridView1.CurrentRow;


                // =================================================
                // ID
                // =================================================

                int id_aluno =
                    Convert.ToInt32(
                        linha.Cells["id_aluno"].Value
                    );


                // =================================================
                // CAMPOS DE TEXTO
                // =================================================

                string usuario =
                    Convert.ToString(
                        linha.Cells["usuario"].Value
                    );

                string cpf =
                    Convert.ToString(
                        linha.Cells["cpf"].Value
                    );

                string senha =
                    Convert.ToString(
                        linha.Cells["senha"].Value
                    );

                string nome_responsavel =
                    Convert.ToString(
                        linha.Cells["nome_responsavel"].Value
                    );

                string telefone_resp =
                    Convert.ToString(
                        linha.Cells["telefone_resp"].Value
                    );

                string cpf_responsavel =
                    Convert.ToString(
                        linha.Cells["cpf_responsavel"].Value
                    );

                string bairro =
                    Convert.ToString(
                        linha.Cells["bairro"].Value
                    );

                string turma_idade =
                    Convert.ToString(
                        linha.Cells["turma_idade"].Value
                    );

                string rua =
                    Convert.ToString(
                        linha.Cells["rua"].Value
                    );

                string telefone =
                    Convert.ToString(
                        linha.Cells["telefone"].Value
                    );


                // =================================================
                // MENOR DE IDADE
                // =================================================

                int menor_de_idade = 0;

                if (linha.Cells["menor_de_idade"].Value != null &&
                    linha.Cells["menor_de_idade"].Value != DBNull.Value)
                {
                    bool valor =
                        Convert.ToBoolean(
                            linha.Cells["menor_de_idade"].Value
                        );

                    menor_de_idade = valor ? 1 : 0;
                }


                // =================================================
                // DATA DE NASCIMENTO
                // =================================================

                DateTime? data_nasc = null;

                if (linha.Cells["data_nasc"].Value != null &&
                    linha.Cells["data_nasc"].Value != DBNull.Value &&
                    !string.IsNullOrWhiteSpace(
                        linha.Cells["data_nasc"].Value.ToString()))
                {
                    DateTime data;

                    if (DateTime.TryParse(
                        linha.Cells["data_nasc"].Value.ToString(),
                        out data))
                    {
                        data_nasc = data;
                    }
                }


                // =================================================
                // NÚMERO DA CASA
                // =================================================

                int? num_casa = null;

                if (linha.Cells["num_casa"].Value != null &&
                    linha.Cells["num_casa"].Value != DBNull.Value &&
                    !string.IsNullOrWhiteSpace(
                        linha.Cells["num_casa"].Value.ToString()))
                {
                    int numero;

                    if (int.TryParse(
                        linha.Cells["num_casa"].Value.ToString(),
                        out numero))
                    {
                        num_casa = numero;
                    }
                    else
                    {
                        MessageBox.Show(
                            "O número da casa precisa ser um número válido.",
                            "Atenção",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }
                }


                // =================================================
                // CHAMA O MÉTODO DO BANCO
                // =================================================

                editar_aluno_bd editar =
                    new editar_aluno_bd();

                editar.alterar(
                    id_aluno,
                    usuario,
                    cpf,
                    senha,
                    nome_responsavel,
                    telefone_resp,
                    cpf_responsavel,
                    bairro,
                    menor_de_idade,
                    turma_idade,
                    data_nasc,
                    rua,
                    num_casa,
                    telefone
                );


                // =================================================
                // VOLTA PARA O MODO NORMAL
                // =================================================

                modoEdicao = false;

                dataGridView1.ReadOnly = true;


                // =================================================
                // RECARREGA OS DADOS
                // =================================================

                DataTable tabela =
                    ss.consultar();

                dataGridView1.DataSource = tabela;

                configurarColunas();


                MessageBox.Show(
                    "Aluno alterado com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao editar aluno:\n\n" +
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // =========================================================
        // LOAD
        // =========================================================

        private void editar_aluno_Load(object sender, EventArgs e)
        {
        }


        // =========================================================
        // EVENTO DO DATAGRIDVIEW
        // =========================================================

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }
    }
}