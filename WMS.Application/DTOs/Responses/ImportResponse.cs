using WMS.Domain.Enums;

namespace WMS.Application.DTOs.Responses
{
    public class ImportResponse
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public double Amount { get; set; }

        public bool Cancelled { get; set; }

        public DateTime? CompletedDate { get; set; }

        public string? Note { get; set; }

        public string OrderBy { get; set; }

        public int SuplierId { get; set; }

        public string? WarehouseId { get; set; }
    }
    public class ImportItemInfo
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Photo { get; set; }
    }
}
