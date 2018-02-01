using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _1171316_CarlosMorales_Clase2_MVC.Models;

namespace _1171316_CarlosMorales_Clase2_MVC.Controllers
{
    public class JuegosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Juegos
        public ActionResult Index()
        {
            return View(db.Juegos.ToList());
        }

        // GET: Juegos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juegos juegos = db.Juegos.Find(id);
            if (juegos == null)
            {
                return HttpNotFound();
            }
            return View(juegos);
        }

        // GET: Juegos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Juegos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Genero,Titulo,Precio,FechaDeSalida")] Juegos juegos)
        {
            if (ModelState.IsValid)
            {
                db.Juegos.Add(juegos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(juegos);
        }

        // GET: Juegos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juegos juegos = db.Juegos.Find(id);
            if (juegos == null)
            {
                return HttpNotFound();
            }
            return View(juegos);
        }

        // POST: Juegos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Genero,Titulo,Precio,FechaDeSalida")] Juegos juegos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juegos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(juegos);
        }

        // GET: Juegos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juegos juegos = db.Juegos.Find(id);
            if (juegos == null)
            {
                return HttpNotFound();
            }
            return View(juegos);
        }

        // POST: Juegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Juegos juegos = db.Juegos.Find(id);
            db.Juegos.Remove(juegos);
            db.SaveChanges();
            return RedirectToAction("Index");
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
