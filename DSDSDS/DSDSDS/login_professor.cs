using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSDSDS
{
    internal class login_professor:conexao
    {
        private string usuario;
        private string senha;

        public void setUsuario(string usuario)
        {
            this.usuario = usuario;
        }
        public string getUsuario()
        {

            return this.usuario;
        }
        public void setSenha(string senha)
        {
            this.senha = senha;
        }
        public string getSenha()
        {

            return this.senha;

        }
        public int consultarLogin()
        {
            this.abrirconexao();

            string mSQL = "SELECT COUNT(usuario) from professor where usuario ='" + getUsuario() + "'and senha = '" + getSenha() + "'";
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
