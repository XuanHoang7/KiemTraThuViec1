using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data;
using KiemTraThuViec1.Repository;
using Microsoft.IdentityModel.Tokens;
using KiemTraThuViec1.DTO;

namespace KiemTraThuViec1.Services
{
    public class VatTuService :IVatTuService
    {
        private readonly IVatTuRepository _vatTuRepository;
        private readonly ILoiVatTuRepository _loaiVatTuRepository;
        private readonly IDonViTinhRepository _donViTinhRepository;

        public VatTuService(IVatTuRepository vatTuRepository, ILoiVatTuRepository loiVatTuRepository, IDonViTinhRepository donViTinhRepository)
        {
            _vatTuRepository = vatTuRepository;
            _loaiVatTuRepository = loiVatTuRepository;
            _donViTinhRepository = donViTinhRepository;
        }
        ResponseDTO IVatTuService.AddVatTu(VatTuDTO dto)
        {
            try
            {
                if (dto != null)
                {
                    if (!string.IsNullOrWhiteSpace(dto.MaVatTu))
                    {
                        LoaiVatTu? loaiVatTu = _loaiVatTuRepository.GetLoaiVatTuByMa(dto.MaLoaiVatTu);
                        if (loaiVatTu != null)
                        {
                            DonViTinh? donViTinh = _donViTinhRepository.GetDonViTinhByMa(dto.MaDonViTinh);
                            if (donViTinh != null)
                            {
                                var vatTu = new VatTu
                                {
                                    MaVatTu = dto.MaVatTu,
                                    TenVatTu = dto.TenVatTu,
                                    LoaiVatTuId = loaiVatTu.Id,
                                    LoaiVatTu = loaiVatTu,
                                    DonViTinh = donViTinh,
                                    DonViTinhId = donViTinh.Id

                                };
                                _vatTuRepository.AddVatTu(vatTu);
                                try
                                {
                                    if (_vatTuRepository.IsSaveChange()) return new ResponseDTO()
                                    {
                                        code = 200,
                                        message = "Success",
                                        description = null
                                    };
                                }
                                catch (Exception e)
                                {
                                    new ResponseDTO()
                                    {
                                        code = 400,
                                        message = "Mã vật tư đã tồn tại",
                                        description = null
                                    };
                                }
                            }
                            else return new ResponseDTO()
                            {
                                code = 400,
                                message = "Sai Ma Don Vi Tinh",
                                description = null
                            };
                        }
                        else return new ResponseDTO()
                        {
                            code = 400,
                            message = "Sai Ma loai Vat Tu hoặc mã loại vật tư",
                            description = null
                        };
                    }
                    else return new ResponseDTO()
                    {
                        code = 400,
                        message = "mã is null or only white space",
                        description = null
                    };
                }
                return new ResponseDTO()
                {
                    code = 400,
                    message = "Faile",
                    description = null
                };
            }
            catch (Exception)
            {

                return new ResponseDTO()
                {
                    code = 400,
                    message = "Trùng mã",
                    description = null
                };
            }
        }

        ResponseDTO IVatTuService.DeleteVatTu(string maVatTu)
        {
            var vatTu = _vatTuRepository.GetVatTuByMa(maVatTu);
            if (vatTu != null)
            {
                _vatTuRepository.DeleteVatTu(vatTu);
                if (_vatTuRepository.IsSaveChange()) return new ResponseDTO()
                {
                    code = 200,
                    message = "Success",
                    description = vatTu
                };
                else return new ResponseDTO()
                {
                    code = 400,
                    message = "Faile",
                    description = null
                };
            }
            return new ResponseDTO()
            {
                code = 400,
                message = "Mã không tồn tại",
                description = null
            };
        }

        ResponseDTO IVatTuService.GetVatTuByMa(string maVatTu)
        {
            try
            {
                var vatTu = _vatTuRepository.GetVatTuByMa(maVatTu);
                if (vatTu != null)
                    return new ResponseDTO()
                    {
                        code = 200,
                        message = "Success",
                        description = vatTu
                    };
                else return new ResponseDTO()
                {
                    code = 200,
                    message = "Id is not exists",
                    description = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO()
                {
                    code = 400,
                    message = ex.Message,
                    description = null
                };
            }
        }

        ResponseDTO IVatTuService.GetVatTuByName(string name)
        {
            try
            {
                var vatTu = _vatTuRepository.GetVatTuByName(name);
                if (vatTu != null)
                    return new ResponseDTO()
                    {
                        code = 200,
                        message = "Success",
                        description = vatTu
                    };
                else return new ResponseDTO()
                {
                    code = 200,
                    message = "name is not exists",
                    description = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO()
                {
                    code = 400,
                    message = ex.Message,
                    description = null
                };
            }
        }

        ResponseDTO IVatTuService.UpdateVatTu(VatTu vatTu)
        {
            var check = _vatTuRepository.GetVatTuByMa(vatTu.MaVatTu);

            if (check == null) return new ResponseDTO()
            {
                code = 200,
                message = vatTu.MaVatTu + " is not exists",
                description = null
            };

            check.LoaiVatTu = vatTu.LoaiVatTu;
            check.LoaiVatTuId = vatTu.LoaiVatTuId;
            check.DonViTinhId = vatTu.DonViTinhId;
            check.DonViTinh = vatTu.DonViTinh;
            check.TenVatTu = vatTu.TenVatTu;
            check.SanPhamVatTus = vatTu.SanPhamVatTus;


            _vatTuRepository.UpdateVatTu(vatTu);
            if (_vatTuRepository.IsSaveChange()) return new ResponseDTO()
            {
                code = 200,
                message = "Success",
                description = vatTu
            };
            else return new ResponseDTO()
            {
                code = 400,
                message = "Faile",
                description = null
            };
        }
    }
}
