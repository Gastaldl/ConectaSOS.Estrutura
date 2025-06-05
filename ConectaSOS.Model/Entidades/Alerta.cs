using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectaSOS.Model.Base;

namespace ConectaSOS.Model.Entidades
{
    public class Alerta : Comunicado
    {
        public string Tipo { get; set; } // Ex: Informativo, Urgente

        public Alerta(string titulo, string conteudo, string tipo)
            : base(titulo, conteudo)
        {
            Tipo = tipo;
        }
    }
}

