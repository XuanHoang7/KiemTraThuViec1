using System.ComponentModel.DataAnnotations;

namespace KiemTraThuViec1.Data.Entities
{
    public class SanPhamVatTu
    {
        public int Id { get; set; }

        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }

        public int VatTuId { get; set; }
        public VatTu VatTu { get; set; }

        [Required]
        public decimal SoLuongDinhMuc { get; set; }
    }

}
