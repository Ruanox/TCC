using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DSDSDS
{
    internal class criarTurma : conexao
    {
        public void Criar(
            string nomeTurma,
            int idadeTurma,
            int idTurno,
            string horarioInicio,
            string horarioFim,
            List<int> dias,
            HashSet<int> alunos)
        {
            if (!abrirconexao())
                throw new Exception(
                    "Não foi possível conectar ao banco de dados."
                );

            MySqlTransaction transacao =
                conectar.BeginTransaction();

            try
            {
                string sqlTurma =
                    "INSERT INTO turma " +
                    "(nome_turma, idade_turma, id_turno) " +
                    "VALUES (@nome, @idade, @turno)";

                MySqlCommand cmdTurma =
                    new MySqlCommand(
                        sqlTurma,
                        conectar,
                        transacao
                    );

                cmdTurma.Parameters.AddWithValue(
                    "@nome",
                    nomeTurma
                );

                cmdTurma.Parameters.AddWithValue(
                    "@idade",
                    idadeTurma
                );

                cmdTurma.Parameters.AddWithValue(
                    "@turno",
                    idTurno
                );

                cmdTurma.ExecuteNonQuery();

                int idTurma =
                    Convert.ToInt32(
                        new MySqlCommand(
                            "SELECT LAST_INSERT_ID()",
                            conectar,
                            transacao
                        ).ExecuteScalar()
                    );

                DateTime horaInicio =
                    DateTime.Parse(horarioInicio);

                DateTime horaFim =
                    DateTime.Parse(horarioFim);

                foreach (int idDia in dias)
                {
                    string sqlHorario =
                        "INSERT INTO horario " +
                        "(id_dia, hora_inicio, hora_fim) " +
                        "VALUES (@dia, @inicio, @fim)";

                    MySqlCommand cmdHorario =
                        new MySqlCommand(
                            sqlHorario,
                            conectar,
                            transacao
                        );

                    cmdHorario.Parameters.AddWithValue(
                        "@dia",
                        idDia
                    );

                    cmdHorario.Parameters.AddWithValue(
                        "@inicio",
                        horaInicio.ToString("HH:mm:ss")
                    );

                    cmdHorario.Parameters.AddWithValue(
                        "@fim",
                        horaFim.ToString("HH:mm:ss")
                    );

                    cmdHorario.ExecuteNonQuery();

                    int idHorario =
                        Convert.ToInt32(
                            new MySqlCommand(
                                "SELECT LAST_INSERT_ID()",
                                conectar,
                                transacao
                            ).ExecuteScalar()
                        );

                    string sqlTurmaHorario =
                        "INSERT INTO turma_horario " +
                        "(id_turma, id_horario) " +
                        "VALUES (@turma, @horario)";

                    MySqlCommand cmdTurmaHorario =
                        new MySqlCommand(
                            sqlTurmaHorario,
                            conectar,
                            transacao
                        );

                    cmdTurmaHorario.Parameters.AddWithValue(
                        "@turma",
                        idTurma
                    );

                    cmdTurmaHorario.Parameters.AddWithValue(
                        "@horario",
                        idHorario
                    );

                    cmdTurmaHorario.ExecuteNonQuery();
                }

                foreach (int idAluno in alunos)
                {
                    string sqlAluno =
                        "INSERT INTO turma_aluno " +
                        "(id_turma, id_aluno) " +
                        "VALUES (@turma, @aluno)";

                    MySqlCommand cmdAluno =
                        new MySqlCommand(
                            sqlAluno,
                            conectar,
                            transacao
                        );

                    cmdAluno.Parameters.AddWithValue(
                        "@turma",
                        idTurma
                    );

                    cmdAluno.Parameters.AddWithValue(
                        "@aluno",
                        idAluno
                    );

                    cmdAluno.ExecuteNonQuery();

                    string sqlIdade =
                        "UPDATE aluno " +
                        "SET turma_idade = @idade " +
                        "WHERE id_aluno = @aluno";

                    MySqlCommand cmdIdade =
                        new MySqlCommand(
                            sqlIdade,
                            conectar,
                            transacao
                        );

                    cmdIdade.Parameters.AddWithValue(
                        "@idade",
                        idadeTurma
                    );

                    cmdIdade.Parameters.AddWithValue(
                        "@aluno",
                        idAluno
                    );

                    cmdIdade.ExecuteNonQuery();
                }

                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
                throw;
            }
            finally
            {
                fecharconexao();
            }
        }
    }
}