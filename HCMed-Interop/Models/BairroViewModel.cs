using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Models
{
    public class BairroViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Selecione uma {0}")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecionea um {0}")]
        public int IdCidade { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Informe o nome do bairro")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres")]
        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}