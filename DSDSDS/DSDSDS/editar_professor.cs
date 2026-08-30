using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSDSDS
{
    internal class editar_professor : inserir_professor
    {
        public void alterar()
        {
            string query = @"UPDATE professor 
                 SET cpf = @cpf,
                     usuario = @usuario,
                     email = @email,
                     telefone = @telefone,
                     bairro = @bairro,
                     rua = @rua,
                     num_casa = @num_casa
                 WHERE id_professor = @id_professor";

            if (abrirconexao())
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);

                cmd.Parameters.AddWithValue("@id_professor", getId_professor());
                cmd.Parameters.AddWithValue("@cpf", getCpf());
                cmd.Parameters.AddWithValue("@usuario", getUsuario());
                cmd.Parameters.AddWithValue("@email", getEmail());
                cmd.Parameters.AddWithValue("@telefone", getTelefone());
                cmd.Parameters.AddWithValue("@bairro", getBairro());
                cmd.Parameters.AddWithValue("@rua", getRua());
                cmd.Parameters.AddWithValue("@num_casa", getNum_casa());

                cmd.ExecuteNonQuery();

                fecharconexao();
            }
        }


    }


}
