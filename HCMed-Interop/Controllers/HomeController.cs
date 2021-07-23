using HCMed_Interop.Data;
using HCMed_Interop.Data.Entities;
using HCMed_Interop.Data.Manager;
using HCMed_Interop.Models;
using Microsoft.AspNet.Identity.Owin;
using SysHC.Utils.Autenticacao;
using SysHC.Utils.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCMed_Interop.Controllers
{
    public class HomeController : Controller
    {
        private EstadoManager _estadoManager;
        private CidadeManager _cidadeManager;
        private BairroManager _bairroManager;

        public HomeController() { }

        public HomeController(EstadoManager estadoManager, BairroManager bairroManager, CidadeManager cidadeManager)
        {
            MyEstadoManager = estadoManager;
            MyBairroManager = bairroManager;
            MyCidadeManager = cidadeManager;
        }

        public EstadoManager MyEstadoManager
        {
            get
            {
                return _estadoManager ?? HttpContext.GetOwinContext().Get<EstadoManager>();
            }
            private set
            {
                _estadoManager = value;
            }
        }

        public BairroManager MyBairroManager
        {
            get
            {
                return _bairroManager ?? HttpContext.GetOwinContext().Get<BairroManager>();
            }
            private set
            {
                _bairroManager = value;
            }
        }

        public CidadeManager MyCidadeManager
        {
            get
            {
                return _cidadeManager ?? HttpContext.GetOwinContext().Get<CidadeManager>();
            }
            private set
            {
                _cidadeManager = value;
            }
        }

        //[SysHC.Utils.Autenticacao.HCAuthorize(Vinculos = "*|ICHC|*")]
        [HCAuthorize()]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListaBairros(HCDataTableRequest<Bairro> dataTableRequest)
        {
            HCDataTableResponse<BairroViewModel> dataTable = MyBairroManager.ToList(dataTableRequest)
                                                                .CastViewModel(x => new BairroViewModel
                                                                {
                                                                    Id = x.Id,
                                                                    IdCidade = x.IdCidade,
                                                                    Bairro = x.Descricao,
                                                                    Cidade = x.Cidade.Nome,
                                                                    Estado = x.Cidade.SiglaEstado
                                                                });

            return Json(dataTable);
        }

        [HttpPost]
        public ActionResult AddOrUpdateBairro(BairroViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });

            try
            {
                var b = new Bairro
                {
                    Id = model.Id,
                    Descricao = model.Bairro,
                    IdCidade = model.IdCidade
                };

                b = MyBairroManager.AddOrUpdate(b);

                return Json(new { success = b != null });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult DeleteBairro(int id)
        {
            try
            {
                bool r = MyBairroManager.Delete(id);

                return Json(new { success = r });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult AddOrUpdateCidade(CidadeViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });

            try
            {
                var c = new Cidade
                {
                    Id = model.Id,
                    Nome = model.Cidade,
                    SiglaEstado = model.Estado
                };

                c = MyCidadeManager.AddOrUpdate(c);

                return Json(new { success = c != null });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult CidadesAutocomplete(string query)
        {
            return Json(MyCidadeManager.Autocomplete(query).Select(x => new { Id = x.Id, Nome = string.Format("{0}/{1}", x.Nome, x.SiglaEstado) }));
        }

        [HttpPost]
        public ActionResult EstadosAutocomplete(string query)
        {
            return Json(MyEstadoManager.Autocomplete(query).Select(x => new { Id = x.Sigla, Nome = string.Format("{0} - {1}", x.Sigla, x.Descricao) }));
        }
    }
}