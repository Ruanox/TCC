using System.Data;
using MySql.Data.MySqlClient;

namespace DSDSDS
{
    internal class alunosTurma : conexao
    {
        public DataTable consultar()
        {
            this.abrirconexao();

            string sql = "SELECT id_aluno, usuario, data_nasc, altura, peso FROM aluno";

            MySqlCommand cmd = new MySqlCommand(sql, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            this.fecharconexao();

            return dt;
        }
    }
}