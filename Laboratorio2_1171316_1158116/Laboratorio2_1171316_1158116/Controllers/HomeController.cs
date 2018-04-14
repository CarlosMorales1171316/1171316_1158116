using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio2_1171316_1158116.Models;

namespace Laboratorio2_1171316_1158116.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch
            {
                return View("InformaciondeGrupo");
            }
        }


        public ActionResult ArbolBinarioEnteros(string texto1)
        {
            try
            {             
                TempData["Valor1"] = texto1;
                return View();
            }
            catch
            {
                return View("Index");
            }
        }

        public ActionResult ArbolBinarioCadena(string texto2)
        {
            try
           {
                TempData["Valor2"] = texto2;
                return View();
            }
            catch
            {
                return View("Index");
            }
        }

        public ActionResult ArbolBinarioPaises(string texto3,string texto4)
        {
            try
            {        
                TempData["Valor3"] = texto3;
                TempData["Valor4"] = texto4;
                return View();
            }
            catch
            {
                return View("Index");
            }
        }


        public ActionResult InformaciondeGrupo()
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
    }
}