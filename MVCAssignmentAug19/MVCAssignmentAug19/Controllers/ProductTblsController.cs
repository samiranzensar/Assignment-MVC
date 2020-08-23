﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAssignmentAug19;

namespace MVCAssignmentAug19.Controllers
{
    public class ProductTblsController : Controller
    {
        private ZensarTrainingEntities1 db = new ZensarTrainingEntities1();

        // GET: ProductTbls
        public ActionResult Index()
        {
            var productTbls = db.ProductTbls.Include(p => p.BookTable);
            return View(productTbls.ToList());
        }

        // GET: ProductTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTbl productTbl = db.ProductTbls.Find(id);
            if (productTbl == null)
            {
                return HttpNotFound();
            }
            return View(productTbl);
        }

        // GET: ProductTbls/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.BookTables, "BookId", "BookName");
            return View();
        }

        // POST: ProductTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PId,PName,PRate,BookId")] ProductTbl productTbl)
        {
            if (ModelState.IsValid)
            {
                db.ProductTbls.Add(productTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.BookTables, "BookId", "BookName", productTbl.BookId);
            return View(productTbl);
        }

        // GET: ProductTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTbl productTbl = db.ProductTbls.Find(id);
            if (productTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.BookTables, "BookId", "BookName", productTbl.BookId);
            return View(productTbl);
        }

        // POST: ProductTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PId,PName,PRate,BookId")] ProductTbl productTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.BookTables, "BookId", "BookName", productTbl.BookId);
            return View(productTbl);
        }

        // GET: ProductTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTbl productTbl = db.ProductTbls.Find(id);
            if (productTbl == null)
            {
                return HttpNotFound();
            }
            return View(productTbl);
        }

        // POST: ProductTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductTbl productTbl = db.ProductTbls.Find(id);
            db.ProductTbls.Remove(productTbl);
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
