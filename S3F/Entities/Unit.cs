using System;
using System.Collections.Generic;

namespace SPS.Entities
{
    public class Unit
    {
        public Unit()
        {
            CommodityPrices = new HashSet<CommodityPrice>();
        }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public DateTime Register { get; set; }
        public bool Enabled { get; set; }



        public virtual ICollection<CommodityPrice> CommodityPrices { get; set; }
    }
}