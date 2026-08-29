using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace DSDSDS
{
    internal class conexao
    {
        public MySqlConnection conectar;
        public string servidor;
        public string database;
        public string usuario;
        public string senha;

        public conexao()
        {
            inicializar();
        }

        public void inicializar()
        {
            servidor = "127.0.0.1";
            database = "volei";
            usuario = "root";
            senha = "";
            string conexaostring;
            conexaostring = "SERVER=" + servidor + ";" + "DATABASE=" + database + ";" + "UID=" + usuario + ";" + "PASSWORD=" + senha + ";";      
            conectar = new MySqlConnection(conexaostring);
        }
         
        public bool abrirconexao()
        {
            try
            {
                conectar.Open();
                    return true;
            }
            catch(MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        System.Windows.Forms.MessageBox.Show("Não foi possivel conectar");
                        break;
                    case 1045: System.Windows.Forms.MessageBox.Show("Usuario e senha invalidos! verifique");
                        break;
                }
                return false;
            }
        }
        public bool fecharconexao()
        {
            try
            {
                conectar.Close();
                return true;
            }
            catch(MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

                
        }




    }
}
