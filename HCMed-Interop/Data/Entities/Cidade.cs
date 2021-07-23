using System.Collections.Generic;

namespace HCMed_Interop.Data.Entities
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SiglaEstado { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual List<Bairro> Bairros { get; set; }
    }
}