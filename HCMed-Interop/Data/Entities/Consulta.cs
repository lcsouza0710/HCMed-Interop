using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Entities
{
    public class Consulta
    {
        public int Id { get; set; }

        public int IdPaciente { get; set; }

        public int IdProfissional { get; set; }

        public DateTime DataHorarioConsulta { get; set; }

        public StatusConsulta Status { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual ProfissionalSaude Doutor { get; set; }

        public Consulta()
        {

        }

        public Consulta(
            int id, 
            int idPaciente, 
            int idProfissional, 
            DateTime dataHorarioConsulta,
            StatusConsulta status
            )
        {
            this.Id = id;
            this.IdPaciente = idPaciente;
            this.IdProfissional = idProfissional;
            this.DataHorarioConsulta = dataHorarioConsulta;
            this.Status = status;
        }

        public Consulta(
            int id, 
            int idPaciente, 
            int idProfissional, 
            DateTime dataHorarioConsulta,
            StatusConsulta status,
            Paciente paciente,
            ProfissionalSaude doutor
            )
        {
            this.Id = id;
            this.IdPaciente = idPaciente;
            this.IdProfissional = idProfissional;
            this.DataHorarioConsulta = dataHorarioConsulta;
            this.Status = status;
            this.Paciente = paciente;
            this.Doutor = doutor;
        }
    }

    public enum StatusConsulta
    {
        Aguardando,
        Realizada,
        Cancelada
    }

    public class RelatorioMedico
    {
        public int Id { get; set; }

        public int IdPaciente { get; set; }

        public int IdProfissional { get; set; }

        public DateTime Data { get; set; }

        public CID Diagnostico { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual ProfissionalSaude Doutor { get; set; }

        public RelatorioMedico()
        {

        }

        public RelatorioMedico(
            int id, 
            int idPaciente,
            int idProfissional,
            DateTime data,
            CID diagnostico
            )
        {
            this.Id = id;
            this.IdPaciente = idPaciente;
            this.IdProfissional = idProfissional;
            this.Data = data;
            this.Diagnostico = diagnostico;
        }

        public RelatorioMedico(
            int id,
            int idPaciente,
            int idProfissional,
            DateTime data,
            CID diagnostico,
            Paciente paciente,
            ProfissionalSaude doutor
            )
        {
            this.Id = id;
            this.IdPaciente = idPaciente;
            this.IdProfissional = idProfissional;
            this.Data = data;
            this.Diagnostico = diagnostico;
            this.Paciente = paciente;
            this.Doutor = doutor;
        }
    }

    public class CID
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public CID()
        {

        }

        public CID(int id, string codigo, string descricao)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Descricao = descricao;
        }
    }


}