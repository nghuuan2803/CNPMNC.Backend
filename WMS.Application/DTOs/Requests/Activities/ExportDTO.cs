using WMS.Domain.Enums;

namespace WMS.Application.DTOs.Requests.Activities
{
    public class ExportDTO
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public ExportStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        //[StringLength(200)]
        public string? Note { get; set; }

        public DateTime? PaidDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public int AgencyId { get; set; }

        public string AgencyName { get; set; }

        //[StringLength(10)]
        public string ManagerId { get; set; }

        public string? ManagerName { get; set; }

        public ICollection<ExportItem> Items { get; set; }
    }
    public class ExportItem
    {
        public int Id { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int ExportId { get; set; }

        public string ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? Photo { get; set; }

        //[StringLength(5)]
        public string WarehouseId { get; set; }

        public string? WarehouseName { get; set; }
    }
}
