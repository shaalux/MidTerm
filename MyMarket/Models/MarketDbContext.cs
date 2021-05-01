using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyMarket.Models
{
    public class MarketDbContext : DbContext
    {
        public MarketDbContext() : base("MarketConnection")
        {

        }

        public DbSet<Food> Food { get; set; }
        public DbSet<RefFood> RefFood { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Market> Market { get; set; }
        

    }
}