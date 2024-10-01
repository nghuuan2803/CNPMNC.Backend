using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs.Requests.ProductGroup;
using WMS.Application.DTOs.Responses;
using WMS.Application.Interfaces;
using WMS.Application.Mappers;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService service, IMapper mapper) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await service.FindAsync(id);
            if (result.Succeeded)
                return Ok(new BaseResponse<Product>(data: result.Data!, result.Message!));
            return BadRequest(new { message = result.Message });
        }
        [HttpGet("get-all")]
        public async Task<ActionResult> GetAll()
        {
            var result = await service.GetListAsync(p => !p.Deleted);
            if (result.Succeeded)
            {
                var data = mapper.Map<List<ProductDTO>>(result.Data);
                return Ok(new BaseResponse<IEnumerable<ProductDTO>>(data: data, result.Message!));
            }
            return BadRequest(new { message = result.Message });
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] ProductDTO model)
        {
            var product = mapper.Map<Product>(model);
            var result = await service.AddAsync(product);
            if (result.Succeeded)
            {
                var data = mapper.Map<ProductDTO>(result.Data);
                return Ok(new BaseResponse<ProductDTO>(data, result.Message!));
            }
            return BadRequest(new { message = result.Message });
        }

        [HttpPost("create-multiple")]
        public async Task<ActionResult> CreateMultiple([FromBody] List<ProductDTO> model)
        {
            var product = mapper.Map<List<Product>>(model);
            var result = await service.AddMultipleAsync(product);
            if (result.Succeeded)
            {
                var data = mapper.Map<List<ProductDTO>>(result.Data);
                return Ok(new BaseResponse<List<ProductDTO>>(data, result.Message!));
            }
            return BadRequest(new { message = result.Message });
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] ProductDTO product)
        {
            var result = await service.UpdateAsync(product.Map());
            if (result.Succeeded)
                return Ok(new BaseResponse(message: result.Message!));
            return BadRequest(new { message = result.Message });
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await service.DeleteAsync(id);
            if (result.Succeeded)
                return Ok(new BaseResponse(message: result.Message!));
            return BadRequest(new { message = result.Message });
        }
        [HttpPut("recover")]
        public async Task<ActionResult> Recover([FromBody] int id)
        {
            var result = await service.RecoverAsync(id);
            if (result.Succeeded)
                return Ok(new BaseResponse(message: result.Message!));
            return BadRequest(new { message = result.Message });
        }

        [HttpGet("export-excel")]
        public async Task<IActionResult> ExportProducts()
        {
            // Danh sách sản phẩm giả lập, có thể thay bằng dữ liệu từ database
            var result = await service.GetListAsync(p => !p.Deleted);
            var products = mapper.Map<List<ProductDTO>>(result.Data);

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Products");

            // Tiêu đề cột
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Tên";
            worksheet.Cell(1, 3).Value = "Đơn giá";
            worksheet.Cell(1, 4).Value = "Số lượng";

            // Ghi dữ liệu sản phẩm vào file Excel
            for (int i = 0; i < products.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = products[i].Id;
                worksheet.Cell(i + 2, 2).Value = products[i].Name;
                worksheet.Cell(i + 2, 3).Value = products[i].Price;
                worksheet.Cell(i + 2, 4).Value = products[i].Quantity;
            }

            // Tạo MemoryStream để lưu file Excel tạm thời
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            // Trả về file Excel
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "products.xlsx");
        }

    }
}
