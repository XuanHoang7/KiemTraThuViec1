using KiemTraThuViec1.Data;
using KiemTraThuViec1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KiemTraThuViec1.Repository
{
    public class SanPhamVatTuRepository : ISanPhamVatTuRepository
    {
        private readonly ApplicationDbContext _context;
        public SanPhamVatTuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        void ISanPhamVatTuRepository.AddSanPhamVatTu(SanPhamVatTu sanPhamVatTu)
        {
            _context.SanPhamVatTus.Add(sanPhamVatTu);
        }

        List<SanPhamVatTu>? ISanPhamVatTuRepository.GetSanPhamVatTus()
        {
            return _context.SanPhamVatTus.ToList();
        }
    }
}
