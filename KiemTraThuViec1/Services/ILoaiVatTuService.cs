using KiemTraThuViec1.Data;
using KiemTraThuViec1.Data.Entities;

namespace KiemTraThuViec1.Services
{
    public interface ILoaiVatTuService
    {
        ResponseDTO GetLoaiVatTuByName(string name);

        ResponseDTO GetLoaiVatTuByMa(string maLoaiVatTu);

        ResponseDTO AddLoaiVatTu(LoaiVatTu loaiVatTu, string userId);

        ResponseDTO DeleteLoaiVatTu(string maLoaiVatTu, string userId);

        ResponseDTO UpdateLoaiVatTu(LoaiVatTu loaiVatTu, string userId);
    }
}
