using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMarket.Models
{
    public class RefFood
    {
        [Key]
        public byte FoodTypeID { get; set; }
        [Display(Name ="Food Name")]
        public string FoodTypeName { get; set; }
    }
}