using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMarket.Models
{
    public class Stock
    {
        [Key]
        public int ItemID { get; set; }

        public Food Food { get; set; }
        [StringLength(15)]
        public string FoodBarcode { get; set; }

        [Display(Name = "Food Name")]
        public string FoodRefFoodFoodTypeName { get; set; }

        public int Quantity { get; set; }

        public float PricePerUnit { get; set; }


    }
}