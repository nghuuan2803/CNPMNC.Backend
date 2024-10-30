using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.ProductInfo;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities.Activities
{
    public class InventoryCheck : BaseEntity<int>
    {
        public string ProductId { get; set; }

        public CheckStatus Status { get; set; }

        public string? Note { get; set; }

        public DateTime? ReportDate { get; set; }

        public int Quantity { get; set; }

        public int ActualQuantity { get; set; }

        public string? AssigneeId { get; set; }

        [StringLength(10)]
        public string ManagerId { get; set; } //FK

        [StringLength(5)]
        public string WarehouseId { get; set; } //FK

        public Product Product { get; set; }

        public Employee Manager { get; set; }

        public Employee Assignee { get; set; }

        public Warehouse Warehouse { get; set; }

    }
}
