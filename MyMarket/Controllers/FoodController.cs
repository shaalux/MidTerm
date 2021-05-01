using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMarket.Models;

namespace MyMarket.Controllers
{
    public class FoodController : Controller
    {
        private MarketDbContext db = new MarketDbContext();

        // GET: Food
        public ActionResult Index()
        {
            var food = db.Food.Include(f => f.RefFood);
            return View(food.ToList());
        }

        // GET: Food/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // GET: Food/Create
        public ActionResult Create()
        {
            ViewBag.RefFoodFoodTypeID = new SelectList(db.RefFood, "FoodTypeID", "FoodTypeName");
            return View();
        }

        // POST: Food/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Barcode,BrandName,RefFoodFoodTypeID,RefFoodFoodTypeName,ProductionDate,ExpiryDate")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Food.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RefFoodFoodTypeID = new SelectList(db.RefFood, "FoodTypeID", "FoodTypeName", food.RefFoodFoodTypeID);
            return View(food);
        }

        // GET: Food/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.RefFoodFoodTypeID = new SelectList(db.RefFood, "FoodTypeID", "FoodTypeName", food.RefFoodFoodTypeID);
            return View(food);
        }

        // POST: Food/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Barcode,BrandName,RefFoodFoodTypeID,RefFoodFoodTypeName,ProductionDate,ExpiryDate")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RefFoodFoodTypeID = new SelectList(db.RefFood, "FoodTypeID", "FoodTypeName", food.RefFoodFoodTypeID);
            return View(food);
        }

        // GET: Food/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Food food = db.Food.Find(id);
            db.Food.Remove(food);
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
