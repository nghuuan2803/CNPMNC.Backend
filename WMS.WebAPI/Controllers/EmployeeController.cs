using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs.Requests.Organization;
using WMS.Application.DTOs.Responses;
using WMS.Application.Interfaces;
using WMS.Domain.Entities.Organization;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService service, IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeDTO dto)
        {
            var model = _mapper.Map<Employee>(dto);
            model.CreatedOn = DateTime.Now;
            var result = await service.AddAsync(model);
            if (result.Succeeded)
            {
                return Ok(new BaseResponse<Employee>(result.Data!, result.Message!));
            }
            return BadRequest(new BaseResponse(result.Message!));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmployeeDTO dto)
        {
            var model = _mapper.Map<Employee>(dto);
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
                return Ok(new BaseResponse<IEnumerable<Employee>>(result.Data!, result.Message!));
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await service.FindAsync(id);
            if (result.Succeeded)
            {
                return Ok(new BaseResponse<Employee>(result.Data!, result.Message!));
            }
            return BadRequest(result.Message);
        }
    }
}
