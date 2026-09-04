using MySql.Data.MySqlClient;
using System;

namespace DSDSDS
{
    internal class editar_aluno_bd : conexao
    {
        public void alterar(
            int id_aluno,
            string usuario,
            string cpf,
            string senha,
            string nome_responsavel,
            string telefone_resp,
            string cpf_responsavel,
            string bairro,
            int menor_de_idade,
            string turma_idade,
            DateTime? data_nasc,
            string rua,
            int? num_casa,
            string telefone,
            decimal peso,
            decimal altura
        )
        {
            string query = @"
                UPDATE aluno SET
                    usuario = @usuario,
                    cpf = @cpf,
                    senha = @senha,
                    nome_responsavel = @nome_responsavel,
                    telefone_resp = @telefone_resp,
                    cpf_responsavel = @cpf_responsavel,
                    bairro = @bairro,
                    menor_de_idade = @menor_de_idade,
                    turma_idade = @turma_idade,
                    data_nasc = @data_nasc,
                    rua = @rua,
                    num_casa = @num_casa,
                    telefone = @telefone,
                    peso = @peso,
                    altura = @altura
                WHERE id_aluno = @id_aluno
            ";

            if (this.abrirconexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);

                    cmd.Parameters.AddWithValue("@id_aluno", id_aluno);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    cmd.Parameters.AddWithValue(
                        "@nome_responsavel",
                        string.IsNullOrWhiteSpace(nome_responsavel)
                            ? (object)DBNull.Value
                            : nome_responsavel
                    );

                    cmd.Parameters.AddWithValue(
                        "@telefone_resp",
                        string.IsNullOrWhiteSpace(telefone_resp)
                            ? (object)DBNull.Value
                            : telefone_resp
                    );

                    cmd.Parameters.AddWithValue(
                        "@cpf_responsavel",
                        string.IsNullOrWhiteSpace(cpf_responsavel)
                            ? (object)DBNull.Value
                            : cpf_responsavel
                    );

                    cmd.Parameters.AddWithValue(
                        "@bairro",
                        string.IsNullOrWhiteSpace(bairro)
                            ? (object)DBNull.Value
                            : bairro
                    );

                    cmd.Parameters.AddWithValue(
                        "@menor_de_idade",
                        menor_de_idade
                    );

                    cmd.Parameters.AddWithValue(
                        "@turma_idade",
                        string.IsNullOrWhiteSpace(turma_idade)
                            ? (object)DBNull.Value
                            : turma_idade
                    );

                    cmd.Parameters.AddWithValue(
                        "@data_nasc",
                        data_nasc.HasValue
                            ? (object)data_nasc.Value
                            : DBNull.Value
                    );

                    cmd.Parameters.AddWithValue(
                        "@rua",
                        string.IsNullOrWhiteSpace(rua)
                            ? (object)DBNull.Value
                            : rua
                    );

                    cmd.Parameters.AddWithValue(
                        "@num_casa",
                        num_casa.HasValue
                            ? (object)num_casa.Value
                            : DBNull.Value
                    );

                    cmd.Parameters.AddWithValue(
                        "@telefone",
                        string.IsNullOrWhiteSpace(telefone)
                            ? (object)DBNull.Value
                            : telefone
                    );

                    cmd.Parameters.AddWithValue("@peso", peso);
                    cmd.Parameters.AddWithValue("@altura", altura);

                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    this.fecharconexao();
                }
            }
        }
    }
}