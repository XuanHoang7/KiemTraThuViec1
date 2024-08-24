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
    public class LoaiVatTuController : ControllerBase
    {
        private ILoaiVatTuService _loaiVatTuService;
        private IUserService _userService;
        public LoaiVatTuController(ILoaiVatTuService loaiVatTuService, IUserService userService)
        {
            _loaiVatTuService = loaiVatTuService;
            _userService = userService;
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
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult AddLoaiVatTu(LoaiVatTuDTO dto)
        {
            string? userId = _userService.GetCurrentUser();
            if(userId != null)
            {
                var loaiVatTu = new LoaiVatTu
                {
                    MaLoaiVatTu = dto.MaLoaiVatTu,
                    TenLoaiVatTu = dto.TenLoaiVatTu
                };
                var res = _loaiVatTuService.AddLoaiVatTu(loaiVatTu, userId);
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
        public IActionResult DeleteLoaiVatTu(string ma)
        {
            string? userId = _userService.GetCurrentUser();
            if(userId != null)
            {
                var res = _loaiVatTuService.DeleteLoaiVatTu(ma, userId);
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
        public IActionResult UpdateLoaiVatTu(LoaiVatTuDTO dto)
        {
            string? userId = _userService.GetCurrentUser();
            if(userId != null)
            {
                var loaiVatTu = new LoaiVatTu
                {
                    MaLoaiVatTu = dto.MaLoaiVatTu,
                    TenLoaiVatTu = dto.TenLoaiVatTu
                };
                var res = _loaiVatTuService.UpdateLoaiVatTu(loaiVatTu, userId);
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
