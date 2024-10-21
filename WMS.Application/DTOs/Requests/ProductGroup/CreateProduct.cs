using Microsoft.AspNetCore.Http;

namespace WMS.Application.DTOs.Requests.ProductGroup
{
    public class CreateProduct
    {
        public IFormFile ImageFile { get; set; }
        public string DataJson { get; set; }
    }
}
