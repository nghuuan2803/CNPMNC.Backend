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
            var result = await service.GetAllAsync();
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

        [HttpPost("approval")]
        public async Task<IActionResult> ApprovalOrder(ExportDTO request)
        {
            var model = _mapper.Map<Export>(request);
            var res = await service.ApprovalOrderAsync(model);
            if (res.Succeeded)
                return Ok(new BaseResponse<ExportDTO>(_mapper.Map<ExportDTO>(res.Data)));
            return BadRequest();
        }

        [HttpPost("refuse")]
        public async Task<IActionResult> RefuseOrder(int id)
        {
            var res = await service.RefuseOrderAsync(id);
            if (res.Succeeded)
                return Ok();
            return BadRequest();
        }

        [HttpPost("complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var res = await service.CompleteAsync(id);
            if (res.Succeeded)
                return Ok();
            return BadRequest();
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            var res = await service.CancelAsync(id);
            if (res.Succeeded)
                return Ok();
            return BadRequest();
        }
    }
}
