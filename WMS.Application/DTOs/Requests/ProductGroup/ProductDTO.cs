using WMS.Domain.Enums;

namespace WMS.Application.DTOs.Requests.ProductGroup
{
    public class ProductDTO
    {        
        public string Id { get; set; }

        public string Name { get; set; }
        
        public double Price { get; set; }

        public double ImportPrice { get; set; }

        public int Quantity { get; set; }

        public string? Photo { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public bool Discontinued { get; set; }

    }
}
