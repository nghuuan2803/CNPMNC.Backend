using WMS.Domain.Entities.ProductInfo;

namespace WMS.Domain.Entities.ProductGroup
{
    public class Item
    {
        public string Id { get; set; }
        public string BatchId { get; set; }
        public bool Exported { get; set; }
        public string? StockAt { get; set; }
        public Batch Batch { get; set; }
    }
}
