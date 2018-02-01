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
    public class FutbolsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Futbols
        public ActionResult Index()
        {
            return View(db.Futbols.ToList());
        }

        // GET: Futbols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Futbol futbol = db.Futbols.Find(id);
            if (futbol == null)
            {
                return HttpNotFound();
            }
            return View(futbol);
        }

        // GET: Futbols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Futbols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NombreEquipo,Pais,CopasGanadas")] Futbol futbol)
        {
            if (ModelState.IsValid)
            {
                db.Futbols.Add(futbol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(futbol);
        }

        // GET: Futbols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Futbol futbol = db.Futbols.Find(id);
            if (futbol == null)
            {
                return HttpNotFound();
            }
            return View(futbol);
        }

        // POST: Futbols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NombreEquipo,Pais,CopasGanadas")] Futbol futbol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(futbol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(futbol);
        }

        // GET: Futbols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Futbol futbol = db.Futbols.Find(id);
            if (futbol == null)
            {
                return HttpNotFound();
            }
            return View(futbol);
        }

        // POST: Futbols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Futbol futbol = db.Futbols.Find(id);
            db.Futbols.Remove(futbol);
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
