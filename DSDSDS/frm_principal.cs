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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lbl_tel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_cadastrar frm_cadastrar = new frm_cadastrar();
            frm_cadastrar.Show();
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
            aluno aluno = new aluno();
            aluno.Show();
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
            escola escola = new escola();
            escola.Show();
        }
    }
}
