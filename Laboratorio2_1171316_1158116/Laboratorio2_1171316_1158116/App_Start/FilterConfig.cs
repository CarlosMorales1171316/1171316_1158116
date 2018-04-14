using System.Web;
using System.Web.Mvc;

namespace Laboratorio2_1171316_1158116
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
