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
    public class JewelController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Jewel
        public ActionResult Index()
        {
            return View(db.Jewels.ToList());
        }

        // GET: Jewel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewels jewels = db.Jewels.Find(id);
            if (jewels == null)
            {
                return HttpNotFound();
            }
            return View(jewels);
        }

        // GET: Jewel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jewel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,Type")] Jewels jewels)
        {
            if (ModelState.IsValid)
            {
                db.Jewels.Add(jewels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jewels);
        }

        // GET: Jewel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewels jewels = db.Jewels.Find(id);
            if (jewels == null)
            {
                return HttpNotFound();
            }
            return View(jewels);
        }

        // POST: Jewel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,Type")] Jewels jewels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jewels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jewels);
        }

        // GET: Jewel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewels jewels = db.Jewels.Find(id);
            if (jewels == null)
            {
                return HttpNotFound();
            }
            return View(jewels);
        }

        // POST: Jewel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jewels jewels = db.Jewels.Find(id);
            db.Jewels.Remove(jewels);
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
