using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyMarket.Models
{
    public class Food
    {
        [Key]
        [StringLength(15)]
        public string Barcode { get; set; }
        [Display(Name ="Brand")]
        public string BrandName { get; set; }
        
        public RefFood RefFood { get; set; }
        
        
        public byte RefFoodFoodTypeID { get; set; }
        [Display(Name = "The Food Name")]
        public string RefFoodFoodTypeName { get; set; }

        [Column(TypeName ="DateTime2")]
        public DateTime ProductionDate { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime ExpiryDate { get; set; }
    }
}