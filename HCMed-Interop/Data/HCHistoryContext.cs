using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data
{
    public class HCHistoryContext : HistoryContext
    {
        public HCHistoryContext(DbConnection dbConnection, string defaultSchema)
                : base(dbConnection, defaultSchema)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string appCode = System.Configuration.ConfigurationManager.AppSettings["App"].ToUpper();
            modelBuilder.Entity<HistoryRow>().ToTable(tableName: "MIGRATION_HISTORY_" + appCode);
        }
    }
}