namespace MyMarket.Migrations
{
    using MyMarket.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyMarket.Models.MarketDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyMarket.Models.MarketDbContext context)
        {
            context.RefFood.AddOrUpdate(a => a.FoodTypeID,
                new RefFood() { FoodTypeID=1,FoodTypeName="Spaghetti"},
                new RefFood() { FoodTypeID=2,FoodTypeName="Milk"});

            context.Food.AddOrUpdate(x => x.Barcode,
                new Food() { Barcode = "1214", BrandName = "Khoury", RefFoodFoodTypeID = 1, ExpiryDate = new DateTime(2017, 11, 10), ProductionDate = new DateTime(2015, 11, 10),RefFoodFoodTypeName="Spaghetti" },
                new Food()
                {
                    Barcode = "1215",
                    BrandName = "Candia",
                    RefFoodFoodTypeID = 2,
                    RefFoodFoodTypeName = "Milk",
                    ExpiryDate = new DateTime(2017, 11, 10),
                    ProductionDate = new DateTime(2015, 11, 10)
                });

            context.Stock.AddOrUpdate(a => a.ItemID,
                new Stock() {
                    ItemID = 5,
                    FoodBarcode = "1215",
                    Quantity = 10,
                    FoodRefFoodFoodTypeName = "Candia",
                    PricePerUnit = 15
                }
                );

            context.Market.AddOrUpdate(a => a.TransactionId,
                new Market()
                {
                    TransactionId = 6,
                    FoodBarcode = "1215",
                    StockQuantity = 5,
                    DateTimeSold = new DateTime(2015, 11, 10),
                    FoodRefFoodFoodTypeName = "Candia"
                }
                );
            
        }
    }
}
