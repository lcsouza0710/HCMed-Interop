using HCMed_Interop.Data.Entities;
using SysHC.Web.Lib.Autenticacao.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Store
{
    public class EstadoStore : BaseStore<Estado, AppContext>
    {
        public EstadoStore(AppContext context) : base(context) { }

        public List<Estado> ToList()
        {
            return _context.Estados.ToList();
        }

        public Estado Add(Estado item)
        {
            try
            {
                _context.Estados.Add(item);
                _context.SaveChanges();

                return item;
            }
            catch
            {
                return null;
            }
        }

        public List<Estado> Autocomplete(string query)
        {
            return _context.Estados.Where(x => x.Descricao.ToUpper().Contains(query) || x.Sigla.Equals(query, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public Estado Update(Estado item)
        {
            try
            {
                Estado itemDb = Find(item.Sigla);
                itemDb.Descricao = item.Descricao;
                _context.SaveChanges();
                return item;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int idEstado)
        {
            try
            {
                Estado itemDb = Find(idEstado);

                if (itemDb == null)
                    return false;

                _context.Estados.Remove(itemDb);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}