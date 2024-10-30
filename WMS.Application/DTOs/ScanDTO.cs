using WMS.Application.DTOs.Requests.Organization;
using WMS.Application.DTOs.Requests.ProductGroup;

namespace WMS.Application.DTOs
{
    public class ScanDTO
    {
        public ProductDTO Product { get; set; }
        public EmployeeDTO Employee { get; set; }
        public ItemDTO Item { get; set; }
    }
}
