using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities.ProductInfo
{
    public class Batch : BaseEntity<string>
    {
        public int Quantity { get; set; }

        public DateOnly ManufactureDate { get; set; }

        public BatchStatus Status { get; set; }

        public int ProductId { get; set; } //FK

        [StringLength(5)]
        public string OriginId { get; set; } //FK

        public int? ImportId { get; set; }

        public Product Product { get; set; }
        public Origin Origin { get; set; }
        public Import? Import { get; set; }
    }
}
