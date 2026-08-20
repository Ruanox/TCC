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
    public partial class ALN_ADD : Form
    {
        public ALN_ADD()
        {
            InitializeComponent();
            panel_resp.Visible = false;
        }
        inserir_aluno pu = new inserir_aluno();
        private void btn_pronto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtbox_idade.Text, out int idade))
                {
                    MessageBox.Show(
                        "Digite uma idade válida.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );



                    pu.setUsuario(txtbox_nome.Text);
                    pu.setSenha(txtbox_senha.Text);
                    pu.setIdade(txtbox_idade.Text);
                    pu.setBairro(txtbox_bairro.Text);
                    pu.setNomeResponsavel(txtbox_idade.Text);
                    pu.setTelefoneResponsavel(txtbox_tel_resp.Text);
                    pu.inserir();
                }
            }

            finally
            {
                MessageBox.Show("Aluno cadastrado com sucesso!!");
            }
        }



        

        private void txtbox_tel_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void circularPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_tel_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
       
        }
    }
}
