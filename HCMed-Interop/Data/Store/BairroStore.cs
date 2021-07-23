using HCMed_Interop.Data.Entities;
using SysHC.Utils.Data;
using SysHC.Web.Lib.Autenticacao.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Store
{
    public class BairroStore : BaseStore<Bairro, AppContext>
    {
        public BairroStore(AppContext context) : base(context) { }

        public Bairro Add(Bairro item)
        {
            try
            {
                _context.Bairros.Add(item);
                _context.SaveChanges();

                return item;
            }
            catch
            {
                return null;
            }
        }

        public Bairro Update(Bairro item)
        {
            try
            {
                Bairro itemDb = Find(item.Id);
                itemDb.Descricao = item.Descricao;
                itemDb.IdCidade = item.IdCidade;

                _context.SaveChanges();
                return item;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int idBairro)
        {
            try
            {
                Bairro itemDb = Find(idBairro);

                if (itemDb == null)
                    return false;

                _context.Bairros.Remove(itemDb);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public HCDataTableResponse<Bairro> ToList(HCDataTableRequest<Bairro> dataTableRequest)
        {
            HCDataTableResponse<Bairro> response = new HCDataTableResponse<Bairro>();
            var qr = _context.Bairros.Include("Cidade").AsQueryable();
            response.recordsTotal = qr.Count();

            if (dataTableRequest.HasSearch())
            {
                string s = dataTableRequest.search.value.ToUpper();
                qr = qr.Where(x => x.Descricao.ToUpper().Contains(s) || x.Cidade.Nome.ToUpper().Contains(s) || x.Cidade.SiglaEstado.Equals(s, StringComparison.InvariantCultureIgnoreCase));
            }

            response.recordsFiltered = qr.Count();
            qr = qr.OrderAndPaging(dataTableRequest);

            response.data = qr.ToList();
            return response;
        }
    }
}