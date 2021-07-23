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

        public int IdDoutor { get; set; }

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
            int idDoutor, 
            DateTime dataHorarioConsulta,
            StatusConsulta status
            )
        {
            this.Id = id;
            this.IdPaciente = idPaciente;
            this.IdDoutor = idDoutor;
            this.DataHorarioConsulta = dataHorarioConsulta;
            this.Status = status;
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

        public int IdDiagnostico { get; set; }

        public DateTime Data { get; set; }

        public virtual CID Diagnostico { get; set; }

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
            int idDiagnostico
            )
        {
            this.Id = id;
            this.IdPaciente = idPaciente;
            this.IdProfissional = idProfissional;
            this.Data = data;
            this.IdDiagnostico = idDiagnostico;
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