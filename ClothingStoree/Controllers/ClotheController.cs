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
    public class ClotheController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Clothe
        public ActionResult Index()
        {
            return View(db.Clothes.ToList());
        }

        // GET: Clothe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View(clothes);
        }

        // GET: Clothe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clothe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Color,Price")] Clothes clothes)
        {
            if (ModelState.IsValid)
            {
                db.Clothes.Add(clothes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clothes);
        }

        // GET: Clothe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View(clothes);
        }

        // POST: Clothe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Color,Price")] Clothes clothes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clothes);
        }

        // GET: Clothe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View(clothes);
        }

        // POST: Clothe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clothes clothes = db.Clothes.Find(id);
            db.Clothes.Remove(clothes);
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
