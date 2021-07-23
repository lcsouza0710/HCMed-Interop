using HCMed_Interop.Data.Entities;
using HCMed_Interop.Data.Store;
using SysHC.Utils.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Manager
{
    public class BairroManager : BaseManager<Bairro, BairroStore, AppContext>
    {
        public BairroManager(BairroStore store) : base(store) { }

        public Bairro AddOrUpdate(Bairro item)
        {
            if (item.Id == 0)
                return this.Store.Add(item);
            else
                return this.Store.Update(item);
        }

        public bool Delete(int idBairro)
        {
            return this.Store.Delete(idBairro);
        }

        public HCDataTableResponse<Bairro> ToList(HCDataTableRequest<Bairro> dataTableRequest)
        {
            dataTableRequest.AddColumn(x => x.Descricao);
            dataTableRequest.AddColumn(x => x.Cidade.Nome);
            dataTableRequest.AddColumn(x => x.Cidade.SiglaEstado);
            return this.Store.ToList(dataTableRequest);
        }
    }
}