using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities.ProductInfo
{
    //Xuất sứ sản phẩm
    public class Origin
    {
        [Key]
        [StringLength(5)]
        public string Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
    }
}
