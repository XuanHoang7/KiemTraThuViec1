using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data;
using KiemTraThuViec1.DTO;

namespace KiemTraThuViec1.Services
{
    public interface ISanPhamService
    {
        ResponseDTO GetSanPhamByName(string name);

        ResponseDTO GetSanPhamByMa(string maSanPham);

        ResponseDTO AddSanPham(SanPhamDTO sanPham);

        ResponseDTO DeleteSanPham(string maSanPham);

        ResponseDTO UpdateSanPham(SanPham sanPham);
    }
}
