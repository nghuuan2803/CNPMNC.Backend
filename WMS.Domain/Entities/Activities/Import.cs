using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.ProductInfo;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities.Activities
{
    public class Import: BaseEntity<int>
    {

        public double Amount { get; set; }

        public ImportStatus Status { get; set; }

        public DateTime? CompletedDate { get; set; }

        [StringLength(200)]
        public string? Note { get; set; }

        [StringLength(10)]
        public string OrderBy { get; set; } //FK

        public int SuplierId { get; set; } //FK

        [StringLength(5)]
        public string WarehouseId { get; set; } //FK

        public Employee? Manager { get; set; }

        public Suplier? Suplier { get; set; }

        public Warehouse? Warehouse { get; set; }

        public ICollection<ImportDetail>? Items { get; set; }
    }
}
