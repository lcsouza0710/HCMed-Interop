using HCMed_Interop.Data.Entities;
using SysHC.Web.Lib.Autenticacao.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop.Data.Store
{
    public class CidadeStore : BaseStore<Cidade, AppContext>
    {
        public CidadeStore(AppContext context) : base(context) { }

        public Cidade Add(Cidade item)
        {
            try
            {
                item.Id = GetSequenceId("SQ_CIDADE");

                _context.Cidades.Add(item);
                _context.SaveChanges();

                return item;
            }
            catch
            {
                return null;
            }
        }

        public Cidade Update(Cidade item)
        {
            try
            {
                Cidade itemDb = Find(item.Id);

                itemDb.SiglaEstado = item.SiglaEstado;
                itemDb.Nome = item.Nome;

                _context.SaveChanges();

                return item;
            }
            catch
            {
                return null;
            }
        }

        internal List<Cidade> Autocomplete(string query)
        {
            return _context.Cidades.Where(x => x.Nome.ToUpper().Contains(query)).ToList();
        }

        public bool Delete(int idCidade)
        {
            try
            {
                Cidade itemDb = Find(idCidade);

                if (itemDb == null)
                    return false;

                _context.Cidades.Remove(itemDb);
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