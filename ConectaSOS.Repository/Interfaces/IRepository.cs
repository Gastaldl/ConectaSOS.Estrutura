using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectaSOS.Repository.Interfaces
{
    public interface IRepository<T>
    {
        void Adicionar(T item);
        List<T> ListarTodos();
    }
}

