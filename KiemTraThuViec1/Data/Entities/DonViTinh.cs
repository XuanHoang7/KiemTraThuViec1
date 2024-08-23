using System.ComponentModel.DataAnnotations;

namespace KiemTraThuViec1.Data.Entities
{
    public class DonViTinh
    {
        public int Id { get; set; }

        private string _maDonViTinh;

        [Required]
        [MaxLength(50)]
        public string MaDonViTinh
        {
            get => _maDonViTinh;
            set => _maDonViTinh = value?.Trim().ToUpper().Replace(" ", string.Empty);
        }

        [Required]
        [MaxLength(255)]
        public string TenDonViTinh { get; set; }

        // Navigation property
        public ICollection<VatTu> VatTus { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
