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
    public partial class escola : Form
    {
        public escola()
        {
            InitializeComponent();
            CustomizeDesign();

        }

        private void CustomizeDesign()
        {
            panelcadSubMenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelcadSubMenu.Visible == true)
            {
                panelcadSubMenu.Visible = false;
            }
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


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_aluno_Click(object sender, EventArgs e)
        {
            Hide();
            informacao informacao = new informacao();
            informacao.Show();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            showSubMenu(panelcadSubMenu);
        }

        private void btn_escola_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void _KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void btn_escola_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Documentos_escola Documentos_escola = new Documentos_escola();
            Documentos_escola.Show();
        }
    }
}
