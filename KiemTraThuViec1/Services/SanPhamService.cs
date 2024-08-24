using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data;
using KiemTraThuViec1.Repository;
using KiemTraThuViec1.DTO;

namespace KiemTraThuViec1.Services
{
    public class SanPhamService : ISanPhamService
    {
        private readonly ISanPhamRepository _SanPhamRepository;
        private readonly IDonViTinhRepository _IDonViTinhRepository;
        private readonly IVatTuRepository _IVatTuRepository;
        private readonly ISanPhamVatTuRepository _sanPhamVatTuRepository;

        public SanPhamService(ISanPhamRepository SanPhamRepository, IDonViTinhRepository iDonViTinhRepository,
            IVatTuRepository vatTuRepository, ISanPhamVatTuRepository sanPhamVatTuRepository)
        {
            _SanPhamRepository = SanPhamRepository;
            _IDonViTinhRepository = iDonViTinhRepository;
            _IVatTuRepository = vatTuRepository;
            _sanPhamVatTuRepository = sanPhamVatTuRepository;
        }
        ResponseDTO ISanPhamService.AddSanPham(SanPhamDTO dto, string userId)
        {
            try
            {
                if (dto != null)
                {
                    if (!string.IsNullOrWhiteSpace(dto.MaSanPham))
                    {
                        DonViTinh? donViTinh = _IDonViTinhRepository.GetDonViTinhByMa(dto.MaDonViTinh);
                        if (donViTinh != null)
                        {
                            var sanPham = new SanPham
                            {
                                MaSanPham = dto.MaSanPham,
                                TenSanPham = dto.TenSanPham,
                                DonViTinhId = donViTinh.Id,
                                DonViTinh = donViTinh
                            };
                            List<SanPhamVatTu> vatTuList = new List<SanPhamVatTu>();
                            foreach (var vatTu in dto.VatTus)
                            {
                                VatTu? v = _IVatTuRepository.GetVatTuByMa(vatTu.MaVatTu);
                                if (v != null)
                                {
                                    if (vatTu.SoLuong > 0)
                                    {
                                        SanPhamVatTu s = new SanPhamVatTu
                                        {
                                            SanPham = sanPham,
                                            SanPhamId = sanPham.Id,
                                            VatTu = v,
                                            VatTuId = v.Id,
                                            SoLuongDinhMuc = vatTu.SoLuong
                                        };
                                        vatTuList.Add(s);
                                    }
                                    else
                                    {
                                        return new ResponseDTO()
                                        {
                                            code = 400,
                                            message = "số lượng bé hơn hoặc bằng 0",
                                            description = null
                                        };
                                    }
                                }
                                else
                                {
                                    return new ResponseDTO()
                                    {
                                        code = 400,
                                        message = "ma vat tu khong ton tai",
                                        description = null
                                    };
                                }

                            }
                            foreach (var sanPhamVatTu in vatTuList)
                            {
                                sanPhamVatTu.CreateBy = userId;
                                sanPhamVatTu.CreateDate = DateTime.Now;
                                _sanPhamVatTuRepository.AddSanPhamVatTu(sanPhamVatTu);
                            }
                            sanPham.CreateBy = userId;
                            sanPham.CreateDate = DateTime.Now;
                            _SanPhamRepository.AddSanPham(sanPham);
                            if (_SanPhamRepository.IsSaveChange()) return new ResponseDTO()
                            {
                                code = 200,
                                message = "Success",
                                description = sanPham
                            };
                            else return new ResponseDTO()
                            {
                                code = 400,
                                message = "Faile",
                                description = null
                            };
                        }
                        else
                        {
                            return new ResponseDTO()
                            {
                                code = 400,
                                message = "sai ma don vi tinh",
                                description = null
                            };
                        }
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

        ResponseDTO ISanPhamService.DeleteSanPham(string maSanPham, string userId)
        {
            var sanPham = _SanPhamRepository.GetSanPhamByMa(maSanPham);
            if (sanPham != null)
            {
                sanPham.IsDeleted = true;
                sanPham.DeleteBy = userId;
                sanPham.DeleteDate = DateTime.Now;
                _SanPhamRepository.DeleteSanPham(sanPham);
                if (_SanPhamRepository.IsSaveChange()) return new ResponseDTO()
                {
                    code = 200,
                    message = "Success",
                    description = sanPham
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

        ResponseDTO ISanPhamService.GetSanPhamByMa(string maSanPham)
        {
            try
            {
                var sanPham = _SanPhamRepository.GetSanPhamByMa(maSanPham);
                if (sanPham != null)
                    return new ResponseDTO()
                    {
                        code = 200,
                        message = "Success",
                        description = sanPham
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

        ResponseDTO ISanPhamService.GetSanPhamByName(string name)
        {
            try
            {
                var sanPham = _SanPhamRepository.GetSanPhamByName(name);
                if (sanPham != null)
                    return new ResponseDTO()
                    {
                        code = 200,
                        message = "Success",
                        description = sanPham
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

        ResponseDTO ISanPhamService.UpdateSanPham(SanPham sanPham, string userId)
        {
            var check = _SanPhamRepository.GetSanPhamByMa(sanPham.MaSanPham);

            if (check == null) return new ResponseDTO()
            {
                code = 200,
                message = sanPham.MaSanPham + " is not exists",
                description = null
            };

            check.TenSanPham = sanPham.TenSanPham;
            check.SanPhamVatTus = sanPham.SanPhamVatTus;
            check.DonViTinh = sanPham.DonViTinh;
            check.DonViTinhId = sanPham.DonViTinhId;
            check.UpdateBy = userId;
            check.UpdateDate = DateTime.Now;
            _SanPhamRepository.UpdateSanPham(check);
            if (_SanPhamRepository.IsSaveChange()) return new ResponseDTO()
            {
                code = 200,
                message = "Success",
                description = sanPham
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
