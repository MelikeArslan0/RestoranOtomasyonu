using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestoranOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class Puan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_masa_masasayisi_masasayisiID",
                table: "masa");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "musteri");

            migrationBuilder.RenameColumn(
                name: "masasayisiID",
                table: "masa",
                newName: "masasayisiIDID");

            migrationBuilder.RenameIndex(
                name: "IX_masa_masasayisiID",
                table: "masa",
                newName: "IX_masa_masasayisiIDID");

            migrationBuilder.AlterColumn<double>(
                name: "Tutar",
                table: "sepet",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "GeriBildirimview",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoyAD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefon = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Acıklama = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    puan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeriBildirimview", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_masa_masasayisi_masasayisiIDID",
                table: "masa",
                column: "masasayisiIDID",
                principalTable: "masasayisi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_masa_masasayisi_masasayisiIDID",
                table: "masa");

            migrationBuilder.DropTable(
                name: "GeriBildirimview");

            migrationBuilder.RenameColumn(
                name: "masasayisiIDID",
                table: "masa",
                newName: "masasayisiID");

            migrationBuilder.RenameIndex(
                name: "IX_masa_masasayisiIDID",
                table: "masa",
                newName: "IX_masa_masasayisiID");

            migrationBuilder.AlterColumn<int>(
                name: "Tutar",
                table: "sepet",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "musteri",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_masa_masasayisi_masasayisiID",
                table: "masa",
                column: "masasayisiID",
                principalTable: "masasayisi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
