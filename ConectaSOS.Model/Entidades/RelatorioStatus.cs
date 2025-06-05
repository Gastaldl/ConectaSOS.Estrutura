using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectaSOS.Model.Entidades
{
    public class RelatorioStatus
    {
        public bool SemEnergia { get; set; }
        public bool SemInternet { get; set; }
        public bool ModoEmergencialAtivo { get; set; }
        public DateTime GeradoEm { get; private set; }

        public RelatorioStatus(bool semEnergia, bool semInternet, bool modoEmergencialAtivo)
        {
            SemEnergia = semEnergia;
            SemInternet = semInternet;
            ModoEmergencialAtivo = modoEmergencialAtivo;
            GeradoEm = DateTime.Now;
        }

        public string ObterResumo()
        {
            return $"[STATUS - {GeradoEm}]\n" +
                   $"- Energia: {(SemEnergia ? "FALTA" : "OK")}\n" +
                   $"- Internet: {(SemInternet ? "FALTA" : "OK")}\n" +
                   $"- Modo Emergencial: {(ModoEmergencialAtivo ? "ATIVO" : "DESATIVADO")}";
        }
    }
}
