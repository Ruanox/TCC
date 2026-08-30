using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            // Inicialmente mostra o painel de "nenhum professor"
            panel_vazio.Visible = true;

            // Esconde a tabela até clicar em Buscar
            dataGridView1.Visible = false;

            // Configurações do DataGridView
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            // Começa bloqueado
            dataGridView1.ReadOnly = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Hide();
            Add_prof_ asd = new Add_prof_();
            asd.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            try
            {
                // =================================================
                // PRIMEIRO CLIQUE
                // Entrar no modo de edição
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
                    linhaEmEdicao = dataGridView1.SelectedRows[0];

                    // Libera a edição
                    dataGridView1.ReadOnly = false;

                    // O ID continua bloqueado
                    if (dataGridView1.Columns.Contains("id_professor"))
                    {
                        dataGridView1.Columns["id_professor"].ReadOnly = true;
                    }

                    // CPF continua LIBERADO
                    if (dataGridView1.Columns.Contains("cpf"))
                    {
                        dataGridView1.Columns["cpf"].ReadOnly = false;
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
                // Salvar alterações
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
                // PEGAR O ID DO PROFESSOR
                // =================================================

                int idProfessor = Convert.ToInt32(
                    linhaEmEdicao.Cells["id_professor"].Value
                );


                // =================================================
                // PEGAR OS DADOS EDITADOS
                // =================================================

                long cpf = Convert.ToInt64(
                    linhaEmEdicao.Cells["cpf"].Value
                );

                string usuario = Convert.ToString(
                    linhaEmEdicao.Cells["usuario"].Value
                );

                string email = Convert.ToString(
                    linhaEmEdicao.Cells["email"].Value
                );

                string telefone = Convert.ToString(
                    linhaEmEdicao.Cells["telefone"].Value
                );

                string bairro = Convert.ToString(
                    linhaEmEdicao.Cells["bairro"].Value
                );

                string rua = Convert.ToString(
                    linhaEmEdicao.Cells["rua"].Value
                );

                int numCasa = Convert.ToInt32(
                    linhaEmEdicao.Cells["num_casa"].Value
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
                    // VOLTAR PARA O MODO NORMAL
                    // =================================================

                    dataGridView1.ReadOnly = true;

                    modoEdicao = false;

                    linhaEmEdicao = null;


                    // =================================================
                    // ATUALIZAR O DATAGRIDVIEW
                    // =================================================

                    DataTable dados = ss.Consultar();

                    if (dados != null && dados.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dados;

                        dataGridView1.Visible = true;
                        panel_vazio.Visible = false;

                        // ID continua bloqueado
                        if (dataGridView1.Columns.Contains("id_professor"))
                        {
                            dataGridView1.Columns["id_professor"].ReadOnly = true;
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
                    // Se clicou em NÃO, continua no modo de edição
                    // para que possa corrigir os dados.
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
        // DATAGRIDVIEW
        // =====================================================

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }
         

        private void label10_Click(object sender, EventArgs e)
        {
            try
            {
                // Consulta os professores
                DataTable dados = ss.Consultar();

                if (dados != null && dados.Rows.Count > 0)
                {
                    // Mostra a tabela
                    panel_vazio.Visible = false;
                    dataGridView1.Visible = true;

                    // Coloca os dados no DataGridView
                    dataGridView1.DataSource = dados;

                    // A tabela começa bloqueada
                    dataGridView1.ReadOnly = true;

                    // Permite selecionar uma linha inteira
                    dataGridView1.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.MultiSelect = false;

                    // O ID nunca deve ser alterado
                    if (dataGridView1.Columns.Contains("id_professor"))
                    {
                        dataGridView1.Columns["id_professor"].ReadOnly = true;
                    }

                    // CPF NÃO é bloqueado
                    // Portanto, poderá ser editado.
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
    }
}

