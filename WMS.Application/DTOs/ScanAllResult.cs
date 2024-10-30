using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.ProductGroup;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.DTOs
{
    public class ScanAllResult
    {
        public Product Product { get; set; }
        public Employee Employee { get; set; }
        public Item Item { get; set; }
    }
}
