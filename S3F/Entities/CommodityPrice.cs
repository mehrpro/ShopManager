using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPS.Entities
{
    public class CommodityPrice
    {
        
        public int PriceId { get; set; }
        [Key,ForeignKey("Commodity")]
        public int CommodityId { get; set; }
        [Key,ForeignKey("Seller")]
        public int SellerId { get; set; }
        [Key, ForeignKey("Unit")]
        public int UnitId { get; set; }

        public int PurchasePrice { get; set; }
        public int SalesPrice { get; set; }


        public virtual Commodity Commodity { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual Unit Unit { get; set; }

    }
}