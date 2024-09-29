using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities.Activities
{
    public class Return : BaseEntity<int>
    {
        public double RefundAmount { get; set; }

        public ReturnStatus Status { get; set; }

        public string? Reason { get; set; }

        public double? RefundDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public string? Note { get; set; }

        public int AgencyId { get; set; } //FK

        public int ExportId { get; set; } //FK

        [StringLength(10)]
        public string? ManagerId { get; set; } //FK

        [StringLength(5)]
        public string? WarehouseId { get; set; } //FK

        public Agency Agency { get; set; }

        public Export Export { get; set; }

        public Employee? Manager { get; set; }

        public Warehouse? Warehouse { get; set; }

        public ICollection<ReturnDetail> Items { get; set; }
    }
}
