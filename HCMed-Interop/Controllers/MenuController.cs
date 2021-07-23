using SysHC.Utils.Autenticacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCMed_Interop.Controllers
{
    /// <summary>
    /// Excluir este controller
    /// </summary>
    public class MenuController : Controller
    {
        // GET: Menu
        [HCAuthorize(Roles = "Menu I")]
        public ActionResult MenuI()
        {
            ViewBag.Message = "Teste página Menu I";
            return View();
        }

        // GET: Menu II
        [HCAuthorize(Roles = "Menu II")]
        public ActionResult MenuII()
        {
            ViewBag.Message = "Teste página Menu II";
            return View();
        }
    }
}