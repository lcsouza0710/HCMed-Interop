using Oracle.ManagedDataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data
{
    public class ModelConfiguration : DbConfiguration
    {
        public ModelConfiguration()
        {
            SetProviderServices("Oracle.ManagedDataAccess.Client", EFOracleProviderServices.Instance);
            SetHistoryContext("Oracle.ManagedDataAccess.Client",
                (connection, defaultSchema) => new HCHistoryContext(connection, defaultSchema));
        }
    }
}