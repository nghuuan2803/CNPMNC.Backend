using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Domain.Entities.Activities
{
    public class ExportDetail
    {
        [Key]
        public int Id { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int ExportId { get; set; } //FK

        public string ProductId { get; set; } //FK

        [StringLength(5)]
        public string? WarehouseId { get; set; } //FK

        public Export Export { get; set; }

        public Product Product { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
