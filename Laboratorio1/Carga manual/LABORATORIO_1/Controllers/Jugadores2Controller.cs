using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LABORATORIO_1.Models;

namespace LABORATORIO_1.Controllers
{
    public class Jugadores2Controller : Controller
    {
        private LABORATORIO_1Context db = new LABORATORIO_1Context();
        Stopwatch sw = new Stopwatch();
        List<string> logs = new List<string>();
        string path;
        int contador;
        // GET: Jugadores
        public ActionResult Index()
        {

            Session["Path"] = Session["Path"] ?? path;
            Session["Contador"] = Session["Contador"] ?? contador;
            Session["Logs"] = Session["Logs"] ?? logs;
            return View(db.Jugadores.ToList());
        }

        private void PrintCreateTimeEllapsed(List<string> logs)
        {
            string ruta = @"C:\Laboratorio1\Datos.txt";
            StreamWriter writer = new StreamWriter(ruta, false);

            for (int i = 0; i < logs.Count; i++)
            {
                writer.WriteLine(logs.ElementAt(i));
            }
            writer.Close();
            System.Diagnostics.Process.Start(ruta);
        }

        // GET: Jugadores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugadores jugadores = db.Jugadores.Find(id);
            if (jugadores == null)
            {
                return HttpNotFound();
            }
            return View(jugadores);
        }

        // GET: Jugadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jugadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "club,apellido,nombre,posicion,compensacion_garantizada")] Jugadores2 jugadores)
        {
            try
            {
                sw.Restart();
                if (ModelState.IsValid)
                {
                    contador = (int)Session["Contador"];
                    logs = (List<string>)Session["Logs"];
                    db.Jugadores2.Add(jugadores);
                    db.SaveChanges();
                    sw.Stop();
                    logs.Add("El tiempo tardado para crear fue: " + sw.Elapsed.ToString());
                    PrintCreateTimeEllapsed(logs);
                    return RedirectToAction("Index");
                }

                return View(jugadores);
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugadores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                contador = (int)Session["Contador"];
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugadores2 jugadores = db.Jugadores2.Find(id);
            if (jugadores == null)
            {
                return HttpNotFound();
            }
            return View(jugadores);
        }

        // POST: Jugadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "club,apellido,nombre,posicion,compensacion_garantizada")] Jugadores2 jugadores)
        {
            try
            {
                sw.Restart();
                if (ModelState.IsValid)
                {
                    contador = (int)Session["Contador"];
                    logs = (List<string>)Session["Logs"];
                    db.Entry(jugadores).State = EntityState.Modified;
                    db.SaveChanges();
                    sw.Stop();
                    logs.Add("El tiempo tardado para editar fue: " + sw.Elapsed.ToString());
                    PrintCreateTimeEllapsed(logs);
                    return RedirectToAction("Index");
                }
                return View(jugadores);
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugadores/Delete/5
        public ActionResult Delete(string id)
        {
            contador = (int)Session["Contador"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugadores2 jugadores = db.Jugadores2.Find(id);
            if (jugadores == null)
            {
                return HttpNotFound();
            }
            return View(jugadores);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {

                sw.Restart();
                contador = (int)Session["Contador"];
                logs = (List<string>)Session["Logs"];
                Jugadores2 jugadores = db.Jugadores2.Find(id);
                db.Jugadores2.Remove(jugadores);
                db.SaveChanges();
                sw.Stop();
                logs.Add("El tiempo tardado para eliminar fue: " + sw.Elapsed.ToString());
                PrintCreateTimeEllapsed(logs);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
