using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMarket.Models
{
    public class Market
    {
        [Key]
        public int TransactionId { get; set; }
        public Food Food { get; set; }        
        [StringLength(15)]
        public string FoodBarcode { get; set; }
        
        [Display(Name ="Food Name")]
        public string FoodRefFoodFoodTypeName { get; set; }
        
        public Stock Stock { get; set; }
        [Display(Name ="Quantity")]
        public int StockQuantity { get; set; }
        
        [Display(Name ="Date Sold")]
        public DateTime DateTimeSold { get; set; }
        
       
        public int TotalPrice { get; set; }
            
        
    }
}