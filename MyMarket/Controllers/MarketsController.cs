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
    public class MarketsController : Controller
    {
        private MarketDbContext db = new MarketDbContext();

        // GET: Markets
        public ActionResult Index()
        {
            var market = db.Market.Include(m => m.Food);
            return View(market.ToList());
        }

        // GET: Markets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Market market = db.Market.Find(id);
            if (market == null)
            {
                return HttpNotFound();
            }
            return View(market);
        }

        // GET: Markets/Create
        public ActionResult Create()
        {
            ViewBag.FoodBarcode = new SelectList(db.Food, "Barcode", "BrandName");
            return View();
        }

        // POST: Markets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionId,FoodBarcode,FoodRefFoodFoodTypeName,StockQuantity,DateTimeSold,TotalPrice")] Market market)
        {
            if (ModelState.IsValid)
            {
                db.Market.Add(market);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodBarcode = new SelectList(db.Food, "Barcode", "BrandName", market.FoodBarcode);
            return View(market);
        }

        // GET: Markets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Market market = db.Market.Find(id);
            if (market == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodBarcode = new SelectList(db.Food, "Barcode", "BrandName", market.FoodBarcode);
            return View(market);
        }

        // POST: Markets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionId,FoodBarcode,FoodRefFoodFoodTypeName,StockQuantity,DateTimeSold,TotalPrice")] Market market)
        {
            if (ModelState.IsValid)
            {
                db.Entry(market).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodBarcode = new SelectList(db.Food, "Barcode", "BrandName", market.FoodBarcode);
            return View(market);
        }

        // GET: Markets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Market market = db.Market.Find(id);
            if (market == null)
            {
                return HttpNotFound();
            }
            return View(market);
        }

        // POST: Markets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Market market = db.Market.Find(id);
            db.Market.Remove(market);
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
