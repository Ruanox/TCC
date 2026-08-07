using K4os.Compression.LZ4.Streams.Adapters;
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

        }

        private void txtbox_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_email_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void btn__Click(object sender, EventArgs e)
        {
            try
            {


            }

            finally
            {
                MessageBox.Show("Informações gravadas com sucesso");
            }


        }

        private void group_Escola_Enter(object sender, EventArgs e)
        {

        }

        private void btn_escola_Click(object sender, EventArgs e)
        {

        }
        login_escola l = new login_escola();
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            l.setUsuario(txtbox_usuario.Text);
            l.setCnpj(int.Parse(txtbox_cnpj.Text));
            l.consultarLogin();

            int valor = l.consultarLogin();
            if (valor == 1)
            {
                entrada_escola formulario = new entrada_escola();
                formulario.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("usuario e senhas Invalidos", "acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_principal nsei = new Form_principal();
            nsei.Show();
        }

        private void panelcadSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtbox_usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void Documentos_escola_Load(object sender, EventArgs e)
        {

        }
    }
}
