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
    public class ReservesController : Controller
    {
        private Context db = new Context();

        // GET: Reserves
        public ActionResult Index()
        {
            var reserves = db.Reserves.Include(r => r.Llogater);
            return View(reserves.ToList());
        }

        // GET: Reserves/Details/5
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

        // GET: Reserves/Create
        public ActionResult Create()
        {
            ViewBag.IdLlogater = new SelectList(db.Llogaters, "IdLlogater", "NomLlogater");
            return View();
        }

        // POST: Reserves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReserva,DataEntrada,DataSortida,IdLlogater")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                var data_a_comprobar = new DateTime();
                data_a_comprobar = data_a_comprobar.AddDays(1);
                if (reserva.DataEntrada < reserva.DataSortida && reserva.DataSortida > data_a_comprobar)
                {
                    db.Reserves.Add(reserva);
                    db.SaveChanges();
                }//
                return RedirectToAction("Index");
            }

            ViewBag.IdLlogater = new SelectList(db.Llogaters, "IdLlogater", "NomLlogater", reserva.IdLlogater);
            return View(reserva);
        }

        // GET: Reserves/Edit/5
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

        // POST: Reserves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReserva,DataEntrada,DataSortida,IdLlogater")] Reserva reserva)
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

        // GET: Reserves/Delete/5
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

        // POST: Reserves/Delete/5
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
