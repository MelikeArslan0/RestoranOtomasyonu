using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestoranOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class DbSepet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "musteri",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sepet",
                columns: table => new
                {
                    SepetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    urunlerID = table.Column<int>(type: "int", nullable: false),
                    IcerikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sepet", x => x.SepetID);
                    table.ForeignKey(
                        name: "FK_sepet_icerik_IcerikID",
                        column: x => x.IcerikID,
                        principalTable: "icerik",
                        principalColumn: "IcerikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sepet_urunler_urunlerID",
                        column: x => x.urunlerID,
                        principalTable: "urunler",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_sepet_IcerikID",
                table: "sepet",
                column: "IcerikID");

            migrationBuilder.CreateIndex(
                name: "IX_sepet_urunlerID",
                table: "sepet",
                column: "urunlerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sepet");

            migrationBuilder.AlterColumn<int>(
                name: "Telefon",
                table: "musteri",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
