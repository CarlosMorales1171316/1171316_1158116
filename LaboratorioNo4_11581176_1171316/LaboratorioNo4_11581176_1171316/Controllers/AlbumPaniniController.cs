using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratorioNo4_11581176_1171316.Controllers
{
    public class AlbumPaniniController : Controller
    {
        // GET: AlbumPanini        
        public ActionResult RecolectarDatos()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                    file.SaveAs(path);
                    var contenido = System.IO.File.ReadAllText(path);
                    TempData["uploadResult"] = "Archivo subido con éxito";
                    TempData["file"] = contenido;
                  
                }
            }
            return View();
        }

        public ActionResult ListaEstampas()
        {

            return View();
        }


    }
}