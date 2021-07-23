using HCMed_Interop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Models
{
    public class PacienteViewModel
    {
        public Paciente Paciente { get; set; }

        public List<Consulta> Consultas { get; set; }

        public List<RelatorioMedico> RelatoriosMedico { get; set; }

        public List<Internacao> Internacoes { get; set; }

        public List<TransicaoCuidados> Transicoes { get; set; }

    }
}