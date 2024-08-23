using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data;

namespace KiemTraThuViec1.Services
{
    public interface IDonViTinhService
    {
        ResponseDTO GetDonViTinhByName(string name);

        ResponseDTO GetDonViTinhByMa(string maDonViTinh);

        ResponseDTO AddDonViTinh(DonViTinh donViTinh);

        ResponseDTO DeleteDonViTinh(string maDonViTinh);

        ResponseDTO UpdateDonViTinh(DonViTinh donViTinh);
    }
}
