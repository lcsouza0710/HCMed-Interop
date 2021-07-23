using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Entities
{
    public class Estado
    {
        public string Sigla { get; set; }
        public string Descricao { get; set; }

        public virtual List<Cidade> Cidades { get; set; }
    }
}