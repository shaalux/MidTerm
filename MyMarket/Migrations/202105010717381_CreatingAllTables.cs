namespace MyMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingAllTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Barcode = c.String(nullable: false, maxLength: 15),
                        BrandName = c.String(),
                        RefFoodFoodTypeID = c.Byte(nullable: false),
                        RefFoodFoodTypeName = c.String(),
                        ProductionDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExpiryDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Barcode)
                .ForeignKey("dbo.RefFoods", t => t.RefFoodFoodTypeID, cascadeDelete: true)
                .Index(t => t.RefFoodFoodTypeID);
            
            CreateTable(
                "dbo.RefFoods",
                c => new
                    {
                        FoodTypeID = c.Byte(nullable: false),
                        FoodTypeName = c.String(),
                    })
                .PrimaryKey(t => t.FoodTypeID);
            
            CreateTable(
                "dbo.Markets",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        FoodBarcode = c.String(maxLength: 15),
                        FoodRefFoodFoodTypeName = c.String(),
                        StockQuantity = c.Int(nullable: false),
                        DateTimeSold = c.DateTime(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        Stock_ItemID = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Foods", t => t.FoodBarcode)
                .ForeignKey("dbo.Stocks", t => t.Stock_ItemID)
                .Index(t => t.FoodBarcode)
                .Index(t => t.Stock_ItemID);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        FoodBarcode = c.String(maxLength: 15),
                        FoodRefFoodFoodTypeName = c.String(),
                        Quantity = c.Int(nullable: false),
                        PricePerUnit = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Foods", t => t.FoodBarcode)
                .Index(t => t.FoodBarcode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Markets", "Stock_ItemID", "dbo.Stocks");
            DropForeignKey("dbo.Stocks", "FoodBarcode", "dbo.Foods");
            DropForeignKey("dbo.Markets", "FoodBarcode", "dbo.Foods");
            DropForeignKey("dbo.Foods", "RefFoodFoodTypeID", "dbo.RefFoods");
            DropIndex("dbo.Stocks", new[] { "FoodBarcode" });
            DropIndex("dbo.Markets", new[] { "Stock_ItemID" });
            DropIndex("dbo.Markets", new[] { "FoodBarcode" });
            DropIndex("dbo.Foods", new[] { "RefFoodFoodTypeID" });
            DropTable("dbo.Stocks");
            DropTable("dbo.Markets");
            DropTable("dbo.RefFoods");
            DropTable("dbo.Foods");
        }
    }
}
