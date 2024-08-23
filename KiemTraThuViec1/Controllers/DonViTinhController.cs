using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.DTO;
using KiemTraThuViec1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiemTraThuViec1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonViTinhController : ControllerBase
    {
        private IDonViTinhService _donViTinhService;
        public DonViTinhController(IDonViTinhService donViTinhService)
        {
            _donViTinhService = donViTinhService;
        }

        [HttpGet("ma/{ma}")]
        public IActionResult GetDonViTinhByMa(string ma)
        {
            var res = _donViTinhService.GetDonViTinhByMa(ma);
            return StatusCode(res.code, res);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetDonViTinhByName(string name)
        {
            var res = _donViTinhService.GetDonViTinhByName(name);
            return StatusCode(res.code, res);
        }

        [HttpPost]
        public IActionResult AddDonViTinh(DonViTinhDTO dto)
        {
            var donViTinh = new DonViTinh
            {
                MaDonViTinh = dto.MaDonViTinh,
                TenDonViTinh = dto.TenDonViTinh
            };
            var res = _donViTinhService.AddDonViTinh(donViTinh);
            return StatusCode(res.code, res);
        }

        [HttpDelete]
        public IActionResult DeleteDonViTinh(string ma)
        {
            var res = _donViTinhService.DeleteDonViTinh(ma);
            return StatusCode(res.code, res);
        }

        [HttpPut]
        public IActionResult UpdateDonViTinh(DonViTinhDTO dto)
        {
            var donViTinh = new DonViTinh
            {
                MaDonViTinh = dto.MaDonViTinh,
                TenDonViTinh = dto.TenDonViTinh
            };
            var res = _donViTinhService.UpdateDonViTinh(donViTinh);
            return StatusCode(res.code, res);
        }
    }
}
