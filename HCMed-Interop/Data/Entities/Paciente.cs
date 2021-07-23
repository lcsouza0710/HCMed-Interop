using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Entities
{
    public class Paciente
    {
        public int Id { get; set; }

        public string PrimeiroNome { get; set; }

        public string Sobrenome { get; set; }

        public Genero Genero { get; set; }

        public string Matricula { get; set; }

        public string CaminhoFoto { get; set; }

        public virtual List<Consulta> Consultas { get; set; }

        public virtual List<RelatorioMedico> RelatoriosMedicos { get; set; }

        public virtual List<Internacao> Internacoes { get; set; }

        public Paciente()
        {

        }

        public Paciente (   
            int id, 
            string primeiroNome, 
            string sobrenome, 
            Genero genero, 
            string matricula, 
            string caminhoFoto)
        {
            this.Id = id;
            this.PrimeiroNome = primeiroNome;
            this.Sobrenome = sobrenome;
            this.Genero = genero;
            this.Matricula = matricula;
            this.CaminhoFoto = caminhoFoto;
        }
    }

    public enum Genero
    {
        Feminino,
        Mascullino
    }
}