using HCMed_Interop.Data.Entities;
using HCMed_Interop.Data.Store;
using SysHC.Utils.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Manager
{
    public class CidadeManager : BaseManager<Cidade, CidadeStore, AppContext>
    {
        public CidadeManager(CidadeStore store) : base(store) { }

        public Cidade AddOrUpdate(Cidade item)
        {
            if (item.Id == 0)
                return this.Store.Add(item);
            else
                return this.Store.Update(item);
        }

        public bool Delete(int idCidade)
        {
            return this.Store.Delete(idCidade);
        }

        public List<Cidade> Autocomplete(string query)
        {
            if (string.IsNullOrEmpty(query))
                query = "";

            return this.Store.Autocomplete(query.ToUpper());
        }
    }
}