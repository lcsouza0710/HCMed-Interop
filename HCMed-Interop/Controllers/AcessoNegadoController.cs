using SysHC.Utils.Autenticacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCMed_Interop.Controllers
{
    [HCAuthorize]
    public class AcessoNegadoController : Controller
    {
        // GET: AcessoNegado
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}