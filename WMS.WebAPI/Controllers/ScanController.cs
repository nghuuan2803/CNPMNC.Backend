using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs;
using WMS.Application.Interfaces;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScanController(IScanService service, IMapper mapper) : ControllerBase
    {
        [HttpGet("scan-all/{rfid}")]
        public async Task<IActionResult> Get(string rfid)
        {
            var res = await service.ScanAllByRFID(rfid);
            if (res != null)
                return Ok(mapper.Map<ScanDTO>(res));
            return BadRequest();
        }
    }
}
