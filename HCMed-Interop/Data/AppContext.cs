namespace HCMed_Interop.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entities;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Config;

    public partial class AppContext : DbContext
    {
        public AppContext()
            : base("name=ContextSistemasHC")
        {
            Database.SetInitializer<AppContext>(null);
        }

        public static AppContext Create()
        {
            return new AppContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("APP_SISTEMAS_HC");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar2"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(50));

            modelBuilder.Types().Configure(c => c.ToTable(GetTableColumnName(c.ClrType.Name)));
            modelBuilder.Properties().Configure(c => c.HasColumnName(GetTableColumnName(c.ClrPropertyInfo.Name)));

            modelBuilder.Configurations.Add(new EstadoMap());
            modelBuilder.Configurations.Add(new CidadeMap());
            modelBuilder.Configurations.Add(new BairroMap());
        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Bairro> Bairros { get; set; }

        public DbSet<Internacao> Internacoes { get; set; }
        public DbSet<TransicaoCuidados> TransicaoCuidados { get; set; }
        public DbSet<ProfissionalSaude> ProfissionaisSaude { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Conselho> Conselho { get; set; }
        public DbSet<UF> EstadosBrasil { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<RelatorioMedico> Relatorios { get; set; }
        public DbSet<CID> Diagnosticos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }


        private string GetTableColumnName(string name)
        {
            var result = System.Text.RegularExpressions.Regex.Replace(name, ".[A-Z]", m => m.Value[0] + "_" + m.Value[1]);
            return result.ToUpper();
        }
    }
}
