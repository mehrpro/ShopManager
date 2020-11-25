using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPS.Entities
{
    public class Unit
    {
        public Unit()
        {
            CommodityPrices = new HashSet<CommodityPrice>();
        }
        [Display(Name = "شناسه")]
        public int UnitId { get; set; }
        [Display(Name = "واحد")]
        public string UnitName { get; set; }
        [Display(Name = "تاریخ")]
        public DateTime Register { get; set; }
        [Display(Name = "وضعیت")]
        public bool Enabled { get; set; }



        public virtual ICollection<CommodityPrice> CommodityPrices { get; set; }
    }
}