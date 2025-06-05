using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectaSOS.Model.Base;

namespace ConectaSOS.Model.Entidades
{
    public class MensagemSOS : Comunicado
    {
        public string Localizacao { get; set; }
        public string Prioridade { get; set; } // Ex: Alta, Média, Baixa

        public MensagemSOS(string titulo, string conteudo, string localizacao, string prioridade)
            : base(titulo, conteudo)
        {
            Localizacao = localizacao;
            Prioridade = prioridade;
        }
    }
}
