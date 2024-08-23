using KiemTraThuViec1.Data;
using KiemTraThuViec1.Data.Entities;

namespace KiemTraThuViec1.Repository
{
    public class LoiVatTuRepository : ILoiVatTuRepository
    {
        private readonly ApplicationDbContext _context;
        public LoiVatTuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        List<LoaiVatTu>? ILoiVatTuRepository.GetLoaiVatTuByName(string name)
        {
            return _context.LoaiVatTus.Where(lvt => lvt.TenLoaiVatTu.Equals(name)).ToList();
        }
        List<LoaiVatTu>? ILoiVatTuRepository.GetLoaiVatTus()
        {
            return _context.LoaiVatTus.ToList();
        }

        LoaiVatTu? ILoiVatTuRepository.GetLoaiVatTuByMa(string maLoaiVatTu)
        {
            return _context.LoaiVatTus.FirstOrDefault(lvt => lvt.MaLoaiVatTu.Equals(maLoaiVatTu.Trim().ToUpper().Replace(" ", string.Empty)));
        }

        void ILoiVatTuRepository.AddLoaiVatTu(LoaiVatTu loaiVatTu)
        {
            _context.LoaiVatTus.Add(loaiVatTu);
        }

        void ILoiVatTuRepository.DeleteLoaiVatTu(LoaiVatTu loaiVatTu)
        {
            _context.LoaiVatTus.Remove(loaiVatTu);
        }


        void ILoiVatTuRepository.UpdateLoaiVatTu(LoaiVatTu loaiVatTu)
        {
            _context.LoaiVatTus.Update(loaiVatTu);
        }

        bool ILoiVatTuRepository.IsSaveChange()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
