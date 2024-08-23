using KiemTraThuViec1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KiemTraThuViec1.Repository
{
    public interface IDonViTinhRepository
    {
        List<DonViTinh>? GetDonViTinhByName(string name);

        DonViTinh? GetDonViTinhByMa(string maDonViTinh);

        void AddDonViTinh(DonViTinh donViTinh);

        void DeleteDonViTinh(DonViTinh donViTinh);


        void UpdateDonViTinh(DonViTinh donViTinh);


        bool IsSaveChange();
    }
}
