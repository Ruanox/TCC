using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DSDSDS
{
    internal class inserir_professor:conexao
    {
        public string usuario;
        public string bairro;
        public long cpf;
        public string telefone;
        public string senha;
        public string email;

        public void setUsuario(string usuario)
        {
            this.usuario = usuario;
        }
        public string getUsuario()
        {
            return this.usuario;
        }
        public void setBairro(string bairro)
        {
            this.bairro = bairro;
        }
        public string getBairro()
        {
            return this.bairro;
        }
        public void setTelefone(string telefone)
        {
            this.telefone = telefone;
        }
        public string getTelefone()
        {
            return this.telefone;
        }
        public void setCpf(long cpf)
        {
            this.cpf = cpf;
        }
        public long getCpf()
        {
            return this.cpf;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getEmail()
        {
            return this.email;
        }

        public void setSenha(string senha)
        {
            this.senha = senha;
        }

        public string getSenha()
        {
            return this.senha;
        }
        public void inserir()
        {
            string query = "INSERT INTO professor(usuario,cpf,email,senha,telefone,bairro) VALUES ('" + getUsuario() + "','" + getCpf() + "','" + getEmail() + "','" + getSenha() + "','" + getTelefone() + "','" + getBairro() + "')";

            if (this.abrirconexao() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                this.fecharconexao();
            }

        }



    }
}
