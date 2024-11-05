using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Application.DTOs;
using WMS.Application.Interfaces;
using WMS.Domain.Entities.Activities;

namespace WMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController(IReportService service) : ControllerBase
    {
        [HttpGet("get-month-report/{year}")]
        public async Task<IActionResult> GetMonthReport(int year)
        {
            return Ok(await service.GetMonthImportReport(year));
        }

        //[HttpPost("send-notify")]
        //public async Task<IActionResult> SendNotify([FromBody] NotifyDTO notify)
        //{
        //    //goi service thong bao -> tao thong bao luu database
        //    //goi phuong thuc gui mail
        //    return Ok();
        //}

        private string CreateSignature(string name,string email, string phone, string img)
        {
            var content = $"<p><strong>{name}</strong><br>\r\n  " +
                $" Software Engineer<br>\r\n   Acme Corporation<br>\r\n  " +
                $" <a href=\"mailto:{email}\">johndoe@example.com</a> |" +
                $" <a href=\"https://www.example.com\">www.example.com</a>" +
                $"</p>\r\n<img src=\"{img}\" alt=\"Acme Logo\">";
            return content;
        }
    }
}
