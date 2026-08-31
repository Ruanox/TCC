using MySql.Data.MySqlClient;
using System;

namespace DSDSDS
{
    internal class inserir_aluno : conexao
    {
        private string usuario;
        private DateTime data_nasc;
        private string cpf;
        private string nome_responsavel;
        private string telefone_resp;
        private string senha;
        private string cpf_responsavel;
        private string bairro;
        private string rua;
        private int num_casa;
        private string telefone;


        // =========================================================
        // USUARIO
        // =========================================================

        public string getUsuario()
        {
            return usuario;
        }

        public void setUsuario(string usuario)
        {
            this.usuario = usuario;
        }


        // =========================================================
        // DATA DE NASCIMENTO
        // =========================================================

        public DateTime getData_nasc()
        {
            return data_nasc;
        }

        public void setData_nasc(DateTime data_nasc)
        {
            this.data_nasc = data_nasc;
        }


        // =========================================================
        // CPF
        // =========================================================

        public string getCpf()
        {
            return cpf;
        }

        public void setCpf(string cpf)
        {
            this.cpf = cpf;
        }


        // =========================================================
        // NOME DO RESPONSÁVEL
        // =========================================================

        public string getNomeResponsavel()
        {
            return nome_responsavel;
        }

        public void setNomeResponsavel(string nome_responsavel)
        {
            this.nome_responsavel = nome_responsavel;
        }


        // =========================================================
        // TELEFONE DO RESPONSÁVEL
        // =========================================================

        public string getTelefoneResp()
        {
            return telefone_resp;
        }

        public void setTelefoneResp(string telefone_resp)
        {
            this.telefone_resp = telefone_resp;
        }


        // =========================================================
        // SENHA
        // =========================================================

        public string getSenha()
        {
            return senha;
        }

        public void setSenha(string senha)
        {
            this.senha = senha;
        }


        // =========================================================
        // CPF DO RESPONSÁVEL
        // =========================================================

        public string getCpfResponsavel()
        {
            return cpf_responsavel;
        }

        public void setCpfResponsavel(string cpf_responsavel)
        {
            this.cpf_responsavel = cpf_responsavel;
        }


        // =========================================================
        // BAIRRO
        // =========================================================

        public string getBairro()
        {
            return bairro;
        }

        public void setBairro(string bairro)
        {
            this.bairro = bairro;
        }


        // =========================================================
        // RUA
        // =========================================================

        public string getRua()
        {
            return rua;
        }

        public void setRua(string rua)
        {
            this.rua = rua;
        }


        // =========================================================
        // NUMERO DA CASA
        // =========================================================

        public int getNumCasa()
        {
            return num_casa;
        }

        public void setNumCasa(int num_casa)
        {
            this.num_casa = num_casa;
        }
       

        public string getTelefone()
        {
            return telefone;
        }

        public void setTelefone(string telefone)
        {
            this.telefone = telefone;
        }


        // =========================================================
        // CALCULAR IDADE
        // =========================================================

        private int CalcularIdade(DateTime dataNascimento)
        {
            DateTime hoje = DateTime.Today;

            int idade = hoje.Year - dataNascimento.Year;

            if (dataNascimento.Date > hoje.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }


        // =========================================================
        // INSERIR ALUNO
        // =========================================================

        public void inserir()
        {
            // Calcula a idade
            int idade = CalcularIdade(data_nasc);

            // Define se é menor de idade
            int menor_de_idade = idade < 18 ? 1 : 0;


            string query = @"
                INSERT INTO aluno
                (
                    usuario,
                    data_nasc,
                    cpf,
                    senha,
                    nome_responsavel,
                    telefone_resp,
                    cpf_responsavel,
                    bairro,
                    menor_de_idade,
                    turma_idade,
                    rua,
                    num_casa,
                    telefone
                )
                VALUES
                (
                    @usuario,
                    @data_nasc,
                    @cpf,
                    @senha,
                    @nome_responsavel,
                    @telefone_resp,
                    @cpf_responsavel,
                    @bairro,
                    @menor_de_idade,
                    @turma_idade,
                    @rua,
                    @num_casa,
                    @telefone
                )";


            if (this.abrirconexao())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conectar);


                    // =================================================
                    // ALUNO
                    // =================================================

                    cmd.Parameters.Add(
                        "@usuario",
                        MySqlDbType.VarChar
                    ).Value = usuario;


                    cmd.Parameters.Add(
                        "@data_nasc",
                        MySqlDbType.Date
                    ).Value = data_nasc.Date;


                    cmd.Parameters.Add(
                        "@cpf",
                        MySqlDbType.VarChar
                    ).Value = cpf;


                    cmd.Parameters.Add(
                        "@senha",
                        MySqlDbType.VarChar
                    ).Value = senha;


                    // =================================================
                    // RESPONSÁVEL
                    // =================================================

                    cmd.Parameters.Add(
                        "@nome_responsavel",
                        MySqlDbType.VarChar
                    ).Value = string.IsNullOrWhiteSpace(nome_responsavel)
                        ? DBNull.Value
                        : nome_responsavel;


                    cmd.Parameters.Add(
                        "@telefone_resp",
                        MySqlDbType.VarChar
                    ).Value = string.IsNullOrWhiteSpace(telefone_resp)
                        ? DBNull.Value
                        : telefone_resp;


                    cmd.Parameters.Add(
                        "@cpf_responsavel",
                        MySqlDbType.VarChar
                    ).Value = string.IsNullOrWhiteSpace(cpf_responsavel)
                        ? DBNull.Value
                        : cpf_responsavel;


                    // =================================================
                    // ENDEREÇO
                    // =================================================

                    cmd.Parameters.Add(
                        "@bairro",
                        MySqlDbType.VarChar
                    ).Value = string.IsNullOrWhiteSpace(bairro)
                        ? DBNull.Value
                        : bairro;


                    cmd.Parameters.Add(
                        "@rua",
                        MySqlDbType.TinyText
                    ).Value = string.IsNullOrWhiteSpace(rua)
                        ? DBNull.Value
                        : rua;


                    cmd.Parameters.Add(
                        "@num_casa",
                        MySqlDbType.Int32
                    ).Value = num_casa;


                    // =================================================
                    // MENOR DE IDADE
                    // =================================================

                    cmd.Parameters.Add(
                        "@menor_de_idade",
                        MySqlDbType.Byte
                    ).Value = menor_de_idade;

                    cmd.Parameters.Add(
                        "@telefone",
                        MySqlDbType.VarChar
                    ).Value = telefone;

                    // =================================================
                    // TURMA
                    // =================================================

                    cmd.Parameters.Add(
                        "@turma_idade",
                        MySqlDbType.VarChar
                    ).Value = DBNull.Value;


                    // =================================================
                    // EXECUTA
                    // =================================================

                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(
                        "Erro do MySQL:\n\n" +
                        "Código: " + ex.Number +
                        "\n\nMensagem:\n" + ex.Message,
                        "Erro no banco de dados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

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