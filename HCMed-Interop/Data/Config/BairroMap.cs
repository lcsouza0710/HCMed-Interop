using HCMed_Interop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Config
{
    public class BairroMap : EntityTypeConfiguration<Bairro>
    {
        public BairroMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Id);
            this.Property(t => t.Descricao).IsRequired();
            this.Property(t => t.IdCidade).IsRequired();

            this.HasRequired(x => x.Cidade)
                .WithMany(x => x.Bairros)
                .HasForeignKey(x => x.IdCidade);
        }
    }
}