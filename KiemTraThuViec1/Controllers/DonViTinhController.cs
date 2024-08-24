using KiemTraThuViec1.Data;
using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data.Models;
using KiemTraThuViec1.DTO;
using KiemTraThuViec1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KiemTraThuViec1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonViTinhController : ControllerBase
    {
        private readonly IDonViTinhService _donViTinhService;
        private readonly IUserService _userService;
        public DonViTinhController(IDonViTinhService donViTinhService, IUserService userService)
        {
            _donViTinhService = donViTinhService;
            _userService = userService;
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
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult AddDonViTinh(DonViTinhDTO dto)
        {
            string? userId = _userService.GetCurrentUser();
            if(userId != null)
            {
                var donViTinh = new DonViTinh
                {
                    MaDonViTinh = dto.MaDonViTinh,
                    TenDonViTinh = dto.TenDonViTinh
                };
                var res = _donViTinhService.AddDonViTinh(donViTinh, userId);
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
        public IActionResult DeleteDonViTinh(string ma)
        {
            string? userId = _userService.GetCurrentUser();
            if(userId != null)
            {
                var res = _donViTinhService.DeleteDonViTinh(ma, userId);
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
        public IActionResult UpdateDonViTinh(DonViTinhDTO dto)
        {
            string? userId = _userService.GetCurrentUser();
            if(userId != null)
            {
                var donViTinh = new DonViTinh
                {
                    MaDonViTinh = dto.MaDonViTinh,
                    TenDonViTinh = dto.TenDonViTinh
                };
                var res = _donViTinhService.UpdateDonViTinh(donViTinh, userId);
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
