using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities.ProductGroup
{
    public class InventoryItem
    {
        [Key]
        public string Id { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    }
}
