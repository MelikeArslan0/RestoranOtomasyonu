using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestoranOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class DBMusteriAdres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "musteri",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "musteri");
        }
    }
}
