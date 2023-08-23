using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestoranOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class DBNEW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "kategori",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KategoriAd = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategori", x => x.KategoriID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "musteri",
                columns: table => new
                {
                    MusteriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Soyad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musteri", x => x.MusteriID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "terminal",
                columns: table => new
                {
                    TerminalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TAd = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terminal", x => x.TerminalID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "yetkilitablo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KTC = table.Column<int>(type: "int", nullable: false),
                    KUnvan = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KAdSoyad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KTel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yetkilitablo", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "urunler",
                columns: table => new
                {
                    UrunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KategoriID = table.Column<int>(type: "int", nullable: true),
                    UrunAD = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrunFiyat = table.Column<int>(type: "int", nullable: true),
                    ResimYap = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urunler", x => x.UrunID);
                    table.ForeignKey(
                        name: "FK_urunler_kategori_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "kategori",
                        principalColumn: "KategoriID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "geribildirim",
                columns: table => new
                {
                    GID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MusteriID = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YildizPuan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_geribildirim", x => x.GID);
                    table.ForeignKey(
                        name: "FK_geribildirim_musteri_MusteriID",
                        column: x => x.MusteriID,
                        principalTable: "musteri",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "masa",
                columns: table => new
                {
                    MasaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MusteriID = table.Column<int>(type: "int", nullable: false),
                    RezervasyonTarihi = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    KisiSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masa", x => x.MasaID);
                    table.ForeignKey(
                        name: "FK_masa_musteri_MusteriID",
                        column: x => x.MusteriID,
                        principalTable: "musteri",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "icerik",
                columns: table => new
                {
                    IcerikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    urunlerID = table.Column<int>(type: "int", nullable: false),
                    IcerikAD = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_icerik", x => x.IcerikID);
                    table.ForeignKey(
                        name: "FK_icerik_urunler_urunlerID",
                        column: x => x.urunlerID,
                        principalTable: "urunler",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "siparisler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MasaID = table.Column<int>(type: "int", nullable: false),
                    urunlerID = table.Column<int>(type: "int", nullable: false),
                    TerminalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_siparisler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_siparisler_masa_MasaID",
                        column: x => x.MasaID,
                        principalTable: "masa",
                        principalColumn: "MasaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_siparisler_terminal_TerminalID",
                        column: x => x.TerminalID,
                        principalTable: "terminal",
                        principalColumn: "TerminalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_siparisler_urunler_urunlerID",
                        column: x => x.urunlerID,
                        principalTable: "urunler",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_geribildirim_MusteriID",
                table: "geribildirim",
                column: "MusteriID");

            migrationBuilder.CreateIndex(
                name: "IX_icerik_urunlerID",
                table: "icerik",
                column: "urunlerID");

            migrationBuilder.CreateIndex(
                name: "IX_masa_MusteriID",
                table: "masa",
                column: "MusteriID");

            migrationBuilder.CreateIndex(
                name: "IX_siparisler_MasaID",
                table: "siparisler",
                column: "MasaID");

            migrationBuilder.CreateIndex(
                name: "IX_siparisler_TerminalID",
                table: "siparisler",
                column: "TerminalID");

            migrationBuilder.CreateIndex(
                name: "IX_siparisler_urunlerID",
                table: "siparisler",
                column: "urunlerID");

            migrationBuilder.CreateIndex(
                name: "IX_urunler_KategoriID",
                table: "urunler",
                column: "KategoriID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "geribildirim");

            migrationBuilder.DropTable(
                name: "icerik");

            migrationBuilder.DropTable(
                name: "siparisler");

            migrationBuilder.DropTable(
                name: "yetkilitablo");

            migrationBuilder.DropTable(
                name: "masa");

            migrationBuilder.DropTable(
                name: "terminal");

            migrationBuilder.DropTable(
                name: "urunler");

            migrationBuilder.DropTable(
                name: "musteri");

            migrationBuilder.DropTable(
                name: "kategori");
        }
    }
}
