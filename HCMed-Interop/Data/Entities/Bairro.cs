using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Entities
{
    public class Bairro
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public int IdCidade { get; set; }

        public virtual Cidade Cidade { get; set; }
    }
}