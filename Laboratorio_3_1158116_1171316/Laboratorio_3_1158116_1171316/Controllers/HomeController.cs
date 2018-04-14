using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio_3_1158116_1171316;

namespace Laboratorio_3_1158116_1171316.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
          
        }
        [HttpPost]
        public ActionResult Index(string cadena)
        {         
            try
            {
                Session["Valor1"] = cadena;
                if (cadena.ToLower() == "numero de partidos" || cadena.ToLower() == "fecha de partidos")
                {
                    return RedirectToAction("ArbolAvl");
                }
                else
                {
                    return View();
                }
                   
            }
            catch
            {
                return View("InformacionDeGrupo");
            }
        }

        public ActionResult InformacionDeGrupo()
        {
            try
            {               
                return View();
            }
            catch
            {
                return View("Index");
            }
        }
           
        public ActionResult ArbolAvl(string insertar, string eliminar,string buscar)
        {
            try
            {                
                int contador = 0;
                var model = Session["Valor1"];
                Session["Valor2"] = Convert.ToString(model);
                Session["contador"] = Convert.ToInt32(contador);
                TempData["Buscar"] = Convert.ToString(buscar);
                TempData["Valor3"] = insertar;
                TempData["Valor4"] = eliminar;
                return View();
            }
            catch
            {
                return View("Index");
            }
        }
    }
}