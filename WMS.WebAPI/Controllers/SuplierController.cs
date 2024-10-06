using Microsoft.AspNetCore.Mvc;
using WMS.Application.Interfaces;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.WebAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class SuplierController : ControllerBase
        {
            private readonly ISuplierService _suplierService;

            public SuplierController(ISuplierService suplierService)
            {
                _suplierService = suplierService;
            }

            // Thêm nhà cung cấp mới
            [HttpPost]
            public async Task<IActionResult> Add([FromBody] string name)
            {
            var model = new Category { Name = name };
            var result = await _suplierService.AddAsync(model);
            return Ok(result);
        }

        // Cập nhật thông tin nhà cung cấp
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Category model)
        {
            var result = await _suplierService.UpdateAsync(model);
            return Ok(result);
        }

        // Xóa nhà cung cấp
        [HttpDelete]
            public async Task<IActionResult> Delete([FromBody] int id)
            {
                var result = await _suplierService.DeleteAsync(id);
                return Ok(result);
            }

            // Lấy danh sách tất cả nhà cung cấp
            [HttpGet("get-all")]
            public async Task<IActionResult> GetAll()
            {
                var result = await _suplierService.GetListAsync();
                return Ok(result);
            }

            // Tìm kiếm nhà cung cấp theo ID
            [HttpGet("{id}")]
            public async Task<IActionResult> Get(int id)
            {
                var result = await _suplierService.FindAsync(id);
                return Ok(result);
            }
    }
}
