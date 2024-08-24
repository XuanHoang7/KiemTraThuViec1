using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data;

namespace KiemTraThuViec1.Repository
{
    public class VatTuRepository : IVatTuRepository
    {
        private readonly ApplicationDbContext _context;
        public VatTuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        List<VatTu>? IVatTuRepository.GetVatTuByName(string name)
        {
            return _context.VatTus.Where(lvt => lvt.TenVatTu.Equals(name) && lvt.IsDeleted == false).ToList();
        }

        List<VatTu>? IVatTuRepository.GetVattus()
        {
            return _context.VatTus.ToList();
        }

        VatTu? IVatTuRepository.GetVatTuByMa(string maVatTu)
        {
            return _context.VatTus.FirstOrDefault(lvt => lvt.MaVatTu.Equals(maVatTu.Trim().ToUpper().Replace(" ", string.Empty)));
        }

        void IVatTuRepository.AddVatTu(VatTu vatTu)
        {
            _context.VatTus.Add(vatTu);
        }

        void IVatTuRepository.DeleteVatTu(VatTu vatTu)
        {
            _context.VatTus.Update(vatTu);
        }


        void IVatTuRepository.UpdateVatTu(VatTu vatTu)
        {
            _context.VatTus.Update(vatTu);
        }

        bool IVatTuRepository.IsSaveChange()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
