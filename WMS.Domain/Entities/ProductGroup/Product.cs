using System.ComponentModel.DataAnnotations;
using WMS.Domain.Entities.ProductGroup;

namespace WMS.Domain.Entities.ProductInfo
{
    public class Product : BaseEntity<int>
    {
        [StringLength(50)]
        public string Name { get; set; }

        [Range(0, 9000000000)]
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool Discontinued { get; set; }

        [StringLength(150)]
        public string? Photo { get; set; }

        public string? Description { get; set; }

        public int? CategoryId { get; set; } //FK

        public int? BrandId { get; set; } //FK

        public Category? Category { get; set; }
        public Brand? Brand { get; set; }

        public ICollection<StockProduct> Stocks { get; set; }
    }
}
