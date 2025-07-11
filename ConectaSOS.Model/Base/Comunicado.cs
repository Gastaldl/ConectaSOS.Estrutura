﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectaSOS.Model.Base
{
    public abstract class Comunicado
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataHora { get; set; }

        protected Comunicado(string titulo, string conteudo)
        {
            Titulo = titulo;
            Conteudo = conteudo;
            DataHora = DateTime.Now;
        }
    }
}
