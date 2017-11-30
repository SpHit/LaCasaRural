using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaCasaRural.Models;

namespace LaCasaRural.Controllers
{
    public class LlogatersController : Controller
    {
        private Context db = new Context();

        // GET: Llogaters
        public ActionResult Index()
        {
            return View(db.Llogaters.ToList());
        }

        // GET: Llogaters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llogater llogater = db.Llogaters.Find(id);
            if (llogater == null)
            {
                return HttpNotFound();
            }
            return View(llogater);
        }

        // GET: Llogaters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Llogaters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLlogater,NomLlogater,CognomLlogater,CodiPostal,NIF")] Llogater llogater)
        {
            if (ModelState.IsValid)
            {
                db.Llogaters.Add(llogater);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(llogater);
        }

        // GET: Llogaters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llogater llogater = db.Llogaters.Find(id);
            if (llogater == null)
            {
                return HttpNotFound();
            }
            return View(llogater);
        }

        // POST: Llogaters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLlogater,NomLlogater,CognomLlogater,CodiPostal,NIF")] Llogater llogater)
        {
            if (ModelState.IsValid)
            {
                db.Entry(llogater).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(llogater);
        }

        // GET: Llogaters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llogater llogater = db.Llogaters.Find(id);
            if (llogater == null)
            {
                return HttpNotFound();
            }
            return View(llogater);
        }

        // POST: Llogaters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Llogater llogater = db.Llogaters.Find(id);
            db.Llogaters.Remove(llogater);
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
