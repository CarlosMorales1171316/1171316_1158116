using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaboratorioNo4_11581176_1171316.Models;
namespace LaboratorioNo4_11581176_1171316.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {                     
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
