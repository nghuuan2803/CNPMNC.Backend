using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs;
using WMS.Application.DTOs.Requests;
using WMS.Application.Interfaces;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController(IInventoryService service, IMapper mapper) : ControllerBase
    {
        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            var res = await service.GetAllAsync();
            if (res != null)
                return Ok(mapper.Map<List<InventoryDTO>>(res));
            return BadRequest();
        }

        [HttpGet("get-by-product/{productId}")]
        public async Task<IActionResult> GetByProduct(string productId)
        {
            var res = await service.GetAsync(productId);
            if (res != null)
                return Ok(mapper.Map<List<InventoryDTO>>(res));
            return BadRequest();
        }

        [HttpPost("merge")]
        public async Task<IActionResult> Merge(MergeInventoryRequest request)
        {
            try
            {
                var res = await service.MergeAsync(request);
                return Ok(mapper.Map<MergeDTO>(res));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("merge-history")]
        public async Task<IActionResult> MergeHistory()
        {
            var res = await service.GetMergeHistoryAsync();
            if (res != null)
                return Ok(res);
            return BadRequest("Loi");
        }
    }
}
