using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DSDSDS
{
    internal class info_aluno
    {
        private string nome;
        private string email;
        private string senha;
        private int cpf;
        private int idade;
        private string rua;
        private string bairro;
        private string cidade;
        private string estado;
        private int numCasa;
        private string nome_responsavel;
        private string telefone_responsavel;
        private string cpf_responsavel;




        public void setNome (string nome)
        {
            this.nome = nome;
        }
        public string getNome()
        {
            return nome;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getEmail()
        {
            return email;
        }
        public void setSenha(string senha)
        {
            this.senha = senha;
        }
        public string getSenha()
        {
            return senha;
        }
        public void setCpf(int cpf)
        {
            this.cpf = cpf;
        }
        public int getCpf()
        {
            return cpf;
        }
        public void setIdade(int idade)
        {
            this.idade = idade;
        }
        public int getIdade()
        {
            return idade;
        }
        public void setRua(string rua)
        {
            this.rua = rua;
        }
        public string getRua()
        {
            return rua;
        }   
        public void setBairro(string bairro)
        {
            this.bairro = bairro;
        }   
        public string getBairro()
        {
            return bairro;
        }   
        public void setCidade(string cidade)
        {
            this.cidade = cidade;
        }   
        public string getCidade()
        {
            return cidade;
        }
        public void setEstado(string estado)
        {
            this.estado = estado;
        }
        public string getEstado()
        {
            return estado;
        }
        public void setNumCasa(int numCasa)
        {
            this.numCasa = numCasa;
        }
        public int getNumCasa()
        {
            return numCasa;
        }
        public void setNome_responsavel(string nome_responsavel)
        {
            this.nome_responsavel = nome_responsavel;
        }
        public string getNome_responsavel()
        {
            return nome_responsavel;
        }
        public void setTelefone_responsavel(string telefone_responsavel)
        {
            this.telefone_responsavel = telefone_responsavel;
        }
        public string getTelefone_responsavel()
        {
            return telefone_responsavel;
        }
        public void setCpf_responsavel(string cpf_responsavel)
        {
            this.cpf_responsavel = cpf_responsavel;
        }
        public string getCpf_responsavel()
        {
            return cpf_responsavel;
        }


    }
}
