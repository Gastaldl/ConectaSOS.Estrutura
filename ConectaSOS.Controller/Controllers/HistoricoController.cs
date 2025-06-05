using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectaSOS.Repository.Repositorios;

namespace ConectaSOS.Controller.Controllers
{
    public class HistoricoController
    {
        private readonly HistoricoRepository _repo;

        public HistoricoController(HistoricoRepository historicoRepo)
        {
            _repo = historicoRepo;
        }

        public void ExibirHistorico(string filtro = "todos")
        {
            var mensagens = _repo.ListarHistorico();

            // Aplica o filtro (sos, alerta, todos)
            List<string> mensagensFiltradas = filtro.ToLower() switch
            {
                "sos" => mensagens.Where(m => m.ToLower().Contains("[crypto]")).ToList(),
                "alerta" => mensagens.Where(m => m.ToLower().Contains("[crypto-alerta]")).ToList(),
                _ => mensagens
            };

            if (mensagensFiltradas.Count == 0)
            {
                Console.WriteLine("\nNenhuma mensagem registrada para esse filtro.");
                return;
            }

            // Coloca mensagens com "prioridade: alta" primeiro
            var prioridadeAlta = mensagensFiltradas
                .Where(m => m.ToLower().Contains("prioridade: alta"))
                .ToList();

            var outras = mensagensFiltradas.Except(prioridadeAlta).ToList();

            var ordenadas = new List<string>();
            ordenadas.AddRange(prioridadeAlta);
            ordenadas.AddRange(outras);

            Console.WriteLine("\n===== HISTÓRICO DE MENSAGENS CRIPTOGRAFADAS =====\n");

            for (int i = 0; i < ordenadas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ordenadas[i]}");
                Console.WriteLine($"   Registrada em: {DateTime.Now}\n");
            }

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Total exibido: {ordenadas.Count}");
        }

        public void ApagarHistorico()
        {
            Console.Write("\nTem certeza que deseja apagar TODO o histórico? (s/n): ");
            string confirmacao = Console.ReadLine()?.Trim().ToLower();

            if (confirmacao == "s")
            {
                _repo.ApagarTudo();
                Console.WriteLine("Histórico apagado com sucesso.");
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
            }
        }
    }
}
