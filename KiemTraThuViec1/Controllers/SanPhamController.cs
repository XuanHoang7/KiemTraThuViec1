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
    public class SanPhamController : ControllerBase
    {
        private ISanPhamService _sanPhamService;
        private IUserService _userService;
        public SanPhamController(ISanPhamService sanPhamService, IUserService userService)
        {
            _sanPhamService = sanPhamService;
            _userService = userService;
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
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult AddSanPham(SanPhamDTO dto)
        {
            string? userId = _userService.GetCurrentUser();
            if(userId != null)
            {
                var res = _sanPhamService.AddSanPham(dto, userId);
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
        public IActionResult DeleteSanPham(string ma)
        {
            string? userId = _userService.GetCurrentUser();
            if(userId != null)
            {
                var res = _sanPhamService.DeleteSanPham(ma, userId);
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
        public IActionResult UpdateSanPham(SanPham sanPham)
        {
            string? userId = _userService.GetCurrentUser();
            if(userId != null)
            {
                var res = _sanPhamService.UpdateSanPham(sanPham, userId);
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
