using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs;
using WMS.Application.Interfaces;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController(INotifyService service, IMapper mapper) : ControllerBase
    {
        [HttpGet("get-all/{id}")]
        public async Task<IActionResult> GetAll(string id)
        {
            try
            {
                var rs = await service.GetListAsync(id);
                return Ok(mapper.Map<List<NotifyDTO>>(rs));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("checked")]
        public async Task<IActionResult> Checked(int id)
        {
            try
            {
                var rs = await service.Checked(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
