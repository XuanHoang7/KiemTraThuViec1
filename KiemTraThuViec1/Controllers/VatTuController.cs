using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.DTO;
using KiemTraThuViec1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiemTraThuViec1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatTuController : ControllerBase
    {
        private IVatTuService _vatTuService;
        public VatTuController(IVatTuService vatTuService)
        {
            _vatTuService = vatTuService;
        }

        [HttpGet("ma/{ma}")]
        public IActionResult GetVatTuByMa(string ma)
        {
            var res = _vatTuService.GetVatTuByMa(ma);
            return StatusCode(res.code, res);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetVatTuByName(string name)
        {
            var res = _vatTuService.GetVatTuByName(name);
            return StatusCode(res.code, res);
        }

        [HttpPost]
        public IActionResult AddVatTu(VatTuDTO dto)
        {

            var res = _vatTuService.AddVatTu(dto);
            return StatusCode(res.code, res);
        }

        [HttpDelete]
        public IActionResult DeleteVatTu(string ma)
        {
            var res = _vatTuService.DeleteVatTu(ma);
            return StatusCode(res.code, res);
        }

        [HttpPut]
        public IActionResult UpdateVatTu(VatTuDTO dto)
        {
            var vatTu = new VatTu
            {
                MaVatTu = dto.MaVatTu,
                TenVatTu = dto.TenVatTu
            };
            var res = _vatTuService.UpdateVatTu(vatTu);
            return StatusCode(res.code, res);
        }
    }
}
