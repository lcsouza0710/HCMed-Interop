using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Models
{
    public class CidadeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Informe o nome da cidade")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "A {0} deve ter entre {2} e {1} caracteres")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Selecione um {0}")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Selecione um {0}")]
        public string Estado { get; set; }
    }
}