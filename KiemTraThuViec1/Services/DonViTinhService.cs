using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data;
using KiemTraThuViec1.Repository;
using Microsoft.EntityFrameworkCore;

namespace KiemTraThuViec1.Services
{
    public class DonViTinhService : IDonViTinhService
    {
        private readonly IDonViTinhRepository _DonViTinhRepository;
        private readonly IVatTuRepository _VatTuRepository;
        private readonly ISanPhamRepository _PhamRepository;
        public DonViTinhService(IDonViTinhRepository DonViTinhRepository, IVatTuRepository vatTuRepository, ISanPhamRepository sanPhamRepository)
        {
            _DonViTinhRepository = DonViTinhRepository;
            _VatTuRepository = vatTuRepository;
            _PhamRepository = sanPhamRepository;
        }
        ResponseDTO IDonViTinhService.AddDonViTinh(DonViTinh donViTinh, string userId)
        {
            try
            {
                if (donViTinh != null)
                {
                    if (!string.IsNullOrWhiteSpace(donViTinh.MaDonViTinh))
                    {
                        donViTinh.CreateDate = DateTime.Now;
                        donViTinh.CreateBy = userId;
                        _DonViTinhRepository.AddDonViTinh(donViTinh);
                        if (_DonViTinhRepository.IsSaveChange()) return new ResponseDTO()
                        {
                            code = 200,
                            message = "Success",
                            description = donViTinh
                        };
                        else return new ResponseDTO()
                        {
                            code = 400,
                            message = "Faile",
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

        ResponseDTO IDonViTinhService.DeleteDonViTinh(string maDonViTinh, string userId)
        {
            var donViTinh = _DonViTinhRepository.GetDonViTinhByMa(maDonViTinh);
            if (donViTinh != null)
            {
                var hasVatTus = _VatTuRepository.GetVattus().Any(v => v.DonViTinhId == donViTinh.Id);
                var hasSanPhams = _PhamRepository.GetSanPhams().Any( sp => sp.DonViTinhId == donViTinh.Id );

                if (hasVatTus || hasSanPhams)
                {
                    return new ResponseDTO()
                    {
                        code = 400,
                        message = "Không thể xóa đơn vị tính này vì nó đang được sử dụng trong các vật tư hoặc sản phẩm khác.",
                        description = null
                    };
                }
                donViTinh.IsDeleted = true;
                donViTinh.DeleteBy = userId;
                _DonViTinhRepository.DeleteDonViTinh(donViTinh);
                if (_DonViTinhRepository.IsSaveChange()) return new ResponseDTO()
                {
                    code = 200,
                    message = "Success",
                    description = donViTinh
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

        ResponseDTO IDonViTinhService.GetDonViTinhByMa(string maDonViTinh)
        {
            try
            {
                var donViTinh = _DonViTinhRepository.GetDonViTinhByMa(maDonViTinh);
                if (donViTinh != null)
                    return new ResponseDTO()
                    {
                        code = 200,
                        message = "Success",
                        description = donViTinh
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

        ResponseDTO IDonViTinhService.GetDonViTinhByName(string name)
        {
            try
            {
                var donViTinh = _DonViTinhRepository.GetDonViTinhByName(name);
                if (donViTinh != null)
                    return new ResponseDTO()
                    {
                        code = 200,
                        message = "Success",
                        description = donViTinh
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

        ResponseDTO IDonViTinhService.UpdateDonViTinh(DonViTinh donViTinh, string userId)
        {
            var check = _DonViTinhRepository.GetDonViTinhByMa(donViTinh.MaDonViTinh);

            if (check == null) return new ResponseDTO()
            {
                code = 200,
                message = donViTinh.MaDonViTinh + " is not exists",
                description = null
            };
            check.TenDonViTinh = donViTinh.TenDonViTinh;
            check.SanPhams = donViTinh.SanPhams;
            check.VatTus = donViTinh.VatTus;
            check.UpdateDate = DateTime.Now;
            check.UpdateBy = userId;
            _DonViTinhRepository.UpdateDonViTinh(check);
            if (_DonViTinhRepository.IsSaveChange()) return new ResponseDTO()
            {
                code = 200,
                message = "Success",
                description = donViTinh
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
