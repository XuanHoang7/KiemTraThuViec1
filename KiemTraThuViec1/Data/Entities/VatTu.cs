using System.ComponentModel.DataAnnotations;

namespace KiemTraThuViec1.Data.Entities
{
    public class VatTu
    {
        public int Id { get; set; }

        private string _maVatTu;

        [Required]
        [MaxLength(50)]
        public string MaVatTu
        {
            get => _maVatTu;
            set => _maVatTu = value?.Trim().ToUpper().Replace(" ", string.Empty);
        }

        [Required]
        [MaxLength(255)]
        public string TenVatTu { get; set; }

        public int DonViTinhId { get; set; }
        public DonViTinh DonViTinh { get; set; }

        public int LoaiVatTuId { get; set; }
        public LoaiVatTu LoaiVatTu { get; set; }

        public ICollection<SanPhamVatTu> SanPhamVatTus { get; set; }
    }
}
