namespace KiemTraThuViec1.DTO
{
    public class SanPhamDTO
    {
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string MaDonViTinh { get; set; }
            public List<VatTuExistsDTO> VatTus { get; set; }
    }
}
