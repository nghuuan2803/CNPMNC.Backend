using AutoMapper;
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

        [HttpPost]
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
    }
}
