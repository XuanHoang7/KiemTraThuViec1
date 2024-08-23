using KiemTraThuViec1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KiemTraThuViec1.Repository
{
    public interface ISanPhamVatTuRepository
    {
        List<SanPhamVatTu>? GetSanPhamVatTus();
        void AddSanPhamVatTu(SanPhamVatTu sanPhamVatTu);
    }
}
