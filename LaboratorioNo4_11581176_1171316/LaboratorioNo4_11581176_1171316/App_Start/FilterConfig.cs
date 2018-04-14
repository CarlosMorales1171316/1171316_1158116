using System.Web;
using System.Web.Mvc;

namespace LaboratorioNo4_11581176_1171316
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
