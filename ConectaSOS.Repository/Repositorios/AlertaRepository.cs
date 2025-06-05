using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectaSOS.Model.Entidades;
using ConectaSOS.Repository.Interfaces;

namespace ConectaSOS.Repository.Repositorios
{
    public class AlertaRepository : IRepository<Alerta>
    {
        private List<Alerta> alertas = new List<Alerta>();

        public void Adicionar(Alerta item)
        {
            alertas.Add(item);
        }

        public List<Alerta> ListarTodos()
        {
            return alertas;
        }
    }
}

