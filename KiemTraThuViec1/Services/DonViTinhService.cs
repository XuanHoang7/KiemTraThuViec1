using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Data;
using KiemTraThuViec1.Repository;

namespace KiemTraThuViec1.Services
{
    public class DonViTinhService : IDonViTinhService
    {
        private readonly IDonViTinhRepository _DonViTinhRepository;

        public DonViTinhService(IDonViTinhRepository DonViTinhRepository)
        {
            _DonViTinhRepository = DonViTinhRepository;
        }
        ResponseDTO IDonViTinhService.AddDonViTinh(DonViTinh donViTinh)
        {
            try
            {
                if (donViTinh != null)
                {
                    if (!string.IsNullOrWhiteSpace(donViTinh.MaDonViTinh))
                    {
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

        ResponseDTO IDonViTinhService.DeleteDonViTinh(string maDonViTinh)
        {
            var donViTinh = _DonViTinhRepository.GetDonViTinhByMa(maDonViTinh);
            if (donViTinh != null)
            {
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

        ResponseDTO IDonViTinhService.UpdateDonViTinh(DonViTinh donViTinh)
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
