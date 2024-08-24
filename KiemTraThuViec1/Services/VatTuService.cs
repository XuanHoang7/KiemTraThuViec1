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
        private readonly ISanPhamVatTuRepository _sanPhamVatTuRepository;

        public VatTuService(IVatTuRepository vatTuRepository, ILoiVatTuRepository loiVatTuRepository, 
            IDonViTinhRepository donViTinhRepository, ISanPhamVatTuRepository sanPhamVatTuRepository)
        {
            _vatTuRepository = vatTuRepository;
            _loaiVatTuRepository = loiVatTuRepository;
            _donViTinhRepository = donViTinhRepository;
            _sanPhamVatTuRepository = sanPhamVatTuRepository;
        }
        ResponseDTO IVatTuService.AddVatTu(VatTuDTO dto, string userId)
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
                                vatTu.CreateDate = DateTime.Now;
                                vatTu.CreateBy = userId;
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

        ResponseDTO IVatTuService.DeleteVatTu(string maVatTu, string userId)
        {
            var vatTu = _vatTuRepository.GetVatTuByMa(maVatTu);
            if (vatTu != null)
            {
                var hasSanPham = _sanPhamVatTuRepository.GetSanPhamVatTus().Any(spvt => spvt.VatTuId == vatTu.Id);
                if(hasSanPham)
                {
                    return new ResponseDTO()
                    {
                        code = 400,
                        message = "Không thể xóa vật tư này vì nó đang được sử dụng trong sản phẩm khác.",
                        description = null
                    };
                }
                vatTu.IsDeleted = true;
                vatTu.DeleteDate = DateTime.Now;
                vatTu.DeleteBy = userId;
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

        ResponseDTO IVatTuService.UpdateVatTu(VatTu vatTu, string userId)
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

            check.UpdateDate = DateTime.Now;
            check.UpdateBy = userId;
            _vatTuRepository.UpdateVatTu(check);
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
