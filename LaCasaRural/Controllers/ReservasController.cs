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
    public class ReservasController : Controller
    {
        private Context db = new Context();

        // GET: Reservas
        public ActionResult Index()
        {
            var reserves = db.Reserves.Include(r => r.Llogater);
            return View(reserves.ToList());
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserves.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.IdLlogater = new SelectList(db.Llogaters, "IdLlogater", "NomLlogater");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReserva,DataEntrada,IdLlogater")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                //if (reserva.DataEntrada < )
                db.Reserves.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLlogater = new SelectList(db.Llogaters, "IdLlogater", "NomLlogater", reserva.IdLlogater);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserves.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLlogater = new SelectList(db.Llogaters, "IdLlogater", "NomLlogater", reserva.IdLlogater);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReserva,DataEntrada,IdLlogater")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLlogater = new SelectList(db.Llogaters, "IdLlogater", "NomLlogater", reserva.IdLlogater);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserves.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reserves.Find(id);
            db.Reserves.Remove(reserva);
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
