﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iAmDressedToKill.Models;

namespace iAmDressedToKill.Controllers
{
    public class DressController : Controller
    {
        private DressToImpress db = new DressToImpress();

        // GET: DressModels
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: DressModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DressModel dressModel = db.Movies.Find(id);
            if (dressModel == null)
            {
                return HttpNotFound();
            }
            return View(dressModel);
        }

        // GET: DressModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DressModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Color,Price,ImageUrl")] DressModel dressModel)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(dressModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dressModel);
        }

        // GET: DressModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DressModel dressModel = db.Movies.Find(id);
            if (dressModel == null)
            {
                return HttpNotFound();
            }
            return View(dressModel);
        }

        // POST: DressModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Color,Price,ImageUrl")] DressModel dressModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dressModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dressModel);
        }

        // GET: DressModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DressModel dressModel = db.Movies.Find(id);
            if (dressModel == null)
            {
                return HttpNotFound();
            }
            return View(dressModel);
        }

        // POST: DressModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DressModel dressModel = db.Movies.Find(id);
            db.Movies.Remove(dressModel);
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
