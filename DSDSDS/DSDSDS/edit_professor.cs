using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class edit_professor : Form
    {
        consultar ss = new consultar();
        editar_professor papa = new editar_professor();

        private bool modoEdicao = false;
        private DataGridViewRow linhaEmEdicao = null;

        public edit_professor()
        {
            InitializeComponent();

            // =====================================================
            // PAINEL INICIAL
            // =====================================================

            panel_vazio.Visible = true;

            // Esconde a tabela até clicar em Buscar
            dataGridView1.Visible = false;

            // =====================================================
            // CONFIGURAÇÃO DO DATAGRIDVIEW
            // =====================================================

            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;

            dataGridView1.ScrollBars = ScrollBars.Both;

            // Começa bloqueado
            dataGridView1.ReadOnly = true;

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
        // BOTÃO VOLTAR
        // =====================================================

        private void label9_Click(object sender, EventArgs e)
        {
            Hide();

            Add_prof_ asd = new Add_prof_();

            asd.Show();
        }

        // =====================================================
        // BOTÃO EDITAR
        // =====================================================

        private void label12_Click(object sender, EventArgs e)
        {
            try
            {
                // =================================================
                // PRIMEIRO CLIQUE
                // ENTRAR NO MODO DE EDIÇÃO
                // =================================================

                if (!modoEdicao)
                {
                    // Verifica se existe uma linha selecionada
                    if (dataGridView1.SelectedRows.Count == 0)
                    {
                        MessageBox.Show(
                            "Selecione um professor para editar.",
                            "Atenção",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                    // Guarda a linha selecionada
                    linhaEmEdicao =
                        dataGridView1.SelectedRows[0];

                    // Libera a edição
                    dataGridView1.ReadOnly = false;

                    // =================================================
                    // ID CONTINUA BLOQUEADO
                    // =================================================

                    if (dataGridView1.Columns.Contains("id_professor"))
                    {
                        dataGridView1.Columns["id_professor"]
                            .ReadOnly = true;
                    }

                    // =================================================
                    // CPF LIBERADO
                    // =================================================

                    if (dataGridView1.Columns.Contains("cpf"))
                    {
                        dataGridView1.Columns["cpf"]
                            .ReadOnly = false;
                    }

                    modoEdicao = true;

                    MessageBox.Show(
                        "Modo de edição ativado!\n\n" +
                        "Agora você pode alterar os dados diretamente na tabela.\n\n" +
                        "Clique novamente em Editar para salvar.",
                        "Editar professor",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                // =================================================
                // SEGUNDO CLIQUE
                // SALVAR ALTERAÇÕES
                // =================================================

                if (linhaEmEdicao == null)
                {
                    MessageBox.Show(
                        "Nenhum professor foi selecionado.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Finaliza a edição da célula atual
                dataGridView1.EndEdit();

                // =================================================
                // PEGAR ID
                // =================================================

                int idProfessor = Convert.ToInt32(
                    linhaEmEdicao
                        .Cells["id_professor"]
                        .Value
                );

                // =================================================
                // PEGAR DADOS EDITADOS
                // =================================================

                long cpf = Convert.ToInt64(
                    linhaEmEdicao
                        .Cells["cpf"]
                        .Value
                );

                string usuario = Convert.ToString(
                    linhaEmEdicao
                        .Cells["usuario"]
                        .Value
                );

                string email = Convert.ToString(
                    linhaEmEdicao
                        .Cells["email"]
                        .Value
                );

                string telefone = Convert.ToString(
                    linhaEmEdicao
                        .Cells["telefone"]
                        .Value
                );

                string bairro = Convert.ToString(
                    linhaEmEdicao
                        .Cells["bairro"]
                        .Value
                );

                string rua = Convert.ToString(
                    linhaEmEdicao
                        .Cells["rua"]
                        .Value
                );

                int numCasa = Convert.ToInt32(
                    linhaEmEdicao
                        .Cells["num_casa"]
                        .Value
                );

                // =================================================
                // COLOCAR OS DADOS NO OBJETO
                // =================================================

                papa.setId_professor(idProfessor);

                papa.setCpf(cpf);

                papa.setUsuario(usuario);

                papa.setEmail(email);

                papa.setTelefone(telefone);

                papa.setBairro(bairro);

                papa.setRua(rua);

                papa.setNum_casa(numCasa);

                // =================================================
                // CONFIRMAR ALTERAÇÃO
                // =================================================

                DialogResult resposta = MessageBox.Show(
                    "Deseja salvar as alterações deste professor?",
                    "Confirmar alteração",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resposta == DialogResult.Yes)
                {
                    // Executa o UPDATE
                    papa.alterar();

                    MessageBox.Show(
                        "Professor alterado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // =================================================
                    // VOLTAR PARA MODO NORMAL
                    // =================================================

                    dataGridView1.ReadOnly = true;

                    modoEdicao = false;

                    linhaEmEdicao = null;

                    // =================================================
                    // ATUALIZAR DATAGRIDVIEW
                    // =================================================

                    DataTable dados = ss.Consultar();

                    if (dados != null && dados.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dados;

                        dataGridView1.Visible = true;
                        panel_vazio.Visible = false;

                        // Reaplica aparência das colunas
                        configurarColunas();

                        // ID continua bloqueado
                        if (dataGridView1.Columns.Contains("id_professor"))
                        {
                            dataGridView1.Columns["id_professor"]
                                .ReadOnly = true;
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = null;

                        dataGridView1.Visible = false;
                        panel_vazio.Visible = true;
                    }
                }
                else
                {
                    // Continua no modo de edição
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao editar professor:\n\n" +
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // BOTÃO BUSCAR / VISUALIZAR
        // =====================================================

        private void label10_Click(object sender, EventArgs e)
        {
            try
            {
                // Consulta os professores
                DataTable dados = ss.Consultar();

                if (dados != null && dados.Rows.Count > 0)
                {
                    // Mostra tabela
                    panel_vazio.Visible = false;
                    dataGridView1.Visible = true;

                    // Coloca dados no DataGridView
                    dataGridView1.DataSource = dados;

                    // Começa bloqueado
                    dataGridView1.ReadOnly = true;

                    // Seleção de linha inteira
                    dataGridView1.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.MultiSelect = false;

                    // =================================================
                    // CONFIGURA APARÊNCIA
                    // =================================================

                    configurarColunas();

                    // =================================================
                    // ID NÃO PODE SER EDITADO
                    // =================================================

                    if (dataGridView1.Columns.Contains("id_professor"))
                    {
                        dataGridView1.Columns["id_professor"]
                            .ReadOnly = true;
                    }
                }
                else
                {
                    // Não encontrou professores
                    dataGridView1.DataSource = null;

                    dataGridView1.Visible = false;
                    panel_vazio.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao buscar os professores:\n\n" +
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

        // =====================================================
        // DATAGRIDVIEW
        // =====================================================

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        // =====================================================
        // LOAD
        // =====================================================

        private void edit_professor_Load(
            object sender,
            EventArgs e)
        {
        }
    }
}