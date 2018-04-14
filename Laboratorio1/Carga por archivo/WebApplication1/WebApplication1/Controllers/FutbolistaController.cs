using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using WebApplication1.Models;
using System.Net;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class FutbolistaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Importar(HttpPostedFileBase excelfile)
        {
            if (excelfile == null || excelfile.ContentLength == 0)
            {
                ViewBag.Error = ("Porfavor ingrese un archivo de excel<br>");
                return View("Index");
            }
            else
            {
                // string fileExtension = "";
                // System.IO.Path.GetExtension(excelfile.FileName);
                if (excelfile.FileName.EndsWith(".csv") || excelfile.FileName.EndsWith(".xlsx"))
                {
                    string fileName = Path.GetFileName(excelfile.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/"), fileName);


                    //leer el excel
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    List<Futbolista> listaFutbolistas = new List<Futbolista>();
                    for (int fila = 2; fila < range.Rows.Count; fila++)
                    {
                        Futbolista futbolista = new Futbolista();
                        futbolista.club = ((Excel.Range)range.Cells[fila, 1]).Text;
                        futbolista.lastName = ((Excel.Range)range.Cells[fila, 2]).Text;
                        futbolista.firstName = ((Excel.Range)range.Cells[fila, 3]).Text;
                        futbolista.position = ((Excel.Range)range.Cells[fila, 4]).Text;
                        futbolista.baseSalary = ((Excel.Range)range.Cells[fila, 5]).Text;
                        futbolista.guaranteedCompensation = ((Excel.Range)range.Cells[fila, 6]).Text;
                        listaFutbolistas.Add(futbolista);

                    }
                    ViewBag.ListaFutbolistas = listaFutbolistas;
                    return View("Success");
                }
                else
                {
                    ViewBag.Error = ("Tipo de archivo incorrecto<br>");
                    return View("Index");
                }
            }

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Futbolista futbol = db.Futbols.Find(id);
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
        public ActionResult Create([Bind(Include = "club,lastName,firstName,position,baseSalary,guaranteedCompensation")] Futbolista futbol)
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
            Futbolista futbol = db.Futbols.Find(id);
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
        public ActionResult Edit([Bind(Include = "club,lastName,firstName,position,baseSalary,guaranteedCompensation")] Futbolista futbol)
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
            Futbolista futbol = db.Futbols.Find(id);
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
            Futbolista futbol = db.Futbols.Find(id);
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
