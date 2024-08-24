using System.ComponentModel.DataAnnotations;

namespace KiemTraThuViec1.Data.Entities
{
    public class SanPham : Entity
    {
        public int Id { get; set; }

        private string _maSanPham;

        [Required]
        [MaxLength(50)]
        public string MaSanPham
        {
            get => _maSanPham;
            set => _maSanPham = value?.Trim().ToUpper().Replace(" ", string.Empty);
        }

        [Required]
        [MaxLength(255)]
        public string TenSanPham { get; set; }

        public int DonViTinhId { get; set; }
        public DonViTinh DonViTinh { get; set; }

        // Navigation property
        public ICollection<SanPhamVatTu> SanPhamVatTus { get; set; }
    }

}
