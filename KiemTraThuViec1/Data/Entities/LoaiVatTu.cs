using System.ComponentModel.DataAnnotations;

namespace KiemTraThuViec1.Data.Entities
{
    public class LoaiVatTu : Entity
    {
        public int Id { get; set; }

        private string _maLoaiVatTu;

        [Required]
        [MaxLength(50)]
        public string MaLoaiVatTu
        {
            get => _maLoaiVatTu;
            set => _maLoaiVatTu = value?.Trim().ToUpper().Replace(" ", string.Empty);
        }

        [Required]
        [MaxLength(255)]
        public string TenLoaiVatTu { get; set; }

        public ICollection<VatTu> VatTus { get; set; }
    }
}
