using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPS.Entities
{
    public class Seller
    {
        public Seller()
        {
            CommodityPrices = new HashSet<CommodityPrice>();
        }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string Company { get; set; }
        public DateTime Register { get; set; }
        public bool Enabled { get; set; }
        [ForeignKey("AddressBook")]
        public int? AddressBookId { get; set; }
        


        public virtual AddressBook AddressBook { get; set; }
        public virtual ICollection<CommodityPrice> CommodityPrices { get; set; }

    }
}