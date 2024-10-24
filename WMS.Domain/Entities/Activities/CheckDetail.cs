using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Domain.Entities.Activities
{
    public class CheckDetail
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int Result { get; set; }

        public string? Note { get; set; }

        public int InventoryCheckId { get; set; } //FK

        public string ProductId { get; set; } //FK

        public InventoryCheck? InventoryCheck { get; set; }

        public Product? Product { get; set; }
    }
}
