using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data;
namespace DSDSDS
{
    internal class excluir_prof:inserir_professor
    {
        public void excluir()
        {
            try
            {
                string query = @"DELETE FROM professor
                                 WHERE id_professor = @id_professor";

                if (abrirconexao())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);

                    cmd.Parameters.AddWithValue(
                        "@id_professor",
                        getId_professor()
                    );

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                fecharconexao();
            }
        }


    }
}
