using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectaSOS.Model.Entidades;
using ConectaSOS.Repository.Repositorios;

namespace ConectaSOS.Controller.Controllers
{
    public class MensagemController
    {
        private readonly MensagemRepository _mensagemRepo;
        private readonly HistoricoRepository _historicoRepo;

        public MensagemController(HistoricoRepository historicoRepo)
        {
            _historicoRepo = historicoRepo;
            _mensagemRepo = new MensagemRepository();
        }

        public void EnviarMensagemSOS(string titulo, string conteudo, string localizacao, string prioridade)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(titulo) ||
                    string.IsNullOrWhiteSpace(conteudo) ||
                    string.IsNullOrWhiteSpace(localizacao) ||
                    string.IsNullOrWhiteSpace(prioridade))
                    throw new ArgumentException("Todos os campos devem ser preenchidos.");

                var prioridadeNormalizada = prioridade.Trim().ToLower();
                if (prioridadeNormalizada != "alta" &&
                    prioridadeNormalizada != "média" &&
                    prioridadeNormalizada != "media" &&
                    prioridadeNormalizada != "baixa")
                    throw new ArgumentException("Prioridade inválida. Use apenas 'Alta', 'Média' ou 'Baixa'.");

                // Padroniza a prioridade com primeira letra maiúscula
                prioridade = char.ToUpper(prioridadeNormalizada[0]) + prioridadeNormalizada.Substring(1);

                // Corrige "media" para "Média"
                if (prioridade == "Media")
                    prioridade = "Média";

                var mensagem = new MensagemSOS(titulo, conteudo, localizacao, prioridade);
                _mensagemRepo.Adicionar(mensagem);

                var criptografada = $"[SOS]{mensagem.Titulo}:{mensagem.Conteudo}";
                _historicoRepo.AdicionarMensagem(criptografada);

                Console.WriteLine("Mensagem SOS enviada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar mensagem: {ex.Message}");
            }
        }
    }
}

