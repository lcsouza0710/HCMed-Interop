using HCMed_Interop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Config
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            this.HasKey(t => t.Sigla);
            this.ToTable("ESTADO");

            this.Property(t => t.Sigla).HasColumnName("SIGLA").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            this.Property(t => t.Descricao).HasColumnName("DESCRICAO").IsRequired();

            this.HasMany(x => x.Cidades)
                .WithRequired(x => x.Estado)
                .HasForeignKey(x => x.SiglaEstado);
        }
    }
}