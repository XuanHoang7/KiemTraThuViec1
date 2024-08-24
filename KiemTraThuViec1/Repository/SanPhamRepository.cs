using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data;

namespace KiemTraThuViec1.Repository
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly ApplicationDbContext _context;
        public SanPhamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        List<SanPham>? ISanPhamRepository.GetSanPhamByName(string name)
        {
            return _context.SanPhams.Where(lvt => lvt.TenSanPham.Equals(name) && lvt.IsDeleted == false).ToList();
        }
        List<SanPham>? ISanPhamRepository.GetSanPhams()
        {
            return _context.SanPhams.ToList();
        }

        SanPham? ISanPhamRepository.GetSanPhamByMa(string maSanPham)
        {
            return _context.SanPhams.FirstOrDefault(lvt => lvt.MaSanPham.Equals(maSanPham.Trim().ToUpper().Replace(" ", string.Empty)));
        }

        void ISanPhamRepository.AddSanPham(SanPham sanPham)
        {
            _context.SanPhams.Add(sanPham);
        }

        void ISanPhamRepository.DeleteSanPham(SanPham sanPham)
        {
            _context.SanPhams.Update(sanPham);
        }


        void ISanPhamRepository.UpdateSanPham(SanPham sanPham)
        {
            _context.SanPhams.Update(sanPham);
        }

        bool ISanPhamRepository.IsSaveChange()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
