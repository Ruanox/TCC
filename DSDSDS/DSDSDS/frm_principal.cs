using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace DSDSDS

{
    public partial class Form_principal : Form
    {
        public Form_principal()
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
      
      
        private void lbl_tel_Click(object sender, EventArgs e)
        {

        }

    

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_home_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_cadastro_Click(object sender, EventArgs e)
        {


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(panelcadSubMenu);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            informacao informacao = new informacao();
            informacao.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            professor professor = new professor();
            professor.Show();
        }

        private void btn_escola_Click(object sender, EventArgs e)
        {
            this.Hide();
            Documentos_escola Documentos_escola = new Documentos_escola();
            Documentos_escola.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }
    }
}
