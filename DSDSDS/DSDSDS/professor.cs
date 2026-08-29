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
    public partial class professor : Form
    {
        public professor()
        {
            InitializeComponent();
            CustomizeDesign();
        }
        private void CustomizeDesign()
        {

        }
        private void hideSubMenu()
        {

        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void btn_aluno_Click(object sender, EventArgs e)
        {

        }

        private void professor_Load(object sender, EventArgs e)
        {

        }

        private void panel_logo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void btn_info_Click(object sender, EventArgs e)
        {

        }

        private void lbl_idade_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
        login_professor l = new login_professor();
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            l.setUsuario(txtbox_usuario.Text);
            l.setSenha(txtbox_senha.Text);
            l.consultarLogin();

            int valor = l.consultarLogin();
            if (valor == 1)
            {
                entrada_professor nsei = new entrada_professor();
                nsei.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("usuario e senhas Invalidos", "acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form_principal frm_principa = new Form_principal();
            frm_principa.Show();

        }

        private void btn_voltar_menu_Click(object sender, EventArgs e)
        {
            Hide();
            Form_principal abcdefg = new Form_principal();
            abcdefg.Show();
        }
    }
}
