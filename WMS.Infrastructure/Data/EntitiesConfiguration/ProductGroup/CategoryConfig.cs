using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.ProductGroup
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(30);
            builder.HasMany(c => c.Products).WithOne(c=>c.Category).HasForeignKey(c=>c.CategoryId);
            string[] names = { "Ti vi", "Nồi cơm điện", "Máy lọc nước", "Tủ lạnh", "Máy giặt", "Điều hòa", "Quạt điện", "Bếp từ" };
            var data = new List<Category>();
            for (int i = 1; i <= names.Length; i++)
            {
                data.Add(new Category { Id = i, Name = names[i-1] });
            }
            builder.HasData(data);
        }
    }
}
