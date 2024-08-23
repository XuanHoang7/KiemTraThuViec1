using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data;

namespace KiemTraThuViec1.Repository
{
    public class DonViTinhRepository : IDonViTinhRepository
    {
        private readonly ApplicationDbContext _context;
        public DonViTinhRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        List<DonViTinh>? IDonViTinhRepository.GetDonViTinhByName(string name)
        {
            return _context.DonViTinhs.Where(lvt => lvt.TenDonViTinh.Equals(name)).ToList();
        }

        List<DonViTinh>? IDonViTinhRepository.GetDonViTinhs()
        {
            return _context.DonViTinhs.ToList();
        }

        DonViTinh? IDonViTinhRepository.GetDonViTinhByMa(string maDonViTinh)
        {
            return _context.DonViTinhs.FirstOrDefault(lvt => lvt.MaDonViTinh.Equals(maDonViTinh.Trim().ToUpper().Replace(" ", string.Empty)));
        }

        void IDonViTinhRepository.AddDonViTinh(DonViTinh donViTinh)
        {
            _context.DonViTinhs.Add(donViTinh);
        }

        void IDonViTinhRepository.DeleteDonViTinh(DonViTinh donViTinh)
        {
            _context.DonViTinhs.Remove(donViTinh);
        }


        void IDonViTinhRepository.UpdateDonViTinh(DonViTinh donViTinh)
        {
            _context.DonViTinhs.Update(donViTinh);
        }
        bool IDonViTinhRepository.IsSaveChange()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
