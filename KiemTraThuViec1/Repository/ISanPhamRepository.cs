using KiemTraThuViec1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KiemTraThuViec1.Repository
{
    public interface ISanPhamRepository
    {
        List<SanPham>? GetSanPhamByName(string name);

        SanPham? GetSanPhamByMa(string maSanPham);

        void AddSanPham(SanPham sanPham);

        void DeleteSanPham(SanPham sanPham);


        void UpdateSanPham(SanPham sanPham);

        bool IsSaveChange();
    }
}
