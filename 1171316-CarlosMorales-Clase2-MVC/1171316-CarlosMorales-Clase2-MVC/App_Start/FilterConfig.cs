using System.Web;
using System.Web.Mvc;

namespace _1171316_CarlosMorales_Clase2_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
