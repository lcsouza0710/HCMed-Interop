using HCMed_Interop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Config
{
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("CIDADE");

            this.Property(t => t.Id).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            this.Property(t => t.Nome).HasColumnName("NOME").IsRequired();
            this.Property(t => t.SiglaEstado).HasColumnName("SIGLA_ESTADO").IsRequired();

            this.HasRequired(x => x.Estado)
                .WithMany(x => x.Cidades)
                .HasForeignKey(x => x.SiglaEstado);

            this.HasMany(x => x.Bairros)
                .WithRequired(x => x.Cidade)
                .HasForeignKey(x => x.IdCidade);
        }
    }
}