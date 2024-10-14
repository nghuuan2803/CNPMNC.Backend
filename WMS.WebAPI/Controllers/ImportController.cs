using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs.Requests.Activities;
using WMS.Application.DTOs.Responses;
using WMS.Application.Interfaces;
using WMS.Domain.Entities.Activities;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController(IImportService service, IMapper _mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ImportDTO dto)
        {
            var model = _mapper.Map<Import>(dto);
            model.CreatedOn = DateTime.Now;
            var result = await service.CreateAsync(model);
            if (result.Succeeded)
            {
                var data = _mapper.Map<ImportDTO>(result.Data);
                return Ok(new BaseResponse<ImportDTO>(data!, result.Message!));
            }
            return BadRequest(new BaseResponse(result.Message!));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ImportDTO dto)
        {
            var model = _mapper.Map<Import>(dto);
            var result = await service.UpdateAsync(model);
            if (result.Succeeded)
                return Ok(new BaseResponse(result.Message!));
            return BadRequest(new BaseResponse(result.Message!));
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteAsync(id);
            if (result.Succeeded)
                return Ok(new BaseResponse(result.Message!));
            return BadRequest(new BaseResponse(result.Message!));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetListAsync(null!);
            if (result.Succeeded)
            {
                var data = _mapper.Map<List<ImportDTO>>(result.Data);
                return Ok(new BaseResponse<IEnumerable<ImportDTO>>(data, result.Message!));
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.FindByIdAsync(id);
            if (result.Succeeded)
            {
                var data = _mapper.Map<ImportDTO>(result.Data);
                return Ok(new BaseResponse<ImportDTO>(data, result.Message!));
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateImportStatusRequest dto)
        {
            var result = await service.UpdateStatus(dto);
            if (result.Succeeded)
            {
                return Ok(new BaseResponse(result.Message!));
            }
            return BadRequest(result.Message);
        }
    }
}
