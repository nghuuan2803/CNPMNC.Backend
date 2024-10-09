using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs.Requests.Loacations;
using WMS.Application.DTOs.Requests.Organization;
using WMS.Application.DTOs.Responses;
using WMS.Application.Interfaces;
using WMS.Domain.Entities.Locations;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController(IWarehouseSevice service, IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] WarehouseDTO dto)
        {
            var model = _mapper.Map<Warehouse>(dto);
            model.CreatedOn = DateTime.Now;
            var result = await service.AddAsync(model);
            if (result.Succeeded)
            {
                return Ok(new BaseResponse<Warehouse>(result.Data!, result.Message!));
            }
            return BadRequest(new BaseResponse(result.Message!));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmployeeDTO dto)
        {
            var model = _mapper.Map<Warehouse>(dto);
            var result = await service.UpdateAsync(model);
            if (result.Succeeded)
                return Ok(new BaseResponse(result.Message!));
            return BadRequest(new BaseResponse(result.Message!));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string id)
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
                return Ok(new BaseResponse<IEnumerable<Warehouse>>(result.Data!, result.Message!));
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
