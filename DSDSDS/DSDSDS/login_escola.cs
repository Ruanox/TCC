using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSDSDS
{
    internal class login_escola:conexao
    {

        private string usuario;
      
        private int cnpj;

        public void setCnpj(int cnpj)
        {
            this.cnpj = cnpj;
        }
        public int getCnpj()
        {
            return this.cnpj;
        }
        public void setUsuario(string usuario)
        {
            this.usuario = usuario;
        }
        public string getUsuario()
        {

            return this.usuario;
        }
      

        public int consultarLogin()
        {
            this.abrirconexao();

            string mSQL = "SELECT COUNT(usuario) from escola where usuario ='" + getUsuario() + "'and cnpj = '" +getCnpj() + "'";
            MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            Int32 resultado_query = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();

            int valor_login;
            valor_login = resultado_query;
            this.fecharconexao();
            return valor_login;


        }




    }
}
