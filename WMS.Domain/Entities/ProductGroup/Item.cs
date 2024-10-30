using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Domain.Entities.ProductGroup
{
    public class Item
    {
        [Key]   
        public string Id { get; set; }
        public string?  BatchId { get; set; }
        public string ProductId { get; set; }

        public bool Exported { get; set; }

        public string? WarehouseId { get; set; }

        public string? Barcode { get; set; }
        public string? QRcode { get; set; }
        public string? Rfid { get; set; }

        //public Batch Batch { get; set; }
        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
