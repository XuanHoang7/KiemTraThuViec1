using KiemTraThuViec1.Data;
using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data.Models;
using KiemTraThuViec1.DTO;
using KiemTraThuViec1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiemTraThuViec1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatTuController : ControllerBase
    {
        private IVatTuService _vatTuService;
        private readonly IUserService _userService;
        public VatTuController(IVatTuService vatTuService, IUserService  userService)
        {
            _vatTuService = vatTuService;
            _userService = userService;
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
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult AddVatTu(VatTuDTO dto)
        {
            string? userId = _userService.GetCurrentUser();
            if(userId != null)
            {
                var res = _vatTuService.AddVatTu(dto, userId);
                return StatusCode(res.code, res);
            }
            return StatusCode(401, new ResponseDTO
            {
                code = 401,
                message = "Bạn không có quyền truy cập vào tài nguyên này"
            });
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult DeleteVatTu(string ma)
        {
            string? userId = _userService.GetCurrentUser();
            if(userId != null)
            {
                var res = _vatTuService.DeleteVatTu(ma, userId);
                return StatusCode(res.code, res);
            }
            return StatusCode(401, new ResponseDTO
            {
                code = 401,
                message = "Bạn không có quyền truy cập vào tài nguyên này"
            });
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult UpdateVatTu(VatTuDTO dto)
        {
            string? userId = _userService.GetCurrentUser();
            if(userId != null)
            {
                var vatTu = new VatTu
                {
                    MaVatTu = dto.MaVatTu,
                    TenVatTu = dto.TenVatTu
                };
                var res = _vatTuService.UpdateVatTu(vatTu, userId);
                return StatusCode(res.code, res);
            }
            return StatusCode(401, new ResponseDTO
            {
                code = 401,
                message = "Bạn không có quyền truy cập vào tài nguyên này"
            });
        }
    }
}
