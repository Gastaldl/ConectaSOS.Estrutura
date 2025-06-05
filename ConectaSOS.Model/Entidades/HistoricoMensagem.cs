using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectaSOS.Model.Entidades
{
    public class HistoricoMensagem
    {
        public List<string> MensagensCriptografadas { get; private set; }

        public HistoricoMensagem()
        {
            MensagensCriptografadas = new List<string>();
        }

        public void AdicionarMensagem(string mensagemCriptografada)
        {
            MensagensCriptografadas.Add(mensagemCriptografada);
        }
    }
}
