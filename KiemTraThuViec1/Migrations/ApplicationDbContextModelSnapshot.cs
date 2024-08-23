﻿// <auto-generated />
using KiemTraThuViec1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KiemTraThuViec1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KiemTraThuViec1.Data.Entities.DonViTinh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MaDonViTinh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenDonViTinh")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MaDonViTinh")
                        .IsUnique();

                    b.ToTable("DonViTinhs");
                });

            modelBuilder.Entity("KiemTraThuViec1.Data.Entities.LoaiVatTu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MaLoaiVatTu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenLoaiVatTu")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MaLoaiVatTu")
                        .IsUnique();

                    b.ToTable("LoaiVatTus");
                });

            modelBuilder.Entity("KiemTraThuViec1.Data.Entities.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DonViTinhId")
                        .HasColumnType("int");

                    b.Property<string>("MaSanPham")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("DonViTinhId");

                    b.HasIndex("MaSanPham")
                        .IsUnique();

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("KiemTraThuViec1.Data.Entities.SanPhamVatTu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<decimal>("SoLuongDinhMuc")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VatTuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VatTuId");

                    b.HasIndex("SanPhamId", "VatTuId")
                        .IsUnique();

                    b.ToTable("SanPhamVatTus");
                });

            modelBuilder.Entity("KiemTraThuViec1.Data.Entities.VatTu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DonViTinhId")
                        .HasColumnType("int");

                    b.Property<int>("LoaiVatTuId")
                        .HasColumnType("int");

                    b.Property<string>("MaVatTu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenVatTu")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("DonViTinhId");

                    b.HasIndex("LoaiVatTuId");

                    b.HasIndex("MaVatTu")
                        .IsUnique();

                    b.ToTable("VatTus");
                });

            modelBuilder.Entity("KiemTraThuViec1.Data.Entities.SanPham", b =>
                {
                    b.HasOne("KiemTraThuViec1.Data.Entities.DonViTinh", "DonViTinh")
                        .WithMany("SanPhams")
                        .HasForeignKey("DonViTinhId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonViTinh");
                });

            modelBuilder.Entity("KiemTraThuViec1.Data.Entities.SanPhamVatTu", b =>
                {
                    b.HasOne("KiemTraThuViec1.Data.Entities.SanPham", "SanPham")
                        .WithMany("SanPhamVatTus")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("KiemTraThuViec1.Data.Entities.VatTu", "VatTu")
                        .WithMany("SanPhamVatTus")
                        .HasForeignKey("VatTuId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SanPham");

                    b.Navigation("VatTu");
                });

            modelBuilder.Entity("KiemTraThuViec1.Data.Entities.VatTu", b =>
                {
                    b.HasOne("KiemTraThuViec1.Data.Entities.DonViTinh", "DonViTinh")
                        .WithMany("VatTus")
                        .HasForeignKey("DonViTinhId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KiemTraThuViec1.Data.Entities.LoaiVatTu", "LoaiVatTu")
                        .WithMany("VatTus")
                        .HasForeignKey("LoaiVatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonViTinh");

                    b.Navigation("LoaiVatTu");
                });

            modelBuilder.Entity("KiemTraThuViec1.Data.Entities.DonViTinh", b =>
                {
                    b.Navigation("SanPhams");

                    b.Navigation("VatTus");
                });

            modelBuilder.Entity("KiemTraThuViec1.Data.Entities.LoaiVatTu", b =>
                {
                    b.Navigation("VatTus");
                });

            modelBuilder.Entity("KiemTraThuViec1.Data.Entities.SanPham", b =>
                {
                    b.Navigation("SanPhamVatTus");
                });

            modelBuilder.Entity("KiemTraThuViec1.Data.Entities.VatTu", b =>
                {
                    b.Navigation("SanPhamVatTus");
                });
#pragma warning restore 612, 618
        }
    }
}
