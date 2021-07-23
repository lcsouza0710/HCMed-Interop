using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Entities
{
    public class Prontuario
    {

    }

    public class Internacao
    {
        public int Id { get; set; }

        public int IdPaciente { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }

        public StatusInternacao Status { get; set; }

        public int IdResponsavel { get; set; }

        public virtual ProfissionalSaude Responsavel { get; set; }

        public virtual Paciente Paciente { get; set; }

        public string Resumo { get; set; }

        public Internacao()
        {

        }

        public Internacao(  
            int id, 
            int idPaciente, 
            DateTime inicio, 
            DateTime fim,
            StatusInternacao status,
            int idResponsavel,
            string resumo
            )
        {
            this.Id = id;
            this.IdPaciente = idPaciente;
            this.Inicio = inicio;
            this.Fim = fim;
            this.Status = status;
            this.IdResponsavel = idResponsavel;
            this.Resumo = resumo;
        }
    }

    public enum StatusInternacao
    {
        EmAndamento = 1,
        Finalizada = 2
    }

    public class TransicaoCuidados
    {
        public int Id { get; set; }

        public int IdPaciente { get; set; }

        public int IdResponsavel { get; set; }

        public DateTime DataTransicao { get; set; }

        public string ResumoTransicao { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual ProfissionalSaude Responsavel { get; set; }

        public TransicaoCuidados()
        {

        }

        public TransicaoCuidados(
            int id, 
            int idPaciente, 
            int idResponsavel,
            DateTime dataTransicao,
            string resumoTransicao
            )
        {
            this.Id = id;
            this.IdPaciente = idPaciente;
            this.IdResponsavel = idResponsavel;
            this.DataTransicao = dataTransicao;
            this.ResumoTransicao = resumoTransicao;
        }
    }

    
}