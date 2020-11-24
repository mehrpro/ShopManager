using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPS.Entities
{
    public class Commodity
    {

        public Commodity()
        {
            CommodityPrices = new HashSet<CommodityPrice>();
        }
       
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public string  Description { get; set; }
        public DateTime Register { get; set; }
        public bool Enabled { get; set; }


        protected virtual ICollection<CommodityPrice> CommodityPrices { get; set; }
    }
}
