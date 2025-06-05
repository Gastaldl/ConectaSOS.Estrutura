using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectaSOS.Model.Entidades;
using ConectaSOS.Repository.Interfaces;

namespace ConectaSOS.Repository.Repositorios
{
    public class RelatorioRepository : IRepository<RelatorioStatus>
    {
        private List<RelatorioStatus> relatorios = new List<RelatorioStatus>();

        public void Adicionar(RelatorioStatus item)
        {
            relatorios.Add(item);
        }

        public List<RelatorioStatus> ListarTodos()
        {
            return relatorios;
        }
    }
}

