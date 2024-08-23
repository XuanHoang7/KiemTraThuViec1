using KiemTraThuViec1.Data.Entities;

namespace KiemTraThuViec1.Repository
{
    public interface IVatTuRepository
    {
        List<VatTu>? GetVatTuByName(string name);

        List<VatTu>? GetVattus();

        VatTu? GetVatTuByMa(string maVatTu);

        void AddVatTu(VatTu vatTu);


        void DeleteVatTu(VatTu vatTu);


        void UpdateVatTu(VatTu vatTu);

        bool IsSaveChange();
    }
}
