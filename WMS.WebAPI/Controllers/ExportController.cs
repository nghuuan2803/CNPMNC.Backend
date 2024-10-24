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
    public class ExportController(IExportService service, IMapper _mapper) : ControllerBase
    {
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetListAsync(null!);
            if (result.Succeeded)
            {
                var data = _mapper.Map<List<ExportDTO>>(result.Data);
                return Ok(new BaseResponse<IEnumerable<ExportDTO>>(data, result.Message!));
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.GetAsync(id);
            if (result.Succeeded)
            {
                var data = _mapper.Map<ExportDTO>(result.Data);
                return Ok(new BaseResponse<ExportDTO>(data, result.Message!));
            }
            return BadRequest(result.Message);
        }
    }
}
