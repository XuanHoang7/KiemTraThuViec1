using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KiemTraThuViec1.Migrations
{
    /// <inheritdoc />
    public partial class initialmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonViTinhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDonViTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDonViTinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViTinhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiVatTus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoaiVatTu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenLoaiVatTu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiVatTus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSanPham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DonViTinhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhams_DonViTinhs_DonViTinhId",
                        column: x => x.DonViTinhId,
                        principalTable: "DonViTinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VatTus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaVatTu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenVatTu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DonViTinhId = table.Column<int>(type: "int", nullable: false),
                    LoaiVatTuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatTus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VatTus_DonViTinhs_DonViTinhId",
                        column: x => x.DonViTinhId,
                        principalTable: "DonViTinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VatTus_LoaiVatTus_LoaiVatTuId",
                        column: x => x.LoaiVatTuId,
                        principalTable: "LoaiVatTus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamVatTus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    VatTuId = table.Column<int>(type: "int", nullable: false),
                    SoLuongDinhMuc = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamVatTus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhamVatTus_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPhamVatTus_VatTus_VatTuId",
                        column: x => x.VatTuId,
                        principalTable: "VatTus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonViTinhs_MaDonViTinh",
                table: "DonViTinhs",
                column: "MaDonViTinh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoaiVatTus_MaLoaiVatTu",
                table: "LoaiVatTus",
                column: "MaLoaiVatTu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_DonViTinhId",
                table: "SanPhams",
                column: "DonViTinhId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaSanPham",
                table: "SanPhams",
                column: "MaSanPham",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamVatTus_SanPhamId_VatTuId",
                table: "SanPhamVatTus",
                columns: new[] { "SanPhamId", "VatTuId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamVatTus_VatTuId",
                table: "SanPhamVatTus",
                column: "VatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_VatTus_DonViTinhId",
                table: "VatTus",
                column: "DonViTinhId");

            migrationBuilder.CreateIndex(
                name: "IX_VatTus_LoaiVatTuId",
                table: "VatTus",
                column: "LoaiVatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_VatTus_MaVatTu",
                table: "VatTus",
                column: "MaVatTu",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPhamVatTus");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "VatTus");

            migrationBuilder.DropTable(
                name: "DonViTinhs");

            migrationBuilder.DropTable(
                name: "LoaiVatTus");
        }
    }
}
