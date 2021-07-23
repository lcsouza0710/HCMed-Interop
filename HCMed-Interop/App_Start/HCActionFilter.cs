using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCMed_Interop
{
    public class HCActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
#if DEBUG
            HttpContext.Current.Items.Add("DEBUG", true);
#endif
            base.OnActionExecuting(filterContext);
        }
    }
}