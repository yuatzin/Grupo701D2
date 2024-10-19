using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Grupo701D2.Models;

namespace Grupo701D2.Controllers
{
    public class autobusesController : Controller
    {
        private TerminalEntities db = new TerminalEntities();

        // GET: autobuses
        public ActionResult Index()
        {
            return View(db.autobuses.ToList());
        }

        // GET: autobuses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            autobuses autobuses = db.autobuses.Find(id);
            if (autobuses == null)
            {
                return HttpNotFound();
            }
            return View(autobuses);
        }

        // GET: autobuses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: autobuses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ruta,Precio,Marca,TotalP,Conductor")] autobuses autobuses)
        {
            if (ModelState.IsValid)
            {
                db.autobuses.Add(autobuses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autobuses);
        }

        // GET: autobuses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            autobuses autobuses = db.autobuses.Find(id);
            if (autobuses == null)
            {
                return HttpNotFound();
            }
            return View(autobuses);
        }

        // POST: autobuses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ruta,Precio,Marca,TotalP,Conductor")] autobuses autobuses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autobuses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autobuses);
        }

        // GET: autobuses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            autobuses autobuses = db.autobuses.Find(id);
            if (autobuses == null)
            {
                return HttpNotFound();
            }
            return View(autobuses);
        }

        // POST: autobuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            autobuses autobuses = db.autobuses.Find(id);
            db.autobuses.Remove(autobuses);
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
