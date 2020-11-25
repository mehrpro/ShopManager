using System.ComponentModel.DataAnnotations.Schema;

namespace SPS.Entities
{
    public class StoreHouse
    {
        public int StoreId { get; set; }
        [ForeignKey("CommodityPrice")]
        public int CommodityId { get; set; }
        public int Stock { get; set; }

        public virtual CommodityPrice CommodityPrice { get; set; }
    }
}