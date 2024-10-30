using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs.Requests.Account;
using WMS.Application.Interfaces;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService service) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var result = await service.LoginAsync(model);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("login-by-rfid")]
        public async Task<IActionResult> LoginByRfid([FromBody] string rfid)
        {
            var result = await service.LoginByRfid(rfid);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] LoginDTO model)
        {
            var result = await service.AgencyLoginAsync(model);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
