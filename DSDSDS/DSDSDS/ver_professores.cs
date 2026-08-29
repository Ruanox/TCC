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
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
        consultar ss = new consultar();
        private void btn_consultar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ss.Consultar();
        }
    }
}
