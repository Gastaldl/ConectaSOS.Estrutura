using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectaSOS.Model.Entidades;
using System.IO;
using System.Text.Json;

namespace ConectaSOS.Repository.Repositorios
{
    public class HistoricoRepository
    {
        private readonly string _caminhoArquivo = "data/historico.json";
        public List<string> MensagensCriptografadas { get; private set; }

        public HistoricoRepository()
        {
            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");

            if (File.Exists(_caminhoArquivo))
            {
                string json = File.ReadAllText(_caminhoArquivo);
                MensagensCriptografadas = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }
            else
            {
                MensagensCriptografadas = new List<string>();
            }
        }

        public void AdicionarMensagem(string mensagemCriptografada)
        {
            MensagensCriptografadas.Add(mensagemCriptografada);
            SalvarArquivo();
        }

        public List<string> ListarHistorico()
        {
            return MensagensCriptografadas;
        }

        public void ApagarTudo()
        {
            MensagensCriptografadas.Clear();
            SalvarArquivo();
        }

        private void SalvarArquivo()
        {
            string json = JsonSerializer.Serialize(MensagensCriptografadas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_caminhoArquivo, json);
        }
    }
}

