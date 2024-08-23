using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data;
using Microsoft.EntityFrameworkCore;

namespace KiemTraThuViec1.Repository
{
    public interface ILoiVatTuRepository
    {

        List<LoaiVatTu>? GetLoaiVatTuByName(string name);

        List<LoaiVatTu>? GetLoaiVatTus();

        LoaiVatTu? GetLoaiVatTuByMa(string maLoaiVatTu);

        void AddLoaiVatTu(LoaiVatTu loaiVatTu);

        void DeleteLoaiVatTu(LoaiVatTu loaiVatTu);

        void UpdateLoaiVatTu(LoaiVatTu loaiVatTu);

        bool IsSaveChange();
    }
}
