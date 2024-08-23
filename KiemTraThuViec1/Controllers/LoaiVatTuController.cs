using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.DTO;
using KiemTraThuViec1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiemTraThuViec1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiVatTuController : ControllerBase
    {
        private ILoaiVatTuService _loaiVatTuService;
        public LoaiVatTuController(ILoaiVatTuService loaiVatTuService)
        {
            _loaiVatTuService = loaiVatTuService;
        }

        [HttpGet("ma/{ma}")]
        public IActionResult GetLoaiVatTuByMa(string ma)
        {
            var res = _loaiVatTuService.GetLoaiVatTuByMa(ma);
            return StatusCode(res.code, res);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetLoaiVatTuByName(string name)
        {
            var res = _loaiVatTuService.GetLoaiVatTuByName(name);
            return StatusCode(res.code, res);
        }

        [HttpPost]
        public IActionResult AddLoaiVatTu(LoaiVatTuDTO dto)
        {
            var loaiVatTu = new LoaiVatTu
            {
                MaLoaiVatTu = dto.MaLoaiVatTu,
                TenLoaiVatTu = dto.TenLoaiVatTu
            };
            var res = _loaiVatTuService.AddLoaiVatTu(loaiVatTu);
            return StatusCode(res.code, res);
        }

        [HttpDelete]
        public IActionResult DeleteLoaiVatTu(string ma)
        {
            var res = _loaiVatTuService.DeleteLoaiVatTu(ma);
            return StatusCode(res.code, res);
        }

        [HttpPut]
        public IActionResult UpdateLoaiVatTu(LoaiVatTuDTO dto)
        {
            var loaiVatTu = new LoaiVatTu
            {
                MaLoaiVatTu = dto.MaLoaiVatTu,
                TenLoaiVatTu = dto.TenLoaiVatTu
            };
            var res = _loaiVatTuService.UpdateLoaiVatTu(loaiVatTu);
            return StatusCode(res.code, res);
        }
    }
}
