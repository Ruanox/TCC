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
    public partial class excluir_professor : Form
    {
        excluir_prof papa = new excluir_prof();
        consultar ss = new consultar();

        public excluir_professor()
        {
            InitializeComponent();

            panel_vazio.Visible = true;
        }

        private void excluir_professor_Load(object sender, EventArgs e)
        {
        }

        // BOTÃO VOLTAR
        private void label9_Click(object sender, EventArgs e)
        {
            Hide();

            Add_prof_ jairo = new Add_prof_();
            jairo.Show();
        }

        // BOTÃO VOLTAR / PAINEL
        private void buttonPanel1_Click(object sender, EventArgs e)
        {
            Hide();

            Add_prof_ jairo = new Add_prof_();
            jairo.Show();
        }

        // BOTÃO EXCLUIR
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

                // Pega o ID do professor selecionado
                int idProfessor = Convert.ToInt32(
                    dataGridView1.SelectedRows[0]
                    .Cells["id_professor"].Value
                );

                // Coloca o ID no objeto
                papa.setId_professor(idProfessor);

                // Confirma a exclusão
                DialogResult resposta = MessageBox.Show(
                    "Tem certeza que deseja excluir este professor?\n\n" +
                    "Os horários relacionados a ele também serão excluídos.",
                    "Confirmar exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resposta == DialogResult.Yes)
                {
                    // Executa a exclusão
                    papa.excluir();

                    MessageBox.Show(
                        "Professor excluído com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Atualiza a tabela
                    DataTable dados = ss.Consultar();

                    if (dados != null && dados.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dados;

                        dataGridView1.Visible = true;
                        panel_vazio.Visible = false;
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

        // BOTÃO BUSCAR
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
    }
}