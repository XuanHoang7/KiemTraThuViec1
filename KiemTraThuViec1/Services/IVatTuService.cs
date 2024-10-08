﻿using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data;
using KiemTraThuViec1.DTO;

namespace KiemTraThuViec1.Services
{
    public interface IVatTuService
    {
        ResponseDTO GetVatTuByName(string name);

        ResponseDTO GetVatTuByMa(string maVatTu);

        ResponseDTO AddVatTu(VatTuDTO dto, string userId);

        ResponseDTO DeleteVatTu(string maVatTu, string userId);

        ResponseDTO UpdateVatTu(VatTu vatTu, string userId);
    }
}
