using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectaSOS.Model.Entidades;
using ConectaSOS.Repository.Repositorios;


namespace ConectaSOS.Controller.Controllers
{
    public class AlertaController
    {
        private readonly AlertaRepository _repo;
        private readonly HistoricoRepository _historicoRepo;

        public AlertaController(HistoricoRepository historicoRepo)
        {
            _historicoRepo = historicoRepo;
            _repo = new AlertaRepository();
        }

        public void EmitirAlerta(string titulo, string conteudo, string tipo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(titulo) ||
                    string.IsNullOrWhiteSpace(conteudo) ||
                    string.IsNullOrWhiteSpace(tipo))
                    throw new ArgumentException("Todos os campos são obrigatórios.");

                var alerta = new Alerta(titulo, conteudo, tipo);
                _repo.Adicionar(alerta);

                var criptografada = $"[ALERTA]{alerta.Titulo}:{alerta.Conteudo}";
                _historicoRepo.AdicionarMensagem(criptografada);

                Console.WriteLine("Alerta emitido com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao emitir alerta: {ex.Message}");
            }
        }
    }
}

