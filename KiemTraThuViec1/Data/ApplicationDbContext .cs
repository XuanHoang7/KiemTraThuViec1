using KiemTraThuViec1.Data.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
namespace KiemTraThuViec1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<LoaiVatTu> LoaiVatTus { get; set; }
        public DbSet<VatTu> VatTus { get; set; }
        public DbSet<DonViTinh> DonViTinhs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<SanPhamVatTu> SanPhamVatTus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VatTu>()
                .HasIndex(v => v.MaVatTu)
                .IsUnique();

            modelBuilder.Entity<LoaiVatTu>()
                .HasIndex(l => l.MaLoaiVatTu)
                .IsUnique();

            modelBuilder.Entity<DonViTinh>()
                .HasIndex(d => d.MaDonViTinh)
                .IsUnique();

            modelBuilder.Entity<SanPham>()
                .HasIndex(s => s.MaSanPham)
                .IsUnique();

            modelBuilder.Entity<SanPhamVatTu>()
                .HasIndex(spv => new { spv.SanPhamId, spv.VatTuId })
                .IsUnique();

            modelBuilder.Entity<SanPhamVatTu>()
                .HasOne(spv => spv.SanPham)
                .WithMany(s => s.SanPhamVatTus)
                .HasForeignKey(spv => spv.SanPhamId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<SanPhamVatTu>()
                .HasOne(spv => spv.VatTu)
                .WithMany(v => v.SanPhamVatTus)
                .HasForeignKey(spv => spv.VatTuId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        //public override int SaveChanges()
        //{
        //    var entries = ChangeTracker.Entries()
        //        .Where(e => e.Entity is LoaiVatTu || e.Entity is VatTu || e.Entity is DonViTinh || e.Entity is SanPham);

        //    foreach (var entry in entries)
        //    {
        //        if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
        //        {
        //            var entity = entry.Entity;

        //            foreach (var property in entry.Properties)
        //            {
        //                if (property.Metadata.Name == "MaLoaiVatTu" ||
        //                    property.Metadata.Name == "MaVatTu" ||
        //                    property.Metadata.Name == "MaDonViTinh" ||
        //                    property.Metadata.Name == "MaSanPham")
        //                {
        //                    var value = property.CurrentValue as string;
        //                    if (string.IsNullOrWhiteSpace(value))
        //                    {
        //                        throw new DbUpdateException("Mã không được để trống.");
        //                    }
        //                    property.CurrentValue = value.Trim().ToUpper().Replace(" ", string.Empty);
        //                }
        //            }
        //        }
        //    }

        //    return base.SaveChanges();
        //}
    }
}
