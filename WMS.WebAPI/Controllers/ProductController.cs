using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WMS.Application.DTOs.Requests.ProductGroup;
using WMS.Application.DTOs.Responses;
using WMS.Application.Interfaces;
using WMS.Application.Mappers;
using WMS.Domain.Entities.ProductInfo;
using WMS.WebAPI.Helper;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="admin")]
    public class ProductController(IProductService service, IMapper mapper, HttpClient _httpClient) : ControllerBase
    {
        private readonly string _imgurClientId = "your_imgur_client_id";


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

        //[HttpPost("create")]
        //public async Task<ActionResult> Create([FromBody] ProductDTO model)
        //{
        //    var product = mapper.Map<Product>(model);
        //    var result = await service.AddAsync(product);
        //    if (result.Succeeded)
        //    {
        //        var data = mapper.Map<ProductDTO>(result.Data);
        //        return Ok(new BaseResponse<ProductDTO>(data, result.Message!));
        //    }
        //    return BadRequest(new { message = result.Message });
        //}
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromForm] CreateProduct model)
        {
            if (model.ImageFile == null || model.ImageFile.Length == 0)
                return BadRequest("No file uploaded.");
            var productDTO = JsonConvert.DeserializeObject<ProductDTO>(model.DataJson);
            var product = mapper.Map<Product>(productDTO);
            var result = await service.AddAsync(product);
            if (result.Succeeded)
            {
                using var memoryStream = new MemoryStream();
                await model.ImageFile.CopyToAsync(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                byte[] resizedImage = ImageHandler.ResizeImage(imageBytes, 500, 500);

                // Upload ảnh lên Imgur
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Client-ID 157611a9fc2c121");
                using var content = new MultipartFormDataContent();
                content.Add(new ByteArrayContent(resizedImage), "image", model.ImageFile.FileName);

                var response = await client.PostAsync("https://api.imgur.com/3/image", content);

                if (response.IsSuccessStatusCode)
                {
                    var imgurResult = await response.Content.ReadAsStringAsync();

                    // Giải mã JSON để lấy URL
                    var jsonResult = JsonConvert.DeserializeObject<ImgurResponse>(imgurResult);
                    product.Photo = jsonResult.Data.Link;
                    var setPhotoResult = await service.UpdateAsync(product);
                    return Ok(new BaseResponse<ProductDTO>(mapper.Map<ProductDTO>(product), result.Message!));
                }
                else
                {
                    return Ok(new BaseResponse<ProductDTO>(mapper.Map<ProductDTO>(product), "Lỗi không thể lưu ảnh, hãy cập nhật lại sau!"));
                }
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


        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            // Đọc ảnh vào byte array
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] imageBytes = memoryStream.ToArray();
            byte[] resizedImage = ImageHandler.ResizeImage(imageBytes, 500, 500);

            // Upload ảnh lên Imgur
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Client-ID 157611a9fc2c121");
            using var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(resizedImage), "image", file.FileName);

            var response = await client.PostAsync("https://api.imgur.com/3/image", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                // Giải mã JSON để lấy URL
                var jsonResult = JsonConvert.DeserializeObject<ImgurResponse>(result);
                return Ok(jsonResult.Data.Link); // Trả về URL của ảnh
            }

            return StatusCode((int)response.StatusCode, "Upload failed.");
        }
    }
}
