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
    public partial class ver_professores : Form
    {
        public ver_professores()
        {
            InitializeComponent();
            panel_vazio.Visible = true;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        consultar ss = new consultar();
        private void btn_consultar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ss.Consultar();
            panel_vazio.Visible = false;
        }

        private void buttonPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void ver_professores_Load(object sender, EventArgs e)
        {

        }

        private void buttonPanel1_Click(object sender, EventArgs e)
        {
            Hide();
            Add_prof_ asdas = new Add_prof_();
            asdas.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Hide();
            Add_prof_ ddd = new Add_prof_();
            ddd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
        }

        private void buttonPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ss.Consultar();
            panel_vazio.Visible = false;
        }
    }
}
