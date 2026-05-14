using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DSDSDS
{
    internal class documetos_escola
    {

        private string nome;    
        private string email;
        private int telefone;
        private string rua;
        private string cidade;
        private string bairro;
        private string estado;
        


        public void setNome(string nome)
        {
            this.nome = nome;
        }
        public string getNome()
        {
            return this.nome;
        }
        public string setEmail(string email)
        {
            this.email = email;
            return this.email;
        }
        public string getEmail()
        {
            return this.email;
        }
        public int setTelefone(int telefone)
        {
            this.telefone = telefone;
            return this.telefone;
        }
        public int getTelefone()
        {
            return this.telefone;
        }
        public string setRua(string rua)
        {
            this.rua = rua;
            return this.rua;
        }
        public string getRua()
        {
            return this.rua;
        }
        public string setCidade(string cidade)
        {
            this.cidade = cidade;
            return this.cidade;
        }
        public string getCidade()
        {
            return this.cidade;
        }
        public string setBairro(string bairro)
        {
            this.bairro = bairro;
            return this.bairro;
        }
        public string getBairro()
        {
            return this.bairro;
        }
        public string setEstado(string estado)
        {
            this.estado = estado;
            return this.estado;
        }
        public string getEstado()
        {
            return this.estado;
        }
    }
}
