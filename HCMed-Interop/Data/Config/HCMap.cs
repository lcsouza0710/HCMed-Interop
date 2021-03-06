using HCMed_Interop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Config
{
    public class PacienteMap : EntityTypeConfiguration<Paciente>
    {
        public PacienteMap()
        {
            this.HasKey(t => t.Id);

            this.HasMany(t => t.Consultas)
                .WithRequired(x => x.Paciente)
                .HasForeignKey(t => t.IdPaciente);

            this.HasMany(t => t.Internacoes)
                .WithRequired(x => x.Paciente)
                .HasForeignKey(t => t.IdPaciente);

            this.HasMany(t => t.RelatoriosMedicos)
                .WithRequired(x => x.Paciente)
                .HasForeignKey(t => t.IdPaciente);
        }
    }

    public class ProfissionalSaudeMap : EntityTypeConfiguration<ProfissionalSaude>
    {
        public ProfissionalSaudeMap()
        {
            this.HasKey(t => t.Id);

            this.HasRequired(t => t.Especialidade)
                .WithMany(x => x.Doutores)
                .HasForeignKey(t => t.IdEspecialidade);

            this.HasOptional(t => t.Conselho)
                .WithMany(x => x.Profissionais)
                .HasForeignKey(t => t.IdConselho);

            this.HasMany(t => t.Consultas)
                .WithRequired(x => x.Doutor)
                .HasForeignKey(x => x.IdDoutor);
        }
    }

    public class EspecialidadeMap : EntityTypeConfiguration<Especialidade>
    {
        public EspecialidadeMap()
        {
            this.HasKey(t => t.Id);
        }
    }

    public class ConselhoMap : EntityTypeConfiguration<Conselho>
    {
        public ConselhoMap()
        {
            this.HasKey(t => t.Id);
        }
    }

    public class UFMap: EntityTypeConfiguration<UF>
    {
        public UFMap()
        {
            this.HasKey(t => t.Id);

            this.HasMany(t => t.Conselhos)
                .WithRequired(x => x.Estado)
                .HasForeignKey(x => x.IdEstado);
        }
    }

    public class ConsultaMap : EntityTypeConfiguration<Consulta>
    {
        public ConsultaMap()
        {
            this.HasKey(t => t.Id);
        }
    }

    public class RelatorioMedicoMap : EntityTypeConfiguration<RelatorioMedico>
    {
        public RelatorioMedicoMap()
        {
            this.HasKey(t => t.Id);

            this.HasRequired(t => t.Doutor)
                .WithMany(x => x.RelatoriosMedicos)
                .HasForeignKey(t => t.IdProfissional);

            this.HasRequired(t => t.Paciente)
                .WithMany(x => x.RelatoriosMedicos)
                .HasForeignKey(t => t.IdPaciente);
        }
    }

    public class CIDMap : EntityTypeConfiguration<CID>
    {
        public CIDMap()
        {
            this.HasKey(t => t.Id);
        }
    }

    public class InternacaoMap : EntityTypeConfiguration<Internacao>
    {
        public InternacaoMap()
        {
            this.HasKey(t => t.Id);
        }
    }

    public class TransicaoCuidadosMap : EntityTypeConfiguration<TransicaoCuidados>
    {
        public TransicaoCuidadosMap()
        {
            this.HasKey(t => t.Id);
        }
    }

}