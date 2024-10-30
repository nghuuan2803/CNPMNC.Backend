using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs.Requests.Loacations;
using WMS.Application.DTOs.Responses;
using WMS.Application.Interfaces;
using WMS.Domain.Entities.Locations;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController(IWarehouseService service, IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] WarehouseDTO dto)
        {
            var model = _mapper.Map<Warehouse>(dto);
            model.CreatedOn = DateTime.Now;
            var result = await service.AddAsync(model);
            if (result.Succeeded)
            {
                var data = _mapper.Map<WarehouseDTO>(result.Data);
                return Ok(new BaseResponse<WarehouseDTO>(data!, result.Message!));
            }
            return BadRequest(new BaseResponse(result.Message!));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] WarehouseDTO dto)
        {
            var model = _mapper.Map<Warehouse>(dto);
            var result = await service.UpdateAsync(model);
            if (result.Succeeded)
                return Ok(new BaseResponse(result.Message!));
            return BadRequest(new BaseResponse(result.Message!));
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await service.DeleteAsync(id);
            if (result.Succeeded)
                return Ok(new BaseResponse(result.Message!));
            return BadRequest(new BaseResponse(result.Message!));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetListAsync();
            if (result.Succeeded)
            {
                var res = _mapper.Map<IEnumerable<WarehouseDTO>>(result.Data);
                return Ok(new BaseResponse<IEnumerable<WarehouseDTO>>(res, result.Message!));
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await service.FindAsync(id);
            if (result.Succeeded)
            {
                return Ok(new BaseResponse<Warehouse>(result.Data!, result.Message!));
            }
            return BadRequest(result.Message);
        }
    }
}
