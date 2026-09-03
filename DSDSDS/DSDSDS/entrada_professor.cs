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
    public partial class entrada_professor : Form
    {
        public entrada_professor()
        {
            InitializeComponent();
        }

        private void entrada_professor_Load(object sender, EventArgs e)
        {
            CircularPanel painel = new CircularPanel();

            painel.Size = new Size(90, 90);
            painel.BackColor = Color.FromArgb(255, 235, 238);
            painel.Location = new Point(100, 100);

            this.Controls.Add(painel);
        }
        alunos al = new alunos();
        private void btn_consultar_Click(object sender, EventArgs e)
        {



        }

        private void dataGv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Hide();
            criacaoTurmas saf = new criacaoTurmas();
            saf.Show();
        }

        private void buttonPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
