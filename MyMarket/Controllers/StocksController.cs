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
    public class StocksController : Controller
    {
        private MarketDbContext db = new MarketDbContext();

        // GET: Stocks
        public ActionResult Index()
        {
            var stock = db.Stock.Include(s => s.Food);
            return View(stock.ToList());
        }

        // GET: Stocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: Stocks/Create
        public ActionResult Create()
        {
            ViewBag.FoodBarcode = new SelectList(db.Food, "Barcode", "BrandName");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,FoodBarcode,FoodRefFoodFoodTypeName,Quantity,PricePerUnit")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Stock.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodBarcode = new SelectList(db.Food, "Barcode", "BrandName", stock.FoodBarcode);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodBarcode = new SelectList(db.Food, "Barcode", "BrandName", stock.FoodBarcode);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,FoodBarcode,FoodRefFoodFoodTypeName,Quantity,PricePerUnit")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodBarcode = new SelectList(db.Food, "Barcode", "BrandName", stock.FoodBarcode);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stock stock = db.Stock.Find(id);
            db.Stock.Remove(stock);
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
