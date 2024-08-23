using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.DTO;
using KiemTraThuViec1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiemTraThuViec1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamService _sanPhamService;
        public SanPhamController(ISanPhamService sanPhamService)
        {
            _sanPhamService = sanPhamService;
        }

        [HttpGet("ma/{ma}")]
        public IActionResult GetSanPhamByMa(string ma)
        {
            var res = _sanPhamService.GetSanPhamByMa(ma);
            return StatusCode(res.code, res);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetSanPhamByName(string name)
        {
            var res = _sanPhamService.GetSanPhamByName(name);
            return StatusCode(res.code, res);
        }

        [HttpPost]
        public IActionResult AddSanPham(SanPhamDTO dto)
        {
            
            var res = _sanPhamService.AddSanPham(dto);
            return StatusCode(res.code, res);
        }

        [HttpDelete]
        public IActionResult DeleteSanPham(string ma)
        {
            var res = _sanPhamService.DeleteSanPham(ma);
            return StatusCode(res.code, res);
        }

        [HttpPut]
        public IActionResult UpdateSanPham(SanPham sanPham)
        {
            var res = _sanPhamService.UpdateSanPham(sanPham);
            return StatusCode(res.code, res);
        }
    }
}
