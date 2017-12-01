using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalpProjeto.DTL
{
    public class EntradaDTL
    {
        public int idEntrada { get; set; }
        public string nomeEntrada { get; set; }
        public string descEntrada { get; set; }
        public double valorEntrada { get; set; }
        public DateTime dataEntrada { get; set; }
        public int idCat { get; set; }
        public int idUsuario { get; set; }
    }
}