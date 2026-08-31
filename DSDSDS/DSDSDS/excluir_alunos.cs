using MySql.Data.MySqlClient;
using System;
using MySql.Data;
namespace DSDSDS
{
    internal class excluir_alunos : inserir_aluno
    {
        private int id_aluno;

        public void setIdAluno(int id_aluno)
        {
            this.id_aluno = id_aluno;
        }

        public int getIdAluno()
        {
            return this.id_aluno;
        }

        public void excluir()
        {
            if (this.abrirconexao())
            {
                MySqlTransaction transacao = null;

                try
                {
                    transacao = conectar.BeginTransaction();

                    // =====================================================
                    // 1 - Exclui as presenças do aluno
                    // =====================================================

                    string queryPresenca = @"
                        DELETE FROM presenca
                        WHERE id_aluno = @id_aluno";

                    MySqlCommand cmdPresenca =
                        new MySqlCommand(queryPresenca, conectar, transacao);

                    cmdPresenca.Parameters.AddWithValue(
                        "@id_aluno",
                        getIdAluno()
                    );

                    cmdPresenca.ExecuteNonQuery();


                    // =====================================================
                    // 2 - Exclui a matrícula do aluno
                    // =====================================================

                    string queryMatricula = @"
                        DELETE FROM matricula
                        WHERE id_aluno = @id_aluno";

                    MySqlCommand cmdMatricula =
                        new MySqlCommand(queryMatricula, conectar, transacao);

                    cmdMatricula.Parameters.AddWithValue(
                        "@id_aluno",
                        getIdAluno()
                    );

                    cmdMatricula.ExecuteNonQuery();


                    // =====================================================
                    // 3 - Exclui o aluno
                    // =====================================================

                    string queryAluno = @"
                        DELETE FROM aluno
                        WHERE id_aluno = @id_aluno";

                    MySqlCommand cmdAluno =
                        new MySqlCommand(queryAluno, conectar, transacao);

                    cmdAluno.Parameters.AddWithValue(
                        "@id_aluno",
                        getIdAluno()
                    );

                    int linhasAfetadas = cmdAluno.ExecuteNonQuery();


                    // =====================================================
                    // Confirma tudo
                    // =====================================================

                    if (linhasAfetadas == 0)
                    {
                        throw new Exception(
                            "Nenhum aluno foi encontrado com o ID informado."
                        );
                    }

                    transacao.Commit();
                }
                catch
                {
                    if (transacao != null)
                    {
                        transacao.Rollback();
                    }

                    throw;
                }
                finally
                {
                    this.fecharconexao();
                }
            }
        }
    }
}