using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectaSOS.Model.Entidades;
using ConectaSOS.Repository.Repositorios;

namespace ConectaSOS.Controller.Controllers
{
    public class RelatorioController
    {
        private readonly RelatorioRepository _repo;

        public RelatorioController()
        {
            _repo = new RelatorioRepository();
        }

        public void GerarRelatorio(bool semEnergia, bool semInternet)
        {
            try
            {
                var modoEmergencial = semEnergia || semInternet;
                var relatorio = new RelatorioStatus(semEnergia, semInternet, modoEmergencial);
                _repo.Adicionar(relatorio);

                Console.WriteLine("\nRelatório gerado com sucesso:");
                Console.WriteLine(relatorio.ObterResumo());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar relatório: {ex.Message}");
            }
        }
    }
}

