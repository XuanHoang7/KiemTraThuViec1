using KiemTraThuViec1.Data;
using KiemTraThuViec1.Data.Entities;

namespace KiemTraThuViec1.Services
{
    public interface ILoaiVatTuService
    {
        ResponseDTO GetLoaiVatTuByName(string name);

        ResponseDTO GetLoaiVatTuByMa(string maLoaiVatTu);

        ResponseDTO AddLoaiVatTu(LoaiVatTu loaiVatTu);

        ResponseDTO DeleteLoaiVatTu(string maLoaiVatTu);

        ResponseDTO UpdateLoaiVatTu(LoaiVatTu loaiVatTu);
    }
}
