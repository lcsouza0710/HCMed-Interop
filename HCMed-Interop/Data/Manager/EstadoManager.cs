using HCMed_Interop.Data.Entities;
using HCMed_Interop.Data.Store;
using SysHC.Utils.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Manager
{
    public class EstadoManager : BaseManager<Estado, EstadoStore, AppContext>
    {
        public EstadoManager(EstadoStore store) : base(store) { }

        public List<Estado> ToList()
        {
            return this.Store.ToList();
        }

        public List<Estado> Autocomplete(string query)
        {
            if (string.IsNullOrEmpty(query))
                query = "";

            return this.Store.Autocomplete(query.ToUpper());
        }
    }
}