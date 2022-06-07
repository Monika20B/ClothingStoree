using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothingStoree.Data;
using ClothingStoree.Models;

namespace ClothingStoree.Controllers
{
    public class BoughtJewelController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: BoughtJewel
        public ActionResult Index()
        {
            var boughtJewel = db.BoughtJewels.Include(c => c.Jewels).Include(c => c.Customers);
            return View(boughtJewel);
        }

        // GET: BoughtJewel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoughtJewels boughtJewels = db.BoughtJewels.Find(id);
            if (boughtJewels == null)
            {
                return HttpNotFound();
            }
            return View(boughtJewels);
        }

        // GET: BoughtJewel/Create
        public ActionResult Create()
        {
            ViewBag.JewelId = new SelectList(db.Jewels, "JewelId", "Name");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");

            return View();
        }

        // POST: BoughtJewel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,JewelId")] BoughtJewels boughtJewels)
        {
            if (ModelState.IsValid)
            {
                db.BoughtJewels.Add(boughtJewels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JewelId = new SelectList(db.Jewels, "JewelId", "Name", boughtJewels.JewelId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", boughtJewels.CustomerId);
            return View(boughtJewels);
        }

        // GET: BoughtJewel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoughtJewels boughtJewels = db.BoughtJewels.Find(id);
            if (boughtJewels == null)
            {
                return HttpNotFound();
            }
            ViewBag.JewelId = new SelectList(db.Jewels, "JewelId", "Name", boughtJewels.JewelId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", boughtJewels.CustomerId);
            return View(boughtJewels);
        }

        // POST: BoughtJewel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,JewelId")] BoughtJewels boughtJewels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boughtJewels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JewelId = new SelectList(db.Jewels, "JewelId", "Name", boughtJewels.JewelId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", boughtJewels.CustomerId);
            return View(boughtJewels);
        }

        // GET: BoughtJewel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoughtJewels boughtJewels = db.BoughtJewels.Find(id);
            if (boughtJewels == null)
            {
                return HttpNotFound();
            }
            return View(boughtJewels);
        }

        // POST: BoughtJewel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoughtJewels boughtJewels = db.BoughtJewels.Find(id);
            db.BoughtJewels.Remove(boughtJewels);
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
