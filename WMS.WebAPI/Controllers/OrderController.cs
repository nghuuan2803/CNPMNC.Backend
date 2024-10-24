using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs.Requests;
using WMS.Application.DTOs.Requests.Activities;
using WMS.Application.Interfaces;
using WMS.Domain.Entities.Activities;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService service, IMapper mapper) : ControllerBase
    {
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.GetDetailAsync(id);
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpGet("invoice-id/{invoiceId}")]
        public async Task<IActionResult> Get(string invoiceId)
        {
            var result = await service.GetDetailAsync(invoiceId);
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpGet("history/{agencyId}")]
        public async Task<IActionResult> GetHistory(int agencyId)
        {
            var result = await service.HistoryListAsync(agencyId);
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetListAsync();
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(OrderRequest request)
        {
            var order = mapper.Map<Export>(request);
            var result = await service.CreateAsync(order);
            if (result.Succeeded)
            {
                var res = mapper.Map<ExportDTO>(result.Data);
                return Ok(res);
            }
            return BadRequest(result.Message);
        }
    }
}
