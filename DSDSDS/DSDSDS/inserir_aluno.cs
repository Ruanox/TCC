using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSDSDS
{
    internal class inserir_aluno:conexao
    {


        private string usuario;
        private string idade;
        private int cpf;
        private string nome_responsavel;
        private string telefone_responsavel;
        private string senha;
        private int cpf_responsavel;
        private string bairro;

        public string getUsuario()
        {
            return usuario;
        }

        public void setUsuario(string usuario)
        {
            this.usuario = usuario;
        }

        public string getIdade()
        {
            return idade;
        }

        public void setIdade(string idade)
        {
            this.idade = idade;
        }

        public int getCpf()
        {
            return cpf;
        }

        public void setCpf(int cpf)
        {
            this.cpf = cpf;
        }

        public string getNomeResponsavel()
        {
            return nome_responsavel;
        }

        public void setNomeResponsavel(string nome_responsavel)
        {
            this.nome_responsavel = nome_responsavel;
        }

        public string getTelefoneResponsavel()
        {
            return telefone_responsavel;
        }

        public void setTelefoneResponsavel(string telefone_responsavel)
        {
            this.telefone_responsavel = telefone_responsavel;
        }

        public string getSenha()
        {
            return senha;
        }

        public void setSenha(string senha)
        {
            this.senha = senha;
        }

        public int getCpfResponsavel()
        {
            return cpf_responsavel;
        }

        public void setCpfResponsavel(int cpf_responsavel)
        {
            this.cpf_responsavel = cpf_responsavel;
        }

        public string getBairro()
        {
            return bairro;
        }

        public void setBairro(string bairro)
        {
            this.bairro = bairro;
        }

        public void inserir()
        {
            string query = "INSERT INTO aluno(usuario,idade,cpf,nome_rsponsavel,telefone_responsavel,senha,cpf_responsavel,bairro) VALUES ('" + getUsuario() + "','" + getCpf() + "','" + getNomeResponsavel() + "','" + getSenha() + "','" + getTelefoneResponsavel() + "','" + getBairro() + "')";

            if (this.abrirconexao() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharconexao();
            }

        }



    }
}
