using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs.Requests.Account;
using WMS.Application.Interfaces;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService service) : ControllerBase
    {
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync([FromBody] LoginDTO model)
        {
            var result = await service.LoginAsync(model);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
