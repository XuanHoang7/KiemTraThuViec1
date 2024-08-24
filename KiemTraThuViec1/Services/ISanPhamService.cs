using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data;
using KiemTraThuViec1.DTO;

namespace KiemTraThuViec1.Services
{
    public interface ISanPhamService
    {
        ResponseDTO GetSanPhamByName(string name);

        ResponseDTO GetSanPhamByMa(string maSanPham);

        ResponseDTO AddSanPham(SanPhamDTO sanPham, string userId);

        ResponseDTO DeleteSanPham(string maSanPham, string userId);

        ResponseDTO UpdateSanPham(SanPham sanPham, string userId);
    }
}
