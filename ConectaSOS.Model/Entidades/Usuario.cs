using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectaSOS.Model.Entidades
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Grupo { get; set; }
        public string Papel { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario(string nome, string grupo, string papel, string login, string senha)
        {
            Nome = nome;
            Grupo = grupo;
            Papel = papel;
            Login = login;
            Senha = senha;
        }
    }
}
