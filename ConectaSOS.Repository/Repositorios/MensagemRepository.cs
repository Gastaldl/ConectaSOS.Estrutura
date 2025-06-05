using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectaSOS.Model.Entidades;
using ConectaSOS.Repository.Interfaces;

namespace ConectaSOS.Repository.Repositorios
{
    public class MensagemRepository : IRepository<MensagemSOS>
    {
        private List<MensagemSOS> mensagens = new List<MensagemSOS>();

        public void Adicionar(MensagemSOS item)
        {
            mensagens.Add(item);
        }

        public List<MensagemSOS> ListarTodos()
        {
            return mensagens;
        }
    }
}

