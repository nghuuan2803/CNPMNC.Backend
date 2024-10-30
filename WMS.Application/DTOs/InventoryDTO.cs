namespace WMS.Application.DTOs
{
    public class InventoryDTO
    {
        public string WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
