﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusOnlineReservationSystem.Models;

namespace BusOnlineReservationSystem.Controllers
{
    public class LinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lines
        public ActionResult Index()
        {
            return View(db.Lines.ToList());
        }

        // GET: Lines/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lines lines = db.Lines.Find(id);
            if (lines == null)
            {
                return HttpNotFound();
            }
            return View(lines);
        }

        // GET: Lines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FromCity,ToCity,price,distance")] Lines lines)
        {
            if (ModelState.IsValid)
            {
                db.Lines.Add(lines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lines);
        }

        // GET: Lines/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lines lines = db.Lines.Find(id);
            if (lines == null)
            {
                return HttpNotFound();
            }
            return View(lines);
        }

        // POST: Lines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FromCity,ToCity,price,distance")] Lines lines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lines);
        }

        // GET: Lines/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lines lines = db.Lines.Find(id);
            if (lines == null)
            {
                return HttpNotFound();
            }
            return View(lines);
        }

        // POST: Lines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Lines lines = db.Lines.Find(id);
            db.Lines.Remove(lines);
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
