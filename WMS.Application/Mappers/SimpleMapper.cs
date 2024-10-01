using WMS.Application.DTOs.Requests.ProductGroup;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Mappers
{
    public static class SimpleMapper
    {
        public static Category Map(this UpdateCategoryDTO dto)
        {
            return new Category { Id = dto.Id, Name = dto.Name };
        }
        public static Product Map(this ProductDTO dto)
        {
            return new Product
            {
                Name = dto.Name,
                Id = dto.Id,
                Price = dto.Price,
                BrandId = dto.BrandId,
                CategoryId = dto.CategoryId,
                Discontinued = dto.Discontinued,
                Description = dto.Description,
                Photo = dto.Photo,
                Quantity = dto.Quantity
            };
        }
        public static ProductDTO Map(this Product product)
        {
            return new ProductDTO
            {
                Name = product.Name,
                Id = product.Id,
                Price = product.Price,
                BrandId = (int)product.BrandId,
                CategoryId = (int)product.CategoryId,
                Discontinued = product.Discontinued,
                Description = product.Description,
                Photo = product.Photo,
                Quantity = product.Quantity
            };
        }
    }
}
