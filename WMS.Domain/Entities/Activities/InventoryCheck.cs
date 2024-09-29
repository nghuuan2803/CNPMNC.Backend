using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities.Activities
{
    public class InventoryCheck : BaseEntity<int>
    {
        public DateTime BeginDate { get; set; }

        public CheckStatus Status { get; set; }

        public string? Note { get; set; }

        public string? Result { get; set; }

        public DateTime? CompletedDate { get; set; }

        [StringLength(10)]
        public string ManagerId { get; set; } //FK

        [StringLength(5)]
        public string WarehouseId { get; set; } //FK

        public Employee Manager { get; set; }

        public Warehouse Warehouse { get; set; }

        public ICollection<CheckDetail>? Items { get; set; }
    }
}
