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
    public partial class aluno : Form
    {
        public aluno()
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
        private void btn_info_Click(object sender, EventArgs e)
        {
            this.Hide();
            informacao informacao = new informacao();
            informacao.Show();
        }

       

        private void btnSelect_Click(object sender, EventArgs e)
        {
            showSubMenu(panelcadSubMenu);
        }
    }
}
