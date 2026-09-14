using MySql.Data.MySqlClient;
using System;

namespace DSDSDS
{
    internal class controle_modalidade : conexao
    {
        public bool VerificarCadastro(int idModalidade, DateTime dataNascimento, out string mensagem)
        {
            mensagem = "";

            if (!this.abrirconexao())
            {
                mensagem = "Não foi possível conectar ao banco de dados.";
                return false;
            }

            try
            {
                string queryModalidade = @"
                    SELECT vagas, idade_min, idade_max
                    FROM modalidade
                    WHERE id_modalidade = @id_modalidade
                ";

                MySqlCommand cmdModalidade = new MySqlCommand(
                    queryModalidade,
                    conectar
                );

                cmdModalidade.Parameters.AddWithValue(
                    "@id_modalidade",
                    idModalidade
                );

                using (MySqlDataReader reader = cmdModalidade.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        mensagem = "A modalidade não foi encontrada.";
                        return false;
                    }

                    int vagas = Convert.ToInt32(reader["vagas"]);
                    int idadeMin = Convert.ToInt32(reader["idade_min"]);
                    int idadeMax = Convert.ToInt32(reader["idade_max"]);

                    reader.Close();

                    DateTime hoje = DateTime.Today;

                    int idade = hoje.Year - dataNascimento.Year;

                    if (dataNascimento.Date > hoje.AddYears(-idade))
                    {
                        idade--;
                    }

                    if (idade < idadeMin || idade > idadeMax)
                    {
                        mensagem =
                            "A idade do aluno não está dentro da faixa permitida.\n\n" +
                            "Idade permitida: " + idadeMin + " a " + idadeMax + " anos.\n" +
                            "Idade do aluno: " + idade + " anos.";

                        return false;
                    }

                    string queryQuantidade = @"
                        SELECT COUNT(*)
                        FROM aluno
                    ";

                    MySqlCommand cmdQuantidade = new MySqlCommand(
                        queryQuantidade,
                        conectar
                    );

                    int quantidadeAlunos = Convert.ToInt32(
                        cmdQuantidade.ExecuteScalar()
                    );

                    if (quantidadeAlunos >= vagas)
                    {
                        mensagem =
                            "As vagas da modalidade estão esgotadas.\n\n" +
                            "Limite de alunos: " + vagas + ".";

                        return false;
                    }

                    return true;
                }
            }
            finally
            {
                this.fecharconexao();
            }
        }
    }
}