using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
namespace DSDSDS
{
    internal class alunos :conexao
    {

        public DataTable consultar()
        {
            this.abrirconexao();
            string Msql = "SELECT * FROM aluno";
            MySqlCommand cmd = new MySqlCommand(Msql, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            this.fecharconexao();
            DataTable dt = new DataTable(); 
            da.Fill (dt);
            return dt;
        }




    }
}
