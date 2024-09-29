using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities.ProductInfo
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
