﻿using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs.Requests.ProductGroup;
using WMS.Application.DTOs.Responses;
using WMS.Application.Interfaces;
using WMS.Application.Mappers;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.WebAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class BrandController(IBrandService service) : ControllerBase
        {
            [HttpPost]
            public async Task<IActionResult> Add([FromBody] string name)
            {
                var model = new Brand { Name = name };
                var result = await service.AddAsync(model);
                if (result.Succeeded)
                    return Ok(new BaseResponse<Brand>(result.Data!, result.Message!));
                return BadRequest(result.Message);
            }

            [HttpPut]
            public async Task<IActionResult> Update([FromBody] UpdateBrandDTO model)
            {
            var result = await service.UpdateAsync(model.Map());
                if (result.Succeeded)
                    return Ok(new BaseResponse(result.Message!));
                return BadRequest(result.Message);
            }
            [HttpDelete]
            public async Task<IActionResult> Delete([FromBody] int id)
            {
                var result = await service.DeleteAsync(id);
                if (result.Succeeded)
                    return Ok(result.Message);
                return BadRequest(new BaseResponse(result.Message!));
            }

            [HttpGet("get-all")]
            public async Task<IActionResult> GetAll()
            {
                var result = await service.GetListAsync();
                if (result.Succeeded)
                    return Ok(new BaseResponse<IEnumerable<Brand>>(result.Data!, result.Message!));
                return BadRequest(result.Message);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> Get(int id)
            {
                var result = await service.FindAsync(id);
                if (result.Succeeded)
                {
                    return Ok(new BaseResponse<Brand>(result.Data!, result.Message!));
                }
                return BadRequest(result.Message);
            }
        }
    
}

