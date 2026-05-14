using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSDSDS
{
    public partial class Documentos_escola : Form
    {
        public Documentos_escola()
        {
            InitializeComponent();
            txtbox_email.KeyPress += txtbox_email_KeyPress;
        }

        private void txtbox_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) &&
       e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '_' &&
       !char.IsControl(e.KeyChar)) // Control inclui backspace
            {
                e.Handled = true; // Impede a tecla de ser digitada
                MessageBox.Show("Só letras, números, @, ., - e _ no email! Como em 'aluno@suaescola.br'", "Email da escola",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn__Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace (txtbox_nome.Text) || string.IsNullOrWhiteSpace(txtbox_email.Text) || string.IsNullOrWhiteSpace(txtbox_senha.Text) || string.IsNullOrWhiteSpace(msk_tel.Text) || string.IsNullOrWhiteSpace(txtbox_estado.Text) || string.IsNullOrWhiteSpace(txtbox_rua.Text)|| string.IsNullOrWhiteSpace(txtbox_bairro.Text) || string.IsNullOrWhiteSpace(txtbox_cidade.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }
            if (!txtbox_email.Text.Contains("@") || !txtbox_email.Text.Contains(".gov.br"))
            {
                MessageBox.Show("Email precisa de @ e .gov.br! Ex: escola@exemplo.gov.br");
                txtbox_email.Focus();
                return;
            }
            else
            {

            }



        }
    }
}
