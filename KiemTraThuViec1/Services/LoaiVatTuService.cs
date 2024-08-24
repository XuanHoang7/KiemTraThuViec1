using KiemTraThuViec1.Data;
using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Repository;

namespace KiemTraThuViec1.Services
{
    public class LoaiVatTuService : ILoaiVatTuService
    {
        private readonly ILoiVatTuRepository _loiVatTuRepository;
        private readonly IVatTuRepository _vatTuRepository;

        public LoaiVatTuService(ILoiVatTuRepository loiVatTuRepository, IVatTuRepository vatTuRepository)
        {
            _loiVatTuRepository = loiVatTuRepository;
            _vatTuRepository = vatTuRepository;
        }
        ResponseDTO ILoaiVatTuService.AddLoaiVatTu(LoaiVatTu loaiVatTu, string userId)
        {
            try
            {
                if (loaiVatTu != null)
                {
                    if (!string.IsNullOrWhiteSpace(loaiVatTu.MaLoaiVatTu))
                    {
                        loaiVatTu.CreateDate = DateTime.Now;
                        loaiVatTu.CreateBy = userId;
                        _loiVatTuRepository.AddLoaiVatTu(loaiVatTu);
                        if (_loiVatTuRepository.IsSaveChange()) return new ResponseDTO()
                        {
                            code = 200,
                            message = "Success",
                            description = loaiVatTu
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
                        message = "mã là null or only whitespace",
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

        ResponseDTO ILoaiVatTuService.DeleteLoaiVatTu(string maLoaiVatTu, string userId)
        {
            var loaiVatTu = _loiVatTuRepository.GetLoaiVatTuByMa(maLoaiVatTu);
            if (loaiVatTu != null)
            {
                var hasVatTu = _vatTuRepository.GetVattus().Any(v => v.LoaiVatTuId == loaiVatTu.Id);
                if (hasVatTu)
                {
                    return new ResponseDTO()
                    {
                        code = 400,
                        message = "Không thể xóa loại vật tư này vì nó đang được sử dụng trong các vật tư khác.",
                        description = null
                    };
                }
                loaiVatTu.IsDeleted = true;
                loaiVatTu.DeleteDate = DateTime.Now;
                loaiVatTu.DeleteBy = userId;
                _loiVatTuRepository.DeleteLoaiVatTu(loaiVatTu);
                if (_loiVatTuRepository.IsSaveChange()) return new ResponseDTO()
                {
                    code = 200,
                    message = "Success",
                    description = loaiVatTu
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

        ResponseDTO ILoaiVatTuService.GetLoaiVatTuByMa(string maLoaiVatTu)
        {
            try
            {
                var loaiVatTu = _loiVatTuRepository.GetLoaiVatTuByMa(maLoaiVatTu);
                if (loaiVatTu != null)
                    return new ResponseDTO()
                    {
                        code = 200,
                        message = "Success",
                        description = loaiVatTu
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

        ResponseDTO ILoaiVatTuService.GetLoaiVatTuByName(string name)
        {
            try
            {
                var loaiVatTu = _loiVatTuRepository.GetLoaiVatTuByName(name);
                if (loaiVatTu != null)
                    return new ResponseDTO()
                    {
                        code = 200,
                        message = "Success",
                        description = loaiVatTu
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

        ResponseDTO ILoaiVatTuService.UpdateLoaiVatTu(LoaiVatTu loaiVatTu, string userId)
        {
            var check = _loiVatTuRepository.GetLoaiVatTuByMa(loaiVatTu.MaLoaiVatTu);

            if (check == null) return new ResponseDTO()
            {
                code = 200,
                message = loaiVatTu.MaLoaiVatTu + " is not exists",
                description = null
            };
            check.TenLoaiVatTu = loaiVatTu.TenLoaiVatTu;
            check.VatTus = loaiVatTu.VatTus;
            check.UpdateDate = DateTime.Now;
            check.UpdateBy = userId;
            _loiVatTuRepository.UpdateLoaiVatTu(check);
            if (_loiVatTuRepository.IsSaveChange()) return new ResponseDTO()
            {
                code = 200,
                message = "Success",
                description = loaiVatTu
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
