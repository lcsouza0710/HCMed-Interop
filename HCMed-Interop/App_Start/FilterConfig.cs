using System.Web;
using System.Web.Mvc;

namespace HCMed_Interop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HCActionFilter());
        }
    }
}
