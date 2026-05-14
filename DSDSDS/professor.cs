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
            showSubMenu(panelcadSubMenu);
        }

        private void btn_info_Click(object sender, EventArgs e)
        {
            this.Hide();
            info_prof info_Prof = new info_prof();
            info_Prof.Show();
        }

        private void lbl_idade_Click(object sender, EventArgs e)
        {

        }
    }
}
